using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Balda
{
    class BaldaGame
    {
        String words;//тут будуть всі слова
        bool curpl = true;

        public bool FirstPlayer
        {
            get
            {
                return curpl;
            }
        }

        //void AddToArray(ref Byte[] data, int k)
        //{
        //    Array.Resize(ref data, data.Length + 1);
        //    data[data.Length - 1] = (byte)k;
        //}
        public string GetRandWord()
        {
            Random rand = new Random();
            int pos = rand.Next(0,words.Length-100);
            string answer = "";

            while (words[pos] != '\n') pos++;
            pos++;

            while (words[pos] != '\r')
            {
                answer += words[pos];
                pos++;
            }

            return answer;
        }
        public void NextPlayer()
        {
            curpl = !curpl;
        }
        public BaldaGame(string pathToDic = "data.txt")
        {   
            //откриваем поток і загружаем всі слова
            StreamReader file = new StreamReader(pathToDic, Encoding.UTF8);
            words = file.ReadToEnd();
            file.Close();
        }


        //public bool botMove(char[][] matrix); bot 
                                              //буде пізніше

        public bool CheckWord(string word)//чи існує слово word?
        {
            if (words.IndexOf("\r\n" + word + "\r\n") == -1)
                return false;
            return true;
        }
    }
}
