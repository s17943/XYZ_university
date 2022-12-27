using System;
using System.Text.Json;
using System.Xml.Serialization;
using XYZ_university;

namespace XYZExporter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!" + " " + args[0]);

            string input_file_path = args[0];
            string log_file_path = args[1];
            string format = args[2];
            int proper_column_count = 9;
            List<Student> correct_student_entries = new List<Student>();
            List<Student> incorrect_student_entries = new List<Student>();
            using (StreamWriter streamWriter = File.CreateText(log_file_path));
            

            if (input_file_path == null || log_file_path == null || format == null)
            {
                throw new Exception("Invalid argument exception, argument cannot be null");
            }
            if (args.Length < 3)
            {
                using (StreamWriter streamWriter = File.AppendText(log_file_path))
                {
                    streamWriter.WriteLine("Insifficient number of arguments.");
                };
                throw new Exception("Invalid argument exception, one or more arguments are missing");
            }
            

            if (!File.Exists(log_file_path))
            {
                using (StreamWriter streamWriter = File.AppendText(log_file_path))
                {
                    streamWriter.WriteLine("New file created, no previous log files existed prior to this run");
                };
            }
            else using (StreamWriter streamWriter = File.AppendText(log_file_path))
                {
                    streamWriter.WriteLine("File has been overwritten");
                }; ;


            if (!File.Exists(input_file_path))
            {
                using (StreamWriter streamWriter = File.AppendText(log_file_path))
                {
                    streamWriter.WriteLine("Input file is missing");
                };
                throw new FileNotFoundException("File not found");

            }
            else
            {
                Console.WriteLine("Input file found, accessing data...");
            }

            var file = new FileInfo(input_file_path);
            using (var file_stream = new StreamReader(file.OpenRead())) { 
            string line = null;

            while ((line = file_stream.ReadLine()) != null)
            {
                    bool test = true;
                    string[] columns = line.Split(',');
                    foreach (string text in columns)
                    {
                        if (string.IsNullOrWhiteSpace(text)){
                            test = false;
                        }
                    }

                    if (columns.Length == proper_column_count && test)
                    {
                        Student temp_valid_student = new Student(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5], columns[6], columns[7], columns[8]);
                        bool already_on_list = false;

                        foreach(Student s in correct_student_entries)
                        {
                            bool test1 = false;
                            bool test2 = false; 
                            bool test3 = false;
                            
                            if(correct_student_entries.Any(s => s.id.Equals(temp_valid_student.id)))
                            {
                                test1 = true;
                            }
                            if (correct_student_entries.Any(s => s.name.Equals(temp_valid_student.name)))
                            {
                                test2 = true;
                            }
                            if (correct_student_entries.Any(s => s.surname.Equals(temp_valid_student.surname)))
                            {
                                test3 = true;
                            }

                            if(test1 && test2 && test3)
                            {
                                already_on_list = true; 
                            } 
                            

                        }

                        if (!already_on_list)
                        {
                            correct_student_entries.Add(temp_valid_student);
                        }


                    }
                    else
                    {
                        var temp_invalid_student = new Student(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5], columns[6], columns[7], columns[8]);
                        incorrect_student_entries.Add((temp_invalid_student));

                    }
                   


                }


                Console.WriteLine("---------------------------");

                

                /*foreach(Student item in correct_student_entries)
                {
                    Console.WriteLine("correct entry: " + item.id + " " + item.name + " " + item.surname);
                    using (StreamWriter streamWriter = File.AppendText(log_file_path))
                    {
                        streamWriter.WriteLine("Correct entry found for student with following credentials: name: " + item.name + ", surname: " + item.surname + " id: " + item.id);
                    };
                    */
                //}
                foreach (Student item in incorrect_student_entries)
                {
                    Console.WriteLine("incorrect entry: " + item.id + " " + item.name + " " + item.surname);
                    using (StreamWriter streamWriter = File.AppendText(log_file_path))
                    {
                        streamWriter.WriteLine("Incorrect entry found for a student with the following credentials: name: " + item.name + ", surname: " + item.surname + " id: " + item.id);
                    };

                }

                foreach (Student item in correct_student_entries)
                    Console.WriteLine("Correct entries: " + item.name + ", surname: " + item.surname + " id: " + item.id);
            



                string author = "Jan Lisowski";
                University university = new University(correct_student_entries);

                switch (format)
                {
                    case "xml":
                        XmlSerializer writer = new XmlSerializer(typeof(University));
                        FileStream my_file = File.Create("sample.xml");
                        writer.Serialize(my_file, university);
                        break;
                    case "json":
                        Console.WriteLine("generating json");
                        var jsonString = JsonSerializer.Serialize<University>(university);
                        Console.WriteLine(jsonString);
                        File.WriteAllText("example.json", jsonString);
                        break;
                    default:
                        using(StreamWriter streamWriter = File.AppendText(log_file_path))
                            streamWriter.WriteLine("Invalid format name");
                        break;

                }












                Console.WriteLine("Source: " + input_file_path + " Write to: " + log_file_path + " Data format:  " + format);



            }
        }
    }
}
