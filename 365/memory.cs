using System;
class Program
{
    static unsafe void WriteMemoryLocations(byte[] arr)
    {
        // Pointers to references must be "pinned" as either
        // 1. GCHandleType.Pinned in a GCHandle.Alloc
        // 2. fixed() block
        fixed(byte* p = &arr[0]){

            byte* element = p;
            for (int i = 0; i < arr.Length; i+=1)
            {
                Console.WriteLine("arr[{0}] at 0x{1:X}",
                i, (uint)element, *element);
                element += 1;
            }
            element = p;
            for (int i = 0;i < arr.Length;i+=1) {
                byte* ptr = element + i;
                Console.WriteLine($"arr[{arr[i]}] = {*ptr}");
            }
        }
    }
    static void Main()
    {
        string line;
        int num;
        Console.Write("How many values? ");
        line = Console.ReadLine() ?? "-1";
        try {
            num = int.Parse(line);
        }
        catch {
            Console.WriteLine("Invalid number of values.");
            return;
        }
        if (num <= 0) {
            Console.WriteLine("No values to give.");
            return;
        }
        byte[] arr = new byte[num];
        Console.WriteLine("Enter values.");
        for (int i = 0;i < arr.Length;i+=1) {
            try {
                arr[i] = byte.Parse(Console.ReadLine() ?? "0");
            }
            catch {
                arr[i] = 0;
            }
        }
        unsafe {
            WriteMemoryLocations(arr);
        }
    }
}

