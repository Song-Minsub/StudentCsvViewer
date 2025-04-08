using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Documents;

namespace StudentCsvViewer
{
    public class CSVParser
    {
        public List<Students> Students { get; private set; } = new List<Students>();
        public List<Subject> Subjects { get; private set; } = new List<Subject>();


        public void LoadStudents(string fileName)
        {
            var lines = File.ReadAllLines(fileName, Encoding.Default);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(new char[] { ',', ';' });

                Students.Add(new Students
                {
                    name = fields[0],
                    age = int.Parse(fields[1]),
                    koreanScore = int.Parse(fields[2]),
                    englishScore = int.Parse(fields[3]),
                    mathScore = int.Parse(fields[4]),
                    scienceScore = int.Parse(fields[5]),
                    major = fields[6]
                });
            }
        }

        public void LoadSubject(string fileName)
        {
            var lines = File.ReadAllLines(fileName, Encoding.Default);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(new char[] { ',', ';' });

                Subjects.Add(new Subject
                {
                    name = fields[0],
                    imageFile = fields[1],
                    desc = fields[2]
                });
            }
        }
    }
}
