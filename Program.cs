using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using studentGrades.entities;


internal class Program
{
    private static void Main(string[] args){

        bool contWhile = true;
        int respMainMen;

        List<Student> studentList = new List<Student>();
        Student newStudent = new Student("12345", "samir", "correo@correo", 20, "cra12 #2-19");
        Student newStudent2 = new Student("123456789123456", "samir stiven villamizar garcés", "samir@correo.com", 25, "cra12 #2-19 mirador");
        studentList.Add(newStudent);
        studentList.Add(newStudent2);

        /*  Console.WriteLine(newStudent.Code); */
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;


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
                        Console.WriteLine("{0,3}", " 3) -> Exit App");
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
                        Console.WriteLine("{0,3}", " 4) -> Exit App");
                        Console.WriteLine("Enter the number of the option you want: ");
                        resGra = Convert.ToInt16(Console.ReadLine());
                        switch (resGra)
                        {
                            case 1:
                                SearchStu(studentList);
                                Console.ReadKey();
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                contGrad = false;
                                break;
                            default:
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
                        Console.WriteLine("{0,3}", " 3) -> Exit App");
                        Console.WriteLine("Enter the number of the option you want: ");
                        resRep = Convert.ToInt16(Console.ReadLine());
                        switch (resRep)
                        {
                            case 1:
                                ListData(studentList, "stud", "", "", "");
                                break;
                            case 2:
                                ListData(studentList,"", "", "", "");
                                break;
                            case 3:
                                break;
                            case 4:
                                contGradRep = false;
                                break;
                            default:
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

    public static bool CheckData(string element, int lenEle){
        if (element.Length <= lenEle)
        {
            /* string newElem = element.Remove(lenEle);
            return newElem; */
            return true;
        } else {
            return false;
        }
    }

    public static string GetExactVal(string msg, int dataLen, string dataStu){
        bool contGetExa = true;
        while (contGetExa)
        {
            Console.WriteLine($"Enter the Student {msg}");
            dataStu = Console.ReadLine();
            if (CheckData(dataStu, dataLen))
            {
                contGetExa = false;
            } else {
                Console.WriteLine($"The Student {msg} must be at least {dataLen} characters");
            }
        }
        return dataStu;
    }

    public static void SearchStu(List<Student> lista){
        string stuCode;
        Console.WriteLine($"Enter the Student code: ");
        stuCode = Console.ReadLine();
        if (lista.Count() < 1) {
            Console.WriteLine("There are no students in the database");
            Console.ReadKey();
        } else {
            foreach (Student stud in lista)
            {
                if (stud.Code == stuCode) {
                    ArrayList studentQuiz = new ArrayList();
                    studentQuiz = stud.GetQuizzes();
                    if (studentQuiz.Count < 4){
                        decimal quizGrade;
                        Console.WriteLine("Enter the Quiz Grade: ");
                        quizGrade = Convert.ToDecimal(Console.ReadLine());
                        stud.UpdQuizzes(0,quizGrade);
                    } else {
                        Console.WriteLine("All quiz grades have already been Added. ");
                         Console.ReadKey();
                    }

                } else {
                    Console.WriteLine("There is no student with that code");
                    Console.ReadKey();
                }
            }
        }
    }

    public static void ListData(List<Student> lista, string opcion, string quizzNots, string tasksNots, string examsNots){
        if (lista.Count() < 1) {
            Console.WriteLine("There are no students in the database");
            Console.ReadKey();
        } else {
            if (opcion == "stud") {
                Console.WriteLine("{0,-16} {1, -41} {2, -5} {3,-41} {4,3}" , "Id", "Name", "Age", "Email", "Address");
                foreach (Student stud in lista)
                {
                    Console.WriteLine("{0,-16} {1, -41} {2, -5} {3,-41} {4,3}", stud.Code, stud.Name, stud.Age, stud.Email, stud.Address);
                }
                Console.ReadKey();
            } else {
                Console.WriteLine("{0,-16} {1, -48} {2, -23} {3, -16} {4, 7}" , "Id", "Name", "Quizzes", "Tasks", "Exams");
                foreach (Student stud in lista)
                {
                    quizzNots = "";
                    tasksNots = "";
                    examsNots = "";
                    foreach (var quiz in stud.GetQuizzes()) {
                        quizzNots+= $"[{quiz}] -  ";
                    }
                    foreach (var task in stud.GetTasks()) {
                        tasksNots+= $"[{task}] -  ";
                    }
                    foreach (var exam in stud.GetExams()) {
                        examsNots+= $"[{exam}] -  ";
                    }
                    Console.WriteLine("{0,-16} {1, -41} {2, -28} {3, -14} {4, 16}", stud.Code, stud.Name, quizzNots.Substring(0,quizzNots.Length - 3), tasksNots.Substring(0,tasksNots.Length - 3), examsNots.Substring(0,examsNots.Length - 3));

                }
                Console.ReadKey();
            }
        }
    }

}






