using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class Errors
    {
        public void NotValidMove()
        {
            Console.WriteLine("*you tried to walk into the woods without a path, unfortunately the forrest is protected with magic which won't allow you to do this*");
        }

        public void NotValidCombination()
        {
            Console.WriteLine("*After some time you and some cursewords you realize these items cannot be combined*");
        }
        public void NotValidGift()
        {
            Console.WriteLine("*You tried to give the guard something they don't want*");
        }
        public void NotValidInput ()
        {
            try
            {
                Console.ReadLine();
            }
            catch (Exception)
            {

                Console.WriteLine("*oops! your input was invalid");
            }
        }
    }
}
