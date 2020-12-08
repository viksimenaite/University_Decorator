using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class PrestigiousUniversity : UniversityDecorator
    {
        private readonly double afterHoursConsultationDuration = 0.5;
        private readonly decimal consultationPriceCoefficient = 2.5m;
        private readonly decimal lecturePriceCoefficient = 1.5m;
        private readonly int requiredYearsOfExperience = 5;
        public PrestigiousUniversity(IUniversity university) : base(university)
        {
        }

        public override decimal CalculateLecturePrice(Lecturer lecturer, Lecture lecture)
        {
            if (IsLecturerSuitable(lecturer))
            {
                return base.CalculateLecturePrice(lecturer, lecture) * lecturePriceCoefficient;
            }
            else
            {
                return -1;
            }
        }

        public override double CalculateOverallLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture)
        {
            return base.CalculateOverallLecturerTimeDedicatedToLecture(lecturer, lecture) + afterHoursConsultationDuration;
        }

        public decimal CalculateConsultationBeforeCompetitionPrice(Lecturer lecturer, Lecture lecture)
        {
            if (IsLecturerSuitable(lecturer))
            {
                if (lecture.IsPrivate)
                {
                    return base.CalculateLecturePrice(lecturer, lecture) * consultationPriceCoefficient;
                }
                else
                {
                    return base.CalculateLecturePrice(lecturer, lecture);
                }
            }
            else
            {
                return -1;
            }

        }

        private bool IsLecturerSuitable(Lecturer lecturer)
        {
            return lecturer.HasPHD && lecturer.Experience > requiredYearsOfExperience;
        }

    }
}