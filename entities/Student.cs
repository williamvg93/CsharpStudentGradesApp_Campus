
using System.Collections;

namespace studentGrades.entities;

public class Student
{
    private string code;
    private string name;
    private string email;
    private int age;
    private string address;
/*  private ArrayList quizzes = new ArrayList(){3.2f,4.5f,4.9f,3.9f};
    private ArrayList tasks = new ArrayList(){4.5f,4.9f};
    private ArrayList exams = new ArrayList(){4.5f,3.2f,4.5f}; */
    private ArrayList quizzes = new ArrayList(){0,0,0,0};
    private ArrayList tasks = new ArrayList(){0,0};
    private ArrayList exams = new ArrayList(){0,0,0};


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

    public int Age {
        get {return age;}
        set {age = value;}
    }

    public string Address {
        get {return address;}
        set {address = value;}
    }

    public void UpdGrades(int ranGra, float grade, string gradeNa) {
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
    }

/*     public void UpdQuizzes(int ranQuiz, float quiz) {
        quizzes.RemoveAt(ranQuiz);
        quizzes.Insert(ranQuiz,quiz);
    }

    public ArrayList GetQuizzes() {
        return quizzes;
    }

    public void UpdTasks(int ranTask, float task) {
        tasks.Insert(ranTask,task);
    }

    public ArrayList GetTasks() {
        return tasks;
    }

    public void UpdExams(int ranExam ,float exam) {
        exams.Insert(ranExam,exam);
    }

    public ArrayList GetExams() {
        return exams;
    } */

    public Student(){}

    public Student(string nId, string nName, string nEmail, int nAge, string nAddress) {
        this.code = nId;
        this.name = nName;
        this.email = nEmail;
        this.age = nAge;
        this.address = nAddress;
    }

}
