using System.Threading.Tasks;

namespace Lab22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            object a = Convert.ToInt32(Console.ReadLine());
            

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, a);
            Action<Task<int[]>> action = new Action<Task<int[]>>(GetSumma);
            Task task2 = task1.ContinueWith(action);
            Action<Task<int[]>> action2 = new Action<Task<int[]>>(GetMax);
            Task task3 = task1.ContinueWith(action2);
            task1.Start();
            task2.Wait();
            task3.Wait();
            Console.WriteLine("Конец метода Main");


        }

        static int[] GetArray (object a) 
        {

            int n = (int)a;
          
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 15);
                
            }  
            return array;
        }
        static void GetSumma(Task<int[]> task)
        {
            int[] array= task.Result;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" {0:00} ", array[i]);
                sum += array[i];
                
            }
            Console.WriteLine();
            Console.WriteLine(sum);
            
        }

        static  void GetMax(Task<int[]> task2)
        {
            int[] array = task2.Result;
            int max = array[0];
            for (int i = 0; i < array.Length; i++) 
            {
                if (array[i] > max) 
                {
                    
                    max = array[i];
                }
            }
            Console.WriteLine(max);
        }


        
    }
}
