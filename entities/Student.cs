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
        newStudent.Email = Functions.GetExactVal("strEmail", "3,40", "Example: correo@correo.com, only letters, numbers and(@,-,_,.)", "student Email");
        newStudent.Address = Functions.GetExactVal("strDir", "3,40", "only letters, numbers and(#,-,_,.)", "student Address");
        try
        {
            students.Add(newStudent);
            Functions.SaveData(students);
            Console.WriteLine("student updated successfully");
        }
        catch (Exception er)
        {
            Console.WriteLine($"Error Info: {er}");
        } 
        return students;
    }  

    public List<Student> DeleteStud(List<Student> students){
        if (students.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            string StuId = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");

            Student studRemo = students.FirstOrDefault(stud => (stud.Code ?? string.Empty).Equals(StuId)) ?? new Student();

            /* Console.WriteLine((studRemo.Name).GetType()); */
            if (studRemo.Code == null)
            {
                Console.WriteLine("There is no student with that code !!!");
            } else {
                Console.WriteLine($"Student Name: {studRemo.Name}");
                try
                {
                    students.Remove(studRemo);
                    Functions.SaveData(students);
                    Console.WriteLine("Student Successfully removed");
                }
                catch (Exception er)
                {
                    Console.WriteLine($"Error Info: {er}");
                }  
            }
        }
        Console.WriteLine("Pres a Key to Continue...");
        Console.ReadKey();
        return students;
    } 

    public List<Student> UpdateStud(List<Student> students){
        if (students.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            string StuId = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");
            Student studRemo = students.FirstOrDefault(stud => (stud.Code ?? string.Empty).Equals(StuId)) ?? new Student();
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
                    Console.WriteLine("{0,3} {1,3}", $"{contDataStu+1})", "-> Back to Student Menu\t"); 
                    Console.WriteLine();
                    byte resEdiStu =  Byte.Parse(Functions.GetExactVal("int", "1", "only numbers", "number of the Option you want: "));
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
                            Console.WriteLine("Enter a valid Option !!!, press a key to Continuae.");
                            Console.ReadKey();
                            break;
                    }
                }
                try
                {
                    Functions.SaveData(students);
                    Console.WriteLine("student updated successfully");
                }
                catch (Exception er)
                {
                    Console.WriteLine($"Error Info: {er}");
                } 
            }
        }
        Console.WriteLine("Pres a Key to Continue...");
        Console.ReadKey();
        return students;
    } 

    public void ListStud(List<Student> lista){
        if (lista.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("{0,-16} {1, -41} {2, -5} {3,-41} {4,3}" , "Code", "Name", "Age", "Email", "Address");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (Student stud in lista)
            {
                Console.WriteLine("{0,-16} {1, -41} {2, -5} {3,-41} {4,3}", stud.Code, stud.Name, stud.Age, stud.Email, stud.Address);
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine();
        Console.WriteLine("Pres a Key to Continue.");
        Console.ReadKey();
    }

    public List<Student> AddGrade(List<Student> students, string option, string msg){
        if (students.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            string studCod = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");
            Student stud = students.FirstOrDefault(s => s.Code.Equals(studCod));
            if (stud == null){
                Console.WriteLine("There is no students whit than code..");
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

                try
                {
                    Functions.SaveData(students);
                    Console.WriteLine("Student grade added successfully.");
                }
                catch (Exception er)
                {
                    Console.WriteLine($"Error Info: {er}");
                } 
            }
        }
        Console.WriteLine("Pres a Key to Continue...");
        Console.ReadKey();
        return students;
    }  

    public List<Student> UpdateStuGrade(List<Student> students, string gradeOpti){
        if (students.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            string StuId = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");
            Student student = students.FirstOrDefault(stud => (stud.Code ?? string.Empty).Equals(StuId)) ?? new Student();
            if (student.Code == null)
            {
                Console.WriteLine("There is no student with that code !!!");
            } else {
                /* bool contEditGra = true; */
                Console.Clear();
                Console.WriteLine($"Student Name: {student.Name}\n");
                Console.WriteLine();
                switch (gradeOpti)
                {
                    case "quiz":
                        if (student.Quizzes.Count >= 1)
                        {
                            bool contEdiQuiz = true;
                            while (contEdiQuiz)
                            {
                                Console.Clear();
                                Console.WriteLine($"Number of quizzes: {student.Quizzes.Count}");
                                for (int q = 0; q < student.Quizzes.Count; q++)
                                {
                                    Console.WriteLine("{0,3} {1,3} {2,3}", $"{q+1})", $"-> Update Quiz:\t", student.Quizzes[q]); 
                                }
                                Console.WriteLine("{0,3} {1,3}", $"{student.Quizzes.Count+1})", "-> Back to Edit Grade Menu\t"); 
                                Console.WriteLine();
                                byte resEdiQuiz =  Byte.Parse(Functions.GetExactVal("int", "1", "only numbers", "number of the Option you want: "));

                                if (resEdiQuiz >= 1 && resEdiQuiz <= student.Quizzes.Count)
                                {   student.Quizzes.RemoveAt(resEdiQuiz-1);
                                    student.Quizzes.Add(float.Parse(Functions.GetExactVal("float", "1-4", "only numbers", "new Quiz Grade")));
                                    Console.WriteLine("Quiz edit successfully !!!");
                                    Functions.SaveData(students);
                                } else if (resEdiQuiz == student.Quizzes.Count+1)
                                {
                                    contEdiQuiz = false;
                                } else
                                {
                                    Console.WriteLine("Enter a valid Option !!!, press a key to Continuae.");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        } else
                        {
                           Console.WriteLine("There are no quizzes to edit !!!");
                        }                        
                        break;
                    case "task":
                        if (student.Tasks.Count >= 1)
                        {
                            bool contEdiTask = true;
                            while (contEdiTask)
                            {
                                Console.Clear();
                                Console.WriteLine($"Number of Tasks: {student.Tasks.Count}");
                                for (int t = 0; t < student.Tasks.Count; t++)
                                {
                                    Console.WriteLine("{0,3} {1,3} {2,3}", $"{t+1})", $"-> Update Task:\t", student.Tasks[t]); 
                                }
                                Console.WriteLine("{0,3} {1,3}", $"{student.Tasks.Count+1})", "-> Back to Edit Grade Menu\t"); 
                                Console.WriteLine();
                                byte resEdiTask =  Byte.Parse(Functions.GetExactVal("int", "1", "only numbers", "number of the Option you want: "));

                                if (resEdiTask >= 1 && resEdiTask <= student.Tasks.Count)
                                {   student.Tasks.RemoveAt(resEdiTask-1);
                                    student.Tasks.Add(float.Parse(Functions.GetExactVal("float", "1-4", "only numbers", "new Task Grade")));
                                    Console.WriteLine("Task edit successfully !!!");
                                    Functions.SaveData(students);
                                } else if (resEdiTask == student.Tasks.Count+1)
                                {
                                    contEdiTask = false;
                                } else
                                {
                                    Console.WriteLine("Enter a valid Option !!!, press a key to Continuae.");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        } else
                        {
                           Console.WriteLine("There are no Tasks to edit !!!");
                        }                        
                        break;
                    case "exam":
                        if (student.Exams.Count >= 1)
                        {
                            bool contEdiExam = true;
                            while (contEdiExam)
                            {
                                Console.Clear();
                                Console.WriteLine($"Number of Exams: {student.Exams.Count}");
                                for (int e = 0; e < student.Exams.Count; e++)
                                {
                                    Console.WriteLine("{0,3} {1,3} {2,3}", $"{e+1})", $"-> Update Exam:\t", student.Exams[e]); 
                                }
                                Console.WriteLine("{0,3} {1,3}", $"{student.Exams.Count+1})", "-> Back to Edit Grade Menu\t"); 
                                Console.WriteLine();
                                byte resEdiExam =  Byte.Parse(Functions.GetExactVal("int", "1", "only numbers", "number of the Option you want: "));

                                if (resEdiExam >= 1 && resEdiExam <= student.Exams.Count)
                                {   student.Exams.RemoveAt(resEdiExam-1);
                                    student.Exams.Add(float.Parse(Functions.GetExactVal("float", "1-4", "only numbers", "new Exam Grade")));
                                    Console.WriteLine("Exam edit successfully !!!");
                                    Functions.SaveData(students);
                                } else if (resEdiExam == student.Exams.Count+1)
                                {
                                    contEdiExam = false;
                                } else
                                {
                                    Console.WriteLine("Enter a valid Option !!!, press a key to Continuae.");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        } else
                        {
                           Console.WriteLine("There are no Exams to edit !!!");
                        }                        
                        break;
                    default:
                        break;
                }
            }
        }
        Console.WriteLine("Pres a Key to Continue...");
        Console.ReadKey();
        return students;
    } 

    public List<Student> DeleteStuGra(List<Student> students, string option, string msg)
    {
        if (students.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            string studCod = Functions.GetExactVal("int", "2,15", "only numbers", "student Code");
            Student stud = students.FirstOrDefault(s => s.Code.Equals(studCod));
            if (stud == null){
                Console.WriteLine("There is no students whit than code..");
            } else {
                bool contGrad = true;
                while (contGrad) {
                    switch (option)
                    {
                        case "quiz":
                            if (stud.Quizzes.Count < 1)
                            {
                                Console.WriteLine("There are no quizzes to delete !!!.");
                                contGrad = false;
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
                                        Console.WriteLine("Quiz successfully deleted.");
                                    } else
                                    {
                                        Console.WriteLine("Enter a number between [1-{0}] to delete this grade", stud.Quizzes.Count);
                                    }
                                }
                            }
                            break;
                        case "task":
                            if (stud.Tasks.Count < 1)
                            {
                                Console.WriteLine("There are no Task to delete !!!.");
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
                                        Console.WriteLine("Task successfully deleted.");
                                    } else
                                    {
                                        Console.WriteLine("Enter a number between [1-{0}] to delete this grade", stud.Tasks.Count);
                                    }
                                }
                            }
                            break;
                        case "exam":
                            if (stud.Exams.Count < 1)
                            {
                                Console.WriteLine("There are no Exam to delete !!!.");
                                contGrad = false;
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
                                        Console.WriteLine("Exam successfully deleted.");
                                    } else
                                    {
                                        Console.WriteLine("Enter a number between [1-{0}] to delete this grade", stud.Exams.Count);
                                    }
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Opcion !!!");
                            Console.WriteLine("Pres a Key to Continue...");
                            Console.ReadKey();
                            break;
                    }
                }
                int studPosi = students.FindIndex(stu => stu.Code.Equals(studCod));
                students[studPosi] = stud;
                Functions.SaveData(students);
            }
        }
        Console.WriteLine("Pres a Key to Continue...");
        Console.ReadKey();
        return students;
    }

    public void StuGradeList(List<Student> lista,  string quizzNots, string tasksNots, string examsNots){
        if (lista.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {           
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("{0,-16} {1, -52} {2, -30} {3, -25} {4, 16}" , "Code", "Name", "Quizzes", "Tasks", "Exams");
            Console.WriteLine();
            foreach (Student stud in lista)
            {
                quizzNots = "";
                tasksNots = "";
                examsNots = "";
                if(stud.Quizzes.Count >= 1 ){
                    foreach(var quiz in stud.Quizzes) {
                        quizzNots+= $"{quiz} -  ";
                    }
                    quizzNots = quizzNots.Substring(0,quizzNots.Length - 4);
                } else {
                    quizzNots = "There are no quiz grades";
                }
                if(stud.Tasks.Count >= 1 ){
                    foreach(var task in stud.Tasks) {
                        tasksNots+= $"{task} -  ";
                    }
                    tasksNots = tasksNots.Substring(0,tasksNots.Length - 4);
                } else {
                    tasksNots = "There are no Task grades";
                }
                if(stud.Exams.Count >= 1 ){
                    foreach(var exam in stud.Exams) {
                        examsNots+= $"{exam} -  ";
                    }
                    examsNots = examsNots.Substring(0,examsNots.Length - 4);
                } else {
                    examsNots = examsNots = "There are no Exam grades";
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("{0,-16} {1, -41} {2, -34} {3, -34} {4, 20}", stud.Code, stud.Name, $"[ {quizzNots} ]", $"[ {tasksNots} ]", $"[ {examsNots} ]");
            }       
        }
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine();
        Console.WriteLine("Pres a Key to Continue...");
        Console.ReadKey();
    }  

    public void StuReporCard(List<Student> lista, float quizGra, float tasksGra, float examsGra, float finalNot){
        if (lista.Count() < 1) {
            Console.WriteLine("There are no students in the database");
        } else {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("{0,-16} {1, -41} {2, -20} {3, -20} {4, -20} {5, 8}" , "Code", "Name", "Final Quiz Grade", "Final Task Grade", "Final Exam Grade", "Final Grade");
            Console.WriteLine();
            foreach (Student stud in lista)
            {
                float fquizGra = 0;
                float ftasksGra = 0;
                float fexamsGra = 0;
                quizGra = 0;
                tasksGra = 0;
                examsGra = 0;
                if(stud.Quizzes.Count >= 1 ){
                    foreach(var quiz in stud.Quizzes) {
                        float fquiz = Convert.ToSingle(quiz);
                        quizGra+= fquiz;
                    }
                    fquizGra = (((quizGra/4)*25)/100);
                }
                if(stud.Tasks.Count >= 1 ){
                    foreach(var task in stud.Tasks) {
                        float ftask = Convert.ToSingle(task);
                        tasksGra+= ftask;
                    }
                    ftasksGra = (((tasksGra/2)*15)/100);
                }
                if(stud.Exams.Count >= 1 ){
                    foreach(var exam in stud.Exams) {
                        float fexam = Convert.ToSingle(exam);
                        examsGra+= fexam;
                    }
                    fexamsGra = (((examsGra/3)*60)/100);
                }
                finalNot = fquizGra + ftasksGra + fexamsGra;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("{0,-16} {1, -44} {2, -23} {3, -18} {4, -16} {5, 8}", stud.Code, stud.Name, $"[ {Math.Round(fquizGra,2)} ]", $"[ {Math.Round(ftasksGra,2)} ]", $"[ {Math.Round(fexamsGra,2)} ]", $"[ {Math.Round(finalNot,2)} ]");
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine();
        Console.WriteLine("Pres a Key to Continue...");
        Console.ReadKey();
    }


}
