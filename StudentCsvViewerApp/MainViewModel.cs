using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace StudentCsvViewer
{
    public class MainViewModel :INotifyPropertyChanged
    {
        private ObservableCollection<Students> _students;
        public ObservableCollection<Students> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public MainViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            CSVParser parser = new CSVParser();
            parser.LoadStudents("Students.csv");
            parser.LoadSubject("Subject.csv");

            Students = new ObservableCollection<Students>(parser.Students);
            Subjects = parser.Subjects;
        }

        public void SortStudents(string key)
        {
            switch (key)
            {
                case "name":
                    Students = new ObservableCollection<Students>(Students.OrderBy(s => s.name));
                    break;
                case "age":
                    Students = new ObservableCollection<Students>(Students.OrderBy(s => s.age));
                    break;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
