using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class Lecture
    {
        private string subject;
        private double duration;
        private bool isPrivate;
        private bool isVideo; // whether it is on online lecture
        private decimal basePrice;

        public Lecture(string subject, double duration, bool isPrivate, bool isVideo)
        {
            this.subject = subject;
            this.duration = duration;
            this.isPrivate = isPrivate;
            this.isVideo = isVideo;
            this.basePrice = 12.5m;

        }

        public string Subject { get => subject; set => subject = value; }
        public double Duration { get => duration; set => duration = value; }
        public bool IsPrivate { get => isPrivate; set => isPrivate = value; }
        public bool IsVideo { get => isVideo; set => isVideo = value; }
        public decimal BasePrice { get => basePrice; set => basePrice = value; }
    }
}
