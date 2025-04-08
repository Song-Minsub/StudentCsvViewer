using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCsvViewer
{
    public class Subject
    {
        public string name { get; set; }
        public string imageFile { get; set; }
        public string desc { get; set; }

        public Subject(string[] fields)
        {
            name = fields[0];
            imageFile = fields[1];
            desc = fields[2];
        }
    }
}
