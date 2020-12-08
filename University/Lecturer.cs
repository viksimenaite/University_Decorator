using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class Lecturer
    {
        string name;
        bool isDoctor;
        int experience;

        public Lecturer(string name, bool isDoctor, int experience)
        {
            this.name = name;
            this.isDoctor = isDoctor;
            this.experience = experience;
        }

        public string Name { get => name; set => name = value; }
        public bool IsDoctor { get => isDoctor; set => isDoctor = value; }
        public int Experience { get => experience; set => experience = value; }
    }
}
