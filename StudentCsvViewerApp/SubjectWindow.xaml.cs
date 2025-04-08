using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Media.Imaging;

namespace StudentCsvViewer
{
    /// <summary>
    /// SubjectWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubjectWindow : Window
    {
        string subjectName;
        CSVParser parser;
        string basePath;
        public SubjectWindow(string subject, CSVParser parserInstance)
        {
            InitializeComponent();
            subjectName = subject;
            parser = parserInstance;
            basePath = $"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            parser.CSVParser_Subject("Subject.csv");

            for (int i = 0; i < parser.subjectCount; i++)
            {
                Subject sub = parser.subjects[i];
                if (sub.name == subjectName)
                {
                    Tb_Subject.Text = sub.name;
                    Tb_Desc.Text = sub.desc;

                    if (File.Exists(basePath + sub.imageFile))
                    {
                        Tb_Photo.Source = new BitmapImage(new Uri(basePath + sub.imageFile, UriKind.Absolute));
                    }
                    break;
                }
            }
        }
    }
}
