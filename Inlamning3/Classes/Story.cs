using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Inlamning3.Classes
{
    public class Story
        
    {
        string startFile = @"c:\\temp\\StartStory.txt";

        public List<string> StoryLine ()
        {
            
            List<string> story = new List<string>();
            using (StreamReader read = new StreamReader(startFile))
            {
                string row;
                while ((row = read.ReadLine())!=null)
                {
                    story.Add(row);

                }
            }
            return story;
        }
        public void Start()
        {
            List<string> startStory = StoryLine();
            foreach (var row in startStory)
            {
                Console.WriteLine(row);
            }
        }
        public void End ()
        {
            //när spelet är avklarat
        }
        public void PigGuardInteraction()
        {
            //interaktion med vakten
        }
    }
}
