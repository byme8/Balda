using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Balda
{
    class BaldaGame
    {
        String words;

        void AddToArray(ref Byte[] data, int k)
        {
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = (byte)k;
        }

        public BaldaGame()
        {   
            StreamReader file = new StreamReader("data.txt", Encoding.UTF8);
            words = file.ReadToEnd();
            file.Close();
        }


        //public bool botMove(char[][] matrix); 
        public bool CheckWord(string word)
        {
            if (words.IndexOf("\r\n" + word + "\r\n") == -1)
                return false;
            return true;
        }
    }
}
