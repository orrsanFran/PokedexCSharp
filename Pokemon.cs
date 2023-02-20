using System;
using System.Xml.Linq;

namespace PokedexCSharp
{
	public class Pokemon
	{
        public int id
        { get; set; }
        public string species
        { get; set; }
		public PokemonType firstType;
		public PokemonType secondType;

        public Pokemon()
        {
            this.id = 0;
            this.species = "";
            this.firstType = PokemonType.NONE;
            this.secondType = PokemonType.NONE;
        }

		public Pokemon(int id, string species, PokemonType firstType, PokemonType secondType)
		{
            this.id = id;
            this.species = species;
            this.firstType = firstType;
			this.secondType = secondType;
        }






        /*
        public int Id   // property FIRST LETTER MUST BE UPPERCASE
        {
            get { return id; }   // get method
            set { id = value; }  // set method
        }
        */


        public enum PokemonType
        {
            WATER, GRASS, FIRE, ELECTRIC, PSYCHIC, DARK, GHOST, GROUND, POISON, FAIRY, STEEL,
            BUG, ROCK, ICE, NORMAL, DRAGON, FLYING, FIGHTING, NONE
        }

        override
        public string ToString()
        {
            string id = string.Format("{0}", this.id.ToString("D3"));
            string name = string.Format("{0,10}", this.species);
            string ft = string.Format("{0,10}", this.firstType);
            string st = string.Format("{0,10}", this.secondType);

            if (secondType == PokemonType.NONE)
            {
                return "   #" + id + "    " + name + " " + ft;
            }
            else
            {
                return "   #" + id + "    " + name + " " + ft + " " + st;
            }
        }
    }
}

