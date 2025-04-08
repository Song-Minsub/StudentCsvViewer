using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudentCsvViewer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        CSVParser parser = new CSVParser();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            parser.CSVParser_Students("Students.csv");
            tb_text.Text = parser.builder.ToString();
        }

        private void Label_MouseLeftButtonDown_Name(object sender, MouseButtonEventArgs e)
        {
            SortStudents("name");
        }

        private void Label_MouseLeftButtonDown_Age(object sender, MouseButtonEventArgs e)
        {
            SortStudents("age");
        }

        private void Label_MouseLeftButtonDown_Korean(object sender, MouseButtonEventArgs e)
        {
            SubjectWindow subWindow = new SubjectWindow("국어", parser);
            subWindow.Show();
        }

        private void Label_MouseLeftButtonDown_English(object sender, MouseButtonEventArgs e)
        {
            SubjectWindow subWindow = new SubjectWindow("영어", parser);
            subWindow.Show();
        }
        private void Label_MouseLeftButtonDown_Math(object sender, MouseButtonEventArgs e)
        {
            SubjectWindow subWindow = new SubjectWindow("수학", parser);
            subWindow.Show();
        }
        private void Label_MouseLeftButtonDown_Science(object sender, MouseButtonEventArgs e)
        {
            SubjectWindow subWindow = new SubjectWindow("과학", parser);
            subWindow.Show();
        }

        private void SortStudents(string sortBy)
        {
            for (int i = 0; i < parser.studentCount - 1; i++)
            {
                for (int j = i + 1; j < parser.studentCount; j++)
                {
                    bool swap = false;

                    if (sortBy == "name")
                        swap = string.Compare(parser.students[i].name, parser.students[j].name) > 0;
                    else if (sortBy == "age")
                        swap = int.Parse(parser.students[i].age) > int.Parse(parser.students[j].age);

                    if (swap)
                    {
                        Students temp = parser.students[i];
                        parser.students[i] = parser.students[j];
                        parser.students[j] = temp;
                    }
                }
            }

            UpdateTextBlock();
        }

        private void UpdateTextBlock()
        {
            parser.builder.Clear();
            for (int i = 0; i < parser.studentCount; i++)
            {
                Students s = parser.students[i];
                string text = $"{s.name}\t{s.age}\t{s.grade.Replace(";", "\t")}\t{s.major}\n";
                parser.builder.Append(text);
            }

            tb_text.Text = parser.builder.ToString();
        }
    }
}
