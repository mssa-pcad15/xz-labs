using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDelegate
{
    public class Teacher
    {
        public int _counter = 0;

        /* ################ use delegate declaration ################# */
        /* public event delFlipTable? FlipsTable; */ // this line declares a field named FlipsTable, "?" indicate
                                                     // delegate field is nullable at this point, FlipsTable is a
                                                     // delegate field that does not yet point to any method. It’s
                                                     // just a placeholder.
                                                     // add "event" keyword to prevent overwrite, which can only use
                                                     // "+=" and "-="
        /* ################ use delegate declaration ################# */

        public event Action? FlipsTable;


        public void AnswerQuestion(Student who, string question)
        {
            if (++_counter > 10)
            {
                GetsMad();
                return;
            }
            who.Listen($"Good Question, {who.Name}");
        }

        public void GetsMad()
        {
            FlipsTable?.Invoke(); //In "TeacherStudentTest.cs" file, there is an implementation for FlipsTable
        }
    }



    public class Student(string _name) //primary constructor, introduced in C# 12, combine 
                                       //declaration of the class and its constructor into a single, compact syntax
    {
        /* ################ use delegate declaration ################# */
        /* public event delAskQuestion AskQuestion; */
        /* ################ use delegate declaration ################# */
        public event Action<Student, String> AskQuestion; //add "event" keyword turn field into event, doesn't allow override

        public string Name => _name; //property

        public void Listen(string Answer)
        {
            Debug.WriteLine(Answer); //it helps in debug mode to see which student raise the question
        }

        public void RaiseHand()
        {
            AskQuestion.Invoke(this, "What is delegate"); //explicitly invoke delegate mathod "AskQuestion"
        }

        public void HandleTableFlip()
        {
            if (DateTime.Now.Ticks % 2 == 0)//There are 10,000 ticks in a millisecond and 1,000,000 ticks in a second
            {
                Debug.WriteLine($"{Name} is handling flipping tables");
            }
            else {
                Debug.WriteLine($"{Name} is not doing anything when teacher flips tables");
            }
        }
    }

    /* delegate is declared under namespace, not inside a class  */
    //public delegate void delAskQuestion(Student who, string question); -- retired this delegate declaration in favor of Action Delegate
    //public delegate void delFlipTable(); -- retired this delegate declaration in favor of Action Delegate
}
