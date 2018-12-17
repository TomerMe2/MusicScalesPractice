using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicScalesPractice
{
    class Scale
    {
        private string name;
        private string[] notes;

        public Scale(string name, string[] notes)
        {
            this.name = name;
            this.notes = notes;
           
        }

        public override string ToString()
        {
            string toReturn = name + ": ";
            foreach (string note in notes)
            {
                toReturn += note + " ";
            }
            //Returns with an extra space at the end
            return toReturn;
        }

        /// <summary>
        /// Returns a string of a note in the given degree
        /// </summary>
        public string GetNoteInDeg(int deg)
        {
            return notes[deg - 1];
        }

        public string GetScaleName()
        {
            return name;
        }
    }
}
