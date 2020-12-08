using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class Lecturer
    {
        private string name;
        private bool hasPHD;
        private int experience;

        public Lecturer(string name, bool hasPHD, int experience)
        {
            this.name = name;
            this.hasPHD = hasPHD;
            this.experience = experience;
        }

        public string Name { get => name; set => name = value; }
        public int Experience { get => experience; set => experience = value; }
        public bool HasPHD { get => hasPHD; set => hasPHD = value; }
    }
}
