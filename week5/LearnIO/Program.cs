using System.Text;
using System.Text.Json;

namespace LearnIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] data = [1, 2, 3, 4, 67, 68, 69, 70];
            string happy = @"\(^ワ^)/"; //"ワ" is a unicode, it is not an ASCII code, so it can be 2 or more byes instead of 1 byte
            byte[] happyInBytes = Encoding.UTF8.GetBytes(happy);



            // | Use static method: File.Create to create a new file
            //CreateFile(data, happyInBytes);

            FileStream s1 = File.Create("FileWithBinaryWriter.bin");
            BinaryWriter bw = new BinaryWriter(s1); //the binary writer constructor must need to know what file stream it is writing into
            bw.Write(@"HelloWorld, \^~^/");
            bw.Write(true); //Binary Writer can write a boolean 
            bw.Write(int.MaxValue); ////Binary Writer can write an int
            bw.Flush(); //flush the buffer
            bw.Close(); //close the stream

            // | stream writer uses ToString() under the scene, it display the string representation
            FileStream s2 = File.Create("FileWithStreamWriter.bin");
            StreamWriter sw = new StreamWriter(s2,Encoding.UTF8);
            sw.WriteLine(@"HelloWorld, \^~^/");
            sw.Write(true);
            sw.Write(int.MaxValue);
            sw.WriteLine();
            sw.Flush();
            sw.Close();


            FileStream s3 = File.Create("FileWithJsonSerialization.txt");
            StreamWriter sw2 = new StreamWriter(s3, Encoding.UTF8);

            DemoClass serializeThis = new() { FlagA = true, FlagB = false, StringC = "Hello", IntD = 1000 };
            string jsonString = JsonSerializer.Serialize<DemoClass>(serializeThis, new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            });

            sw2.Write(jsonString);
            sw2.Flush();
            sw2.Close();


        }

        // | for demonstation that a Json Serializer takes an instance of the class and turn it into
        // a string that is human readable.
        public class DemoClass
        {
            public bool FlagA;
            public bool FlagB;
            public string StringC;
            public int IntD;
        }

        private static void CreateFile(byte[] data, byte[] happyInBytes)
        {
            FileStream s1 = File.Create("FileCreatedByStatic.txt"); //return a file stream
            s1.Write(data, 0, data.Length); //s1.Write(byte data I want to write, start from where, how many bytes I want to write)
            Console.WriteLine(s1.Position); //point at the last's next position of the byte data, which is after "70".
            s1.WriteByte(71); //"71" will be placed after "70"
            s1.Position = 0; //reset the position pointer to pisition 0
            s1.WriteByte(72); //write "72" to position 0

            s1.Position = 9;
            s1.Write(happyInBytes);

            s1.Close(); //When "Write", the content is written to memory buffer, after close, it flushes the buffer and written to the actual file.

            //Use the instance to create a new file
            FileInfo aNewFile = new FileInfo("FileCreatedByInstance.txt"); //return a file stream
            FileStream s2 = aNewFile.Create();
            s2.Write(data, 0, data.Length);
            s2.Close();
        }
    }
}
