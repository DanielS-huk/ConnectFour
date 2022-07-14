using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    public  class GamePeice
    {
        //public string Red { get; set; }
        //public string Green { get; set; }
        //public string Empty { get; set; }

        public GamePeice()
        {
        }

        public void RedGamePeice()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("__");
            Console.ResetColor();
        }
        public void GreenGamePeice()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("__");
            Console.ResetColor();
        }
        public void NoGamePeice()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("__");
            Console.ResetColor();
        }
        
        
    }
    
}
