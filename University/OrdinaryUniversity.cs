using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class OrdinaryUniversity : IUniversity
    {
        private readonly decimal privateLecturePriceCoefficient = 2m;
        private readonly decimal lerturerWithPHDLecturePriceCoefficient = 1.2m;
        private readonly decimal lerturerWithExperienceLecturePriceCoefficient = 1.3m;
        private readonly int requiredYearsOfExperience = 5;
        private readonly double lerturerWithExperiencePreparationTimeCoefficient = 1.5;
        private readonly double lerturerWithoutExperiencePreparationTimeCoefficient = 2.5;
        public decimal CalculateLecturePrice(Lecturer lecturer, Lecture lecture)
        {
            decimal price = lecture.BasePrice;
            if (lecture.IsPrivate)
            {
                price *= privateLecturePriceCoefficient;
            }
            if (lecturer.HasPHD)
            {
                price *= lerturerWithPHDLecturePriceCoefficient;
            }
            if (lecturer.Experience > 2)
            {
                price *= lerturerWithExperienceLecturePriceCoefficient;
            }
            return price;
        }

        public double CalculateOverallLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture) //include time to prepare for the lecture
        {
            if (lecturer.Experience > requiredYearsOfExperience)
            {
                return lecture.Duration * lerturerWithExperiencePreparationTimeCoefficient;
            }
            else
            {
                return lecture.Duration * lerturerWithoutExperiencePreparationTimeCoefficient;
            }
        }
    }
}
