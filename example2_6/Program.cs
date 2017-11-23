using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example2_6
{
    class Program
    {
        //正在 await 一批任务，希望在每个任务完成时对它做一些处理。另外，希望在任务一完成
        //就立即进行处理，而不需要等待其他任务
        static void Main(string[] args)
        {
            Porcess.ProcessTasksAsync();
            Console.WriteLine("执行完了");
            Console.ReadKey();
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class Porcess
    {
        static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }
        // 当前，此方法输出“2” ,“3” ,“1”。
        // 我们希望它输出“1” ,“2” ,“3”。
        public static async Task ProcessTasksAsync()
        {
            // 创建任务队列。
            Task<int> taskA = DelayAndReturnAsync(2);
            Task<int> taskB = DelayAndReturnAsync(3);
            Task<int> taskC = DelayAndReturnAsync(1);
            var tasks = new[] { taskA, taskB, taskC };
            // 按顺序 await 每个任务。
            foreach (var task in tasks)
            {
                var result = await task;
                Console.WriteLine(result);
            }

        }

    }
}
