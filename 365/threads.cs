using System;
using System.Threading.Tasks;

class Program {
    public static void Main() {
        //Console.Write("Enter number of threads: ");
        string? line = Console.ReadLine();
        if (string.IsNullOrEmpty(line)) {
            Console.WriteLine("Invalid input.");
            return;
        }
        int num;
        try {
            num = int.Parse(line);
        } 
        catch {
            Console.WriteLine("Invalid number of threads.");
            return;
        }
        int i;
        int v = 0;
        Task<int>[] threads = new Task<int>[num];
        for(i = 0; i < num; i++){
            threads[i] = Task.Run(() => {
                int iterator;
                int to = 10_000_000 * (i + 5);
                for(iterator = 0; iterator < to; iterator++){
                    v += 1;
                }
                return iterator;
            });
        }
        threads[0].Wait();
        for(int j = 0; j < num; j++){
            Console.WriteLine($"Task {j} finished, got {threads[j].Result}.");
        }
    }
}
