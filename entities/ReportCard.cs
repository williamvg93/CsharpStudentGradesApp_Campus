using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentGrades.entities
{
    public class ReportCard
    {
        List<float> quizzes = new List<float>();    
        List<float> tasks = new List<float>();
        List<float> exams = new List<float>();
        
    
        public ReportCard(){}

        public ReportCard(List<float> quizzes, List<float> tasks, List<float> exams ){
            this.quizzes = quizzes;
            this.tasks = tasks;
            this.exams = exams;
        }

        public List<float> Quizzes {
            get => quizzes;
            set => quizzes = value;
        }
        public List<float> Tasks {
            get => tasks;
            set => tasks = value;
        }
        public List<float> Exams {
            get => exams;
            set => exams = value;
        }
    }
}