using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    interface IUniversity
    {
        double CalculateLecturerWorkingHours(Lecturer lecturer);
        decimal CalculateLecturePrice(Lecture lecture);
        decimal CalculateLecturerSalary(Lecturer lecturer);
    }
}
