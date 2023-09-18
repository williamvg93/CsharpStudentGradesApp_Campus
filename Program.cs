using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using studentGrades.entities;
using studentGrades;

/* Nuget Gallery estension */
/* https://www.nuget.org/packages/Newtonsoft.Json */

internal class Program
{
    private static void Main(string[] args){

        bool contWhile = true;
        Byte respMainMen;
        List<Student> studentList = new List<Student>();
        Student newStud = new Student();

        Console.ForegroundColor = ConsoleColor.DarkMagenta;

        while (contWhile)
        {   
            Console.Clear();
            studentList = Functions.LoadData(studentList);
            respMainMen = Functions.MainMenu();
            switch (respMainMen)
            {
                case 1: 
                    bool contStud = true;
                    while (contStud)
                    {
                        Console.Clear();
                        byte resStud; 
                        resStud = Functions.StudentMenu();
                        switch (resStud)
                        {
                            case 1:
                                Console.Clear();
                                studentList = newStud.AddStudent(studentList);
                                break;
                            case 2:
                                Console.Clear();
                                studentList = newStud.UpdateStud(studentList);
                                break;
                            case 3:
                                Console.Clear();
                                studentList = newStud.DeleteStud(studentList);
                                break;
                            case 4:
                                Console.Clear();
                                newStud.ListStud(studentList);
                                break;
                            case 5:
                                contStud = false;
                                break;
                            default:
                                Console.WriteLine("Enter a Valid Option !!!!, Pres a Key to Continue.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break; 
                case 2:                
                    bool contGrad = true;
                    while (contGrad) {
                    Console.Clear();
                    byte resGra = Functions.GradetMenu();
                        switch (resGra)
                        {
                            case 1:
                                bool contQuizGrad = true;
                                while (contQuizGrad) {
                                    Console.Clear();
                                    byte resQuizMen = Functions.QuizGradMen();
                                    switch (resQuizMen)
                                    {
                                        case 1:
                                            Console.Clear();
                                            studentList = newStud.AddGrade(studentList, "quiz" , "Quiz Grade #");
                                            break;
                                        case 2:
                                            Console.Clear();
                                            studentList = newStud.UpdateStuGrade(studentList, "quiz");
                                            break;
                                        case 3:
                                            Console.Clear();
                                            studentList = newStud.DeleteStuGra(studentList, "quiz" , "Quiz Grade #");
                                            break;
                                        case 4:
                                            contQuizGrad = false;
                                            break;
                                        default:
                                            Console.WriteLine("Enter a Valid Option !!!!, Pres a Key to Continue.");
                                            Console.ReadKey();
                                            break;
                                    }
                                }
                                break;
                            case 2:
                                bool contTaskGrad = true;
                                while (contTaskGrad) {
                                    Console.Clear();
                                    byte resTaskMen = Functions.TaskGradMen();
                                    switch (resTaskMen)
                                    {
                                        case 1:
                                            Console.Clear();
                                            studentList = newStud.AddGrade(studentList, "task" , "task Grade #");
                                            break;
                                        case 2:
                                            Console.Clear();
                                            studentList = newStud.UpdateStuGrade(studentList, "task");
                                            break;
                                        case 3:
                                            Console.Clear();
                                            studentList = newStud.DeleteStuGra(studentList, "task" , "task Grade #");
                                            break;
                                        case 4:
                                            contTaskGrad = false;
                                            break;
                                        default:
                                             Console.WriteLine("Enter a Valid Option !!!!, Pres a Key to Continue.");
                                            Console.ReadKey();
                                            break;
                                    }
                                }                      
                                break;
                            case 3:
                                bool contExamGrad = true;
                                while (contExamGrad) {
                                    Console.Clear();
                                    byte resTaskMen = Functions.ExamGradMen();
                                    switch (resTaskMen)
                                    {
                                        case 1:
                                            Console.Clear();
                                            studentList = newStud.AddGrade(studentList, "exam" , "exam Grade #");
                                            break;
                                        case 2:
                                            Console.Clear();
                                            studentList = newStud.UpdateStuGrade(studentList, "exam");
                                            break;
                                        case 3:
                                            Console.Clear();
                                            studentList = newStud.DeleteStuGra(studentList, "exam" , "exam Grade #");
                                            Console.Clear();
                                            break;
                                        case 4:
                                            contExamGrad = false;
                                            break;
                                        default:
                                            Console.WriteLine("Enter a Valid Option !!!!");
                                            Console.ReadKey();
                                            break;
                                    }
                                }                      
                                break;
                            case 4:
                                contGrad = false;
                                break;
                            default:
                                Console.WriteLine("Enter a Valid Option !!!!, Pres a Key to Continue.");
                                Console.ReadKey();
                                break;
                        }
                    }

                    break;
                case 3:

                    bool contGradRep = true;
                    while (contGradRep) {
                        Console.Clear();
                        byte resRep = Functions.GradeReportMenu();
                        switch (resRep)
                        {
                            case 1:
                                Console.Clear();
                                newStud.ListStud(studentList);
                                break;
                            case 2:
                                Console.Clear();
                                newStud.StuGradeList(studentList, "","","");                      
                                break;
                            case 3:
                                Console.Clear();
                                newStud.StuReporCard(studentList, 0,0,0,0);         
                                break;
                            case 4:
                                contGradRep = false;
                                break;
                            default:
                                Console.WriteLine("Enter a Valid Option !!!!, Pres a Key to Continue.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case 4:
                    contWhile = false;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Enter a Valid Option !!!!, Pres a Key to Continue.");
                    Console.ReadKey();
                    break;
            }
        
        }
    }

}



