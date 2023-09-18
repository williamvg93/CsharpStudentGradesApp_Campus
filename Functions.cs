using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using studentGrades.entities;


namespace studentGrades
{
    public class Functions
    {
        public static byte MainMenu(){
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("{0,40}", "-------------------------");
            Console.WriteLine("{0,40}", "----- Student Grades ----");
            Console.WriteLine("{0,40}", "-------------------------");
            Console.WriteLine();
            Console.WriteLine("{0,30}", " Main Menú \n");
            Console.WriteLine("{0,3}", " 1) -> Manage Student");
            Console.WriteLine("{0,3}", " 2) -> Manage Student Grades");
            Console.WriteLine("{0,3}", " 3) -> Generate Grade Report");
            Console.WriteLine("{0,3}", " 4) -> Exit App \n");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Main Menu Option: "));
        }
        public static byte StudentMenu(){
            Console.Clear();
            Console.WriteLine("{0,30}", " Manage Student \n");
            Console.WriteLine("{0,3}", " 1) -> Add Student");
            Console.WriteLine("{0,3}", " 2) -> Update Student");
            Console.WriteLine("{0,3}", " 3) -> Delete Student");
            Console.WriteLine("{0,3}", " 4) -> View Student List");
            Console.WriteLine("{0,3}", " 5) -> Back to Main Menu\n");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Student Menu Option: "));
        }

        public static byte EditMenu(){
            Console.Clear();
            Console.WriteLine("{0,30}", " Manage Student \n");
            Console.WriteLine("{0,3}", " 1) -> Add Student");
            Console.WriteLine("{0,3}", " 2) -> Delete Student");
            Console.WriteLine("{0,3}", " 3) -> Update Student");
            Console.WriteLine("{0,3}", " 4) -> View Student List");
            Console.WriteLine("{0,3}", " 5) -> Back to Main Menu\n");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Student Menu Option: "));
        }

        public static byte GradetMenu(){
            Console.Clear();
            Console.WriteLine("{0,30}", " Manage Student Grades \n");
            Console.WriteLine("{0,3}", " 1) -> Manage Quiz Grade");
            Console.WriteLine("{0,3}", " 2) -> Manage Tasks Grade");
            Console.WriteLine("{0,3}", " 3) -> Manage Exam Garde");
            Console.WriteLine("{0,3}", " 4) -> Back to Main Menu\n");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Grade Menu Option: "));
        }

        public static byte QuizGradMen(){
            Console.Clear();
            Console.WriteLine("{0,30}", " Manage Quiz Grades \n");
            Console.WriteLine("{0,3}", " 1) -> Add Quiz Grade");
            Console.WriteLine("{0,3}", " 2) -> Edit Quiz Grade");
            Console.WriteLine("{0,3}", " 3) -> Delete Quiz Garde");
            Console.WriteLine("{0,3}", " 4) -> Back to Student Grade Menu\n");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Grade Quiz Option: "));
        }
        public static byte TaskGradMen(){
            Console.Clear();
            Console.WriteLine("{0,30}", " Manage Task Grades \n");
            Console.WriteLine("{0,3}", " 1) -> Add Task Grade");
            Console.WriteLine("{0,3}", " 2) -> Edit Task Grade");
            Console.WriteLine("{0,3}", " 3) -> Delete Task Garde");
            Console.WriteLine("{0,3}", " 4) -> Back to Student Grade Menu\n");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Grade Task Option: "));
        }
        public static byte ExamGradMen(){
            Console.Clear();
            Console.WriteLine("{0,30}", " Manage Exam Grades \n");
            Console.WriteLine("{0,3}", " 1) -> Add Exam Grade");
            Console.WriteLine("{0,3}", " 2) -> Edit Exam Grade");
            Console.WriteLine("{0,3}", " 3) -> Delete Exam Garde");
            Console.WriteLine("{0,3}", " 4) -> Back to Student Grade Menu\n");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Grade Exam Option: "));
        }
            public static byte GradeReportMenu(){
            Console.Clear();
            Console.WriteLine("{0,30}", "Student Grade Report \n");
            Console.WriteLine("{0,3}", " 1) -> View Student List");
            Console.WriteLine("{0,3}", " 2) -> Generate Student Grade Report");
            Console.WriteLine("{0,3}", " 3) -> Generate Final Student Grade Report");
            Console.WriteLine("{0,3}", " 4) -> Back to Main Menu\n");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Student Grade Option: "));
        }

        public static string GetExactVal(string valType, string dataLen, string msgRestric, string msg){
            string newData = null;
            string regExp;
            switch (valType)
            {
                case "strSpace":
                    regExp = @"^[a-zA-ZÀ-ÿ\u00f1\u00d1\x20]{"+dataLen+"}$";
                    break;
                case "strDir":
                    regExp = @"^[a-zA-Z0-9À-ÿ_\u00f1\u00d1\-\#\.\x20]{"+dataLen+"}$";
                    break;
                case "strEmail":
                    regExp = @"^([\w\.\-_]+)@([\w\-]+)((\.(\w){2,4})+)$";
                    break;
                case "int":
                    regExp = @"^[0-9]{"+dataLen+"}$";
                    break;
                case "float":
                    regExp = @"^([0-5]{1})+\,[0-9]{1,3}$";
                    break;
                default:
                    regExp = @"^[\s\S]{"+dataLen+"}$";
                    break;
            }
            /* Console.WriteLine(regExp); */
            bool contGetExa = true;
            while (contGetExa)
            {
                Console.WriteLine($"Enter the {msg}");
                newData = Console.ReadLine();
                if (Regex.IsMatch(newData, regExp))
                {
                    newData = Regex.Replace(newData, @"\s+", " ").Trim();
                    /* Console.WriteLine(newData); */
                    contGetExa = false;
                    if (valType == "float")
                    {
                        if(float.Parse(newData) <= 5 && float.Parse(newData) >= 0 ){
                            contGetExa = false;
                        } else {
                            Console.WriteLine("Remember thah only numbers between (0 and 5) are Allowed");
                            contGetExa = true;
                        }
                    }
                } else {
                    if (valType == "float")
                    {
                        Console.WriteLine($"{msgRestric} are allowed, the allowed format is: (4,4), Remember thah only numbers between (0 and 5) are Allowed.");
                    } else {
                        Console.WriteLine($"{msgRestric} are allowed, The {msg} must be at least {dataLen} characters.");   
                    }
                }
            }
            return newData;
        }

        public static void SaveData(List<Student> studList){
            /* deserializacion/serializacion Json - Lista */
            string json = JsonConvert.SerializeObject(studList, Formatting.Indented);
            File.WriteAllText("reportCard.json", json);
        }

        public static List<Student> LoadData(List<Student> studList){
            if (!File.Exists("reportCard.json"))
            {
                SaveData(studList);
            }
            using (StreamReader reader = new StreamReader("reportCard.json")){
                string json = reader.ReadToEnd();
                if (json.Length >= 4)
                {
                    studList = System.Text.Json.JsonSerializer.Deserialize<List<Student>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true}) ?? new List<Student>();
                    Console.WriteLine(studList);
                    return studList;
                }
                return studList;
            }
            /* 
            PropertyNameCaseInsensitive
            Mantener carecteres como estan en el archivo JSON  
            */
        }
        
    }
}
