using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSATest.Queue
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void EnqueueTenThings()
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < 10; i++) { 
                queue.Enqueue(i);
            }

            Assert.AreEqual(10, queue.Count);
            Assert.AreEqual(0, queue.Peek());
            Assert.AreEqual(10, queue.Count);
            Assert.AreEqual(0, queue.Dequeue());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(7, queue.Count);
        }

        [TestMethod]
        public async Task AsyncEnqueueLotsOfItems()
        {
            Queue<int> queue = new Queue<int>();
            /*
             These are tasks (on going things to do), 1 thread is the worker who is working on these tasks
             COMPARED with "Parallel" below
             */
            InsertItemAsync(queue, 10);
            InsertItemAsync(queue, 10);
            InsertItemAsync(queue, 10);
            InsertItemAsync(queue, 10);
            InsertItemAsync(queue, 10);
            

            Assert.AreEqual(100, queue.Count);
        }

        [TestMethod]
        public async Task ConcurrentEnqueueLotsOfItemsAsync()
        {
            Queue<int> queue = new Queue<int>();
            /*  
             This is Parallel, think of as 5 threads (5 workers), each of them work on 1 task at the same time
             COMPARED with "InsertItemAsync()" above    
             When each thread calls InsertItemAsync(queue, 10), will not cause race condition, because 
             there is no shared resource, but when each thread tries to stick 10 items into queue, race
             condition will occur because queue is a shared resource(not thread safe).
             */
            Parallel.For(0, 5, loopCounter => InsertItemAsync(queue, 10)); //InsertItemAsync(queue, 10) is called 5 times
            Assert.AreEqual(50, queue.Count);


            Assert.AreEqual(100, queue.Count);
        }

        private async Task InsertItemAsync(Queue<int> queue, int numberOfItem) {
            for (int i = 0; i < numberOfItem; i++) { 
                queue.Enqueue(i);
                Task.Delay(100).Wait();
            }
        }
    }
}
