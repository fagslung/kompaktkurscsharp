using System;
using System.IO; // importiert FileStream und StreamWriter

namespace Kompaktkurs {
    
    class Program {
        
        static void Main(string[] args) {
            //Console.WriteLine("Hello World!");
            //string[] a = { "Anton", "Berta", "Caesar" };
            //for (int i = 0; i < a.Length; i++) {
            //    Console.WriteLine("a[{0,5f}] = {1}", i, a[i]);
            //}

            FileStream s = new FileStream("myfile.txt", FileMode.Create);
            StreamWriter w = new StreamWriter(s);
            for (int i = 0; i < 10; i++)
                w.WriteLine("{0,3}: {1,5}", i, i * i);
            w.Close(); // nötig, damit der letzte Ausgabepuffer geleert wird
        }

    }
}
