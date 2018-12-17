using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicScalesPractice
{
    class ScalesUtil
    {
        private List<Scale> scalesLst;

        public ScalesUtil()
        {
            //init Arrays
            string[] cMajorNt = { "C", "Dm", "Em", "F", "G", "Am", "Bdim" };
            string[] cDiezMajorNt = { "C#", "D#m", "E#m", "F#", "G#", "A#m", "B#dim" };
            string[] dMajorNt = { "D", "Em", "F#m", "G", "A", "Bm", "C#dim" };
            string[] eMajorNt = { "E", "F#m", "G#m", "A", "B", "C#m", "D#dim" };
            string[] fDiezMajorNt = { "F#", "G#m", "A#m", "B", "C#", "D#m", "E#dim" };
            string[] gMajorNt = { "G", "Am", "Bm", "C", "D", "Em", "F#dim" };
            string[] aMajorNt = { "A", "Bm", "C#m", "D", "E", "F#m", "G#dim" };
            string[] bMajorNt = { "B", "C#m", "D#m", "E", "F#", "G#m", "A#dim" };
            string[] fMajorNt = { "F", "Gm", "Am", "Bb", "C", "Dm", "Edim" };
            string[] bBemolMajorNt = { "Bb", "Cm", "Dm", "Eb", "F", "Gm", "A" };
            string[] eBemolMajorNt = { "Eb", "Fm", "Gm", "Ab", "Bb", "Cm", "Ddim" };
            string[] aBemolMajorNt = { "Ab", "Bbm", "Cm", "Db", "Eb", "Fm", "Gdim" };
            string[] dBemolMajorNt = { "Db", "Ebm", "Fm", "Gb", "Ab", "Bbm", "Cdim" };
            string[] gBemolMajorNt = { "Gb", "Abm", "Bbm", "Cb", "Db", "Ebm", "Fdim" };
            string[] cBemolMajorNt = { "Cb", "Dbm", "Ebm", "Fb", "Gb", "Abm", "Bbdim" };
            string[] aNaturalMinorNt = { "Am", "Bdim", "C", "Dm", "Em", "F", "G" };
            string[] eNaturalMinorNt = { "Em", "F#dim", "G", "Am", "Bm", "C", "D" };
            string[] bNaturalMinorNt = { "Bm", "C#dim", "D", "Em", "F#m", "G", "A" };
            string[] fDiezNaturalMinorNt = { "F#m", "G#dim", "A", "Bm", "C#m", "D", "E" };
            string[] cDiezNaturalMinorNt = { "C#m", "D#dim", "E", "F#m", "G#m", "A", "B" };
            string[] gDiezNaturalMinorNt = { "G#m", "A#dim", "B", "C#m", "D#m", "E", "F#" };
            string[] dDiezNaturalMinorNt = { "D#m", "E#dim", "F#", "G#m", "A#m", "B", "C#" };
            string[] aDiezNaturalMinorNt = { "A#m", "B#dim", "C#", "D#m", "E#m", "F#", "G#" };
            string[] dNaturalMinorNt = { "Dm", "Edim", "F", "Gm", "Am", "Bb", "C" };
            string[] gNaturalMinorNt = { "Gm", "Adim", "Bb", "Cm", "Dm", "Eb", "F" };
            string[] cNaturalMinorNt = { "Cm", "Ddim", "Eb", "Fm", "Gm", "Ab", "Bb" };
            string[] fNaturalMinorNt = { "Fm", "Gdim", "Ab", "Bbm", "Cm", "Db", "Eb" };
            string[] bBemolNaturalMinorNt = { "Bbm", "Cdim", "Db", "Ebm", "Fm", "Gb", "Ab" };
            string[] eBemolNaturalMinorNt = { "Ebm", "Fdim", "Gb", "Abm", "Bbm", "Cb", "Db" };
            string[] aBemolNaturalMinorNt = { "Abm", "Bbdim", "Cb", "Dbm", "Ebm", "Fb", "Gb" };
            string[] aHarmonicMinorNt = { "Am", "Bdim", "Caug", "Dm", "E", "F", "G#m" };
            string[] eHarmonicMinorNt = { "Em", "F#dim", "Gaug", "Am", "B", "C", "D#dim" };
            string[] bHarmonicMinorNt = { "Bm", "C#dim", "Daug", "Em", "F#", "G", "A#dim" };
            string[] fDiezHarmonicMinorNt = { "F#m", "G#dim", "Aaug", "Bm", "C#", "D", "E#dim" };
            string[] cDiezHarmonicMinorNt = { "C#m", "D#dim", "Eaug", "F#m", "G#", "A", "B#dim" };
            string[] gDiezHarmonicMinorNt = { "G#m", "A#dim", "Baug", "C#m", "D#", "E", "F#dim" };
            string[] dDiezHarmonicMinorNt = { "D#m", "E#dim", "F#aug", "G#m", "A#", "B", "Cxdim" };
            string[] aDiezHarmonicMinorNt = { "A#m", "B#dim", "C#aug", "D#m", "E#", "F#", "Gxdim" };
            string[] dHarmonicMinorNt = { "Dm", "Edim", "Faug", "Gm", "A", "Bb", "C#dim" };
            string[] gHarmonicMinorNt = { "Gm", "Adim", "Bbaug", "Cm", "D", "Eb", "F#dim" };
            string[] cHarmonicMinorNt = { "Cm", "Ddim", "Ebaug", "Fm", "G", "Ab", "Bbekardim" };
            string[] fHarmonicMinorNt = { "Fm", "Gdim", "Abaug", "Bbm", "C", "Db", "Ebekardim" };
            string[] bBemolHarmonicMinorNt = { "Bbm", "Cdim", "Dbaug", "Ebm", "F", "Gb", "Abekardim" };
            string[] eBemolHarmonicMinorNt = { "Ebm", "Fdim", "Gbaug", "Abm", "Bb", "Cb", "Dbekardim" };
            string[] aBemolHarmonicMinorNt = { "Abm", "Bbdim", "Cbaug", "Dbm", "Eb", "Fb", "Gbekardim" };
            string[] aMelodicMinorNt = { "Am", "Bm", "Caug", "D", "E", "F#dim", "G#dim" };
            string[] eMelodicMinorNt = { "Em", "F#m", "Gaug", "A", "B", "C#dim", "D#dim" };
            string[] bMelodicMinorNt = { "Bm", "C#m", "Daug", "E", "F#", "G#dim", "A#dim" };
            string[] fDiezMelodicMinorNt = { "F#m", "G#m", "Aaug", "B", "C#", "D#dim", "E#dim" };
            string[] cDiezMelodicMinorNt = { "C#m", "D#m", "Eaug", "F#", "G#", "A#dim", "B#dim" };
            string[] gDiezMelodicMinorNt = { "G#m", "A#m", "Baug", "C#", "D#", "E#dim", "Fxdim" };
            string[] dDiezMelodicMinorNt = { "D#m", "E#m", "F#aug", "G#", "A#", "B#dim", "Cxdim" };
            string[] aDiezMelodicMinorNt = { "A#m", "B#m", "C#aug", "D#", "E#", "Fxdim", "Gxdim" };
            string[] dMelodicMinorNt = { "Dm", "Em", "Faug", "G", "A", "Bbekardim", "C#dim" };
            string[] gMelodicMinorNt = { "Gm", "Am", "Bbaug", "C", "D", "Ebekardim", "F#dim" };
            string[] cMelodicMinorNt = { "Cm", "Dm", "Ebaug", "F", "G", "Abekardim", "Bbekardim" };
            string[] fMelodicMinorNt = { "Fm", "Gm", "Abaug", "Bb", "C", "Dbekardim", "Ebekardim" };
            string[] bBemolMelodicMinorNt = { "Bbm", "Cm", "Dbaug", "Eb", "F", "Gbekardim", "Abekardim" };
            string[] eBemolMelodicMinorNt = { "Ebm", "Fm", "Gbaug", "Ab", "Bb", "Cbekardim", "Dbekardim" };
            string[] aBemolMelodicMinorNt = { "Abm", "Bbm", "Cbaug", "Db", "Eb", "Fbekardim", "Gbekardim" };
            //init Scales
            scalesLst = new List<Scale>();
            scalesLst.Add(new Scale("C Major", cMajorNt));
            scalesLst.Add(new Scale("C# Major", cDiezMajorNt));
            scalesLst.Add(new Scale("D Major", dMajorNt));
            scalesLst.Add(new Scale("E Major", eMajorNt));
            scalesLst.Add(new Scale("F# Major", fDiezMajorNt));
            scalesLst.Add(new Scale("G Major", gMajorNt));
            scalesLst.Add(new Scale("A Major", aMajorNt));
            scalesLst.Add(new Scale("B Major", bMajorNt));
            scalesLst.Add(new Scale("F Major", fMajorNt));
            scalesLst.Add(new Scale("Bb Major", bBemolMajorNt));
            scalesLst.Add(new Scale("Eb Major", eBemolMajorNt));
            scalesLst.Add(new Scale("Ab Major", aBemolMajorNt));
            scalesLst.Add(new Scale("Db Major", dBemolMajorNt));
            scalesLst.Add(new Scale("Gb Major", gBemolMajorNt));
            scalesLst.Add(new Scale("Cb Major", cBemolMajorNt));
            scalesLst.Add(new Scale("A Natural Minor", aNaturalMinorNt));
            scalesLst.Add(new Scale("E Natural Minor", eNaturalMinorNt));
            scalesLst.Add(new Scale("B Natural Minor", bNaturalMinorNt));
            scalesLst.Add(new Scale("F# Natural Minor", fDiezNaturalMinorNt));
            scalesLst.Add(new Scale("C# Natural Minor", cDiezNaturalMinorNt));
            scalesLst.Add(new Scale("G# Natural Minor", gDiezNaturalMinorNt));
            scalesLst.Add(new Scale("D# Natural Minor", dDiezNaturalMinorNt));
            scalesLst.Add(new Scale("A# Natural Minor", aDiezNaturalMinorNt));
            scalesLst.Add(new Scale("D Natural Minor", dNaturalMinorNt));
            scalesLst.Add(new Scale("G Natural Minor", gNaturalMinorNt));
            scalesLst.Add(new Scale("C Natural Minor", cNaturalMinorNt));
            scalesLst.Add(new Scale("F Natural Minor", fNaturalMinorNt));
            scalesLst.Add(new Scale("Bb Natural Minor", bBemolNaturalMinorNt));
            scalesLst.Add(new Scale("Eb Natural Minor", eBemolNaturalMinorNt));
            scalesLst.Add(new Scale("Ab Natural Minor", aBemolNaturalMinorNt));
            scalesLst.Add(new Scale("A Harmonic Minor", aHarmonicMinorNt));
            scalesLst.Add(new Scale("E Harmonic Minor", eHarmonicMinorNt));
            scalesLst.Add(new Scale("B Harmonic Minor", bHarmonicMinorNt));
            scalesLst.Add(new Scale("F# Harmonic Minor", fDiezHarmonicMinorNt));
            scalesLst.Add(new Scale("C# Harmonic Minor", cDiezHarmonicMinorNt));
            scalesLst.Add(new Scale("G# Harmonic Minor", gDiezHarmonicMinorNt));
            scalesLst.Add(new Scale("D# Harmonic Minor", dDiezHarmonicMinorNt));
            scalesLst.Add(new Scale("A# Harmonic Minor", aDiezHarmonicMinorNt));
            scalesLst.Add(new Scale("D Harmonic Minor", dHarmonicMinorNt));
            scalesLst.Add(new Scale("G Harmonic Minor", gHarmonicMinorNt));
            scalesLst.Add(new Scale("C Harmonic Minor", cHarmonicMinorNt));
            scalesLst.Add(new Scale("F Harmonic Minor", fHarmonicMinorNt));
            scalesLst.Add(new Scale("Bb Harmonic Minor", bBemolHarmonicMinorNt));
            scalesLst.Add(new Scale("Eb Harmonic Minor", eBemolHarmonicMinorNt));
            scalesLst.Add(new Scale("Ab Harmonic Minor", aBemolHarmonicMinorNt));
            scalesLst.Add(new Scale("A Melodic Minor", aMelodicMinorNt));
            scalesLst.Add(new Scale("E Melodic Minor", eMelodicMinorNt));
            scalesLst.Add(new Scale("B Melodic Minor", bMelodicMinorNt));
            scalesLst.Add(new Scale("F# Melodic Minor", fDiezMelodicMinorNt));
            scalesLst.Add(new Scale("C# Melodic Minor", cDiezMelodicMinorNt));
            scalesLst.Add(new Scale("G# Melodic Minor", gDiezMelodicMinorNt));
            scalesLst.Add(new Scale("D# Melodic Minor", dDiezMelodicMinorNt));
            scalesLst.Add(new Scale("A# Melodic Minor", aDiezMelodicMinorNt));
            scalesLst.Add(new Scale("D Melodic Minor", dMelodicMinorNt));
            scalesLst.Add(new Scale("G Melodic Minor", gMelodicMinorNt));
            scalesLst.Add(new Scale("C Melodic Minor", cMelodicMinorNt));
            scalesLst.Add(new Scale("F Melodic Minor", fMelodicMinorNt));
            scalesLst.Add(new Scale("Bb Melodic Minor", bBemolMelodicMinorNt));
            scalesLst.Add(new Scale("Eb Melodic Minor", eBemolMelodicMinorNt));
            scalesLst.Add(new Scale("Ab Melodic Minor", aBemolMelodicMinorNt));
        }

        public Scale GetRandomScale()
        {
            Random rnd = new Random();
            return scalesLst.ElementAt(rnd.Next(scalesLst.Count - 1));
        }
    }
}
