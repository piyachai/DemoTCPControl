using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DparkTerminal
{
    class IOControl
    {

        public string command { get; set; }

        public  string OPEN_DOOR = "IR#OPENWT1\r\n";
        public  string CLOSE_DOOR = "IR#CLOSE\r\n";
        public  string GET_COUNT = "IR#COUNT?\r\n";
        public  string SET_COUNT = "IR#COUNT="; 
        public  string GET_MAC = "IR#MAC?\r\n";
        public  string SET_MAC = "IR#MAC=";
        public  string ENTER = "\r\n";

        public string getMAC { get; set; }
        public bool openGate { get; set; }
        public bool closeGate { get; set; }

        public string getCount { get; set; }

       

        //public Queue<tcpInfo> queueTCPInfo { get; set; }
        //public tcpInfo recvTCPInfo { get; set; }

        public class counterPerson
        {
            public string getMAC { get; set; }

            public string getCount { get; set; }

            public counterPerson(string mac, string count)
            {
                this.getMAC = mac;
                this.getCount = count;
            }
            
        }

        public counterPerson counter;

        public IOControl()
        { 
          
            counter = new counterPerson("-1", "0");
        }


        public delegate void counterEvent(string mac,string count);
        public event counterEvent counterEventGate;

        public delegate void OpenEvent(bool openStatus);
        public event OpenEvent OpenEventGate;

        public delegate void CloseEvent(bool closeStatus);
        public event CloseEvent CloseEventGate;

        public delegate void getMacID(bool getMacID);
        public event getMacID getMacIDEvent;

        public delegate void setCountOK(bool setCount);
        public event setCountOK setCountOKEvent;

        public void commandProcess(string cmd)
        {
            //Console.WriteLine("RECV:" + cmd);
            if (cmd.Length < 0)
                return;

            string[] str = cmd.Replace(System.Environment.NewLine,"").Split('#');
            //Console.WriteLine(str[0]+str[1]);
            if (str.Length < 0)
                return;


            //Console.WriteLine("RECV:" + cmd);

            try
            {
                //Console.WriteLine(str[0] + str[1]);
                if (str[0] == "MAC") // RECV MAC
                {
                    getMAC = str[1];

                    getMacIDEvent(true);
                }
                else if (str[0] == "OK") // RECV ACK CONTROL SET OK
                {
                    string[] valMsg = str[1].Split(',');

                    if (valMsg.Length == 2)
                    {
                        getMAC = valMsg[0];

                        if (valMsg[1] == "OPEN")// OPEN DOOR OK
                        {
                            
                            openGate = true;
                            OpenEventGate(openGate);
                            closeGate = false;
                            openGate = false;
                        }
                        else if (valMsg[1] == "CLOSE")// CLOSE DOOR OK
                        {
                            closeGate = true;
                            CloseEventGate(closeGate);
                            closeGate = false;
                            openGate = false;
                        }
                        else // GET COUNT OK
                        {
                            //getCount = valMsg[1].Substring(9);
                            setCountOKEvent(true);
                        }
                    }



                }
                else if (str[0] == ">O") // RECV DATA EVENT COUNT 
                {
                    string[] valMsg = str[1].Split(',');

                    //Console.WriteLine("XXXXXfvdsgdfgX" + valMsg[0] + valMsg[1]);

                    if (valMsg.Length == 2)
                    {

                        counter.getMAC = valMsg[0];
                        counter.getCount = valMsg[1];

                        //Console.WriteLine("XXXXXX"+counter.getMAC + counter.getCount);
                        counterEventGate(valMsg[0], valMsg[1]); // send event counter
                        //counter[0].getMAC = getMAC;
                        //counter[]

                    }
                }
            }
            catch (Exception ex)
            {

            }
            

            //return msg;
        }

       
    }
}
