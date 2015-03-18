using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using BackOffice ;
using DparkTerminal;
using DparkTerminal.Properties;
using System.Data;
using System.Net;
using System.Threading;


namespace DparkTerminal
{
    public partial class frmTCPControl : Form
    {

        private fmTakePayment fm , setfm;
        public accounting setAccounting { set; get; }
        private int sumPrice { set; get; }
        static TCPClient tcpclient1, tcpclient2, tcpclient3;
        //Thread tcpMonitor;
        private bool thFlagTCPMonitor { get; set; }

        public string priceProfileName { set; get; }
        public string cancleProblem { set; get; }
    
        ConstructTCP connTCP1 = new ConstructTCP();
        ConstructTCP connTCP2 = new ConstructTCP();
        ConstructTCP connTCP3 = new ConstructTCP();

        public bool blockSumperson { get; set; }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public ComboBoxItem(string txt,int val)
            {
                this.Text = txt;
                this.Value = val;
            }
            public override string ToString()
            {
                return Text;
            }
        }

        public bool[] getLastIsConnect;
        public int sumCount { set; get; }

        public struct initialTCPControl
        {
            public int numServer;
            public string [] ipList;// = new string[];
        }

        initialTCPControl initiTCPCtrl;
       

        public frmTCPControl()
        {
            InitializeComponent();
            //tcpControlInitial();
        }

        private void initialUI()
        {
            General gb = new General();

            using (Dpark3Entities db = new Dpark3Entities())
            {
                db.Database.Connection.ConnectionString = gb.GetConnectionString();

                var ps = from a in db.sysUsers
                         select a;

                var qs = ps.Where(k => k.sysUserID == fmLogin.staticVar.loginID).ToList();

                if (qs.Count() > 0)
                {
                    fmMainTerminal.staticVar.lbSysUser.Text = qs.First().sysUserName.ToString();
                    

                }

            }


            priceSelection.Items.Add(new ComboBoxItem(Settings.Default.NamePrice1
                , Settings.Default.SetPrice1));
            priceSelection.Items.Add(new ComboBoxItem(Settings.Default.NamePrice2
                , Settings.Default.SetPrice2));
            priceSelection.Items.Add(new ComboBoxItem(Settings.Default.NamePrice3
                , Settings.Default.SetPrice3));
            priceSelection.Items.Add(new ComboBoxItem(Settings.Default.NamePrice4
                , Settings.Default.SetPrice4));
            priceSelection.Items.Add(new ComboBoxItem(Settings.Default.NamePrice5
                , Settings.Default.SetPrice5));

            priceSelection.SelectedIndex = 0;

            ComboBoxItem itm = (ComboBoxItem)priceSelection.Items[0];
            getPriceSelect.Text = itm.Value.ToString();
            this.priceProfileName = itm.Text;

            int priPerPeo = Convert.ToInt32(getPriceSelect.Text);
            int numberPerson = Convert.ToInt32(numPerson.Text);
            this.sumPrice = priPerPeo * numberPerson;

            numPerson.Focus();
            this.ActiveControl = numPerson;

            
            
            tcpControlInitial();
            getLastIsConnect = new bool[3];
            for (int i = 0; i < 3; i++)
            {
                getLastIsConnect[i] = false;
            }

                GC.Collect();
        }

        private void  tcpControlInitial()
        {
            initiTCPCtrl.numServer = 3;
            initiTCPCtrl.ipList = new string[initiTCPCtrl.numServer];
            initiTCPCtrl.ipList[0] = Settings.Default.ServerIP1;
            initiTCPCtrl.ipList[1] = Settings.Default.ServerIP2;
            initiTCPCtrl.ipList[2] = Settings.Default.ServerIP3;


            connTCP1.ipAddress = initiTCPCtrl.ipList[0];
            connTCP1.clientSocket = new Socket(AddressFamily.InterNetwork,
                                                SocketType.Stream, ProtocolType.Tcp);
            connTCP1.ioControl = new IOControl();
            connTCP1.isConnected = false;
            connTCP1.stateGateOpen = 10;
            connTCP1.gateOpen = false;
            connTCP1.thFlagControlGate = true;
            connTCP1.thFlagProcessData = true;
            connTCP1.thFlagReconnect = true;
            connTCP1.thFlagCheckConn = true;
            connTCP1.getMacOK = true;
            connTCP1.timeOutCheckConn = 0;
            connTCP1.resetCount = false;


            connTCP2.ipAddress = initiTCPCtrl.ipList[1];
            connTCP2.clientSocket = new Socket(AddressFamily.InterNetwork,
                                                SocketType.Stream, ProtocolType.Tcp);
            connTCP2.ioControl = new IOControl();
            connTCP2.isConnected = false;
            connTCP2.stateGateOpen = 10;
            connTCP2.gateOpen = false;
            connTCP2.thFlagControlGate = true;
            connTCP2.thFlagProcessData = true;
            connTCP2.thFlagReconnect = true;
            connTCP2.thFlagCheckConn = true;
            connTCP2.getMacOK = true;
            connTCP2.timeOutCheckConn = 0;
            connTCP2.resetCount = false;


            connTCP3.ipAddress = initiTCPCtrl.ipList[2];
            connTCP3.clientSocket = new Socket(AddressFamily.InterNetwork,
                                                SocketType.Stream, ProtocolType.Tcp);
            connTCP3.ioControl = new IOControl();
            connTCP3.isConnected = false;
            connTCP3.stateGateOpen = 10;
            connTCP3.gateOpen = false;
            connTCP3.thFlagControlGate = true;
            connTCP3.thFlagProcessData = true;
            connTCP3.thFlagReconnect = true;
            connTCP3.thFlagCheckConn = true;
            connTCP3.getMacOK = true;
            connTCP3.timeOutCheckConn = 0;
            connTCP3.resetCount = false;

            tcpclient1 = new TCPClient(connTCP1);
            tcpclient2 = new TCPClient(connTCP2);
            tcpclient3 = new TCPClient(connTCP3);

            tcpclient1.counterEventGate += tcpclient1_counterEventGate;
            tcpclient2.counterEventGate += tcpclient2_counterEventGate;
            tcpclient3.counterEventGate += tcpclient3_counterEventGate;

            tcpclient1.connectEventGate +=tcpclient1_connectEventGate;
            tcpclient2.connectEventGate +=tcpclient2_connectEventGate;
            tcpclient3.connectEventGate += tcpclient3_connectEventGate;
        }

        
        private void tcpclient3_connectEventGate(bool connect)
        {
            if (txtStatusGate3 != null)
            {
                txtStatusGate3.Invoke(new EventHandler(delegate  // Update Driver
                {
                    try
                    {

                        if (connect)
                        {
                            txtStatusGate3.ForeColor = Color.Lime;
                            txtStatusGate3.Text = "เชื่อมต่อ";

                            int max = 0;
                            this.Invoke(new EventHandler(delegate  // Update Driver
                            {
                                try
                                {
                                    sumCount = Convert.ToInt32(sumNumOfPerson.Text);
                                    max = Convert.ToInt32(maxNumPerson.Text);
                                }
                                catch { }
                            }));

                            if (getLastIsConnect[2] == false) // Return from disconnected
                            {
                                

                                if (sumCount > 0 && sumCount < max) // กำลังทำงาน
                                {
                                    imageStatus("use", picGate3);

                                    if (((max - (sumCount)) > 2)) // ถ้าเหลือมากกว่า 2 คน
                                    {
                                        Thread.Sleep(500);
                                        imageStatus("use", picGate3);
                                        this.connTCP3.stateGateOpen = 0;
                                    }
                                    else // ถ้าเหลือน้อยกว่า 2 คน ให้ใช้ช่องเดียว
                                    {
                                        if (this.connTCP2.stateGateOpen == 10
                                            && this.connTCP3.stateGateOpen == 10) // แต่ถ้าอีก 2 ช่องปิดอยู่ก็ให้ทำงานต่อ
                                        {
                                            Thread.Sleep(500);
                                            this.connTCP3.stateGateOpen = 0;
                                            imageStatus("use", picGate3);
                                        }
                                        else
                                        {
                                            this.connTCP3.stateGateOpen = 10;
                                            imageStatus("st", picGate3);
                                        }
                                    }

                                }
                                else
                                {

                                    if (max > 0) // กำลังรอเริ่มทำงาน
                                    {
                                        Thread.Sleep(500);
                                        imageStatus("use", picGate3);
                                        this.connTCP3.stateGateOpen = 0;
                                    }
                                    else // พร้อม
                                    {
                                        imageStatus("st", picGate3);
                                        this.connTCP3.stateGateOpen = 10;
                                    }
                                }
                            }
                            else
                            {
                                if(max == 0)
                                    imageStatus("st", picGate3);
                                //this.connTCP3.stateGateOpen = 10;
                            }
                            getLastIsConnect[2] = true;
                        }
                        else
                        {
                            txtStatusGate3.ForeColor = Color.Red;
                            txtStatusGate3.Text = "ไม่เชื่อมต่อ";
                            getLastIsConnect[2] = false;
                            imageStatus("not", picGate3);
                            this.connTCP3.stateGateOpen = 10;
                        }



                    }
                    catch { }

                }));
            }
            
            
        }

        private void tcpclient2_connectEventGate(bool connect)
        {
            if (txtStatusGate2 != null)
            {
                txtStatusGate2.Invoke(new EventHandler(delegate  // Update Driver
                {
                    try
                    {

                        if (connect)
                        {
                            txtStatusGate2.ForeColor = Color.Lime;
                            txtStatusGate2.Text = "เชื่อมต่อ";
                            int max = 0;
                            this.Invoke(new EventHandler(delegate  // Update Driver
                            {
                                try
                                {
                                    sumCount = Convert.ToInt32(sumNumOfPerson.Text);
                                    max = Convert.ToInt32(maxNumPerson.Text);
                                }
                                catch { }
                            }));
                            if (getLastIsConnect[1] == false) // Return from disconnected
                            {
                                

                                if (sumCount > 0 && sumCount < max) // กำลังทำงาน
                                {
                                    imageStatus("use", picGate2);

                                    if (((max - (sumCount)) > 2)) // ถ้าเหลือมากกว่า 2 คน
                                    {
                                        Thread.Sleep(500);
                                        imageStatus("use", picGate2);
                                        this.connTCP2.stateGateOpen = 0;
                                    }
                                    else // ถ้าเหลือน้อยกว่า 2 คน ให้ใช้ช่องเดียว
                                    {
                                        if (this.connTCP1.stateGateOpen == 10
                                            && this.connTCP3.stateGateOpen == 10) // แต่ถ้าอีก 2 ช่องปิดอยู่ก็ให้ทำงานต่อ
                                        {
                                            Thread.Sleep(500);
                                            this.connTCP2.stateGateOpen = 0;
                                            imageStatus("use", picGate2);
                                        }
                                        else
                                        {
                                            this.connTCP2.stateGateOpen = 10;
                                            imageStatus("st", picGate2);
                                        }
                                    }

                                }
                                else
                                {

                                    if (max > 0) // กำลังรอเริ่มทำงาน
                                    {
                                        Thread.Sleep(500);
                                        imageStatus("use", picGate2);
                                        this.connTCP2.stateGateOpen = 0;
                                    }
                                    else // พร้อม
                                    {
                                        imageStatus("st", picGate2);
                                        this.connTCP2.stateGateOpen = 10;
                                    }
                                }
                            }
                            else
                            {
                                if (max < 0)
                                    imageStatus("st", picGate2);
                                //this.connTCP2.stateGateOpen = 10;
                            }
                            getLastIsConnect[1] = true;
                        }
                        else
                        {
                            txtStatusGate2.ForeColor = Color.Red;
                            txtStatusGate2.Text = "ไม่เชื่อมต่อ";
                            getLastIsConnect[1] = false;
                            imageStatus("not", picGate2);
                            this.connTCP2.stateGateOpen = 10;
                        }



                    }
                    catch { }

                }));
            }
            
        }

        private void tcpclient1_connectEventGate(bool connect)
        {
            if (txtStatusGate1 != null)
            {
                txtStatusGate1.Invoke(new EventHandler(delegate  // Update Driver
                {
                    try
                    {

                        if (connect)
                        {
                            txtStatusGate1.ForeColor = Color.Lime;
                            txtStatusGate1.Text = "เชื่อมต่อ";
                            int max = 0;
                            this.Invoke(new EventHandler(delegate  // Update Driver
                            {
                                try
                                {
                                    sumCount = Convert.ToInt32(sumNumOfPerson.Text);
                                    max = Convert.ToInt32(maxNumPerson.Text);
                                }
                                catch { }
                            }));
                            if (getLastIsConnect[0] == false) // Return from disconnected
                            {
                               

                                if (sumCount > 0 && sumCount < max) // กำลังทำงาน
                                {
                                    imageStatus("use", picGate1);

                                    if (((max - (sumCount)) > 2)) // ถ้าเหลือมากกว่า 2 คน
                                    {
                                        Thread.Sleep(500);
                                        imageStatus("use", picGate1);
                                        this.connTCP1.stateGateOpen = 0;
                                    }
                                    else // ถ้าเหลือน้อยกว่า 2 คน ให้ใช้ช่องเดียว
                                    {
                                        if (this.connTCP2.stateGateOpen == 10 
                                            && this.connTCP3.stateGateOpen == 10) // แต่ถ้าอีก 2 ช่องปิดอยู่ก็ให้ทำงานต่อ
                                        {
                                            Thread.Sleep(500);
                                            this.connTCP1.stateGateOpen = 0;
                                            imageStatus("use", picGate1);
                                        }
                                        else
                                        {
                                            this.connTCP1.stateGateOpen = 10;
                                            imageStatus("st", picGate1);
                                        }
                                    }

                                }
                                else
                                {

                                    if (max > 0) // กำลังรอเริ่มทำงาน
                                    {
                                        imageStatus("use", picGate1);
                                        Thread.Sleep(500);
                                        this.connTCP1.stateGateOpen = 0;
                                    }
                                    else // พร้อม
                                    {
                                        imageStatus("st", picGate1);
                                        this.connTCP1.stateGateOpen = 10;
                                    }
                                }
                            }
                            else
                            {
                                if (max < 0)
                                    imageStatus("st", picGate1);
                                //this.connTCP3.stateGateOpen = 10;
                            }
                            getLastIsConnect[0] = true;
                        }
                        else
                        {
                            txtStatusGate1.ForeColor = Color.Red;
                            txtStatusGate1.Text = "ไม่เชื่อมต่อ";
                            getLastIsConnect[0] = false;
                            imageStatus("not", picGate1);
                            this.connTCP1.stateGateOpen = 10;
                        }



                    }
                    catch { }

                }));
            }
            
        }

        
        private void tcpclient3_counterEventGate(string mac, string count) // counter 3
        {
            this.Invoke(new EventHandler(delegate  // Update Driver
            {
                try
                {
                    int num = Convert.ToInt32(count);
                    //int sum = Convert.ToInt32(sumNumOfPerson.Text);
                    sumCount = Convert.ToInt32(sumNumOfPerson.Text);
                    int max = Convert.ToInt32(maxNumPerson.Text);
                    //sum = sum + 1;
                    sumCount = sumCount + 1;
                    sumNumOfPerson.Text = sumCount.ToString();

                    Thread.Sleep(500);
                    
                    if (sumCount >= max)
                    {
                        //this.connTCP3.stateGateOpen = 3;
                        //Thread.Sleep(500);
                        sumNumOfPerson.Text = sumCount.ToString();
                        this.connTCP1.stateGateOpen = 10;
                        this.connTCP2.stateGateOpen = 10;
                        this.connTCP3.stateGateOpen = 10;
                        insertTranSaction(max, sumCount, 1);
                        imageStatus("st", picGate3);
                        MessageBox.Show("จำนวนคนเท่ากับจำนวนสูงสุด", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        

                        
                    }
                    else
                    {
                        //this.connTCP3.stateGateOpen = 3;
                        //Thread.Sleep(500);
                        
                        if (((max - (sumCount)) > 2)) // ถ้าเหลือมากกว่า 2 คน
                        {
                            this.connTCP3.stateGateOpen = 0;
                            imageStatus("use", picGate3);
                        }
                        else // ถ้าเหลือน้อยกว่า 2 คน ให้ใช้ช่องเดียว
                        {
                            if (this.connTCP2.stateGateOpen == 10 && this.connTCP1.stateGateOpen == 10) // แต่ถ้าอีก 2 ช่องปิดอยู่ก็ให้ทำงานต่อ
                            {
                                this.connTCP3.stateGateOpen = 0;
                                imageStatus("use", picGate3);
                            }
                            else
                            {
                                this.connTCP3.stateGateOpen = 10;
                                imageStatus("st", picGate3);
                            }
                        }
                    }
                }
                catch { }

            }));
        }

        private void tcpclient2_counterEventGate(string mac, string count) // counter 2
        {
            this.Invoke(new EventHandler(delegate  // Update Driver
            {
                try
                {
                    int num = Convert.ToInt32(count);
                    //int sum = Convert.ToInt32(sumNumOfPerson.Text);
                    sumCount = Convert.ToInt32(sumNumOfPerson.Text);
                    int max = Convert.ToInt32(maxNumPerson.Text);
                    //sum = sum + 1;
                    sumCount = sumCount + 1;
                    sumNumOfPerson.Text = sumCount.ToString();
                    Thread.Sleep(500);
                    
                    if (sumCount >= max)
                    {
                        //this.connTCP2.stateGateOpen = 3;
                        //Thread.Sleep(500);
                        sumNumOfPerson.Text = sumCount.ToString();
                        this.connTCP1.stateGateOpen = 10;
                        this.connTCP2.stateGateOpen = 10;
                        this.connTCP3.stateGateOpen = 10;
                        insertTranSaction(max, sumCount, 1);
                        imageStatus("st", picGate2);
                        MessageBox.Show("จำนวนคนเท่ากับจำนวนสูงสุด", "ยืนยัน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        //this.connTCP2.stateGateOpen = 3;
                        //Thread.Sleep(500);
                        
                        if (((max - (sumCount)) > 2)) // ถ้าเหลือมากกว่า 2 คน
                        {
                            this.connTCP2.stateGateOpen = 0;
                            imageStatus("use", picGate2);
                        }
                        else // ถ้าเหลือน้อยกว่า 2 คน ให้ใช้ช่องเดียว
                        {
                            if (this.connTCP1.stateGateOpen == 10 && this.connTCP3.stateGateOpen == 10) // แต่ถ้าอีก 2 ช่องปิดอยู่ก็ให้ทำงานต่อ
                            {
                                this.connTCP2.stateGateOpen = 0;
                                imageStatus("use", picGate2);
                            }
                            else
                            {
                                this.connTCP2.stateGateOpen = 10;
                                imageStatus("st", picGate2);
                            }
                        }

                    }
                }
                catch { }

            }));
        }

        private void tcpclient1_counterEventGate(string mac, string count) // counter 1
        {

            this.Invoke(new EventHandler(delegate  // Update Driver
            {
                try
                {
                    int num = Convert.ToInt32(count);
                    //int sum = Convert.ToInt32(sumNumOfPerson.Text);
                    sumCount = Convert.ToInt32(sumNumOfPerson.Text);
                    int max = Convert.ToInt32(maxNumPerson.Text);
                    //sum = sum + 1;
                    sumCount = sumCount + 1;
                    sumNumOfPerson.Text = sumCount.ToString();
                    Thread.Sleep(500);
                    if (sumCount >= max)
                    {
                        //this.connTCP1.stateGateOpen = 3;
                        //Thread.Sleep(500);
                        sumNumOfPerson.Text = sumCount.ToString();
                        this.connTCP1.stateGateOpen = 10;
                        this.connTCP2.stateGateOpen = 10;
                        this.connTCP3.stateGateOpen = 10;
                        insertTranSaction(max, sumCount, 1);
                        imageStatus("st", picGate1);
                        MessageBox.Show("จำนวนคนเท่ากับจำนวนสูงสุด","ยืนยัน",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        //this.connTCP1.stateGateOpen = 3;
                        //Thread.Sleep(500);
                        //Console.WriteLine(this.connTCP2.stateGateOpen);
                        if (((max - (sumCount)) > 2)) // ถ้าเหลือมากกว่า 2 คน
                        {
                            this.connTCP1.stateGateOpen = 0;
                            imageStatus("use", picGate1);
                        }
                        else // ถ้าเหลือน้อยกว่า 2 คน ให้ใช้ช่องเดียว
                        {
                            if (this.connTCP2.stateGateOpen == 10 && this.connTCP3.stateGateOpen == 10) // แต่ถ้าอีก 2 ช่องปิดอยู่ก็ให้ทำงานต่อ
                            {
                                this.connTCP1.stateGateOpen = 0;
                                imageStatus("use", picGate1);
                            }
                            else
                            {
                                this.connTCP1.stateGateOpen = 10;
                                imageStatus("st", picGate1);
                            }
                        }

                    }
                }
                catch { }

            }));
        }

        private void imageStatus(string mode, PictureBox pic)
        {
            if (pic != null)
            {
                pic.Invoke(new EventHandler(delegate  // Update Driver
                {
                    try
                    {
                        if (mode == "st") // stand by
                        {
                            pic.Image = DparkTerminal.Properties.Resources.stand_by;
                        }
                        else if (mode == "use") // normal use
                        {
                            pic.Image = DparkTerminal.Properties.Resources.right;
                        }
                        else if (mode == "not") // cot connected || can't access
                        {
                            pic.Image = DparkTerminal.Properties.Resources.wrong;
                        }
                    }
                    catch (Exception ex)
                    { }
                }));
            }
            

        }

       
        // END TCP ZONE //
        

        // Cashiear ZONE //
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                takePayement();
                return true;    // indicate that you handled this keystroke
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

      
        private void takePayement()
        {
            updatePrice();
            int max = Convert.ToInt32(maxNumPerson.Text);
            if (this.sumPrice > 0 && max == 0)
            {
                if(this.connTCP1.isConnected || this.connTCP2.isConnected || this.connTCP3.isConnected)
                {
                    fm = new fmTakePayment(TypeOfPayment.takeDialyCard, this.sumPrice);
                    fm.printerName = Settings.Default.SlipPrinter;
                    fm.ShowDialog();

                    if (fm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Invoke(new EventHandler(delegate  // Update Driver
                        {
                            try
                            {
                                initialTransaction(fm);
                                //numberCompany, nameCompany, numInvoice, dateInvoice, title, priceSum  ----> Print Slip
                                this.sumPrice = 0;



                            }
                            catch (Exception ex)
                            { }
                        }));


                    }

                }
                else
                {
                    MessageBox.Show("ไม่สามารถเชื่อมต่อได้", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                
                if (max > 0)
                {
                    MessageBox.Show("เครื่องกำลังทำงาน ไม่สามารถสั่งงานใหม่ได้", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("ยอดเงินสุทธิของท่านต้องมีค่ามากกว่า 0 โปรดตรวจสอบจำนวนคน และ ราคา", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
            GC.Collect();
        }



        private void initialTransaction(fmTakePayment fm)
        {
            this.setfm = fm;
            this.setAccounting = fm.getAccounting;
            this.priceProfileName = priceSelection.Text;
            this.cancleProblem = "";
            insertTranSaction(0, 0, 0);
            maxNumPerson.Text = numPerson.Text;
            startSystem(Convert.ToInt32(maxNumPerson.Text));
            sumNumOfPerson.Text = "0";
            numPerson.Text = "0";
            numPerson.Focus();
            this.ActiveControl = numPerson;
            
        }

        private void startSystem(int numperson)
        {
            this.connTCP1.resetCount = false;
            this.connTCP2.resetCount = false;
            this.connTCP3.resetCount = false;


            if (numperson > 2)
            {
                Console.WriteLine(this.connTCP1.isConnected);
                if (this.connTCP1.isConnected)
                {
                    this.connTCP1.stateGateOpen = 3;
                    Thread.Sleep(500);
                    tcpclient1.resetCount();
                    Thread.Sleep(500);
                    this.connTCP1.thFlagControlGate = true;
                    this.connTCP1.stateGateOpen = 0;
                    imageStatus("use", picGate1);
                }

                if (this.connTCP2.isConnected)
                {
                    this.connTCP2.stateGateOpen = 3;
                    Thread.Sleep(500);
                    tcpclient2.resetCount();
                    Thread.Sleep(500);
                    this.connTCP2.thFlagControlGate = true;
                    this.connTCP2.stateGateOpen = 0;
                    imageStatus("use", picGate2);
                }

                if (this.connTCP3.isConnected)
                {
                    this.connTCP3.stateGateOpen = 0;
                    Thread.Sleep(500);
                    tcpclient3.resetCount();
                    Thread.Sleep(500);
                    this.connTCP3.thFlagControlGate = true;
                    this.connTCP3.stateGateOpen = 0;
                    imageStatus("use", picGate3);

                }
            }
            else // ถ้าเหลือน้อยกว่า 2 คน ให้ใช้ช่องเดียว
            {
                if (this.connTCP1.isConnected)
                {
                    this.connTCP1.stateGateOpen = 3;
                    Thread.Sleep(500);
                    tcpclient1.resetCount();
                    Thread.Sleep(500);
                    this.connTCP1.thFlagControlGate = true;
                    this.connTCP1.stateGateOpen = 0;
                    imageStatus("use", picGate1);

                    return;
                }

                if (this.connTCP2.isConnected)
                {
                    this.connTCP2.stateGateOpen = 3;
                    Thread.Sleep(500);
                    tcpclient2.resetCount();
                    Thread.Sleep(500);
                    this.connTCP2.thFlagControlGate = true;
                    this.connTCP2.stateGateOpen = 0;
                    imageStatus("use", picGate2);

                    return;
                }

                if (this.connTCP3.isConnected)
                {
                    this.connTCP3.stateGateOpen = 3;
                    Thread.Sleep(500);
                    tcpclient3.resetCount();
                    Thread.Sleep(500);
                    this.connTCP3.thFlagControlGate = true;
                    this.connTCP3.stateGateOpen = 0;
                    imageStatus("use", picGate3);

                    return;
                }
            }
        }



        // บันทึกข้อมูลการเข้า และ ข้อมูลการเงินหลังการเข้าเสร้จสมบูรณ์
        private void insertTranSaction(int max,int sum , int mode)
        {
            DBManage.TBAccounting DBMnt = new DBManage.TBAccounting();
            reportReceipt reportRep;
            reportRep = new reportReceipt();

            if (mode == 0) // New 
            {

                this.setAccounting.numOfPerson = max;
                this.setAccounting.realNumOfPerson = sum;
                this.setAccounting.priceProfileName = this.priceProfileName;
                this.setAccounting.cancleProblemComment = this.cancleProblem;
                int accountInsertID = DBMnt.New(this.setAccounting);

                maxNumPerson.Text = "0";
                if (accountInsertID <= 0)
                {
                    MessageBox.Show("Can't accounting update or new ERROR:8890");
                } 
                //else // Hidden Function
                //{
                    
                //    //reportRep.Print(Settings.Default.SlipPrinter);
                //    reportRep.PrinterName = Settings.Default.SlipPrinter;
                //    reportRep.lbNameCompany.Text = Settings.Default.nameCompany;
                //    reportRep.lbNumberCompany.Text = "เลขประจำตัวผู้เสียภาษี "Settings.Default.numberCompany;
                //    reportRep.lbTitle.Text = Settings.Default.slipTitle;
                //    reportRep.lbSysUserName.Text = txtUser.Text;
                //    reportRep.lbInVoice.Text = accountInsertID.ToString();
                //    reportRep.lbSumPrice.Text = this.setAccounting.accountingReceive.ToString();
                //    reportRep.lbDateSlip.Text = this.setAccounting.accountingDateTime.ToString();
                //    this.setfm.printSlip(reportRep);
                //    //reportRep.ExportToPdf("lastprint.pdf");
                //}
                
            }
            else if (mode == 1) // Update
            {
                this.setAccounting.numOfPerson = max;
                this.setAccounting.realNumOfPerson = sum;
                this.setAccounting.priceProfileName = this.priceProfileName;
                this.setAccounting.cancleProblemComment = this.cancleProblem;
                int accountInsertID = DBMnt.Update(this.setAccounting);

                maxNumPerson.Text = "0";
                if (accountInsertID <= 0)
                {
                    MessageBox.Show("Can't accounting update or new ERROR:8890");
                }
            }
            
            GC.Collect();
           
        }


        private void updatePrice()
        {
            
            try
            {
                int priPerPeo = Convert.ToInt32(getPriceSelect.Text);
                int numberPerson = Convert.ToInt32(numPerson.Text);
                this.sumPrice = priPerPeo * numberPerson;
                
            }
            catch
            {
                MessageBox.Show("กรุณาใส่ตัวเลขที่เป็นจำนวนเต็ม", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
            GC.Collect();
        }


        private void returnPriceSelection(object sender, EventArgs e)
        {
            ComboBoxItem itm = (ComboBoxItem)priceSelection.SelectedItem;
            Console.WriteLine("{0}, {1}", itm.Text, itm.Value);

            getPriceSelect.Text = itm.Value.ToString();
            this.priceProfileName = itm.Text;
        }


        



        // -----------------  End Cashier -------------------- //



        // ----------------- Zone Event Form ----------------- //


        private void closeGateCancle()
        {
            if (this.connTCP1.isConnected) // 1
            {
                this.connTCP1.stateGateOpen = 11;
                tcpclient1.closeGate();
                Thread.Sleep(500);
                
                imageStatus("st",picGate1);
            }

            if (this.connTCP2.isConnected) // 2
            {
                this.connTCP2.stateGateOpen = 11;
                tcpclient2.closeGate();
                Thread.Sleep(500);
                imageStatus("st", picGate2);
                
            }

            if (this.connTCP3.isConnected) // 3
            {
                this.connTCP3.stateGateOpen = 11;
                tcpclient3.closeGate();
                Thread.Sleep(500);
                imageStatus("st", picGate3);
                
            }
        }
        private void btnCancleTran_Click(object sender, EventArgs e)
        {
            int sum = Convert.ToInt32(sumNumOfPerson.Text);
            int max = Convert.ToInt32(maxNumPerson.Text);

            if (sum > 0) // อยู่ในระหว่างการทำงาน
            {
                fmEmergencyOpenBarier fmE = new fmEmergencyOpenBarier(this.setAccounting.accountingID, fmMainTerminal.staticVar.lbSysUser.Text, 1);
                fmE.ShowDialog();

                if (fmE.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    closeGateCancle();
                    //Thread.Sleep(500);
                    this.cancleProblem = fmE.problemMessage;
                    insertTranSaction(max, sum,1);
                    
                }
            }
            else
            {
                if (max > 0) // Start Open Wait .... Count
                {
                    fmEmergencyOpenBarier fmE = new fmEmergencyOpenBarier(this.setAccounting.accountingID, fmMainTerminal.staticVar.lbSysUser.Text, 1);
                    fmE.ShowDialog();

                    if (fmE.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {

                        closeGateCancle();
                        //Thread.Sleep(500);
                        this.cancleProblem = fmE.problemMessage;
                        insertTranSaction(max, sum,1);
                    }
                }
                else// stand by
                {
                    MessageBox.Show("เครื่องไม่ได้กำลังทำงาน ไม่สามารถยกเลิกได้", "ตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            GC.Collect();
        }

        public void Formclose()
        {
            try
            {
                tcpclient1.destoryedThread();
                tcpclient2.destoryedThread();
                tcpclient3.destoryedThread();

                txtStatusGate1 = null;
                txtStatusGate2 = null;
                txtStatusGate3 = null;
                thFlagTCPMonitor = false;
                //tcpMonitor.Abort();
                
                if (this != null)
                    this.Close();
                this.Dispose();

            }
            catch (Exception ex)
            {

            }

            GC.Collect();

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                tcpclient1.destoryedThread();
                tcpclient2.destoryedThread();
                tcpclient3.destoryedThread();

                txtStatusGate1 = null;
                txtStatusGate2 = null;
                txtStatusGate3 = null;
                thFlagTCPMonitor = false;
                //tcpMonitor.Abort();

                if (this != null)
                    this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {

            }
            GC.Collect();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            initialUI();
            fm = new fmTakePayment(TypeOfPayment.takeDialyCard, this.sumPrice);
            //tcpMonitor = new Thread(new ThreadStart(TCPMonitor));
            //thFlagTCPMonitor = true;
            //tcpMonitor.Start();
        }

       

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Formclose();
        }


    }
}
