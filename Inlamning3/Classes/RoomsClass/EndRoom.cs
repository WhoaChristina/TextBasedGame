using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Inlamning3.Classes
{ 
    public class EndRoom: Room
    {
        string endFileOnePiece = @"c:\\temp\\EndStory1Piece.txt"; 
        string endFileAssembled = @"c:\\temp\\EndStoryAssembled.txt";
        string endFileNotAssembled = @"c:\\temp\\EndStoryNotAssembled.txt";
        public EndRoom()
        {
            Paths = 1;
            PathFinding.Add(Direction.South, 2);
        }
        public override void EndRoomStory(List<Items> inventory) //beroende på vad som finns i din inventory så kommer spelet att avslutas (eller inte) med olika storys
        {
            bool foundPiece1 = false;
            bool foundPiece2 = false;
            bool foundHat = false;
            foreach (var item in inventory)
            {
                List<string> endStory = new List<string>();
                if (item is Hat)
                {
                    foundHat = true;
                    using (StreamReader read = new StreamReader(endFileAssembled))
                    {
                        string row;
                        while ((row = read.ReadLine()) != null)
                        {
                            endStory.Add(row);

                        }
                    }
                    foreach (var rows in endStory)
                    {
                        Console.WriteLine(rows);
                    }
                    Actions.gameDone = true;
                }
                else if (item is HatPiece1)
                {
                    foundPiece1 = true;
                }
                else if (item is HatPiece2)
                {
                    foundPiece2 = true;
                }
            }
            List<string> story = new List<string>();
            if (foundPiece1 && foundPiece2)
            {
                using (StreamReader read = new StreamReader(endFileNotAssembled))
                {
                    string row;
                    while ((row = read.ReadLine()) != null)
                    {
                        story.Add(row);
                    }
                    foreach (var rows in story)
                    {
                        Console.WriteLine(rows);
                    }
                    Actions.gameDone = true;
                }
            }
            else if (foundPiece1 || foundPiece2)
            {
                using (StreamReader read = new StreamReader(endFileOnePiece))
                {
                    string row;
                    while ((row = read.ReadLine()) != null)
                    {
                        story.Add(row);
                    }
                }
                foreach (var rows in story)
                {
                    Console.WriteLine(rows);
                }
            }
            else if (foundHat != true)
            {
                Console.WriteLine("maybe you should look a little bit harder and then come back here");
            }
        }
    }
}
