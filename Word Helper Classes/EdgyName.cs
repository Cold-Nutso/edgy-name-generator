using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ----------------------
// All Name Combinations:
// ----------------------
/*
// Legend:
// ADJ  - Adjective
// SING - Singular noun (hasPlural == true)
// PLUR - Plural noun (hasPlural == true)
// NOUN - Singular noun (hasPlural == false)
// VERB - Singular noun (verbBased == true)
*/
public enum NameStyle
{
    AdjNoun,   // ADJ SING - ADJ NOUN
    NounNoun,  // SING SING - SING NOUN - NOUN SING - NOUN NOUN
    PosNoun    // SING's SING - SING's NOUN - NOUN's SING - NOUN's NOUN
}

namespace Edgy_Name_Generator
{
    public class EdgyName
    {
        // Fields

        private NameStyle style;
        private string tempAdj;
        private NounPair tempNounA;
        private NounPair tempNounB;



        // Properties

        public NameStyle Style { get { return style; } }
        public Object FirstWord
        {
            get
            {
                if (style == NameStyle.AdjNoun)
                    return tempAdj;
                else
                    return tempNounA;
            }
            set
            {
                if (style == NameStyle.AdjNoun)
                    tempAdj = (string)value;
                else
                    tempNounA = (NounPair)value;
            }
        }
        public NounPair SecondWord { get { return tempNounB; } set { tempNounB = value; } }
        public string Full 
        { 
            get 
            {
                if (style == NameStyle.AdjNoun)
                    return $"{tempAdj} {tempNounB.Singular}";
                else if (style == NameStyle.NounNoun)
                    return $"{tempNounA.Singular} {tempNounB.Singular}";
                else if (style == NameStyle.PosNoun)
                    return $"{tempNounA.Singular}'s {tempNounB.Singular}";
                else
                    return "Butter Boy";
            }
        }



        // Constructor

        public EdgyName(string firstWord, NounPair secondWord, NameStyle style = NameStyle.AdjNoun)
        {
            if (style != NameStyle.AdjNoun)
                style = NameStyle.AdjNoun;

            this.style = style;
            tempAdj = firstWord;
            tempNounB = secondWord;
        }
        public EdgyName(NounPair firstWord, NounPair secondWord, NameStyle style = NameStyle.NounNoun)
        {
            if (style == NameStyle.AdjNoun)
                style = NameStyle.NounNoun;

            this.style = style;
            tempNounA = firstWord;
            tempNounB = secondWord;
        }



        // Methods

        public void CycleStyle()
        {
            if (style == NameStyle.NounNoun)
                style = NameStyle.PosNoun;
            else if (style == NameStyle.PosNoun)
                style = NameStyle.NounNoun;
        }

        public void SwapNouns()
        {
            if (style != NameStyle.AdjNoun)
            {
                NounPair extremelyTempNoun = tempNounA;
                tempNounA = tempNounB;
                tempNounB = extremelyTempNoun;
            }
        }
    }
}
