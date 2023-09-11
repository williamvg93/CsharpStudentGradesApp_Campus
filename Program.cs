using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using studentGrades.entities;


internal class Program
{
    private static void Main(string[] args){

        bool contWhile = true;
        int respMainMen;

        
/*         Student newStudent = new Student("12345", "samir", "correo@correo", 20, "cra12 #2-19");
        Student newStudent2 = new Student("123456789123456", "samir stiven villamizar garcés", "samir@correo.com", 25, "cra12 #2-19 mirador");
        studentList.Add(newStudent);
        studentList.Add(newStudent2);
        studentList[0].UpdGrades(0,3.7f,"quiz");
        studentList[0].UpdGrades(3,4.5f,"quiz"); */

        /*  Console.WriteLine(newStudent.Code); */
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        List<Student> studentList = new List<Student>();

        while (contWhile)
        {
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

            Console.WriteLine(CheckValue("holasss1", "^[a-zA-Z](5)$"));
            Console.WriteLine(CheckValue("hol", "^[a-zA-Z](5)$"));
            Console.WriteLine(CheckValue("hol1", "^[a-zA-Z](5)$"));
            Console.WriteLine(CheckValue("hola", "^[a-zA-Z](5)$"));
            

            Console.WriteLine("Enter the number of the option you want: ");
            respMainMen = Convert.ToInt16(Console.ReadLine());

            switch (respMainMen)
            {
                case 1: 
                    bool contStud = true;
                    while (contStud)
                    {
                        Console.Clear();
                        Int16 resStud; 
                        Console.WriteLine("{0,30}", " Manage Student \n");
                        Console.WriteLine("{0,3}", " 1) -> Add Student");
                        Console.WriteLine("{0,3}", " 2) -> View Student List");
                        Console.WriteLine("{0,3}", " 3) -> Back to Main Menu");
                        Console.WriteLine("Enter the number of the option you want: ");
                        resStud = Convert.ToInt16(Console.ReadLine());    
                        switch (resStud)
                        {
                            case 1:
                                Console.Clear();
                                Student newStud = new Student();
                                newStud.Code = GetExactVal("Code", 15, "");
                                newStud.Name = GetExactVal("Name", 40, "");    
                                newStud.Age = Convert.ToInt16(GetExactVal("Age", 3, ""));
                                newStud.Email = GetExactVal("Email", 40, "");
                                newStud.Address = GetExactVal("Address", 35, "");
                                studentList.Add(newStud);
                                break;
                            case 2:
                                Console.Clear();
                                ListData(studentList, "stud", "", "", "");
                                break;
                            case 3:
                                contStud = false;
                                break;
                            default:
                                Console.WriteLine("Enter a Valid Option !!!!");
                                break;
                        }
                    }
                    break; 
                case 2:
                    bool contGrad = true;
                    while (contGrad) {
                        Console.Clear();
                        Int16 resGra; 
                        Console.WriteLine("{0,30}", " Manage Student Grades \n");
                        Console.WriteLine("{0,3}", " 1) -> Add Quiz Grade");
                        Console.WriteLine("{0,3}", " 2) -> Add Tasks Grade");
                        Console.WriteLine("{0,3}", " 3) -> Add Exam Garde");
                        Console.WriteLine("{0,3}", " 4) -> Back to Main Menu");
                        Console.WriteLine("Enter the number of the option you want: ");
                        resGra = Convert.ToInt16(Console.ReadLine());
                        switch (resGra)
                        {
                            case 1:
                                Console.Clear();
                                AddGrades(studentList,0, "quiz");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                AddGrades(studentList,0, "task");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                AddGrades(studentList,0, "exam");
                                Console.ReadKey();
                                break;
                            case 4:
                                contGrad = false;
                                break;
                            default:
                                Console.WriteLine("Enter a Valid Option !!!!");
                                break;
                        }
                    }

                    break;
                case 3:

                    bool contGradRep = true;
                    while (contGradRep) {
                        Console.Clear();
                        Int16 resRep; 
                        Console.WriteLine("{0,30}", " Grade Report \n");
                        Console.WriteLine("{0,3}", " 1) -> View Student List");
                        Console.WriteLine("{0,3}", " 2) -> Generate Grade Report");
                        Console.WriteLine("{0,3}", " 3) -> Generate Final Grade Report");
                        Console.WriteLine("{0,3}", " 4) -> Back to Main Menu");
                        Console.WriteLine("Enter the number of the option you want: ");
                        resRep = Convert.ToInt16(Console.ReadLine());
                        switch (resRep)
                        {
                            case 1:
                                ListData(studentList,"stud", "", "", "");
                                break;
                            case 2:
                                ListData(studentList,"allGra", "", "", "");
                                break;
                            case 3:
                                EndList(studentList,0, 0, 0, 0);
                                break;
                            case 4:
                                contGradRep = false;
                                break;
                            default:
                                Console.WriteLine("Enter a Valid Option !!!!");
                                break;
                        }
                    }
                    break;
                case 4:
                    contWhile = false;
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Enter a Valid Option !!!!");
                    break;
            }
        
        }
    }

    public static string CheckValue(string valType, string msg, string regExp, string dataStu){
        /* return Regex.IsMatch(data, @"^[a-zA-Z](5)$"); */

        /* return Regex.IsMatch(dataStu, @regExp); */

        bool contGetExa = true;
        while (contGetExa)
        {
            if (valType == "string"){
                Console.WriteLine($"Enter the Student {msg}");
                dataStu = Console.ReadLine();
                if (Regex.IsMatch(dataStu, @regExp))
                {
                    contGetExa = false;
                } else {
                    Console.WriteLine($"The Student {msg} must be at least {dataLen} characters");   
                }
            }
        }
        return dataStu;
    }


    public static string GetExactVal(string msg, int dataLen, string dataStu){
        bool contGetExa = true;
        while (contGetExa)
        {
            Console.WriteLine($"Enter the Student {msg}");
            dataStu = Console.ReadLine();
            if ((dataStu.Length <= dataLen) && (dataStu != ""))
            {
                contGetExa = false;
            } else {
                Console.WriteLine($"The Student {msg} must be at least {dataLen} characters");   
            }
        }
        return dataStu;
    }

    public static void AddGrades(List<Student> lista, int conStu, string gradeType){
        string stuCode;
        Console.WriteLine($"Enter the Student code: ");
        stuCode = Console.ReadLine();
        if (lista.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Code == stuCode) {
                    int e = 0;
                    int contGra = 0;
                    conStu++;
                    do
                    {
                        if(Convert.ToInt32(lista[i].GetGrades(gradeType)[e]) <= 0){
                            Console.WriteLine($"Enter the {gradeType} Grade: ");
                            float quizGrade = Single.Parse(Console.ReadLine());
                            lista[i].UpdGrades(e,quizGrade, gradeType);
                            string rtaGra;
                            Console.WriteLine($"Do you want to add more {gradeType} grades ?, Enter (y) for YES or (n) for no: ");
                            rtaGra = Console.ReadLine().ToLower();
                            while (rtaGra != "n" && rtaGra != "y")
                            {
                                Console.WriteLine($"Do you want to add more {gradeType} grades ?, Enter (y) for YES or (n) for no: ");
                                rtaGra = Console.ReadLine().ToLower();
                            }
                            if (rtaGra == "n")
                            {
                                e = lista[i].GetGrades(gradeType).Count + 1; 
                            }
                        } else {
                            contGra++;
                        }
                        e++;
                    } while (e < lista[i].GetGrades(gradeType).Count);

                    if (contGra == lista[i].GetGrades(gradeType).Count)
                    {
                        Console.WriteLine($"All {gradeType} grades have already been added");
                    }
                }
            }
        }
        if (conStu == 0)
        {
            Console.WriteLine("There is no student with that code !!!");
        }
    }

    public static void ListData(List<Student> lista, string opcion, string quizzNots, string tasksNots, string examsNots){
        Console.Clear();
        if (lista.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            if (opcion == "stud") {
                Console.WriteLine("{0,-16} {1, -41} {2, -5} {3,-41} {4,3}" , "Id", "Name", "Age", "Email", "Address");
                foreach (Student stud in lista)
                {
                    Console.WriteLine("{0,-16} {1, -41} {2, -5} {3,-41} {4,3}", stud.Code, stud.Name, stud.Age, stud.Email, stud.Address);
                }
            } else {
                Console.WriteLine("{0,-16} {1, -52} {2, -27} {3, -13} {4, 16}" , "Id", "Name", "Quizzes", "Tasks", "Exams");
                foreach (Student stud in lista)
                {
                    quizzNots = "";
                    tasksNots = "";
                    examsNots = "";
                    foreach (var quiz in stud.GetGrades("quiz")) {
                        quizzNots+= $"{quiz} -  ";
                    }
                    foreach (var task in stud.GetGrades("task")) {
                        tasksNots+= $"{task} -  ";
                    }
                    foreach (var exam in stud.GetGrades("exam")) {
                        examsNots+= $"{exam} -  ";
                    }
                    Console.WriteLine("{0,-16} {1, -41} {2, -34} {3, -20} {4, 16}", stud.Code, stud.Name, $"[ {quizzNots.Substring(0,quizzNots.Length - 4)} ]", $"[ {tasksNots.Substring(0,tasksNots.Length - 4)} ]", $"[ {examsNots.Substring(0,examsNots.Length - 4)} ]");
                }
            }       
        }
        Console.ReadKey();
    }

    public static void EndList(List<Student> lista, float quizGra, float tasksGra, float examsGra, float finalNot){
        Console.Clear();
        if (lista.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            Console.WriteLine("{0,-16} {1, -41} {2, -20} {3, -20} {4, -20} {5, 8}" , "Id", "Name", "Final Quiz Grade", "Final Task Grade", "Final Exam Grade", "Final Grade");
            foreach (Student stud in lista)
            {
                quizGra = 0;
                tasksGra = 0;
                examsGra = 0;
                foreach (var quiz in stud.GetGrades("quiz")) {
                    float fquiz = Convert.ToSingle(quiz);
                    quizGra += fquiz;
                }
                foreach (var task in stud.GetGrades("task")) {
                    float ftask = Convert.ToSingle(task);
                    tasksGra += ftask;
                }
                foreach (var exam in stud.GetGrades("exam")) {
                    float fexam = Convert.ToSingle(exam);
                    examsGra += fexam;
                }
                finalNot = ((((quizGra/4)*25)/100) + (((tasksGra/2)*15)/100) + (((examsGra/3)*60)/100));
                Console.WriteLine("{0,-16} {1, -44} {2, -23} {3, -18} {4, -16} {5, 8}", stud.Code, stud.Name, $"[ {Math.Round((((quizGra/4)*25)/100),2)} ]", $"[ {Math.Round((((tasksGra/2)*15)/100),2)} ]", $"[ {Math.Round((((examsGra/3)*60)/100),2)} ]", $"[ {Math.Round(finalNot,2)} ]");
            }
        }
        Console.ReadKey();
    }

}






