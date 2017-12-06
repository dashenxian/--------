using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace example3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(1, 0, 1, 0, 1, 0);
            RotateMatrices(new List<Matrix> { matrix }, 0.5f);
            int i = 0;
            foreach (var item in matrix.Elements)
            {
                Console.Write(item);
                i++;
                if (i==2)
                {
                    Console.WriteLine();
                    i = 0;
                }
                else
                {
                    Console.Write(",");
                }
                
            }
            Console.ReadKey();
        }
        static void RotateMatrices(IEnumerable<Matrix> matrix, float degree)
        {
            Parallel.ForEach(matrix, (mat,state) =>
            {        if (state.IsStopped)
                {

                }
                mat.Rotate(degree);
        
            });
        }

    }
}
