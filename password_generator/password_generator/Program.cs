using System.Threading.Tasks;
using System;

const string letters = "QWERTYUIPASDFGHJKLZXCVBNMqwertyuipasdfghjklzxcvbnm";
const string numbers = "123456789";
const string symbols = "@#%^&*()_-+~<>?/";

int num_letters = 5;
int num_numbers = 3;
int num_symbols = 3;

Task[] tasks = new Task[3];

tasks[0] = new Task(() => Generator(1, num_letters));
tasks[1] = new Task(() => Generator(2, num_numbers));
tasks[2] = new Task(() => Generator(3, num_symbols));

Console.Write("Your password: ");

foreach (var task in tasks)
{ 
task.Start();
}

Task.WaitAll(tasks);
Console.WriteLine();


static void Generator (int type, int col)
{
  
    Random r = new Random();
switch (type){ 
    
    case 1:
            for (int i = 0; i < col; i++)
            {
                Console.Write(letters[r.Next(letters.Length)]);
                Thread.Sleep(100);
            }
            break;
    case 2:
            for (int i = 0; i < col; i++)
            {
                Console.Write(numbers[r.Next(numbers.Length)]);
                Thread.Sleep(100);
            }
            break ;
    case 3:
            for (int i = 0; i < col; i++)
            {
                Console.Write(symbols[r.Next(symbols.Length)]);
                Thread.Sleep(100);
            }
            break ;
    }

}