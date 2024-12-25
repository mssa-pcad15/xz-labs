using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Requirement:
   Write a function that takes in a string of one or more words, returns the same string
   but with all words that have 5 or more letters reversed. String passed in only contains
   letters and spaces. Spaces will be included only when more than one word is present.
 
 Examples:
   "Hey fellow warriors" --> "Hey wollef sroirraw"
   "This is a test" --> "This is a test"
   "This is another test" --> "This is rehtona test"
 */

namespace LearnDelegate
{
    public class Kata
    {
        public static string SpinWords(string input)
        {
            return new SpinWordSolver(input).Reversed;
        }
    }

    internal class SpinWordSolver
    {
        // | private fields
        private string _initialString = string.Empty;
        private readonly int lengthOfWordsToSpin;

        // | properties
        public string Reversed
        {
            get {
                string[] splitted = _initialString.Split(' ');
                Func<string[], string> processor =
                    (words) => //words is each element in spliited[]: ["Hey", "fellow", "warriors"]
                    {
                        for (int i = 0; i < words.Length; i++) // "Hey"
                        {
                            if (words[i].Length >= lengthOfWordsToSpin)
                                // Reverse() is an extension method in System.Linq namespace, operates on
                                // objects that implement IEnumerable<T>, it doesn't return string directly,
                                // it returns an IEnumerable<char> sequence, ToArray() turns this sequence
                                // into an char array
                                words[i] = new string(words[i].Reverse().ToArray());
                        }
                        return string.Join(' ', words); //join the string with ' ' as delimiter
                    };

                return processor.Invoke(splitted); //equivalent to "return processor(splitted);"
            }
            
         }   
    
        // | constructor
        internal SpinWordSolver(string input, int lengthOfWordsToSpin = 5) //add a length of 5 in constructor, in case in the
                                                       //following code, when omitted it will take this default value of 5
        {
            this._initialString = input;
            this.lengthOfWordsToSpin = lengthOfWordsToSpin;
        }
    }
}
