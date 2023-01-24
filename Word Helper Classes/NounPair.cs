using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edgy_Name_Generator
{
    public class NounPair : IComparable
    {
        // Fields

        private bool hasPlural;
        private string singular;
        private string plural;



        // Properties

        public bool HasPlural { get { return hasPlural; } }
        public string Singular { get { return singular; } }
        public string Plural { get { return plural; } }
        public string Full { 
            get 
            {
                if (hasPlural)
                    return $"{singular} / {plural}";
                else
                    return singular;
            } 
        }



        // Constructors

        public NounPair(string singular)
        {
            hasPlural = false;
            this.singular = singular;
            plural = singular;
        }

        public NounPair(string singular, string plural)
        {
            hasPlural = true;
            this.singular = singular;
            this.plural = plural;
        }



        // Method

        /// <summary>
        /// Compares NounPairs by their singular word.
        /// </summary>
        /// <param name="obj">The other NounPair</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            NounPair other = (NounPair)obj;
            return string.Compare(singular, other.Singular);
        }
    }
}
