using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Configuration;
using System.Drawing.Printing;
using BackOffice;
using System.Xml;
using System.Collections;
using BackOffice.Properties;

namespace BackOffice
{
    public class Globals
    {
        public static int sysUserID = 0; // system user login 
       

        // สำหรับ เริ่ม Profile ใหม่
        public const int priceProfileDayServiceChrageDefault = 10; // ค่าธรรมเนียมแรกเข้า
        public const int priceProfileDayFreeTimeDefault = 15; // การจอดฟรีโดยไม่มีค่าธรรมเนียม

        public const int priceProfileHourRateDefault = 20; // ค่าจอดรายชั่วโมง
    }
    //public class reportTakeTicketInfo {
    //    public string ticketNumber;
    //    public string ticketTypeName;
    //    public string ticketMemberName;
    //    public string carPlateNumber;
    //    public DateTime ticketStartDate;
    //    public DateTime ticketExpiryDate;
    //    public string sysUserName;
    //    public double grandPrices;
    //    public string pageTitle;
    //}

    public class reportTakeTicketInfo
    {
        public string nameCompany;
        public string numberCompany;
        public string invoiceNumber;
        public string invoiceDate;
        public string sysUserName;
        public string sumPrices;
        public string slipTitle;
    }
    public class reportRecitptInfo {
       public string pricesProfileName;
       public int transID;
       public DateTime transChkIn;
       public DateTime transChkOut;
       public string sysUserName;
       public string carPlateNumber;
       public string ticketNumber;
       public int TimeOfFreeParking;
       public string ParkingTime;
       public string TimeOfParkingChange;
       public double LostCardFee;
       public double OverNightFee;

    }
    public class gateOutReceiptInfo {
        public DateTime dt;
        public string ticketNumber;
        public double grandPrices;
        public string cashier;
        public int transactionID;
        public string gateOutName;
    }
 
    public enum TerminalWorkingMode : int
    {
        GateIn = 1, GateOut = 2
    }
    public enum TypeOfReader : int
    {
        GateIn = 1, GateOut = 2
    }
    public enum TypeOfImg
    {
        sysUser,Trans,TicketMember,sysOwner
    }
    public enum TypeOfChkTextBox { 
        mString,mInt
    }
    public enum priceProfileType:int
    {
        normal=1, discount=2
    }
    public enum TypeRecordState
    {
        Save,Update,Idle
    }
    public enum TypeOfTicket : int
    {
        FreeTicket = 1, DialyTicket = 2, MonthlyTicket = 3,  VisitorTicket = 5, Emergency = 6,Times =7
    }

    public  class General
    {
        public class reportTransactionMoreInfo
        {
            public Image img2 { set; get; }
        }   

        public double CalCulateParkingFee(int ProfileID, TimeSpan tm, bool IsLostCard)
        {
            int FreeTimeParking=0;double lostCardFee=0;
            return CalCulateParkingFee(ProfileID, tm, IsLostCard, out FreeTimeParking,out  lostCardFee,0);
      
        }
        public string reportDir { get { return _reportDir; } }
        public string reportReceiptFile { get { return _reportReceiptFile; } }
        public string reportChkIn { get { return _reportChkIn; } }
        public string reportCashierLogout { get { return _reportCashierLogout; } }
        public string reportTakeTicketReceipt { get { return _reportTakeTicketReceipt; } }
        const string _reportDir = "reports";
        const string _reportReceiptFile = "ReportReceipt.repx";
        const string _reportChkIn = "ReportChkIn.repx";
        const string _reportCashierLogout = "ReportCasherLogout.repx";
        const string _reportTakeTicketReceipt = "ReportTakeTicketReceipt.repx";

        public string reportGetFileName(General.typeOfReport e)
        {
            string ReportFileName = string.Empty;
            switch (e)
            {
                case General.typeOfReport.receiptReport: ReportFileName = _reportReceiptFile; break;
                case General.typeOfReport.CashierLogoutReport: ReportFileName = _reportCashierLogout; break;
                case General.typeOfReport.chkInReport: ReportFileName = _reportChkIn; break;
                case General.typeOfReport.TakeTicketReceipt: ReportFileName = _reportTakeTicketReceipt; break;

            }
            return ReportFileName;
        }
        public string reportGetFilePath(General.typeOfReport e)
        {
            string ReportFilePath = string.Empty;
            switch (e)
            {
                case General.typeOfReport.receiptReport: ReportFilePath = _reportDir + "\\" + _reportReceiptFile; break;
                case General.typeOfReport.CashierLogoutReport: ReportFilePath = _reportDir + "\\" + _reportCashierLogout; break;
                case General.typeOfReport.chkInReport: ReportFilePath = _reportDir + "\\" + _reportChkIn; break;
                case General.typeOfReport.TakeTicketReceipt: ReportFilePath = _reportDir + "\\" + _reportTakeTicketReceipt; break;

            }
            return ReportFilePath;
        }
      public double CalCulateParkingFee(int ProfileID, TimeSpan tm,bool IsLostCard,out int FreeTimeParking,out double lostCardFee,int additionFreeParkingTime) {
          double rate = 0;
          DBManage.viewPriceProfile dbmnt = new DBManage.viewPriceProfile();
          List<view_priceProfile> pfL =  dbmnt.getPriceProfileTodayByID(ProfileID);

             if (IsLostCard)
             {
                 rate += pfL[0].priceProfileLostCardFee;
                 lostCardFee = pfL[0].priceProfileLostCardFee;
             }

          lostCardFee = pfL[0].priceProfileLostCardFee; // ส่งออกเพื่อเป็น ref.
        
          rate += pfL[0].priceProfileDayServiceCharge;
          //อยู่ใน ช่วงจอดฟรี   หน่วยเป็นนาที
          int tmp = pfL[0].priceProfileDayFreeTime + additionFreeParkingTime;
          FreeTimeParking = tmp; // output 
            
          //หาชั่วโมงแบบปัดเศษ

            int freeParking = Convert.ToInt16(Math.Floor((double)((double)(pfL[0].priceProfileDayFreeTime + additionFreeParkingTime) / 60)));

            if ((double)pfL[0].priceProfileDayFreeTime + additionFreeParkingTime >= tm.TotalMinutes)
           {
               GC.Collect();
               return rate += 0;
           }
           else
           {
           }
        
        // int freeParking = (int)Math.Round((double)((double)120 / 60), MidpointRounding.AwayFromZero);
         int parkingHour=0;
          if(pfL[0].priceProfileFlooringMode){
            //parkingHour =(int) Math.Round( (double)((double)tm.TotalMinutes -/ 60), MidpointRounding.AwayFromZero  );

              parkingHour = (int)Math.Ceiling((double)((double)tm.Subtract(new TimeSpan(0, (int)pfL[0].priceProfileFlooringOffset, 0)).TotalMinutes / 60));
          }else{
              throw new  NotImplementedException();
          }
          Console.WriteLine("pfID ={2},pfDayID{3},freePark {0},ParkingHour{1}", freeParking, parkingHour, pfL[0].priceProfileID,pfL[0].priceProfileDayID);
         
          for (int i = freeParking; i <= parkingHour - 1; i++)
          {
              
            //  if (i > 23) { rate += pfL[23].priceProfileHourRate; }  // คิดราคา ชั่วโมงที่ 24 เป็นต้นไป
              if (i > 23) {  rate += (pfL[23].priceProfileHourRate * (parkingHour - 24) );
                   GC.Collect();
                  return rate;
              } 
              else { rate += pfL[i].priceProfileHourRate;
              Console.WriteLine("i={0},pfl={1}", i, pfL[i].priceProfileHourRate);
              
              }

        }
          /// ***** ยังไม่บวก จอดค้างคืน
          ///  
          GC.Collect();
          
          return rate;
      }
      public Image[] GetImageLists(string ShareFolder,string tranID) {
          ArrayList img = new ArrayList();
          ShareFolder = ShareFolder+@"\trans\"+ (1000 * (Convert.ToInt32(tranID) / 1000)).ToString();
          Console.WriteLine("Folder : "+ShareFolder+" ID :"+tranID);
          if (!Directory.Exists(ShareFolder))
          {
              return null;
          }
          string[] lists = Directory.GetFiles(ShareFolder, tranID+"*.*", SearchOption.TopDirectoryOnly);
          if(lists==null){return null;}
          foreach (string fileList in lists )
          {
              img.Add(Image.FromFile(fileList));
            // img[i++]= 
             Console.WriteLine(fileList);
          }

          return img.ToArray(typeof(Image)) as Image[];
      }
        public string GetConnectionString() {

            string ServerName = Settings.Default.DBServer;
            string DBName=Settings.Default.DBName;
            string userName = Settings.Default.DBUsername;
            string passwd = Settings.Default.DBPassword;
             string strConn = string.Format("data source={0};initial catalog={1};user id={2};password={3};multipleactiveresultsets=True;App=EntityFramework",ServerName,DBName,userName,passwd);
            
             //updateConfigFile(strConn);
             GC.Collect();
            return strConn;
            
        }
        [DllImport("kernel32.dll")]
        public static extern int SetSystemTime(ref SystemTime systemTime);
    
        [StructLayout(LayoutKind.Sequential)]

        public struct SystemTime {
        public System.UInt16 Year;
        public System.UInt16 Month;
        public System.UInt16 DayOfWeek;
        public System.UInt16 Day;
        public System.UInt16 Hour;
        public System.UInt16 Minute;
        public System.UInt16 Second;
        public System.UInt16 Millisecond;
        }


        public DateTime SyncTimeFormServer() {
            DateTime idag = GetServerTime();
            DateTime tmp = idag;
            idag = idag.ToUniversalTime();
 
            SystemTime s = new SystemTime();
            s.Year = (ushort)idag.Year;
            s.Month = (ushort)idag.Month;
            s.Day = (ushort)idag.Day;
            s.Hour = (ushort)idag.Hour;
            s.Minute = (ushort)idag.Minute;
            s.Second = (ushort)idag.Second;
            s.Millisecond = (ushort)idag.Millisecond;

            SetSystemTime(ref s);
            return tmp;
        }
        public DateTime GetServerTime() { 

              using (Dpark3Entities db = new Dpark3Entities())
              {
                    db.Database.Connection.ConnectionString = GetConnectionString();
                    return  db.Database.SqlQuery<DateTime>(
                           "select GETDATE()").First();
              }

        }
        public string GetSharePath() {
            DBManage.TBsysParam DBMnt = new DBManage.TBsysParam();
            DBMnt.ReadAll();
            GC.Collect();
            return DBMnt.imgPath;
        }
        public enum printType { 
            Receipt,Report,ChkInBill
        }

        public void ConnectToShare()
        {
            DBManage.TBsysParam DBMnt = new DBManage.TBsysParam();
            DBMnt.ReadAll();
            NetworkShare.DisconnectFromShare(DBMnt.imgPath, true); //Disconnect in case we are currently connected with our credentials;
            NetworkShare.ConnectToShare(DBMnt.imgPath, DBMnt.imgPathUser, DBMnt.imgPathPasswd); //Connect with the new credentials
            GC.Collect();
        }
        public void ResetTextBox(TextBox txt)
        {
            txt.Text = string.Empty;
            
        }
        private static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                {
                    GC.Collect();
                    return lang;
                }
            }
            return null;
        }
        public void SetKeyboardLayout(string e) {
           
            InputLanguage.CurrentInputLanguage = GetInputLanguageByName(e);
            GC.Collect();
        }
        public void DisposeControls(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                child.Dispose();
            }
        }
        public void ResetChildControls(Control parent)
        {
            if (parent.Controls.Count == 0)
                return;

            foreach (Control child in parent.Controls)
            {
                if (child is System.Windows.Forms.TextBox)
                {
                    ((TextBox)child).Text = string.Empty;
                }
                else if (child is System.Windows.Forms.RichTextBox)
                {
                    ((RichTextBox)child).Text = string.Empty;
                }
                else if (child is DevExpress.XtraEditors.SpinEdit)
                {
                    child.Text = "0";
                }
                else if (child is System.Windows.Forms.ComboBox) 
                {
                    System.Windows.Forms.ComboBox dropdown = (System.Windows.Forms.ComboBox)child;

                    if (dropdown.Items.Count > 0)
                    {
                        dropdown.SelectedIndex = 0;
                    }
                }
                else if (child is DevExpress.XtraEditors.ComboBox)
                {
                    DevExpress.XtraEditors.ComboBox dropdown = (DevExpress.XtraEditors.ComboBox)child;
                    dropdown.SelectedIndex = 0;
                }
                else if (child is RadioButton)
                {
                    ((RadioButton)child).Checked = false;
                    ((RadioButton)child).BackColor = Color.White;
                }
                ResetChildControls(child);
            }
        }
        public bool IsValidTextbox(TextBox txt) {
                if(txt.Text == ""){
                    txt.Focus();
                    MessageBox.Show( "โปรดกรอกข้อความให้ครบถ้วน","ข้อมูลผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
        }
        private void saveImgTH(System.Drawing.Image img, string fileName, TypeOfImg imgType) {
            string subFolder = string.Empty;

             img = ResizeImage(img, 320, 240); 
            switch (imgType)
            {
                case TypeOfImg.sysUser: subFolder = @"\user\"; break;
                case TypeOfImg.Trans: subFolder = @"\trans\"; break;
                case TypeOfImg.TicketMember: subFolder = @"\ticketmember\"; break;
                case TypeOfImg.sysOwner: subFolder = @"\owner\"; break;
            }

            string imgPath = GetSharePath();
            if (!Directory.Exists(imgPath + subFolder))
            {
              //  try
                {
                    Directory.CreateDirectory(imgPath + subFolder);
                }
             //   catch (IOException)
                {
                }
             //   catch{MessageBox.Show("CODE 45441");}
            }

            fileName = imgPath + subFolder + fileName + ".jpg";
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Compression;
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(encoder, 100);          // 100% Percent Compression
            try
            {
                img.Save(fileName, ImageCodecInfo.GetImageEncoders()[1], encoderParameters);   // jpg format
            }
            catch (ExternalException)
            {
                //MessageBox.Show("ตรวจสอบตำแหน่งการบันทึกภาพ", "การบันทึกภาพผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                // load ภาพไม่ได้ตอนที่ network fail
                MessageBox.Show("Null", "การบันทึกภาพผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch {
                MessageBox.Show("CODE 45451");
            }
        }
        public enum typeOfReport{
            receiptReport,  // ใบเสร็จ
            chkInReport,  // ใบเวลาเข้า
            CashierLogoutReport, // ใบสรุปกะ
            TakeTicketReceipt
       }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs=null;
            try
            {
                dirs = dir.GetDirectories();
            

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            }
            catch { }
            // If the destination directory doesn't exist, create it. 
            destDirName =Path.GetDirectoryName( Application.ExecutablePath) + destDirName;
           
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
                
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = null;
            try
            {
                files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, true);
                }
            }
            catch { }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        private void DownloadAllReportTH() {
            string SharePath = GetSharePath();
            const string reportFolder = "\\reports";
           // try
            {
                DirectoryCopy(SharePath + reportFolder, reportFolder, false);
            }
           // catch {  }
            GC.Collect();        
        }
        public void DownloadAllReport() {
            Thread t = new Thread(DownloadAllReportTH);
            t.Start();
        }
      
        public void saveImg(System.Drawing.Image img, string fileName, TypeOfImg imgType)
        {
            Thread TH = new Thread(() => saveImgTH(img,fileName,imgType));
            TH.Start();

        }
        private void delImgTH(string fileName, TypeOfImg imgType) {

            string subFolder = string.Empty;
            switch (imgType)
            {
                case TypeOfImg.sysUser: subFolder = @"\user\"; break;
                case TypeOfImg.Trans: subFolder = @"\trans\"; break;
                case TypeOfImg.TicketMember: subFolder = @"\ticketmember\"; break;
                case TypeOfImg.sysOwner: subFolder = @"\owner\"; break;
            }
            string imgPath = GetSharePath();

            if (!Directory.Exists(imgPath + subFolder))
            {
                try
                {
                    Directory.CreateDirectory(imgPath + subFolder);
                }
                catch (IOException){
         
                }
            }
            try
            {
                fileName = imgPath + subFolder + fileName + ".jpg";
                File.Delete(fileName);
            }
            catch (IOException)
            {
               // MessageBox.Show("ตรวจสอบตำแหน่งการบันทึกภาพ", "การบันทึกภาพผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            GC.Collect();
        }
        public void delImg(string fileName, TypeOfImg imgType) {
           Thread TH =new Thread(() => delImgTH(fileName,imgType));
           TH.Start();
        }
        public Image loadImg(TypeOfImg imgType, string fileName)
        {
            string subFolder = string.Empty;
            switch (imgType)
            {
                case TypeOfImg.sysUser: subFolder = @"\user\"; break;


                case TypeOfImg.Trans: string folderName = (1000 * (Convert.ToInt32(fileName.Remove(fileName.Length - 3, 3)) / 1000)).ToString();
                    //   MessageBox.Show(fileName.Remove(fileName.Length - 2, 2));
                    subFolder = string.Format("\\trans\\{0}\\", folderName);
                    break;
                case TypeOfImg.TicketMember: subFolder = @"\ticketmember\"; break;
                case TypeOfImg.sysOwner: subFolder = @"\owner\"; break;
            }
            string imgPath = GetSharePath();
            fileName = string.Format ("{0}{1}{2}.jpg",imgPath , subFolder, fileName);
            Image img = null;

            if (!File.Exists(fileName))
            {
                string curfile = "not-found.png";
                if (File.Exists(curfile))
                {
                    FileStream stream = new FileStream(curfile, FileMode.Open, FileAccess.Read);
                    img = Image.FromStream(stream);
                }
            }
            else
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    img = Image.FromStream(stream);
                }
            }
            GC.Collect();
            return img;
        }
        public string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Export To " + title;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        public void OpenFile(string fileName)
        {
            if (MessageBox.Show("Do you want to open this file?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    MessageBox.Show( "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private static Image ResizeImage(Image sourceImage, int width, int height)
        {
            try
            {
                System.Drawing.Image oThumbNail = new Bitmap(sourceImage, width, height);
                Graphics oGraphic = Graphics.FromImage(oThumbNail);
                oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                oGraphic.InterpolationMode = InterpolationMode.Bicubic;
                oGraphic.PixelOffsetMode = PixelOffsetMode.Half;
                Rectangle oRectangle = new Rectangle(0, 0, width, height);
                oGraphic.DrawImage(sourceImage, oRectangle);
                GC.Collect();
                return oThumbNail;
            }
            catch (ArgumentNullException) { }
            GC.Collect();
            return null;
        }
    }
    public  class NetworkShare
    {
        /// <summary>
        /// Connects to the remote share
        /// </summary>
        /// <returns>Null if successful, otherwise error message.</returns>
        private static void ConnectToShareTH(object e) {
            shareFolder sf = (shareFolder)e;
            
            //Create netresource and point it at the share
            NETRESOURCE nr = new NETRESOURCE();
            nr.dwType = RESOURCETYPE_DISK;
            nr.lpRemoteName = sf.uri;

            //Create the share
            int ret = WNetUseConnection(IntPtr.Zero, nr, sf.password, sf.username, 0, null, null, null);

        }
        private class shareFolder {
            public string uri;
            public string username;
            public string password;
        }
        public static void ConnectToShare(string uri, string username, string password)
        {

            shareFolder sf = new shareFolder();
            sf.uri = uri;
            sf.username = username;
            sf.password = password;
            Thread t = new Thread(ConnectToShareTH);
            t.Start((object)sf);
         
        }

        /// <summary>
        /// Remove the share from cache.
        /// </summary>
        /// <returns>Null if successful, otherwise error message.</returns>
        public static string DisconnectFromShare(string uri, bool force)
        {
            //remove the share
            int ret = WNetCancelConnection(uri, force);

            //Check for errors
            if (ret == NO_ERROR)
                return null;
            else
                return GetError(ret);
        }

        #region P/Invoke Stuff
        [DllImport("Mpr.dll")]
        private static extern int WNetUseConnection(
            IntPtr hwndOwner,
            NETRESOURCE lpNetResource,
            string lpPassword,
            string lpUserID,
            int dwFlags,
            string lpAccessName,
            string lpBufferSize,
            string lpResult
            );

        [DllImport("Mpr.dll")]
        private static extern int WNetCancelConnection(
            string lpName,
            bool fForce
            );

        [StructLayout(LayoutKind.Sequential)]
        private class NETRESOURCE
        {
            public int dwScope = 0;
            public int dwType = 0;
            public int dwDisplayType = 0;
            public int dwUsage = 0;
            public string lpLocalName = "";
            public string lpRemoteName = "";
            public string lpComment = "";
            public string lpProvider = "";
        }

        #region Consts
        const int RESOURCETYPE_DISK = 0x00000001;
        const int CONNECT_UPDATE_PROFILE = 0x00000001;
        #endregion

        #region Errors
        const int NO_ERROR = 0;

        const int ERROR_ACCESS_DENIED = 5;
        const int ERROR_ALREADY_ASSIGNED = 85;
        const int ERROR_BAD_DEVICE = 1200;
        const int ERROR_BAD_NET_NAME = 67;
        const int ERROR_BAD_PROVIDER = 1204;
        const int ERROR_CANCELLED = 1223;
        const int ERROR_EXTENDED_ERROR = 1208;
        const int ERROR_INVALID_ADDRESS = 487;
        const int ERROR_INVALID_PARAMETER = 87;
        const int ERROR_INVALID_PASSWORD = 1216;
        const int ERROR_MORE_DATA = 234;
        const int ERROR_NO_MORE_ITEMS = 259;
        const int ERROR_NO_NET_OR_BAD_PATH = 1203;
        const int ERROR_NO_NETWORK = 1222;
        const int ERROR_SESSION_CREDENTIAL_CONFLICT = 1219;

        const int ERROR_BAD_PROFILE = 1206;
        const int ERROR_CANNOT_OPEN_PROFILE = 1205;
        const int ERROR_DEVICE_IN_USE = 2404;
        const int ERROR_NOT_CONNECTED = 2250;
        const int ERROR_OPEN_FILES = 2401;

        private struct ErrorClass
        {
            public int num;
            public string message;
            public ErrorClass(int num, string message)
            {
                this.num = num;
                this.message = message;
            }
        }

        private static ErrorClass[] ERROR_LIST = new ErrorClass[] {
        new ErrorClass(ERROR_ACCESS_DENIED, "Error: Access Denied"), 
        new ErrorClass(ERROR_ALREADY_ASSIGNED, "Error: Already Assigned"), 
        new ErrorClass(ERROR_BAD_DEVICE, "Error: Bad Device"), 
        new ErrorClass(ERROR_BAD_NET_NAME, "Error: Bad Net Name"), 
        new ErrorClass(ERROR_BAD_PROVIDER, "Error: Bad Provider"), 
        new ErrorClass(ERROR_CANCELLED, "Error: Cancelled"), 
        new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"), 
        new ErrorClass(ERROR_INVALID_ADDRESS, "Error: Invalid Address"), 
        new ErrorClass(ERROR_INVALID_PARAMETER, "Error: Invalid Parameter"), 
        new ErrorClass(ERROR_INVALID_PASSWORD, "Error: Invalid Password"), 
        new ErrorClass(ERROR_MORE_DATA, "Error: More Data"), 
        new ErrorClass(ERROR_NO_MORE_ITEMS, "Error: No More Items"), 
        new ErrorClass(ERROR_NO_NET_OR_BAD_PATH, "Error: No Net Or Bad Path"), 
        new ErrorClass(ERROR_NO_NETWORK, "Error: No Network"), 
        new ErrorClass(ERROR_BAD_PROFILE, "Error: Bad Profile"), 
        new ErrorClass(ERROR_CANNOT_OPEN_PROFILE, "Error: Cannot Open Profile"), 
        new ErrorClass(ERROR_DEVICE_IN_USE, "Error: Device In Use"), 
        new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"), 
        new ErrorClass(ERROR_NOT_CONNECTED, "Error: Not Connected"), 
        new ErrorClass(ERROR_OPEN_FILES, "Error: Open Files"), 
        new ErrorClass(ERROR_SESSION_CREDENTIAL_CONFLICT, "Error: Credential Conflict"),
    };

        private static string GetError(int errNum)
        {
            foreach (ErrorClass er in ERROR_LIST)
            {
                if (er.num == errNum) return er.message;
            }
            return "Error: Unknown, " + errNum;
        }
        #endregion

        #endregion
    }
 	
}