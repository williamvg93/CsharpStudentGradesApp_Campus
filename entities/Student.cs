
using System.Collections;

namespace studentGrades.entities;

public class Student
{
    private string code;
    private string name;
    private string email;
    private int age;
    private string address;
    private ArrayList quizzes = new ArrayList();


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

    public void AddQuizzes(decimal quiz) {
        quizzes.Add(quiz);
    }

    public ArrayList GetQuizzes() {
        return quizzes;
    }

    public Student(){}

    public Student(string nId, string nName, string nEmail, int nAge, string nAddress, ArrayList nQuizzes) {
        this.code = nId;
        this.name = nName;
        this.email = nEmail;
        this.age = nAge;
        this.address = nAddress;
        this.quizzes = nQuizzes;
    }

}
