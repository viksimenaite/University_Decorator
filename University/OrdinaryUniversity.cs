using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    class OrdinaryUniversity : IUniversity
    {
        private readonly decimal hourlyRate = 20.0m;
        public decimal CalculateLecturePrice(Lecture lecture)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateLecturerSalary(Lecturer lecturer)
        {
            throw new NotImplementedException();
        }

        public double CalculateLecturerWorkingHours(Lecturer lecturer)
        {
            throw new NotImplementedException();
        }
    }
}
