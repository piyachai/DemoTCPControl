using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using BackOffice;
using DparkTerminal;
using DparkTerminal.Properties;
using System.Data;
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;
namespace DparkTerminal
{
    class TCPClient
    {
        


        public ConstructTCP connIofoTCP { get; set; }

        public enum stateGate
        { 
            OPEN = 0 ,
            CHECK_OPEN = 1 ,
            CLOSE = 11 ,
            CHECK_CLOSE = 12 ,
            NONE_STATE = 10


        }

        public static stateGate stateGateCtrl;

        public static bool gateClose = false;
      
        public TCPClient(ConstructTCP connInfo)
        {
 
            this.connIofoTCP = connInfo;

            Console.WriteLine(this.connIofoTCP.ipAddress+"cdkfmdkfm");

            this.connIofoTCP.ioControl.counterEventGate += ioControl_counterEventGate;
            this.connIofoTCP.ioControl.OpenEventGate += ioControl_OpenEventGate;
            this.connIofoTCP.ioControl.getMacIDEvent +=ioControl_getMacIDEvent;
            this.connIofoTCP.ioControl.setCountOKEvent +=ioControl_setCountOKEvent;
            this.connIofoTCP.ioControl.CloseEventGate +=ioControl_CloseEventGate;

            Thread thAutoConnect, thControlGate, thProcessData ;
            thAutoConnect = new Thread(new ThreadStart(Connect_To_Server));
            thProcessData = new Thread(new ThreadStart(processData));
            thControlGate = new Thread(new ThreadStart(controlGate));

            Thread.Sleep(1000);
  
            this.connIofoTCP.thFlagReconnect = true;
            thAutoConnect.Start();

            this.connIofoTCP.thFlagProcessData = true;
            thProcessData.Start();

            this.connIofoTCP.isConnected = false ;
            this.connIofoTCP.thFlagControlGate = true;
            thControlGate.Start();

            this.connIofoTCP.thFlagCheckConn = false;

            stateGateCtrl = stateGate.NONE_STATE;


        }

        private void ioControl_CloseEventGate(bool closeStatus)
        {
            gateClose = closeStatus;
            if (closeStatus)
            {
                this.connIofoTCP.stateGateOpen = 10;
            }
            else
            {
                clearBuffer();
                Thread.Sleep(500);
                closeGate();
                Thread.Sleep(500);
            }
        }

        private void ioControl_setCountOKEvent(bool setCount)
        {
            this.connIofoTCP.resetCount = setCount;
        }

        private void ioControl_getMacIDEvent(bool getMacID)
        {

            this.connIofoTCP.getMacOK = getMacID;
            //if (getMacID)
            //    connectEventGate(true);

            
        }

        private void ioControl_OpenEventGate(bool openStatus)
        {
            this.connIofoTCP.gateOpen = openStatus;
            //MessageBox.Show("GATE OPEN");
        }

       

        bool SocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 & part2)
                return false;
            else
                return true;
        }


        public delegate void counterEvent(string mac, string count);
        public event counterEvent counterEventGate;
        private void ioControl_counterEventGate(string mac, string count)
        {
            //Thread.Sleep(1000);
            //this.connIofoTCP.stateGateOpen = 0;
            this.connIofoTCP.stateGateOpen = 10;
            counterEventGate(mac, count);
            
            
        }


        public void closeGate()
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(this.connIofoTCP.ioControl.CLOSE_DOOR);
            this.connIofoTCP.clientSocket.Send(msg);
        }

        public void resetCount()
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(this.connIofoTCP.ioControl.SET_COUNT + "0"
                + this.connIofoTCP.ioControl.ENTER);
            this.connIofoTCP.clientSocket.Send(msg);
            this.connIofoTCP.stateGateOpen = 0;
        }


        public void clearBuffer()
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes("IR\r\n");
            this.connIofoTCP.clientSocket.Send(msg);
        }
        public void openGate()
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(this.connIofoTCP.ioControl.OPEN_DOOR);
            this.connIofoTCP.clientSocket.Send(msg);
           
        }



        
        public void controlGate()
        {
            Thread.Sleep(5000);

            while (this.connIofoTCP.thFlagControlGate)
            {
                //Console.WriteLine("inthreaddc,d,.,.," + this.connIofoTCP.ipAddress);
                if (this.connIofoTCP.isConnected)
                {
                    //Console.WriteLine("ctrl gatexxxxx" + this.connIofoTCP.stateGateOpen);
                    try 
                    {
                        switch (this.connIofoTCP.stateGateOpen)
                        {
                            case 0:
                                Console.WriteLine("open gate");
                                if (this.connIofoTCP.resetCount)
                                {
                                    //this.connIofoTCP.resetCount = false;
                                    openGate();
                                    Console.WriteLine("clear buffer");
                                    Thread.Sleep(500);
                                    this.connIofoTCP.stateGateOpen = 1;
                                }
                                else
                                {
                                    Console.WriteLine("clear buffer");
                                    clearBuffer();
                                    Thread.Sleep(500);
                                    resetCount();
                                    Console.WriteLine("reset counter");
                                    Thread.Sleep(500);
                                }
                                break;

                            case 1:
                                // wait ack
                                if (!this.connIofoTCP.gateOpen)
                                {
                                    clearBuffer();
                                    Thread.Sleep(500);
                                    this.connIofoTCP.stateGateOpen = 0;
                                }
                                else
                                {
                                    this.connIofoTCP.stateGateOpen = 1;
                                }
                                break;

                            case 11:
                                if (!gateClose)
                                {
                                    clearBuffer();
                                    Thread.Sleep(500);
                                    closeGate();
                                    Thread.Sleep(500);
                                }
                                else // Cancle Complete
                                {
                                    this.connIofoTCP.stateGateOpen = 10;
                                }
                                break;

                        }
                        GC.Collect();
                    }
                    catch{}
                }
                Thread.Sleep(200);
            }
        }

        public void processData()
        {
            Thread.Sleep(5000);
            while (this.connIofoTCP.thFlagProcessData)
            {
                if (this.connIofoTCP.clientSocket != null)
                {
                    try
                    {
                        if (this.connIofoTCP.clientSocket.Available > 0)
                        {

                            Console.WriteLine("Ready Read");

                            byte[] data = new byte[this.connIofoTCP.clientSocket.Available];

                            int bytesRead = 0;
                            try
                            {
                                bytesRead = this.connIofoTCP.clientSocket.Receive(data);
                            }
                            catch (IOException)
                            {
                            }

                            if (bytesRead < data.Length)
                            {
                                byte[] lastData = data;
                                data = new byte[bytesRead];
                                Array.ConstrainedCopy(lastData, 0, data, 0, bytesRead);
                            }

                            byte[] getData = data;

                            if (data != null)
                            {
                                string dataStr = Encoding.ASCII.GetString(data);

                                Console.WriteLine(dataStr);
                                this.connIofoTCP.ioControl.commandProcess(dataStr);

                                data = null;
                            }

                            GC.Collect();
                        }
                    }
                    catch { }
                    

                }

                Thread.Sleep(200);
            }
            
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();

            try
            {
                PingReply reply = pinger.Send(nameOrAddress, 1000);

                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }

            return pingable;
        }

        private void retry()
        { 
        
            if (!this.connIofoTCP.clientSocket.Connected || !this.connIofoTCP.isConnected)
            {
                if (this.connIofoTCP.clientSocket != null)
                {

                    this.connIofoTCP.clientSocket.Close();
                    this.connIofoTCP.clientSocket.Dispose();
                    this.connIofoTCP.clientSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                }
                Reconnection();

            }
            else
            {
                if (!SocketConnected(this.connIofoTCP.clientSocket))
                {
                    if (this.connIofoTCP.clientSocket != null)
                    {

                        this.connIofoTCP.clientSocket.Close();
                        this.connIofoTCP.clientSocket.Dispose();
                        this.connIofoTCP.clientSocket = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);

                    }

                    Reconnection();

                    
                }
                else
                {
                    this.connIofoTCP.thFlagProcessData = true;
                    this.connIofoTCP.thFlagCheckConn = true;
                    this.connIofoTCP.thFlagControlGate = true;
                    this.connIofoTCP.isConnected = true;
                    connectEventGate(true);

                }
            }
        }

        public delegate void connectEvent(bool connect);
        public event connectEvent connectEventGate;


        public  void Connect_To_Server()
        {
            Thread.Sleep(2000);
            while (this.connIofoTCP.thFlagReconnect)
            {
                if (PingHost(this.connIofoTCP.ipAddress))
                {
                    retry();

                }
                else
                {
                    this.connIofoTCP.isConnected = false;
                    connectEventGate(false);
                }
                Thread.Sleep(1000);
            }
        }


        public void Reconnection()
        {
            try
            {
                //Connecting.Connect(this.ipAddress, 1000);

                //IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(this.connIofoTCP.ipAddress), 1000);
                this.connIofoTCP.clientSocket.Connect(this.connIofoTCP.ipAddress, 1000);
                Console.WriteLine("Connected: " + this.connIofoTCP.ipAddress);
                this.connIofoTCP.thFlagProcessData = true;
                this.connIofoTCP.thFlagCheckConn = true;
                this.connIofoTCP.thFlagControlGate = true;
                this.connIofoTCP.isConnected = true;
               
                
                //tcpStatusEvent(true);
                
            }
            catch(SocketException ex)
            {
                Console.WriteLine("Error Connection... ."+ex.Message);
                //this.connIofoTCP.thFlagProcessData = false;
                //this.connIofoTCP.thFlagControlGate = false;
                this.connIofoTCP.isConnected = false;
                connectEventGate(false);

                try
                {
                    connectEventGate(false);
                }
                catch { }
            }
            GC.Collect();

        }

        public void destoryedThread()
        {
            //this.connIofoTCP.stateGateOpen = 10;
            this.connIofoTCP.resetCount = false;
            this.connIofoTCP.gateOpen = false;
            this.connIofoTCP.isConnected = false;
            this.connIofoTCP.thFlagControlGate = false;
            this.connIofoTCP.thFlagProcessData = false;
            this.connIofoTCP.thFlagReconnect = false;
            
            GC.Collect();

        }
    }
}
