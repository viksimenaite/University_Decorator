using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class Lecturer
    {
        private string name;
        private string specialty;
        private bool hasPHD;
        private int experience;

        public Lecturer(string name, string specialty, bool hasPHD, int experience)
        {
            this.name = name;
            this.specialty = specialty;
            this.hasPHD = hasPHD;
            this.experience = experience;
        }

        public string Name { get => name; set => name = value; }
        public string Specialty { get => specialty; set => specialty = value; }
        public int Experience { get => experience; set => experience = value; }
        public bool HasPHD { get => hasPHD; set => hasPHD = value; }

        public override string ToString()
        {
            string experience = " with " + Experience + " year of experience in " + Specialty ;
            if (HasPHD)
            {
                return Name + ", Ph.D." + experience;
            }
            else
            {
                return Name + experience;
            }

        }
    }
}
