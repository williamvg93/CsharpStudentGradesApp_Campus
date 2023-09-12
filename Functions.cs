using System;
using System.Text.RegularExpressions;
using studentGrades.entities;


namespace studentGrades
{
    public class Functions
    {
        
        public static byte MainMenu(){
            Console.Clear();
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
            return Byte.Parse(Console.ReadLine());
        }

        public static byte StudentMenu(){
            Console.Clear();
            Console.WriteLine("{0,30}", " Manage Student \n");
            Console.WriteLine("{0,3}", " 1) -> Add Student");
            Console.WriteLine("{0,3}", " 2) -> View Student List");
            Console.WriteLine("{0,3}", " 3) -> Back to Main Menu");
            Console.WriteLine("Enter the number of the option you want: ");
            return Byte.Parse(Console.ReadLine());
        }
        public static string GetExactVal(string valType, string dataLen, string msgRestric, string msg){
            string newData = null;
            string regExp = valType == "str" ? "^[a-zA-ZÀ-ÿ\u00f1\u00d1]{"+dataLen+"}$" : "^[0-9]{"+dataLen+"}$";
            Console.WriteLine(regExp);

            bool contGetExa = true;
            while (contGetExa)
            {
                Console.WriteLine($"Enter the {msg}");
                newData = Console.ReadLine();
                Console.WriteLine(newData);
                if (Regex.IsMatch(newData, @regExp))
                {
                    contGetExa = false;
                } else {
                        Console.WriteLine($"{msgRestric} are allowed, The {msg} must be at least {dataLen} characters");   
                }
            }
            return newData;
        }

    }
}

/* 
^[\s\S]{0,25}$
usuario: /^[a-zA-Z0-9\_\-]{4,16}$/, // Letras, numeros, guion y guion_bajo
nombre: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
password: /^.{4,12}$/, // 4 a 12 digitos.
correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
telefono: /^\d{7,14}$/ // 7 a 14 numeros.
 */