using System;
using System.Collections;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using XYZ_university;

public class Student
{
	[JsonPropertyName("fname")]
	[XmlElement(elementName: "fname")]
	public string name { get; set; }

	[JsonPropertyName("lname")]
	[XmlElement(elementName: "lname")]
	public string surname { get; set; }


	public XYZ_university.Course course;
	public string type { get; set; }

	[JsonPropertyName("indexNumber")]
	[XmlAttribute(attributeName: "indexNumber")]
	public string id { get; set; }

	[JsonPropertyName("bdate")]
	[XmlElement(elementName: "birthdate")]
	public string birthdate { get; set; }

	[XmlElement(elementName: "email")]
	[JsonPropertyName("email")]
	public string email { get; set; }

	[JsonPropertyName("mothersName")]
	[XmlElement(elementName: "mothersName")]
	public string some_name1 { get; set; }

	[XmlElement(elementName: "fathersName")]
	[JsonPropertyName("fathersName")]
	public string some_name2 { get; set; }


	public Student(string name, string surname, string course, string type, string id, string birthdate, string email, string some_name1, string some_name2)
	{
		this.name = name;
		this.surname = surname;
		this.course = new XYZ_university.Course(course, type);
		this.id = id;
		this.birthdate = birthdate;
		this.email = email;
		this.some_name1 = some_name1;
		this.some_name2 = some_name2;

		


	}
	public Course GetCourse()
	{
		return this.course;
	}
}
