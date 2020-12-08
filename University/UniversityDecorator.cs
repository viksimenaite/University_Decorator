using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    abstract class UniversityDecorator : IUniversity
    {
        private readonly IUniversity university;
        protected UniversityDecorator(IUniversity university)
        {
            this.university = university;
        }

        public virtual decimal CalculateLecturePrice(Lecture lecture)
        {
            return university.CalculateLecturePrice(lecture);
        }

        public virtual decimal CalculateLecturerSalary(Lecturer lecturer)
        {
            return university.CalculateLecturerSalary(lecturer);
        }

        public virtual double CalculateLecturerWorkingHours(Lecturer lecturer)
        {
            return university.CalculateLecturerWorkingHours(lecturer);
        }
    }
}
