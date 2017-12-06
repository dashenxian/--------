using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace example2_6
{
    class Program
    {
        //正在 await 一批任务，希望在每个任务完成时对它做一些处理。另外，希望在任务一完成
        //就立即进行处理，而不需要等待其他任务
        static void Main(string[] args)
        {
            PorcessShijianShunxu.ProcessTasksAsync();
            Console.WriteLine("执行完了");
            Console.ReadKey();
        }

    }
    /// <summary>
    /// 顺序添加执行
    /// </summary>
    public class PorcessShunxu
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
    /// <summary>
    /// 按先返回先执行
    /// </summary>
    public class PorcessShijianShunxu
    {
        static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }
        static async void Runtask(Task<int> task)
        {
            var result = await task;
            Console.WriteLine(result);
        }
        public async static Task ProcessTasksAsync()
        {
            var task1 = DelayAndReturnAsync(2);
            var task2 = DelayAndReturnAsync(3);
            var task3 = DelayAndReturnAsync(1);
            var tasks = new[] { task1, task2, task3 };

            var pro = tasks.Select(async t =>
           {
               var result = await t;
               Console.WriteLine(result);
           }).ToList();
            await Task.WhenAll(tasks);
        }
        public async static Task ProcessTasksAsync2()
        {
            var task1 = DelayAndReturnAsync(2);
            var task2 = DelayAndReturnAsync(3);
            var task3 = DelayAndReturnAsync(1);
            var tasks = new[] { task1, task2, task3 };

            //var pro = tasks.Select(async t =>
            //{
            //    Runtask(t);
            //}).ToList();
            foreach (var task in tasks)
            {
                Runtask(task);
            }
            await Task.WhenAll(tasks);
        }
        public async static Task ProcessTasksAsync3()
        {
            var task1 = DelayAndReturnAsync(2);
            var task2 = DelayAndReturnAsync(3);
            var task3 = DelayAndReturnAsync(1);
            var tasks = new[] { task1, task2, task3 };
            //扩展方法OrderByCompletion
            //foreach (var task in tasks.OrderByCompletion)
            //{
            //    var result = await task;
            //    Console.WriteLine(result);
            //}
            await Task.WhenAll(tasks);
        }
    }

    sealed class MyAsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        async void ICommand.Execute(object parameter)
        {
            await Execute(parameter);
        }
        public async Task Execute(object parameter)
        {
            // 这里实现异步操作。
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        // 其他成员（CanExecute 等）。
    }
}
