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

namespace DparkTerminal
{
    class ConstructTCP
    {
        public string ipAddress { get; set; }

        
        public bool thFlagControlGate { get; set; }
        public bool thFlagReconnect { get; set; }

        public bool thFlagProcessData { get; set; }

        public bool thFlagCheckConn { get; set; }

        public bool gateOpen { get; set; }

        

        public bool getMacOK { get; set; }

        public bool resetCount { get; set; }

        public bool isConnected { set; get; }

        public int stateGateOpen { get; set; }

        public Socket clientSocket { get; set; }
        public IOControl ioControl { get; set; }

        public int timeOutCheckConn { get; set; }

        public ConstructTCP()
        { }
    }
}
