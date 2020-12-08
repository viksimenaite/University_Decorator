using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class Lecture
    {
        private string subject;
        private double duration;
        bool isConsultation;
        bool isPrivate;
        bool isVideo; // whether it is on online lecture

        public Lecture(string subject, double duration, bool isConsultation, bool isPrivate, bool isVideo)
        {
            this.subject = subject;
            this.duration = duration;
            this.isConsultation = isConsultation;
            this.isPrivate = isPrivate;
            this.isVideo = isVideo;
        }

        public string Subject { get => subject; set => subject = value; }
        public double Duration { get => duration; set => duration = value; }
        public bool IsConsultation { get => isConsultation; set => isConsultation = value; }
        public bool IsPrivate { get => isPrivate; set => isPrivate = value; }
    }
}
