using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Lecturer> lecturersList = new List<Lecturer>
            {
                new Lecturer("Thomas", "Math", true, 6),
                new Lecturer("Julia","Literature", true, 8),
                new Lecturer("Gretchen", "Math", false, 10),
                new Lecturer("John", "Music", false, 1)
            };

            List<Lecture> lecturesList = new List<Lecture>
            {
                new Lecture("Math", 1.5, false, false),
                new Lecture("Literature", 0.75, false, true),
                new Lecture("Music", 1.5, true, false)
            };

            Console.WriteLine("You would like to enter:");
            Console.WriteLine("1 - ordinary university\r\n2 - prestigious university\r\n3 - university of arts\r\n4 - online university");
            Console.WriteLine("\r\nEnter your answer:");

            switch (GetIntInput(4))
            {
                case 1:
                    ServeOrdinaryUniversityStudent(lecturersList, lecturesList);
                    break;
                case 2:
                    ServePrestigiousUniversityStudent(lecturersList, lecturesList);
                    break;
                case 3:
                    ServeArtsUniversityStudent(lecturersList, lecturesList);
                    break;
                case 4:
                    ServeOnlineUniversityStudent(lecturersList, lecturesList);
                    break;
                default:
                    Console.WriteLine("Contact system administrator.");
                    break;
            }

        }

        static bool AskIfExit()
        {
            Console.WriteLine("\r\nWould you like to exit the program?");
            Console.WriteLine("1 - yes\r\n2 - no");
            Console.WriteLine("Enter your answer:");
            return GetIntInput(2) == 1;
        }

        static int GetIntInput(int bound)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input > bound || input < 1)
            {
                Console.WriteLine("\r\nYou've entered an invalid number. Try again:");
            }
            return input;
        }

        static void ServeOnlineUniversityStudent(List<Lecturer> lecturersList, List<Lecture> lecturesList)
        {
            Console.WriteLine("\r\nWelcome to Online University!\r\n");
            IUniversity university = new OnlineUniversity(new OrdinaryUniversity());

            while (true)
            {
                Lecture lecture = lecturesList[AskWhichOneToGet(lecturesList, "lecture") - 1];
                var filteredLecturersList = from lect in lecturersList
                                            where lect.Specialty.Equals(lecture.Subject)
                                            select lect;
                Lecturer lecturer = lecturersList[AskWhichOneToGet(filteredLecturersList.ToList(), "lecturer") - 1];
                Console.WriteLine("Lecture price: " + university.CalculateLecturePrice(lecturer, lecture) + " Eur");
                Console.WriteLine("Lecturers time dedicated to the lecture: " + university.CalculateOverallLecturerTimeDedicatedToLecture(lecturer, lecture) + " h");

                OnlineUniversity onlineUniversity = UniversityDecorator.GetUniversityDecorator<OnlineUniversity>(university);
                if (!(onlineUniversity is null))
                {
                    Console.WriteLine("Lecture price to download: " + onlineUniversity.DownloadLecture(lecture) + " Eur");
                    
                }
                else
                {
                    Console.WriteLine("Invalid decorator.");
                }

                if (AskIfExit())
                {
                    break;
                }
            }
        }
        static void ServeOrdinaryUniversityStudent(List<Lecturer> lecturersList, List<Lecture> lecturesList)
        {
            Console.WriteLine("\r\nWelcome to our University!\r\n");
            IUniversity university = new OrdinaryUniversity();

            DefaultStudentServing(university, lecturersList, lecturesList);
        }

        static void ServePrestigiousUniversityStudent(List<Lecturer> lecturersList, List<Lecture> lecturesList)
        {
            Console.WriteLine("\r\nWelcome to our prestigious University!\r\n");
            IUniversity university = new PrestigiousUniversity(new OrdinaryUniversity());

            while (true)
            {
                Lecture lecture = lecturesList[AskWhichOneToGet(lecturesList, "lecture") - 1];
                var filteredLecturersList = from lect in lecturersList
                                            where lect.Specialty.Equals(lecture.Subject)
                                            select lect;
                Lecturer lecturer = lecturersList[AskWhichOneToGet(filteredLecturersList.ToList(), "lecturer") - 1];
                decimal lecturePrice = university.CalculateLecturePrice(lecturer, lecture);
                if(lecturePrice > 0)
                {
                    Console.WriteLine("Lecture price: " + university.CalculateLecturePrice(lecturer, lecture) + " Eur");
                    Console.WriteLine("Lecturers time dedicated to the lecture: " + university.CalculateOverallLecturerTimeDedicatedToLecture(lecturer, lecture) + " h");

                    PrestigiousUniversity prestigiousUniversity = UniversityDecorator.GetUniversityDecorator<PrestigiousUniversity>(university);
                    if (!(prestigiousUniversity is null))
                    {
                        Console.WriteLine("Consultation before a competition price: " + prestigiousUniversity.CalculateConsultationBeforeCompetitionPrice(lecturer, lecture) + " Eur");

                    }
                    else
                    {
                        Console.WriteLine("Invalid decorator.");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, the lecturer is not suitable.");
                }

                if (AskIfExit())
                {
                    break;
                }
            }
        }

        static void ServeArtsUniversityStudent(List<Lecturer> lecturersList, List<Lecture> lecturesList)
        {
            Console.WriteLine("\r\nWelcome to University of Arts!\r\n");
            IUniversity university = new ArtsUniversity(new OrdinaryUniversity());

            DefaultStudentServing(university, lecturersList, lecturesList);
        }

        static void DefaultStudentServing(IUniversity university, List<Lecturer> lecturersList, List<Lecture> lecturesList)
        {
            while (true)
            {
                Lecture lecture = lecturesList[AskWhichOneToGet(lecturesList, "lecture") - 1];
                var filteredLecturersList = from lect in lecturersList
                                            where lect.Specialty.Equals(lecture.Subject)
                                            select lect;
                Lecturer lecturer = lecturersList[AskWhichOneToGet(filteredLecturersList.ToList(), "lecturer") - 1];
                Console.WriteLine("Lecture price: " + university.CalculateLecturePrice(lecturer, lecture) + " Eur");
                Console.WriteLine("Lecturers time dedicated to the lecture: " + university.CalculateOverallLecturerTimeDedicatedToLecture(lecturer, lecture) + " h");

                if (AskIfExit())
                {
                    break;
                }
            }
        }

        static int AskWhichOneToGet<T>(List<T> list, String requiredObject)
        {
            Console.WriteLine("\r\nWe have the following " + requiredObject + "s:");
            int count = 1;
            foreach (var obj in list)
            {
                Console.WriteLine(count.ToString() + ". " + obj.ToString());
                count++;
            }

            Console.WriteLine("\r\nEnter the number of the " + requiredObject + " you would like:");
            return GetIntInput(list.Count);
        }


    }
}
