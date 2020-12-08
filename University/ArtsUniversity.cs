using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class ArtsUniversity : UniversityDecorator
    {
        private readonly decimal materialsPrice = 15.5m;
        private readonly double overallLectureTimeCoefficient = 1.5;

        public ArtsUniversity(IUniversity university) : base(university)
        {
        }
        public override decimal CalculateLecturePrice(Lecturer lecturer, Lecture lecture)
        {
            if (lecture.IsVideo)
            {
                return base.CalculateLecturePrice(lecturer, lecture);
            }
            else
            {
                return base.CalculateLecturePrice(lecturer, lecture) + materialsPrice;
            }
            
        }

        public override double CalculateOverallLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture)
        {
            return base.CalculateOverallLecturerTimeDedicatedToLecture(lecturer, lecture) * overallLectureTimeCoefficient;
        }
    }
}
