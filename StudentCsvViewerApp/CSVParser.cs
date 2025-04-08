using System.IO;
using System.Text;

namespace StudentCsvViewer
{
    public class CSVParser
    {
        public StringBuilder builder = new StringBuilder();
        public Students[] students = new Students[100]; // 넉넉하게 설정
        public int studentCount = 0;

        public Subject[] subjects = new Subject[10];
        public int subjectCount = 0;

        public void CSVParser_Students(string fileName)
        {
            studentCount = 0;
            builder.Clear();

            StreamReader sr = new StreamReader(fileName, Encoding.Default);
            sr.ReadLine(); // 헤더 제거

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] fields = line.Split(',');

                if (fields.Length < 4)
                    continue;

                Students s = new Students(fields);
                students[studentCount++] = s;

                string text = $"{s.name}\t{s.age}\t{s.grade.Replace(";", "\t")}\t{s.major}\n";
                builder.Append(text);
            }
            sr.Close();
        }

        public void CSVParser_Subject(string fileName)
        {
            subjectCount = 0;

            StreamReader sr = new StreamReader(fileName, Encoding.Default);
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] fields = line.Split(',');

                if (fields.Length < 3)
                    continue;

                subjects[subjectCount++] = new Subject(fields);
            }
            sr.Close();
        }
    }
}
