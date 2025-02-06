/*
 Write a program that downloads a list of website html to files
using async methods.

HttpClient.GetAsync()
File class

https://google.com
https://msn.com
https://yahoo.com
https://abc.com

extra bonus Task.WaitAll(Task[]) Task.WaitAny(Task[])
 */

/*
 Thinking process:
1. Input: Download this list of websites
2. Output: Save each website'html to a separate file 
3. Logic: 
   - Use HttpClient.GetAsync() to make HTTP GET request
   - Save the response to a file using File class
   - Use parallel to download these websites at the same time
   - Use TaskWaitAll() to ensure all tasks are completed before proceeding to anything else
   - Use TaskWaitAny() to detect when any single task is completed
4. Handle errors:
   - Use try catch to handle errors occur during request and response, S.A. network issue, file writing issue
 */

// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using WebsiteDownloader;


// | creating a new Uri object for each website in the sitesUrl array because each URL
// represents a distinct resource (each resource or object has different features)
Uri[] sitesUrl = [new Uri("https://google.com"),
                  new Uri("https://msn.com"),
                  new Uri("https://yahoo.com"),
                  new Uri("https://abc.com")];

// | use a concurrent queue (thread safe) to handle adding urls into the queue
ConcurrentQueue<Downloader> downloadersQueue = new ConcurrentQueue<Downloader>();    
// | add urls to queue at once using parallel
Parallel.ForEach(sitesUrl, site => downloadersQueue.Enqueue(new Downloader(site)));

// | use a list for storing each "Task", because each "Download.DownloadAsync" returns a task
List<Task<int>> downloadTasks = new();
while (!downloadersQueue.IsEmpty)
{
    if (downloadersQueue.TryDequeue(out Downloader downloader))
        downloadTasks.Add(downloader.DownloadAsync());
}

/* 
 * WhenAll() takes multiple tasks and returns a task which is completed when all the provided tasks have
 * completed.WhenAll() doesn't block the calling thread. It works in Asynchronous code.
 */
await Task.WhenAll(downloadTasks);
int totalBytes = downloadTasks.Sum(d=>d.Result); //each d is a task, and each task has a Result property
Console.WriteLine($"All sites downloaded, {totalBytes} bytes written.");