using System;
using System.IO;

struct Data {
    public int a;
    public double b;
    public float c;
}

class Program {
    public static void Main() {
        BinaryReader fin;
        string? filename;
        Console.Write("Enter filename: ");
        filename = Console.ReadLine();
        if (null == filename) {
            Console.WriteLine("Invalid filename given.");
            return;
        }
        try {
            // O_CREAT = FileMode.Create, O_CREAT | O_EXCL = FileMode.CreateNew
            var stream = File.Open(filename, FileMode.Open);
            fin = new(stream);
        }
        catch (IOException ex) {
            Console.WriteLine(ex.Message);
            return;
        }
        //byte for char
        Data data;
        // 1. Read the 32-bit integer first
        data.a = fin.ReadInt32();
        // 2. Read the double second
        data.b = fin.ReadDouble();
        // 3. Read the float third
        data.c = fin.ReadSingle(); // float

        Console.WriteLine($"{data.a}, {data.b}, {data.c}");
        fin.Close();
    }
}

