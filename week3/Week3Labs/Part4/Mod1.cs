namespace Part4
{
    internal class Mod1
    {
        internal static void IntegralTypes()
        {
            //signed 
            Console.WriteLine("Signed integral types:");

            Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}"); //signed byte
            Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}: {sizeof(long)}");

            //unsigned
            Console.WriteLine("Unsigned integral types:");

            Console.WriteLine($"byte  : {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"ushort  : {ushort.MinValue} to {ushort.MaxValue}");
            Console.WriteLine($"uint    : {uint.MinValue} to {uint.MaxValue}");
            Console.WriteLine($"ulong   : {ulong.MinValue} to {ulong.MaxValue}");
            ulong l = ulong.MaxValue;
            Console.WriteLine(++l); //overflow, compiler doesn't report error here is because
                                    //compiler can't run line by line yet to determine what value is l
                                    //Console.WriteLine(ulong.MaxValue + 1); -- but if I directly add 1 to "MaxValue", the compiler doesn't need to do any
                                    //calculation and it already knows it is the MaxValue

        }


        internal static void FloatingTypes()
        {
            Console.WriteLine("Floating point types:");
            Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
            Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
            Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
        }

        #region ValueType and How Stack works
        internal static void ValueTypeAndStack()
        {
            Console.WriteLine("This is in the method 'ValueTypeAndStack'");
            int a = 1;
            Console.WriteLine("Calling Method2()");
            Method2();
            Console.WriteLine($"'ValueTypeAndStack': a is {a}");
        }

        internal static void Method2()
        {
            Console.WriteLine("This is in method 'Method2'");
            int a = 2;
            Console.WriteLine("Calling method3()");
            Method3();
            Console.WriteLine($"'Method2:' a is {a}");
        }

        internal static void Method3()
        {
            Console.WriteLine("This is in method 'Method3'");
            int a = 3;
            Console.WriteLine($"'Method3:' a is {a}");
        }
        #endregion

        internal static void ReferenceTypeAndHeap()
        {
            Console.WriteLine("In method 'ReferenceTypeAndHeap'");
            int[] a = [1, 2, 3];
            Console.WriteLine("Calling Method2Ref");
            Method2Ref();
            foreach (int i in a) Console.Write(i);
            Console.WriteLine("");
        }
        internal static void Method2Ref()
        {
            Console.WriteLine("In method 'Method2Ref'");
            int[] a = [3, 4, 5];
            Console.WriteLine("Calling Method3Ref");
            foreach (int i in a) Console.Write(i);
            Console.WriteLine("");
        }
        internal static void Method3Ref()
        {
            Console.WriteLine("In method 'Method3Ref'");
            int[] a = [6, 7, 8];
            foreach (int i in a) Console.Write(i);
            Console.WriteLine("");
        }
    }
}