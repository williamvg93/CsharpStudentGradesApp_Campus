using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using studentGrades.entities;


/* Student newStudent = new Student(12345, "william", "correo", 30, "cra#122");
Console.WriteLine(newStudent.Code); */
internal class Program
{
    private static void Main(string[] args){

        bool contWhile = true;
        int respMainMen;
        List<Student> studentList = new List<Student>();

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
                                Console.WriteLine("Enter the student Code: ");
                                newStud.Code = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the student Name: ");
                                newStud.Name = Console.ReadLine();
                                Console.WriteLine("Enter the student Age: ");
                                newStud.Age = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("Enter the student Email: ");
                                newStud.Email = Console.ReadLine();
                                Console.WriteLine("Enter the student Address: ");
                                newStud.Address = Console.ReadLine();
                                studentList.Add(newStud);
                                break;
                            case 2:
                                Console.Clear();
                                if (studentList.Count() < 1) {
                                    Console.WriteLine("There are no students in the database");
                                    Console.ReadKey();
                                } else {
                                    Console.WriteLine("{0,-20} {1, -30} {2, -5} {3,-35} {4,3}" , "Id", "Name", "Age", "Email", "Address");
                                    foreach (Student stud in studentList)
                                    {
                                        Console.WriteLine("{0,-20} {1, -30} {2, -5} {3,-35} {4,3}", stud.Code, stud.Name, stud.Age, stud.Email, stud.Address);
                                    }
                                    Console.ReadKey();
                                }
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
                    Console.Clear();
                    Int16 resGra; 
                    Console.WriteLine("{0,30}", " Manage Student Grades \n");
                    Console.WriteLine("{0,3}", " 1) -> Add Quiz Grade");
                    Console.WriteLine("{0,3}", " 2) -> Add HomeWork Grade");
                    Console.WriteLine("{0,3}", " 3) -> Add Exam Garde");
                    Console.WriteLine("{0,3}", " 4) -> Exit App");
                    Console.WriteLine("Enter the number of the option you want: ");
                    resGra = Convert.ToInt16(Console.ReadLine());
                    break;
                case 3:
                    Console.Clear();
                    Int16 resRep; 
                    Console.WriteLine("{0,30}", " Grade Report \n");
                    Console.WriteLine("{0,3}", " 1) -> Generate Grade Report");
                    Console.WriteLine("{0,3}", " 2) -> Exit App");
                    Console.WriteLine("Enter the number of the option you want: ");
                    resRep = Convert.ToInt16(Console.ReadLine());
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

}






