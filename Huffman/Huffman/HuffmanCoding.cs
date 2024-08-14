using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HuffmanCoding
{
    class HuffmanCoding
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "ABABBCBBDEEE";
                HuffmanCoding hc = new HuffmanCoding();
                string encoded = hc.Encode(input);
                string decoded = hc.Decode(encoded);

                Console.WriteLine($"Original string: {input}");
                Console.WriteLine($"Encoded string: {encoded}");
                Console.WriteLine($"Decoded string: {decoded}");
                Console.ReadKey();
            }
        }

        FreqTable table;
        HuffmanTree tree;
        List<HuffmanTree> queue;
        Dictionary<char, string> code;
        private int Length;
        public HuffmanCoding()
        {
        }
        private void Traverse(HuffmanTree t, char c, ref string s)
        {
            if (t.left == null && t.right == null)
            {
                if (t.c.Contains(c.ToString()))
                {
                    return;
                }
            }
            else if (t.left.c.Contains(c.ToString()))
            {
                s = s + "0";
                Traverse(t.left, c, ref s);
            }
            else if (t.right.c.Contains(c.ToString()))
            {
                s = s + "1";
                Traverse(t.right, c, ref s);
            }
        }
        public string Encode(string input)
        {
            tree = new HuffmanTree();
            queue = new List<HuffmanTree>();
            code = new Dictionary<char, string>();
            table = new FreqTable(input);
            Length = input.Length;
            foreach (char c in table.GetSymbols)
            {
                HuffmanTree t = new HuffmanTree();
                t.c = c.ToString();
                t.frequency = table[c];
                queue.Add(t);
            }

            queue.Sort();
            while (queue.Count > 1)
            {
                HuffmanTree t = new HuffmanTree();
                t.left = queue[0];
                t.right = queue[1];
                t.c = queue[0].c + queue[1].c;
                t.frequency = t.left.frequency + t.right.frequency;
                queue.RemoveRange(0, 2);
                queue.Add(t);
                queue.Sort();
            }

            tree = queue[0];

            foreach (char c in table.GetSymbols)
            {
                string codeword = "";
                Traverse(tree, c, ref codeword);
                code.Add(c, codeword);
            }

            StringBuilder returnString = new StringBuilder();

            foreach (char c in input)
            {
                returnString.Append(code[c]);
            }

            return returnString.ToString();
        }
        public string Decode(string encodedString)
        {
            int i = 0;
            HuffmanTree T = tree; //Start from root
            string result = ""; //decoded string
            while (i < encodedString.Length)
            {
                if (encodedString[i] == '0')
                    T = T.left;
                else
                    T = T.right;
                if (T.c.Length == 1)
                {
                    result += T.c;
                    T = tree;
                }
                i++;
            }
            return result;
        }
        public int GetFrequency(char c)
        {
            return int.Parse(table[c].ToString());
        }
        public string GetCodeword(char c)
        {
            return code[c];
        }
        public double AverageBit
        {
            get
            {
                double t = 0;
                foreach (char c in code.Keys)
                {
                    t += (table[c] * (code[c].Length));
                }
                t = t / Length;
                return t;
            }
        }
        public string Symbols
        {
            get
            {
                string t = "";
                foreach (char c in code.Keys)
                {
                    t = t + c;
                }
                return t;
            }
        }
    }
    class FreqTable
    {
        private Hashtable table;
        public FreqTable(string input)
        {
            table = new Hashtable();
            for (int i = 0; i < input.Length; i++)
            {
                char t = input[i];
                if (table.ContainsKey(t))
                    table[t] = (int)table[t] + 1;
                else
                    table.Add(t, 1);
            }

        }
        public int this[char c]
        {
            get
            {
                return int.Parse(table[c].ToString());
            }
        }
        public char[] GetSymbols
        {
            get
            {
                List<char> chars = new List<char>();
                foreach (char c in table.Keys)
                    chars.Add(c);
                return chars.ToArray();
            }
        }
    }

    class HuffmanTree : IComparable
    {
        public string c;
        public int frequency;
        public HuffmanTree left = null, right = null;

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return frequency.CompareTo(((HuffmanTree)(obj)).frequency);
        }

        #endregion
    }
}