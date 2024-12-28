using System.Text.Json;

namespace DeserializeJson
{
    internal class Program
    {
        /* convert a json file back to an object */
        static void Main(string[] args)
        {
            //Get a file stream instance using the JSON file
            StreamReader sr = File.OpenText("FileWithJsonSerialization");

            //Use a StreamReader to read entirety of the file
            // into a string variable named jsonString
            // hint: there should be a method -- ReadToEnd
            string jsonString = sr.ReadToEnd();

            //This is quick and dirty, tell the compiler to stop type checking variable object
            /*
                dynamic obj = JsonSerializer.Deserialize<object>(jsonString);

                Console.WriteLine($"FlagA: {obj.FlagA}, FlagB: {obj.FlagB}");
                Console.WriteLine($"StringC: {obj.StringC}, IntD: {obj.IntD}");
            */

            //this is C# way
            //paste as class and deserialize into instance of class
            DemoClass obj1 = JsonSerializer.Deserialize<DemoClass>(jsonString);
            Console.WriteLine($"FlagA: {obj1.FlagA}, FlagB: {obj1.FlagB}");
            Console.WriteLine($"StringC: {obj1.StringC}, IntD: {obj1.IntD}");

        }
    }

    public class DemoClass
    {
        public bool FlagA { get; set; }
        public bool FlagB { get; set; }
        public string StringC { get; set; }
        public int IntD { get; set; }
    }


}
