using Homework_Lists_Dictionaries.ProgramHeart.Core.Interfaces;
using System;

namespace Homework_Lists_Dictionaries.Programs.Collections.Directionaries
{
    internal class DicStudentsNotes : IRunnable
    {
        public void Run()
        {
            List<string> badStudents = NoteCalculate(6);
            if (badStudents.Count > 0)
            {
                Console.WriteLine("Bad students are:");
                foreach (string student in badStudents)
                {
                    Console.WriteLine(student);
                }
            }
        }
        private static List<string> NoteCalculate(int minEnough)
        {
            List<string> notEnough = new();

            foreach (var item in studentsNotes)
            {
                if (item.Value < minEnough)
                {
                    notEnough.Add(item.Key);
                }
            }

            return notEnough;
        }
        private static readonly Dictionary<string, int> studentsNotes = new()
        {
            { "Alex", 12 },
            { "Anton", 1},
            { "Einstein", 0 },
            { "Tesla", 10 }
        };
    }
}
