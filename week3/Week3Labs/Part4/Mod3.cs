using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part4
{
    internal class Mod3
    {
        internal static void ArrayMethods()
        {
            // | array slice
            int[] arrayVar = [7, 5, 8, 11, 3, 6];
            foreach(int i in arrayVar[0..2]) //only want to loop from index 0 to index 1
            {
                Console.WriteLine(i); //output: 7, 5
            }
            foreach(int i in arrayVar[..2]) 
            {
                Console.WriteLine(i); //output: 7, 5
            }
            foreach (int i in arrayVar[5..])
            {
                Console.WriteLine(i); //output: 6
            }
            foreach(int i in arrayVar[..^0]) //^0 represents the end of the array (exclusive).
            {
                Console.WriteLine(i); //output: 7, 5, 8, 11, 3, 6
            }
            foreach (int i in arrayVar[^2..]) //^2 represents second-to-last element in the array
            //^2.. specifies a range starting from the second-to-last element and going to the end of the array.
            {
                Console.WriteLine(i); //output: 3, 6
            }

            int[] subArray = arrayVar[3..6]; //return a new array, not a reference
            int[] arrayVarDeepCopy = arrayVar[..]; //deep copy: copy the elements
            int[] arrayVarShallowCopy = arrayVar;//shallow: copy only the reference


            // | Sort() method
            Array.Sort(arrayVar); //Array sort() method is an in-place method        
            foreach(int i in arrayVar)
            {
                Console.Write($"{i},");
            }
            Console.WriteLine();


            // | Clear() method
            string[] pallets = ["B14", "A11", "B12", "A13"];
            Console.WriteLine("");

            Console.WriteLine($"Before: {pallets[0].ToLower()}");
            Array.Clear(pallets, 0, 2);//Clear() method doesn't remove the address of the element where it locates, it only clear the value of the element
            /*Console.WriteLine($"After: {pallets[0].ToLower()}");*/  // -- xxx: null referece exception

            Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
            foreach (var pallet in pallets)
            {
                Console.WriteLine($"-- {pallet}");
            }


            // | Resize() method
            string[] pallets1 = ["B14", "A11", "B12", "A13"];
            Console.WriteLine("");

            Array.Clear(pallets1, 0, 2);
            Console.WriteLine($"Clearing 2 ... count: {pallets1.Length}");
            foreach (var pallet in pallets1)
            {
                Console.WriteLine($"-- {pallet}");
            }

            Console.WriteLine("");
            /*++++++++++++++++ 
             * keyword "ref": tell compiler that after resize pallets1 to 6, point to another new block of address
             * ref can be used in pass by reference.
             ++++++++++++++++ */
            Array.Resize(ref pallets1, 6);
            Console.WriteLine($"Resizing 6 ... count: {pallets1.Length}");

            pallets1[4] = "C01";
            pallets1[5] = "C02";

            foreach (var pallet in pallets1)
            {
                Console.WriteLine($"-- {pallet}");
            }

            Console.WriteLine("");
            Array.Resize(ref pallets1, 3);
            Console.WriteLine($"Resizing 3 ... count: {pallets1.Length}");

            foreach (var pallet in pallets1)
            {
                Console.WriteLine($"-- {pallet}");
            }


            //| Reverse() and Join() methods
            string value = "abc123";
            char[] valueArray = value.ToCharArray();
            Array.Reverse(valueArray);
            string result = new String(valueArray);
            result = String.Join(",", valueArray); //output: 3,2,1,c,b,a
            Console.WriteLine(result);

            // | Split() method
            string value1 = "abc123";
            char[] valueArray1 = value.ToCharArray();
            Array.Reverse(valueArray1);
            // string result = new string(valueArray);
            string result1 = String.Join(",", valueArray1);
            Console.WriteLine(result1);
            string[] items = result1.Split(',');
            foreach (string item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
