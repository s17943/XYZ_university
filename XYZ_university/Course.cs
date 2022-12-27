using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace XYZ_university
{

    public class Course
    {
        [JsonPropertyName("name")]
        [XmlElement(elementName: "name")]
        public string name { set; get; }

        [JsonPropertyName("mode")]
        [XmlElement(elementName: "mode")]
        public string mode { set; get; }

        /*[JsonPropertyName("numberOfStudents")]
        public int count { set; get; }*/

        public Course(String course, String type)
        {
            this.SetName(course);
            this.SetMode(type);
        }


        public void SetName(string Name)
        {
            if (Name == null || string.IsNullOrEmpty(Name))
            {
                Name = "invalid";
            }
            this.name = Name;
        }

        public string GetName()
        {
            return this.name;
            
        }

        public void SetMode(string Mode)
        {
            this.mode = Mode;
        }

        public string GetMode()
        {
            
                return this.mode;
            
        }


    }
}