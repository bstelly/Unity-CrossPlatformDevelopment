using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Editor
{
    public class Stat
    {

        private int _value;
        public string Name { get; set; }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Description { get; set; }

        public Stat()
        {
            Name = "";
            Value = 0;
            Description = "";
        }

        public Stat(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public static explicit operator Stat(int i)
        {
            Stat temp = new Stat("Default", i, "Description");
            return temp;
        }

        public static explicit operator Stat(string i)
        {
            Stat temp = new Stat(i, 10, "Description");
            return temp;
        }
    }
}
