namespace Part4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mod1.IntegralTypes();
            //Mod1.FloatingTypes();
            //Mod1.ValueTypeAndStack();
            //Mod1.Method2();
            //Mod1.Method3();
            //Mod1.ReferenceTypeAndHeap();
            //Mod1.Method2Ref();
            //Mod1.Method3Ref();
            //Mod2.ExerciseDataConversion();
            //Challenge1.CombineStringArray();
            //Challenge2.OutputSpecificNumberTypes();
            Mod3.ArrayMethods();

            // | pass by value
            int a = 0;
            int b = a;
            a += 5;
            Console.WriteLine($"a:{a}, b:{b}"); //output: a:5, b:0

            // | pass by reference
            int[] c = [0, 1];
            int[] d = c;
            c[0] += 5;
            Console.WriteLine($"c: {c[0]}, d:{d[0]}"); //output: a:5, d:5

        }
    }
}
