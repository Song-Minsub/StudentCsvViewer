namespace StudentCsvViewer
{
    public class Students
    {
        public string name { get; set; }
        public string age { get; set; }
        public string grade { get; set; }
        public string major { get; set; }

        public Students(string[] args)
        {
            name = args[0];
            age = args[1];
            grade = args[2];
            major = args[3];
        }
    }
}

