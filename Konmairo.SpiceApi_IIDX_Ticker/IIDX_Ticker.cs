using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO.Ports;
using System.Management;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;


namespace Konmairo.SpiceApi_IIDX_Ticker
{
    public partial class IIDX_Ticker : Form
    {
        TcpClient client;
        NetworkStream stream;
        SerialPort Arduino = new SerialPort { BaudRate = 57600 };
        string serialCheck = "", selectedPort = "";
        

        //Custom Font
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font iidxSongSelectFontBIG;
        Font iidxSongSelectFontSmall;

        public IIDX_Ticker()
        {
            InitializeComponent();
            
            //Custom Font 
            byte[] fontData = Properties.Resources.SongSelect;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.SongSelect.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.SongSelect.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            iidxSongSelectFontBIG = new Font(fonts.Families[0], 17.0F, FontStyle.Bold);
            iidxSongSelectFontSmall = new Font(fonts.Families[0], 8.5F, FontStyle.Bold);
        }

        #region API

        public void SpiceAPI_Connect()
        {
            try
            {
                //Abre Conexão
                client = new TcpClient("127.0.0.1", 573);
                stream = client.GetStream();
                SetStatusOK((int)enumStatus.SpiceAPI);
            }
            catch
            {
                SetStatusNG((int)enumStatus.SpiceAPI);
            }
        }

        public void SpiceAPI_Disconnect()
        {
            //Fecha a Conexão
            if (stream != null)
            {
                stream.Close();
                client.Close();
            }

        }

        public string JsonBuilder(string module, string function, List<object> spiceparams)
        {
            //Cria um objeto Request
            var json = new Request();

            //Passa os parametros
            json.id = 1;
            json.module = module;
            json.function = function;
            json.spiceparams = spiceparams;

            //Retorna o JSON serializado, o \0 é importante pq é o que indica para a API que é o fim da mensagem
            return JsonSerializer.Serialize(json) + "\0";
        }

        public Response SendRequest(string messageToSend)
        {
            try
            {
                //Converte o JSON para Byte e envia para a API
                byte[] sendData = Encoding.UTF8.GetBytes(messageToSend);
                stream.Write(sendData, 0, sendData.Length);

                //Recebe a Response da API
                var Data = new byte[256];
                var bytes = stream.Read(Data, 0, Data.Length);
                string response = Encoding.UTF8.GetString(Data, 0, bytes - 1);
                return JsonSerializer.Deserialize<Response>(response);
            }
            catch
            {
                SetStatusNG((int)enumStatus.SpiceAPI);
                return new Response();
            }
        }

        #endregion

        #region Actions

        public string Ticker_get()
        {
            //Valida se API está OK
            if (infoSpiceAPI.Text == "OK")
            {
                try
                {
                    //JsonBuilder - Monta o JSON que será enviado no request 
                    //SendRequest - Envia o JSON gerado para a API
                    //tickerResponse - Resposta recebida da API
                    var tickerResponse = SendRequest(JsonBuilder(constModules.iidx, constFunctions.ticker_get, new List<object>() { }));
                    if (tickerResponse.data != null)
                    {
                        //Retorna string do Ticker
                        var tickerReturn = tickerResponse.data[0].ToString();
                        return tickerReturn;
                    }

                    throw new Exception();

                }
                catch
                {
                    CheckForSpiceAPI.Start();
                    return " API: NG";
                }
            }

            //Retorna informação no Ticker caso esteja OFF
            else
            {
                CheckForSpiceAPI.Start();
                //bwConnect.RunWorkerAsync();
                return " API: NG";
            }
        }

        #endregion

        #region Arduino

        public void IdentifyTickerPort()
        {
            Arduino.Close();

            var PortsToCheck = new List<string>();
            using (ManagementClass i_Entity = new ManagementClass("Win32_PnPEntity"))
            {
                foreach (ManagementObject i_Inst in i_Entity.GetInstances())
                {
                    Object o_Guid = i_Inst.GetPropertyValue("ClassGuid");
                    if (o_Guid == null || o_Guid.ToString().ToUpper() != "{4D36E978-E325-11CE-BFC1-08002BE10318}")
                        continue; // Skip all devices except device class "PORTS"

                    String s_Caption = i_Inst.GetPropertyValue("Caption").ToString();
                    String s_Manufact = i_Inst.GetPropertyValue("Manufacturer").ToString();
                    String s_DeviceID = i_Inst.GetPropertyValue("PnpDeviceID").ToString();
                    String s_RegPath = "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Enum\\" + s_DeviceID + "\\Device Parameters";
                    String s_PortName = Registry.GetValue(s_RegPath, "PortName", "").ToString();

                    int s32_Pos = s_Caption.IndexOf(" (COM");
                    if (s32_Pos > 0) // remove COM port from description
                        s_Caption = s_Caption.Substring(0, s32_Pos);

                    if (s_PortName.Contains("COM") && !s_PortName.Contains("COM1") && !s_Caption.Contains("com0com") && !s_Caption.Contains("Leonardo"))
                    {
                        PortsToCheck.Add(s_PortName);
                    }
                }
            }

            foreach (var port in PortsToCheck)
            {
                try
                {
                    Arduino.PortName = port;
                    Arduino.Open();
                    //Ticker_Write($"  {port}");
                    System.Threading.Thread.Sleep(700);

                    //Check if serial returns what is expected
                    serialCheck = Arduino.ReadExisting();
                    if (serialCheck.Contains("ULTIMATE LED TICKER DELUXE SYSTEM\n"))
                    {
                        selectedPort = port;
                        //Ticker_Write($"  {port} OK");
                        //SetStatusOK((int)enumStatus.Ticker);
                    }
                    else
                    {
                        Arduino.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void Ticker_Write(string T)
        {
            //This Method is the one responsible for sending the text to the Arduino via Serial
            //If it can't send data, displays "Lost Connection" message, stop all timers and start looking for arduino again
            try
            {
                if (T.Length > 9) T = T.Remove(9).ToString();
                T = T.Replace("\t", "");
                T = T.Replace("D", "d");
                T = T.Replace('m', '.');
                T = T.Replace('q', '\'');
                T = T.Replace('u', ',');
                Arduino.Write(T + "\n");
            }
            catch
            {
                SetStatusNG((int)enumStatus.Ticker);
                selectedPort = string.Empty;
                TickerGetTimer.Stop();
                CheckForArduino.Start();
                //this.Refresh();
            }
        }

        #endregion

        #region Timers

        private void CheckForSpiceAPI_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("spice64");
            if (pname.Length > 0)
            {
                if (bwSpiceAPI.IsBusy != true)
                {
                    bwSpiceAPI.RunWorkerAsync();
                }
                if (client != null && client.Connected)
                {
                    SetStatusOK((int)enumStatus.SpiceAPI);
                    bwSpiceAPI.CancelAsync();
                    CheckForSpiceAPI.Stop();
                    TickerGetTimer.Start();
                }
                    
                else
                    SetStatusNG((int)enumStatus.SpiceAPI);
            }
        }

        private void CheckForArduino_Tick(object sender, EventArgs e)
        {
            if (Arduino.IsOpen == false || selectedPort == "")
            {
                if (bwTickerArduino.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    bwTickerArduino.RunWorkerAsync();
                }
                if (Arduino.IsOpen == true) 
                {
                    SetStatusOK((int)enumStatus.Ticker);
                    bwTickerArduino.CancelAsync();
                    CheckForArduino.Stop();
                    TickerGetTimer.Start();
                }
            }
        }
        private void TickerGetTimer_Tick(object sender, EventArgs e)
        {
            Ticker_Write(Ticker_get());
        }

        private void bwTickerArduino_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IdentifyTickerPort();
        }

        private void bwSpiceAPI_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SpiceAPI_Connect();
           
        }

        #endregion

        #region Visual
        private void IIDX_Ticker_Load(object sender, EventArgs e)
        {
            gbStatus.Font = iidxSongSelectFontBIG;
            lblSpiceAPI.Font = iidxSongSelectFontBIG;
            lblTicker.Font = iidxSongSelectFontBIG;
            lblCardReader.Font = iidxSongSelectFontBIG;
            lblPort.Font = iidxSongSelectFontSmall;
            infoSpiceAPI.Font = iidxSongSelectFontBIG;
            infoTicker.Font = iidxSongSelectFontBIG;
            infoCardReader.Font = iidxSongSelectFontBIG;
            
        }

        public void SetStatusOK(int StatusCode)
        {
            switch (StatusCode)
            {
                case (int)enumStatus.SpiceAPI:
                    infoSpiceAPI.ForeColor = System.Drawing.Color.Green;
                    infoSpiceAPI.Text = "OK";
                    break;
                case (int)enumStatus.Ticker:
                    infoTicker.ForeColor = System.Drawing.Color.Green;
                    infoTicker.Text = $"OK - {Arduino.PortName}";
                    break;
                case (int)enumStatus.CardReader:
                    infoCardReader.ForeColor = System.Drawing.Color.Green;
                    infoCardReader.Text = "OK";
                    break;
                default:
                    break;
            }
        }

        public void SetStatusNG(int StatusCode)
        {
            switch (StatusCode)
            {
                case (int)enumStatus.SpiceAPI:
                    infoSpiceAPI.ForeColor = System.Drawing.Color.Red;
                    infoSpiceAPI.Text = "NG";
                    break;
                case (int)enumStatus.Ticker:
                    infoTicker.ForeColor = System.Drawing.Color.Red;
                    infoTicker.Text = "NG";
                    break;
                case (int)enumStatus.CardReader:
                    infoCardReader.ForeColor = System.Drawing.Color.Red;
                    infoCardReader.Text = "NG";
                    break;
                case (int)enumStatus.ALL:
                    infoSpiceAPI.ForeColor = System.Drawing.Color.Red;
                    infoTicker.ForeColor = System.Drawing.Color.Red;
                    infoCardReader.ForeColor = System.Drawing.Color.Red;
                    infoSpiceAPI.Text = "NG";
                    infoTicker.Text = "NG";
                    infoCardReader.Text = "NG";
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
