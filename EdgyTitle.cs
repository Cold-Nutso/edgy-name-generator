using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum TitleStyle
{
    TheAdjNoun,    // the ADJ SING - the ADJ NOUN 
    TheNounNoun,   // the SING SING - the SING NOUN - the NOUN SING - the NOUN NOUN
    ThePosNoun,    // the SING's SING - the SING's NOUN - NOUN's SING - NOUN's NOUN
    NounOfTheNoun, // SING of the SING - SING of NOUN - NOUN of the SING - NOUN of NOUN
    TheNounOfNoun, // the SING of NOUN - the NOUN of NOUN
    NounOfPlur,    // SING of PLUR - NOUN of PLUR
    TheNounOfPlur, // the SING of PLUR - the NOUN of PLUR
    NounOfTheAdj   // SING of the ADJ - NOUN of the ADJ
}

namespace Edgy_Name_Button
{
    // -------
    // Legend:
    // -------
    // ADJ  - Adjective
    // SING - Singular noun (hasPlural == true)
    // NOUN - Singular noun (hasPlural == false)

    // --------------------------
    // All Possible combinations:
    // --------------------------
    // the ADJ SING - the ADJ NOUN
    // the SING SING - the SING NOUN
    // the NOUN SING - the NOUN NOUN
    // the SING's SING - the SING's NOUN
    //     NOUN's SING -     NOUN's NOUN
    // SING of the SING - SING of PLUR - the SING of PLUR - SING of NOUN - the SING of NOUN
    // NOUN of the SING - NOUN of PLUR - the NOUN of PLUR - NOUN of NOUN - the NOUN of NOUN 
    // SING of the ADJ - NOUN of the ADJ
    public class EdgyTitle
    {
        // Fields

        private TitleStyle style;
        private string tempAdj;
        private NounPair tempNounA;
        private NounPair tempNounB;



        // Properties

        public string FirstWord
        {
            get
            {
                if (style == TitleStyle.AdjNoun)
                    return tempAdj;
                else if (style == NameStyle.NounNoun || style == NameStyle.PosNoun)
                    return tempNounA.Singular;
                else
                    return "Butter";
            }
        }
        public string SecondWord
        {
            get
            {
                if (tempNounB != null)
                    return tempNounB.Singular;
                else
                    return "Butter";
            }
        }
        public string Full 
        { 
            get 
            {
                if (style == NameStyle.AdjNoun)
                    return $"{tempAdj} {tempNounB}";
                else if (style == NameStyle.NounNoun)
                    return $"{tempNounA.Singular} {tempNounB}";
                else if (style == NameStyle.PosNoun)
                    return $"{tempNounA.Singular}'s {tempNounB}";
                else
                    return "Butter Boy";
            }
        }



        // Constructor

        public EdgyTitle(string firstWord, NounPair secondWord, NameStyle style = NameStyle.AdjNoun)
        {
            this.style = style;
            tempAdj = firstWord;
            tempNounB = secondWord;
        }
        public EdgyTitle(NounPair firstWord, NounPair secondWord, NameStyle style = NameStyle.NounNoun)
        {
            this.style = style;
            tempNounA = firstWord;
            tempNounB = secondWord;
        }



        // Methods


    }
}
