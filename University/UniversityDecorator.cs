using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    abstract class UniversityDecorator : IUniversity
    {
        private readonly IUniversity university;

        public UniversityDecorator(IUniversity university)
        {
            this.university = university;
        }

        public virtual decimal CalculateLecturePrice(Lecturer lecturer, Lecture lecture)
        {
            return university.CalculateLecturePrice(lecturer, lecture);
        }

        public virtual double CalculateOverallLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture)
        {
            return university.CalculateOverallLecturerTimeDedicatedToLecture(lecturer, lecture);
        }

        public static T GetUniversityDecorator<T>(IUniversity uni) where T : UniversityDecorator
        {
            try
            {
                if(uni is T)
                {
                    return (T) uni;
                }
                else
                {
                    T decorator = GetUniversityDecorator<T>(((UniversityDecorator)uni).university);
                    return decorator;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
