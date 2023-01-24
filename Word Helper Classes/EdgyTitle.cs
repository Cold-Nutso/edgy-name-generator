using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// -----------------------
// All Title Combinations:
// -----------------------
/*
// Legend:
// ADJ  - Adjective
// SING - Singular noun (hasPlural == true)
// PLUR - Plural noun (hasPlural == true)
// NOUN - Singular noun (hasPlural == false)
// VERB - Singular noun (verbBased == true)
*/
public enum TitleStyle
{
    TheAdjNoun,       // the ADJ SING - the ADJ NOUN 
    TheNounNoun,      // the SING SING - the SING NOUN - the NOUN SING - the NOUN NOUN
    ThePosNoun,       // the SING's SING - the SING's NOUN - NOUN's SING - NOUN's NOUN
    NounOfTheNoun,    // SING of the SING - SING of NOUN - NOUN of the SING - NOUN of NOUN
    TheNounOfTheNoun, // the SING of the SING - the SING of NOUN - the NOUN of the SING - the NOUN of NOUN
    NounOfPlur,       // SING of PLUR - NOUN of PLUR
    NounOfThePlur,    // SING of the PLUR - NOUN of the PLUR
    TheNounOfPlur,    // the SING of PLUR - the NOUN of PLUR
    NounOfTheAdj      // SING of the ADJ - NOUN of the ADJ
}

namespace Edgy_Name_Generator
{
    public class EdgyTitle
    {
        // Fields

        private TitleStyle style;
        private string tempAdj;
        private NounPair tempNounA;
        private NounPair tempNounB;



        // Properties

        public TitleStyle Style { get { return style; } }
        public Object FirstWord
        {
            get
            {
                if (style == TitleStyle.TheAdjNoun)
                    return tempAdj;
                else
                    return tempNounA;
            }
            set
            {
                if (style == TitleStyle.TheAdjNoun)
                    tempAdj = (string)value;
                else
                    tempNounA = (NounPair)value;
            }
        }
        public Object SecondWord
        {
            get
            {
                if (style == TitleStyle.NounOfTheAdj)
                    return tempAdj;
                else
                    return tempNounB;
            }
            set
            {
                if (style == TitleStyle.NounOfTheAdj)
                    tempAdj = (string)value;
                else
                    tempNounB = (NounPair)value;
            }
        }
        public string Full 
        { 
            get 
            {
                switch (style)
                {
                    case TitleStyle.TheAdjNoun:
                        return $"The {tempAdj} {tempNounB.Singular}";

                    case TitleStyle.TheNounNoun:
                        return $"The {tempNounA.Singular} {tempNounB.Singular}";

                    case TitleStyle.ThePosNoun:
                        if (tempNounA.HasPlural)
                            return $"The {tempNounA.Singular}'s {tempNounB.Singular}";
                        else
                            return $"{tempNounA.Singular}'s {tempNounB.Singular}";

                    case TitleStyle.NounOfTheNoun:
                        if (tempNounB.HasPlural)
                            return $"{tempNounA.Singular} of the {tempNounB.Singular}";
                        else
                            return $"{tempNounA.Singular} of {tempNounB.Singular}";

                    case TitleStyle.TheNounOfTheNoun:
                        if (tempNounB.HasPlural)
                            return $"The {tempNounA.Singular} of the {tempNounB.Singular}";
                        else
                            return $"The {tempNounA.Singular} of {tempNounB.Singular}";

                    case TitleStyle.NounOfPlur:
                        if (tempNounB.HasPlural)
                            return $"{tempNounA.Singular} of {tempNounB.Plural}";
                        else
                            return $"{tempNounA.Singular} of {tempNounB.Singular}";

                    case TitleStyle.NounOfThePlur:
                        if (tempNounB.HasPlural)
                            return $"{tempNounA.Singular} of the {tempNounB.Plural}";
                        else
                            return $"{tempNounA.Singular} of the {tempNounB.Singular}";

                    case TitleStyle.TheNounOfPlur:
                        if (tempNounB.HasPlural)
                            return $"The {tempNounA.Singular} of {tempNounB.Plural}";
                        else
                            return $"The {tempNounA.Singular} of {tempNounB.Singular}";

                    case TitleStyle.NounOfTheAdj:
                        return $"{tempNounA.Singular} of the {tempAdj}";

                    default:
                        return "Boy of Butter";
                }
            }
        }



        // Constructors

        public EdgyTitle(string firstWord, NounPair secondWord, TitleStyle style = TitleStyle.TheAdjNoun)
        {
            this.style = style;
            tempAdj = firstWord;
            tempNounB = secondWord;
        }
        public EdgyTitle(NounPair firstWord, NounPair secondWord, TitleStyle style = TitleStyle.TheNounNoun)
        {
            this.style = style;
            tempNounA = firstWord;
            tempNounB = secondWord;
        }
        public EdgyTitle(NounPair firstWord, string secondWord, TitleStyle style = TitleStyle.NounOfTheAdj)
        {
            this.style = style;
            tempNounA = firstWord;
            tempAdj = secondWord;
        }



        // Methods

        public void CycleStyle()
        {
            if (style == TitleStyle.TheAdjNoun)
            {
                tempNounA = tempNounB;
                tempNounB = null;
                style = TitleStyle.NounOfTheAdj;
            }
            else if (style == TitleStyle.NounOfTheAdj)
            {
                tempNounB = tempNounA;
                tempNounA = null;
                style = TitleStyle.TheAdjNoun;
            }
            else if (style == TitleStyle.TheNounOfPlur)
                style = TitleStyle.TheNounNoun;
            else
                style++;
        }

        public void SwapNouns()
        {
            if (style != TitleStyle.TheAdjNoun && style != TitleStyle.NounOfTheAdj)
            {
                NounPair extremelyTempNoun = tempNounA;
                tempNounA = tempNounB;
                tempNounB = extremelyTempNoun;
            }
        }
    }
}
