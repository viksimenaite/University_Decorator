using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class OnlineUniversity : UniversityDecorator
    {
        private readonly decimal downloadCoefficient = 2.3m;
        public OnlineUniversity(IUniversity university) : base(university)
        {
        }
        public override double CalculateOverallLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture)
        {
            return 0;
        }

        public decimal DownloadLecture(Lecture lecture)
        {
            return lecture.BasePrice * downloadCoefficient;
        }
    }
}
