using System;

namespace PokedexCSharp
{
	public class UserParty
	{

		public List<Pokemon> uParty = new List<Pokemon>();

		public UserParty()
		{
			this.uParty = new List<Pokemon>(6);
		}

		public void addToParty(List<Pokemon> currPokedex, int id) {

            if (uParty.Count > 6)
            {
                Console.WriteLine("Your party is already full!");
            }
            else
            {
                try
                {
                    if (uParty.Exists(pokemon => pokemon.id == id) == true)
                    {
                        Console.WriteLine("This pokemon is already in your party.");
                    }
                    else
                    {
                        Pokemon p = currPokedex.Find(pokemon => pokemon.id == id);
                        uParty.Add(p);
                        Console.WriteLine("Added " + p.species + " to your party.");
                    }
                }
                catch (Exception)
                {
                    Console.Write("That ID is not valid for the selected generation.");
                }
                
            }   
			
		}

        public List<Pokemon> getList()
        {
            return uParty;
        }

        public void printParty(List<Pokemon> uParty)
        {
            foreach (Pokemon p in uParty)
            {
                Console.WriteLine(p);
            }
        }
    }
}

