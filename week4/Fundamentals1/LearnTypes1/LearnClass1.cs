using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals1.LearnTypes1 //classes are organized under namespace, and the folder name also appears here
{
    public class LearnClass1
    {
        /*
         * fields
         */
        //public fields, should use pascal 
        public int InstanceMember;
        public static int StaticMember;
        //private fields, should use camelCasing with leading underscore
        private DateTime _dob;
        private string _password;


        /*
         * Properties
         */
        public int Age
        {
            get
            {
                return _dob.Year - DateTime.Now.Year;
            }
        }

        public string Password
        {
            set //password can't be accessed, but it can be set
            {
                /*++++++++++ value is implicitly defined by the compiler when working with a property that has a set 
                 * accessor in C#. The value keyword is a placeholder that represents the data being assigned to the
                 * property. When you assign a value to the property, the compiler automatically passes that value 
                 * into the set accessor using the value keyword.
                +++++++++++*/
                if (value.Length > 8 && value.Length < 15)
                    _password = value;
            }
        }

        /* 
         * Method 
         */
        //Password is not allowed to be read, but we can verify the password
        public bool VerifyPassword(string passwordToVerify)
        {
            return (this._password == passwordToVerify);
        }

        /* 
         * constructor
         */
        //string password="":  means password is passed in with a default value, so when
        //user created an obj of this LearnClass1, it is not mandatory to pass in this password
        public LearnClass1(DateTime dob, string password="")
        {
            this._password = password;
            this._dob = dob;    
        }
    }
}
