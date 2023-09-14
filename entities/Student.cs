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

    public List<Student> AddStudent(List<Student> students){
        Student newStudent = new Student();
        newStudent.Code = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");
        newStudent.Name = Functions.GetExactVal("strSpace", "3,40", "only letters", "student Name");
        newStudent.Age = byte.Parse(Functions.GetExactVal("int", "1,2", "only numbers", "student Age"));
        newStudent.Email = Functions.GetExactVal("strEmail", "3,40", "only letters, numbers and(@,-,_,.)", "student Email");
        newStudent.Address = Functions.GetExactVal("strDir", "3,40", "only letters, numbers and(#,-,_,.)", "student Address");
        students.Add(newStudent);
        Functions.SaveData(students);
        Functions.LoadData(students);
        return students;
    }  

    public List<Student> AddGrade(List<Student> students, byte option, string msg){
        string studCod = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");

        Student stud = students.FirstOrDefault(s => s.Code.Equals(studCod));
        Console.WriteLine(stud);
        if (stud == null){
            Console.WriteLine("There are no students in the database");
        } else {
            bool contGrad = true;
            while (contGrad) {
                switch (option)
                {
                    case 1:
                        stud.Quizzes.Add(float.Parse(Functions.GetExactVal("float", "1-4", "only numbers", "Quiz Grade #"+$"{stud.Quizzes.Count + 1}")));
                        break;
                    case 2:
                        stud.Tasks.Add(float.Parse(Functions.GetExactVal("float", "1-4", "only numbers", "Task Grade #"+$"{stud.Tasks.Count + 1}")));
                        break;
                    case 3:
                        stud.Exams.Add(float.Parse(Functions.GetExactVal("float", "1-3", "only numbers", "Exam Grade #"+$"{stud.Exams.Count + 1}")));
                        break;
                    default:
                        Console.WriteLine("Invalid Opcion, plis enter a valid opcion !!!s");
                        break;
                }
            }
            int studPosi = students.FindIndex(s => s.Code.Equals(studCod));
            students[studPosi] = stud;
            Functions.SaveData(students);
            Functions.LoadData(students);
        }
        return students;
    }  


    public void DeleteStud(List<Student> students){
        string StuId = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");

        Student studRemo = students.FirstOrDefault(stud => (stud.Code ?? string.Empty).Equals(StuId)) ?? new Student();

/*         Console.WriteLine((studRemo.Name).GetType()); */
        if (studRemo.Code == null)
        {
            Console.WriteLine("There is no student with that code !!!");
        } else {
            Console.WriteLine($"Student Name: ${studRemo.Name}");
            students.Remove(studRemo);
            Functions.SaveData(students);
        }
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