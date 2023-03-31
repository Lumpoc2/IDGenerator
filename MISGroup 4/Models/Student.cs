using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MISGroup_4.Models
{
    public class Student
    {
        public string rfid { get; set; }
        public string StudentId { get; set; }
        public string Program { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Extname { get; set; }
        public string GuardianName { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Image ProfilePicture { get; set; }
        public Image Signature { get; set; }

       
        
        public string Fullname { get { return string.Format("{0} {1} {2} {3}", Firstname, Middlename,Lastname, Extname); } }

    }
}
