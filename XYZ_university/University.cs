using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;
using XYZ_university;

public class University
    {
        [JsonPropertyName("author")]
        public string author { get; set; }
        [JsonPropertyName("createdAt")]    
        public DateTime createdAt { get; set; }
        [JsonPropertyName("students")]
        public List<Student> student_list { get; set; }
        [JsonPropertyName("activeStudies")]
        public Dictionary<string, int> active_studies { get; set; }

    public University(List<Student> students)
        {
        this.active_studies = new Dictionary<string, int>();
        this.author = "Jan Lisowski";
        this.createdAt = DateTime.Now;
        setList(students);
        setCourses(students);
        
            
        }

        public void setList(List<Student> studentList)
        {
            this.student_list = studentList;
        }
        public void setCourses(List<Student> studentList)
        {
            
            foreach(Student student in studentList)
        {
            
            if (!active_studies.ContainsKey(student.course.name))
            {
               active_studies.Add(student.course.name, 1);
            }
            if (active_studies.ContainsKey(student.course.name))
            {
                active_studies[student.course.name] +=1;
            }



        }
        
    }




}
