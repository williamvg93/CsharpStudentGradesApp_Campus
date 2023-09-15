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

    public void DeleteStud(List<Student> students){
        string StuId = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");

        Student studRemo = students.FirstOrDefault(stud => (stud.Code ?? string.Empty).Equals(StuId)) ?? new Student();

        /* Console.WriteLine((studRemo.Name).GetType()); */
        if (studRemo.Code == null)
        {
            Console.WriteLine("There is no student with that code !!!");
        } else {
            Console.WriteLine($"Student Name: {studRemo.Name}");
            students.Remove(studRemo);
            Functions.SaveData(students);
        }
        Console.ReadKey();
    } 

    public List<Student> UpdateStud(List<Student> students){
        string StuId = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");

        Student studRemo = students.FirstOrDefault(stud => (stud.Code ?? string.Empty).Equals(StuId)) ?? new Student();

        /* Console.WriteLine((studRemo.Name).GetType()); */
        if (studRemo.Code == null)
        {
            Console.WriteLine("There is no student with that code !!!");
        } else {
            bool contEditStu = true;
            while (contEditStu)
            {   
                Console.Clear();
                Console.WriteLine($"Student Name: {studRemo.Name}\n");
                int contDataStu = 0;
                foreach (var studData in studRemo.GetType().GetProperties())
                {
                    if (studData.Name != "Code" && studData.Name != "Quizzes" && studData.Name != "Tasks" && studData.Name != "Exams")
                    {   
                        contDataStu += 1;
                        Console.WriteLine("{0,3} {1,3} {2,3}", $"{contDataStu})", $"-> Update Student {studData.Name}:\t", studData.GetValue(studRemo)); 
                    }
                }
                Console.WriteLine("{0,3} {1,3}", $"{contDataStu})", "Back to Student Menu\t"); 
                Console.WriteLine();
                byte resEdiStu =  Byte.Parse(Functions.GetExactVal("int", "1", "only numbers", "Data number of the data you want to edit: "));
                switch (resEdiStu)
                {
                    case 1:
                        studRemo.Name = Functions.GetExactVal("strSpace", "3,40", "only letters", "student Name");
                        break;
                    case 2:
                        studRemo.Email = Functions.GetExactVal("strEmail", "3,40", "only letters, numbers and(@,-,_,.)", "student Email");
                        break;
                    case 3:
                        studRemo.Age = byte.Parse(Functions.GetExactVal("int", "1,2", "only numbers", "student Age"));
                        break;
                    case 4:
                        studRemo.Address = Functions.GetExactVal("strDir", "3,40", "only letters, numbers and(#,-,_,.)", "student Address");
                        break;
                    case 5:
                        contEditStu = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid Option !!!");
                        break;
                }
            }
            Functions.SaveData(students);
            Functions.LoadData(students);
        }
        return students;
    } 

    public List<Student> AddGrade(List<Student> students, string option, string msg){
        string studCod = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");

        Student stud = students.FirstOrDefault(s => s.Code.Equals(studCod));
        /* Console.WriteLine(stud); */
        if (stud == null){
            Console.WriteLine("There are no students in the database");
        } else {
            bool contGrad = true;
            while (contGrad) {
                switch (option)
                {
                    case "quiz":
                        stud.Quizzes.Add(float.Parse(Functions.GetExactVal("float", "1-4", "only numbers", "Quiz Grade #"+$"{stud.Quizzes.Count + 1}")));
                        contGrad = false;
                        break;
                    case "task":
                        stud.Tasks.Add(float.Parse(Functions.GetExactVal("float", "1-4", "only numbers", "Task Grade #"+$"{stud.Tasks.Count + 1}")));
                        contGrad = false;
                        break;
                    case "exam":
                        stud.Exams.Add(float.Parse(Functions.GetExactVal("float", "1-4", "only numbers", "Exam Grade #"+$"{stud.Exams.Count + 1}")));
                        contGrad = false;
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


    public List<Student> DeleteTask(List<Student> students, string option, string msg)
    {
        string studCod = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");
        Student stud = students.FirstOrDefault(s => s.Code.Equals(studCod));

        if (stud == null){
            Console.WriteLine("There are no students in the database");
        } else {
            bool contGrad = true;
            while (contGrad) {
                switch (option)
                {
                    case "quiz":
                        if (stud.Quizzes.Count < 1)
                        {
                            Console.WriteLine("There are no quizzes to delete, press a Key to return");
                            contGrad = false;
                            Console.ReadKey();
                        } else {
                            for (int q = 0; q < stud.Quizzes.Count; q++)
                            {
                                Console.WriteLine($"{q+1}) -> Quizz Grade: {stud.Quizzes[q]}");
                            }
                            bool contDelQuiz = true;
                            while (contDelQuiz)
                            {
                                byte quizInd = byte.Parse(Functions.GetExactVal("int", "1", "only numbers", "number of the quiz you want to Delete:"));
                                if (quizInd >= 1 && quizInd <= stud.Quizzes.Count)
                                {
                                    stud.Quizzes.RemoveAt(quizInd-1);
                                    contDelQuiz = false;
                                    contGrad = false;
                                } else
                                {
                                    Console.Write("Enter a number between [1-{0}] to delete this grade", stud.Quizzes.Count);
                                }
                            }
                        }
                        break;
                    case "task":
                        if (stud.Tasks.Count < 1)
                        {
                            Console.WriteLine("There are no Task to delete, press a Key to return");
                            contGrad = false;
                            Console.ReadKey();
                        } else {
                            for (int q = 0; q < stud.Tasks.Count; q++)
                            {
                                Console.WriteLine($"{q+1}) -> Task Grade: {stud.Tasks[q]}");
                            }
                            bool contDelTask = true;
                            while (contDelTask)
                            {
                                byte taskInd = byte.Parse(Functions.GetExactVal("int", "1", "only numbers", "number of the task you want to Delete:"));
                                if (taskInd >= 1 && taskInd <= stud.Tasks.Count)
                                {
                                    stud.Tasks.RemoveAt(taskInd-1);
                                    contDelTask = false;
                                    contGrad = false;
                                } else
                                {
                                    Console.Write("Enter a number between [1-{0}] to delete this grade", stud.Tasks.Count);
                                }
                            }
                        }
                        break;
                    case "exam":
                        if (stud.Exams.Count < 1)
                        {
                            Console.WriteLine("There are no Exam to delete, press a Key to return");
                            contGrad = false;
                            Console.ReadKey();
                        } else {
                            for (int q = 0; q < stud.Exams.Count; q++)
                            {
                                Console.WriteLine($"{q+1}) -> Exam Grade: {stud.Exams[q]}");
                            }
                            bool contDelExam = true;
                            while (contDelExam)
                            {
                                byte examInd = byte.Parse(Functions.GetExactVal("int", "1", "only numbers", "number of the task you want to Delete:"));
                                if (examInd >= 1 && examInd <= stud.Exams.Count)
                                {
                                    stud.Exams.RemoveAt(examInd-1);
                                    contDelExam = false;
                                    contGrad = false;
                                } else
                                {
                                    Console.Write("Enter a number between [1-{0}] to delete this grade", stud.Exams.Count);
                                }
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Opcion, plis enter a valid opcion !!!s");
                        break;
                }
            }
            int studPosi = students.FindIndex(stu => stu.Code.Equals(studCod));
            students[studPosi] = stud;
            Functions.SaveData(students);
            Functions.LoadData(students);
        }
        return students;
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