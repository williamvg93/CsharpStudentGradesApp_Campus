using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using studentGrades.entities;


/* Student newStudent = new Student(12345, "william", "correo", 30, "cra#122");
Console.WriteLine(newStudent.Code); */
bool contWhile = true;
int respMainMen;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Magenta;
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
        Console.WriteLine("{0,30}", " Manage Student \n");
        Console.WriteLine("{0,3}", " 1) -> Add Student");
        Console.WriteLine("{0,3}", " 2) -> Exit App");
        break;
    case 2:
        Console.WriteLine("{0,30}", " Manage Student Grades \n");
        Console.WriteLine("{0,3}", " 1) -> Add Student");
        Console.WriteLine("{0,3}", " 2) -> Exit App");
        break;
    case 3:
        Console.WriteLine("{0,30}", " Grade Report \n");
        Console.WriteLine("{0,3}", " 1) -> Generate Grade Report");
        Console.WriteLine("{0,3}", " 2) -> Exit App");
        break;
    default:
        Console.WriteLine("Enter a Valid Option !!!!");
        break;
}




