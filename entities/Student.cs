using System.Collections;
using studentGrades;

namespace studentGrades.entities;

public class Student:ReportCard
{
    private string code;
    private string name;
    private string email;
    private byte age;
    private string address;
    
    public Student():base(){}

    public Student(string nId, string nName, string nEmail, byte nAge, string nAddress, List<float> quizzes, List<float> tasks, List<float> exams ):base(quizzes, tasks, exams) {
        this.code = nId;
        this.name = nName;
        this.age = nAge;
        this.email = nEmail;
        this.address = nAddress;
        this.Quizzes = quizzes;
        this.Tasks = tasks;
        this.Exams = exams;
    }

    public string Code {
        get {return code;}
        set {code = value;}
    }

    public string Name {
        get {return name;}
        set {name = value;}
    }

    public string Email {
        get {return email;}
        set {email = value;}
    }

    public byte Age {
        get {return age;}
        set {age = value;}
    }

    public string Address {
        get {return address;}
        set {address = value;}
    }

    public void AddStudent(List<Student> students){

        Student newStudent = new Student();
        newStudent.Code = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");
        newStudent.Name = Functions.GetExactVal("str", "3,40", "only letters", "student Name");
        newStudent.Age = byte.Parse(Functions.GetExactVal("int", "1,2", "only numbers", "student Age"));
        newStudent.Email = Functions.GetExactVal("str", "3,40", "only letters", "student Email");
        newStudent.Address = Functions.GetExactVal("str", "3,40", "only letters", "student Address");
        Console.WriteLine(newStudent.Code);
        Console.WriteLine(newStudent.Name);
        Console.WriteLine(newStudent.Age);
        Console.WriteLine(newStudent.Email);
        Console.WriteLine(newStudent.Address);
        Console.ReadKey();
    }   


}




    /* public void UpdGrades(int ranGra, float grade, string gradeNa) {
        switch (gradeNa)
        {
            case "quiz":
                quizzes.RemoveAt(ranGra);
                quizzes.Insert(ranGra,grade);
                break;
            case "task": 
                tasks.RemoveAt(ranGra);
                tasks.Insert(ranGra,grade);
                break;
            case "exam": 
                exams.RemoveAt(ranGra);
                exams.Insert(ranGra,grade);
                break;
            default:
                break;
        }
    }
    public ArrayList GetGrades(string gradeNa) {

        switch (gradeNa)
        {
            case "quiz":
                return quizzes;
            case "task": 
                return tasks;
            case "exam": 
                return exams;
            default:
                return quizzes;
        }
    } */