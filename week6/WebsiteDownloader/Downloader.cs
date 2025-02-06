using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteDownloader
{
    internal class Downloader
    {
        /* constructor */
        public Downloader(Uri website)
        {
            Website = website;
            _httpClient = new HttpClient();
        }

        /* private field */
        private HttpClient _httpClient; //_httpClient needs to be accessed multiple times within this 
                                        //Downloader class, hence declare it as private field. Moreover,
                                        //declare it as a private field eliminate the trouble to create
                                        //an object each time within the class.

        /* property */
        public Uri Website { get; } //Declare Website as a public property because 1. it doesn't needs to 
                                    //be reused constantly within a class. It is simply a data passed to
                                    //the constructor and expose as it is. 2. it needs to be accessed by 
                                    //external class. 
        public byte[] ResultBytes { get; set; }

        /* method to asynchronously download these website's html */
        internal async Task<int> DownloadAsync() //Task<int> means that the asynchronous method will
                                                 //return an int value once the task is completed.
        {
            ResultBytes = await _httpClient.GetByteArrayAsync(Website);
            Console.WriteLine($"{Website.ToString()} received. {ResultBytes.Length} bytes");
            // | Use Guid to avoid Filename Collisions: Each call generates a unique filename (e.g.,
            // f47ac10b-58cc-4372-a567-0e02b2c3d479), ensuring files don’t overwrite each other. 
            // Use Guid also avoid manually assign unique names for each file.
            // Guid, (Globally Unique Identifier) is a 128-bit value used to uniquely identify something,
            // such as a file, database record, or resource, in a distributed system.
            string fileName = Path.GetRandomFileName();
            await File.WriteAllBytesAsync(fileName, ResultBytes);
            Console.WriteLine($"{fileName} written to disk.");
            return ResultBytes.Length;
        }
    }
}
