/*
    Answer to bolded questions:

    Number of 0 letter words: 0
    Number of 1 letter words: 0
    Number of 2 letter words: 96
    Number of 3 letter words: 972
    Number of 4 letter words: 3903
    Number of 5 letter words: 8636
    Number of 6 letter words: 15232
    Number of 7 letter words: 23109
    Number of 8 letter words: 28419
    Number of 9 letter words: 24792
    Number of 10 letter words: 20194
    Number of 11 letter words: 15407
    Number of 12 letter words: 11273
    Number of 13 letter words: 7781
    Number of 14 letter words: 5100
    Number of 15 letter words: 3178
    Number of 16 letter words: 0
    Number of 17 letter words: 0
    Number of 18 letter words: 0
    Number of 19 letter words: 0
    Number of 20 letter words: 0
    Median word: LUMBERS 
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace CS;

public class IO {
    public static void IOMain() {
        List<string> words = ReadWordsList("words.txt");
        for (int i = 0; i <= 20; i++)
        {
            Console.WriteLine("Number of " + i + " letter words: " + NumWordsWithSpecificLength(words, i));
            Console.WriteLine();
        }
        Console.WriteLine("Median word: " + MedianWord(words));
    }

    public static List<string> ReadWordsList(string filename)
    {
        List<string> result = new List<string>();
        using (StreamReader input = new StreamReader(filename))
        {
            while (!input.EndOfStream)
            {
                string line = input.ReadLine();
                result.Add(line);
            }
        }
        return result;
    }
    
    public static int NumWordsWithSpecificLength(List<string> words, int length)
    {
        int cnt = 0;
        for(int i = 0; i < words.Count; i++)
        {
            if (words[i].Length == length) cnt++;
        }
        return cnt;
    }

    public static string MedianWord(List<string> words)
    {
        int length = words.Count;
        //even length
        if(words.Count % 2 == 0)
        {
            return words[length / 2];
        }
        //odd length
        else
        {
            string word1 = words[length/2];
            string word2 = words[length/2 + 1];
            if (word1.Length <= word2.Length) return word1;
            else return word2;
        } 
    }
}