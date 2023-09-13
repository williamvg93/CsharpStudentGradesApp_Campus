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
            // Console.Clear();
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
            return Byte.Parse(Console.ReadLine());
        }

        public static byte StudentMenu(){
            Console.Clear();
            Console.WriteLine("{0,30}", " Manage Student \n");
            Console.WriteLine("{0,3}", " 1) -> Add Student");
            Console.WriteLine("{0,3}", " 2) -> Delete Student");
            Console.WriteLine("{0,3}", " 3) -> View Student List");
            Console.WriteLine("{0,3}", " 4) -> Back to Main Menu");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Student Menu Option: "));
        }
        public static byte GradetMenu(){
            Console.Clear();
            Console.WriteLine("{0,30}", " Manage Student Grades \n");
            Console.WriteLine("{0,3}", " 1) -> Add Quiz Grade");
            Console.WriteLine("{0,3}", " 2) -> Add Tasks Grade");
            Console.WriteLine("{0,3}", " 3) -> Add Exam Garde");
            Console.WriteLine("{0,3}", " 4) -> Back to Main Menu");
            Console.WriteLine("Enter the number of the option you want: ");
            return Byte.Parse(GetExactVal("int", "1", "only numbers", "Grade Menu Option: "));
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
/*                     regExp = @"^[0-9\.]{"+dataLen+"}$"; */
                    regExp = @"^[0-9]([\.\,][0-9]{"+dataLen+"})?$";
                    break;
                default:
                    regExp = @"^[\s\S]{"+dataLen+"}$";
                    break;
            }
            Console.WriteLine(regExp);
            bool contGetExa = true;

            while (contGetExa)
            {
                Console.WriteLine($"Enter the {msg}");
                newData = Console.ReadLine();
                if (Regex.IsMatch(newData, regExp))
                {
                    newData = Regex.Replace(newData, @"\s+", " ").Trim();
                    Console.WriteLine(newData);
                    contGetExa = false;
                } else {
                        Console.WriteLine($"{msgRestric} are allowed, The {msg} must be at least {dataLen} characters");   
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
            //bool dirExists = Directory.Exists("./ReportCard.json");
            //string ruta = Path.Combine(Environment.CurrentDirectory,"reportCard.json");
            //Console.WriteLine(ruta);
            //bool dirExists = File.Exists("reportCard.json");
            if (!File.Exists("reportCard.json"))
            {
                SaveData(studList);
            }
            using (StreamReader reader = new StreamReader("reportCard.json")){
                string json = reader.ReadToEnd();
                Console.WriteLine(json); 
                Console.WriteLine(json.Length);
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

/* 
^[\s\S]{0,25}$
usuario: /^[a-zA-Z0-9\_\-]{4,16}$/, // Letras, numeros, guion y guion_bajo
nombre: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
password: /^.{4,12}$/, // 4 a 12 digitos.
correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
telefono: /^\d{7,14}$/ // 7 a 14 numeros.
 */