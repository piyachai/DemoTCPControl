using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using System.Drawing;
using System.Drawing.Drawing2D;

    public enum TypeUser
    {
      Group,
      user
    }
    //public class User {
    //    public void  tagUser(){

    //    }
  //  }
   public struct tagUser
    {
        public int userId;
        public string EMCode;
        public string Name;
        public int parent_id;
        public string telNo;
        public string email;
        public byte[] image;
        public TypeUser userType;
        public int authenMode;
        public string card1;
           public string card2;
      //  public tagUser(string _emcode,string _name,int _parent_id,string _telNo,string _email,string _image,TypeUser _usertype) {
            
          //  EMCode=_emcode;
         //   Name=_name;
         //   parent_id=_parent_id;
         //   telNo=_telNo;
        //    email=_email;
        //    image = _image;
        //    userType=_usertype;
        //}
           public tagUser(int _userId, string _emcode, string _name, int _parent_id, string _telNo, string _email, byte[] _image, TypeUser _usertype, int _authenMode, string _card1, string _card2)
        {
            userId = _userId;
            EMCode = _emcode;
            Name = _name;
            parent_id = _parent_id;
            telNo = _telNo;
            email = _email;
            image = _image;
            userType = _usertype;
            authenMode = _authenMode;
            card1 = _card1;
            card2 = _card2;
        }
        
    }
