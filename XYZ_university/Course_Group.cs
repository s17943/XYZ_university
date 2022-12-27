using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ_university
{
    public class Course_Group
    {
        int count { get; set; }
        string name { get; set; }

        public Course_Group(string name, int count)
        {
            this.name = name;
            this.count = count + 1; 
        }

    }

    


}
