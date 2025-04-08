using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace StudentCsvViewer
{
    /// <summary>
    /// SubjectWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubjectWindow : Window
    {
        string selectedName;
        string basePath;
        List<Subject> Subjects;
        public SubjectWindow(string subject,List<Subject> Subjects)
        {
            InitializeComponent();
            this.Subjects = Subjects;
            selectedName = subject;
            basePath = $"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Subjects.Count; i++) {
                Subject sub = Subjects[i];

                if (sub.name == selectedName)
                {
                    Tb_Subject.Text = sub.name;
                    Tb_Desc.Text = sub.desc;

                    if (File.Exists(basePath + sub.imageFile))
                    {
                        Tb_Photo.Source = new BitmapImage(new Uri(basePath + sub.imageFile, UriKind.Absolute));
                    }
                }
            }
        }
    }
}
