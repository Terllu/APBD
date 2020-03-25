using System;
using System.Xml.Serialization;

namespace Cw2
{
    internal class Student
    {
        private string _surname, _id;

        [XmlElement(ElementName = "Name")]
        public String Name { get; set; }
        [XmlElement(ElementName = "Subject")]
        public String Subject { get; set; }
        [XmlElement(ElementName = "Type")]
        public String Type { get; set; }
        [XmlElement(ElementName = "Birthday")]
        public String Birthday { get; set; }
        [XmlElement(ElementName = "Email")]
        public String Email { get; set; }
        [XmlElement(ElementName = "MotherName")]
        public String MotherName { get; set; }
        [XmlElement(ElementName = "FatherName")]
        public String FatherName { get; set; }

        [XmlElement(ElementName = "Surname")]
        public String Surname
        {
            get { return _surname; }
            set
            {
                if (value == null) throw new ArgumentException();
                _surname = value;
            }
        }

        [XmlElement(ElementName = "ID")]
        public String ID
        {
            get { return _id; }
            set
            {
                if (value == null) throw new ArgumentException();
                _id = "s" + value;
            }
        }


    }
}