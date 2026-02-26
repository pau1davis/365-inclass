using System;
using System.IO;

class Program {
    public static void Main() {
        string? keyfile;
        string? cryptfile;
        string? outputfile;

        FileStream kfin;
        FileStream cfin;
        StreamWriter writer;

        Console.Write("Enter key file: ");
        keyfile = Console.ReadLine();
        if (null == keyfile) {
            Console.WriteLine("Invalid key file.");
            return;
        }
        Console.Write("Enter crypt file: ");
        cryptfile = Console.ReadLine();
        if (null == cryptfile) {
            Console.WriteLine("Invalid crypt file.");
            return;
        }
        Console.Write("Enter output file: ");
        outputfile = Console.ReadLine();
        if (null == outputfile) {
            Console.WriteLine("Invalid output file.");
            return;
        }

        try {
            var kstream = File.Open(keyfile, FileMode.Open);
            kfin = new(kstream);
        }
        catch (IOException ex) {
            Console.WriteLine(ex.Message);
            return;
        }

        try {
            var cstream = File.Open(cryptfile, FileMode.Open);
            cfin = new(cstream);

        }
        catch (IOException ex) {
            Console.WriteLine(ex.Message);
            return;
        }

        try {
            writer = new StreamWriter(outputfile);

        }
        catch (IOException ex) {
            Console.WriteLine(ex.Message);
            return;
        }

        byte[] key = File.ReadAllBytes(keyfile);
        byte[] crypt = File.ReadAllBytes(cryptfile);

        for(int i = 0; i < crypt.Length; i++)
        {
            char c = (char)(crypt[i] ^ key[i % key.Length]);
            writer.Write(c);
        }

        kfin.Close();
        cfin.Close();
        writer.Close();

    }
}
