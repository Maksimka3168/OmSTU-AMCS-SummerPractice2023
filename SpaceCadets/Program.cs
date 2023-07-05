﻿using Newtonsoft.Json;

namespace SpaceCadets
{
    public class Student
    {
        public string Name = "";
        public string Group = "";
        public string Discipline = "";
        public double Mark = 0;
    }

    public class InputFile
    {
        public string taskName = "";
        public List<Student> data = new List<Student>();
    }

    public class Student_with_Highest_GPA
        {
            public string Cadet = "";
            public double GPA = 0;
        }

    public class Best_Group_By_Discipline
    {
        public string Discipline = "";
        public string Group = "";
        public double GPA = 0;
    }

    public class Gpa_By_Discipline
    {
        public string Discipline = "";
        public double GPA = 0;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string pathInput = args[0];
            string pathOutput = args[1];
            string fileAllText = File.ReadAllText(pathInput);
            InputFile file = JsonConvert.DeserializeObject<InputFile>(fileAllText) ?? new InputFile();
            List<Student> students = file.data.ToList();
            switch (file.taskName)
            {
                case "GetStudentsWithHighestGPA":
                    WriteStudentsMaxAverageScore(students, pathOutput);
                    break;
                case "CalculateGPAByDiscipline":
                    WriteAverageScoreDescipline(students, pathOutput);
                    break;
                case "GetBestGroupsByDiscipline":
                    WriteGroupBestAverageScore(students, pathOutput);
                    break;
            }
        }

        static void WriteStudentsMaxAverageScore(List<Student> students, string output_path)
        {
            var grouped_students_name = students.GroupBy(student => student.Name);

            var grouped_students_name_gpa = grouped_students_name.Select(group => new Student_with_Highest_GPA
            {
                Cadet = group.Key,
                GPA = Math.Round(group.Average(student => student.Mark), 2)
            });
            var students_gpa_list = grouped_students_name_gpa.ToList();

            double max_gpa = students_gpa_list.Max(s => s.GPA);

            var students_response = students_gpa_list.Where(student => student.GPA == max_gpa)
                .Select(student => student).ToList();

            Dictionary<string, List<Student_with_Highest_GPA>> rez = new Dictionary<string, List<Student_with_Highest_GPA>> 
            {
                { "Response", students_response }
            };

            File.WriteAllText(output_path, JsonConvert.SerializeObject(rez, Formatting.Indented));
        }

        static void WriteAverageScoreDescipline(List<Student> students, string output_path)
        {
            var grouped_students_discipline = students.GroupBy(student => student.Discipline);

            var grouped_students_discipline_gpa = grouped_students_discipline.Select(discipline => new Gpa_By_Discipline
            {
                Discipline = discipline.Key,
                GPA = Math.Round(discipline.Average(student => student.Mark), 2)
            });

            var gpa_dictionary = grouped_students_discipline_gpa.ToDictionary(p => p.Discipline, p => p.GPA);

            var discipline_response = gpa_dictionary
                .Select(element => new Dictionary<string, double> { { element.Key, element.Value } })
                .ToList();

            Dictionary<string, List<Dictionary<string, double>>> rez = new Dictionary<string, List<Dictionary<string, double>>> 
            {
                { "Response", discipline_response }
            };

            File.WriteAllText(output_path, JsonConvert.SerializeObject(rez, Formatting.Indented));
        }

        static void WriteGroupBestAverageScore(List<Student> students, string output_path)
        {
            var grouped_students = students.GroupBy(student => new 
            {
                Discipline = student.Discipline,
                Group = student.Group
            });

            var groups_with_gpa_objects = grouped_students.Select(group => new Best_Group_By_Discipline
            {
                Discipline = group.Key.Discipline,
                Group = group.Key.Group,
                GPA = Math.Round(group.Average(student => student.Mark), 2)
            });

            var groups_with_gpa_list = groups_with_gpa_objects.ToList();
            
            double max_gpa = groups_with_gpa_list.Max(group => group.GPA);

            var filtered_groups = groups_with_gpa_list.Where(group => group.GPA == max_gpa);

            var response_group = filtered_groups.Select(group => group).ToList();
                
            Dictionary<string, List<Best_Group_By_Discipline>> rez = new Dictionary<string, List<Best_Group_By_Discipline>>
            {
                { "Response", response_group }
            };

            File.WriteAllText(output_path, JsonConvert.SerializeObject(rez, Formatting.Indented));
        }
    }
}
