using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    internal class Challenge4SortStringTagErrors
    {
        internal static void SortStringTagErrors()
        {
            string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";

            string[] orderIDs = orderStream.Split(",");

            //foreach (string orderID in orderIDs)
            //{
            //}
            Array.Sort(orderIDs);

            foreach (string id in orderIDs)
            {
                if (id.Length == 4)
                    Console.WriteLine(id);
                else 
                    Console.WriteLine(id+"\t- ERROR");
            }
            }
        }
    }
