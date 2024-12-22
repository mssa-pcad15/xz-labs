using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnDelegate;

namespace LearnDelegateTest
{
    [TestClass]
    public class TeacherStudentTest
    {
        [TestMethod]
        public void TeacherHandlesStudentAskQuestion()
        {
            Teacher t = new();
            Student tom = new("Tom");
            Student alice = new("Alice");
            Student bob = new("Bob");

            /* student raises AskQuestion event and teacher subscribe this event, it doesn't invoke the event, only subscribe */
            tom.AskQuestion += t.AnswerQuestion;
            bob.AskQuestion += t.AnswerQuestion;
            alice.AskQuestion += t.AnswerQuestion; //using "event" keyword to prevent this code: "alice.AskQuestion = t.AnswerQuestion;" 
                                                   //cuz it overrides the previous event

            /* this invoke the event, because RaiseHand has invoke() method */
            tom.RaiseHand(); 
            bob.RaiseHand();
            alice.RaiseHand();
        }

        [TestMethod]

        public void StudentHandleTeacherFlippingTable()
        {
            Teacher t = new();
            Student tom = new("Tom");
            Student alice = new("Alice");
            Student bob = new("Bob");

            t.FlipsTable += tom.HandleTableFlip; //when teacher flips the table, student will handle this event
            t.FlipsTable += bob.HandleTableFlip; //when teacher flips the table, it raises the event of student flipping table
            t.FlipsTable += alice.HandleTableFlip; //when teacher flips the table, it raises the event of student flipping table

            t.GetsMad();
        }


        //        //coding prompt, when asked 10 questions, teacher gets mad
        //        //step 1: create a counter in Teacher Class that increments when student ask question
        //        //step 2: when the counter exceeds 10, teacher flips table
        [TestMethod]
        public void TeacherGetsMadAfter10Questions()
        {
            Teacher t = new();
            Student tom = new("tom");
            tom.AskQuestion += t.AnswerQuestion;
            t.FlipsTable += () => Debug.Print("Teacher flipped table");
            t.FlipsTable += tom.HandleTableFlip;

            for (int i = 0; i <= 10; i++)
            {
                tom.RaiseHand();
            }
        }
    }
    }
