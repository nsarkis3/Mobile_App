using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CS;

public class IO {
    public static void IOMain() {
        int cnt = 0;
        // The using statement ensure the StreamReader
        // is correctly disposed.
        using (StreamReader input = new StreamReader("words.txt")) {
            while (!input.EndOfStream) {
                string line = input.ReadLine();
                cnt++;
            }
        }
        Console.WriteLine(cnt);
    }
}