using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentCsvViewer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;

            switch (label.Name)
            {
                case "lbName":
                    viewModel.SortStudents("name");
                    break;
                case "lbAge":
                    viewModel.SortStudents("age");
                    break;
                case "lbKorean":
                case "lbEnglish":
                case "lbMath":
                case "lbScience":
                    SubjectWindow subWindow = new SubjectWindow(label.Content.ToString(), viewModel.Subjects.ToList());
                    subWindow.Show();
                    break;
            }
        }

    }
}
