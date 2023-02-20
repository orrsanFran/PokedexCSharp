using System;
using System.IO;

namespace PokedexCSharp
{
	public class Pokedex
	{

		public List<Pokemon> dex;
		StreamReader sr;

		public Pokedex()
		{
			dex = new List<Pokemon>();
		}

		public List<Pokemon> getList()
		{
			return dex;
		}

		public void printDex(List<Pokemon> dex)
		{
			foreach (Pokemon p in dex)
			{
				Console.WriteLine(p);
			}
		}

        public string chooseGen(string s)
        {
            int gen = Convert.ToUInt16(s); //is there an advantage in these being a 16 bit integer instead of a 32/64?
			
            switch (gen)
            {
                case 1:
                    Console.WriteLine("\nSuccessfully loaded Gen " + gen + "!\n"); // maybe find another way to print this message without redundancy
                    return "GenOne.txt";
                case 2:
                    Console.WriteLine("\nSuccessfully loaded Gen " + gen + "!\n");
                    return "GenTwo.txt";
                case 3:
                    Console.WriteLine("\nSuccessfully loaded Gen " + gen + "!\n");
                    return "GenThree.txt";
                case 4:
                    Console.WriteLine("\nSuccessfully loaded Gen " + gen + "!\n");
                    return "GenFour.txt";
                default:
					Console.WriteLine("\nGeneration " + gen + " dex currently not available.");
					Console.WriteLine("Loading default Generation 1.\n");
                    return "GenOne.txt";
            }
        }

        public Pokedex loadGen(string txtPath)
		{
			dex.Clear();
			try
			{
				FileInfo fi = new FileInfo(txtPath);
				sr = fi.OpenText();
				string s;
				while ((s = sr.ReadLine()) != null)
				{
					string[] objectFields = s.Split(" ");

					Pokemon.PokemonType firstType = (Pokemon.PokemonType)Enum.Parse(typeof(Pokemon.PokemonType), objectFields[2]);
					Pokemon.PokemonType secondType = (Pokemon.PokemonType)Enum.Parse(typeof(Pokemon.PokemonType), objectFields[3]); ;
					Pokemon p = new Pokemon(Convert.ToInt16(objectFields[0]), objectFields[1], firstType, secondType);

					dex.Add(p);
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (OutOfMemoryException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return this;
		}


		public void sortingMenu(int choice)
		{
			switch (choice) {
				case 1:
					Console.Write("Enter type(s). If multiple, separate with space. \n>> ");
					try
					{
						string[] typings = Console.ReadLine().Split(" ");
                        string typeOne = typings[0].ToUpper();

                        Console.WriteLine();
                        if (typings.Length > 1)
						{
							string typeTwo = typings[1].ToUpper();
							sortByTyping(dex, (Pokemon.PokemonType)Enum.Parse(typeof(Pokemon.PokemonType), typeOne), (Pokemon.PokemonType)Enum.Parse(typeof(Pokemon.PokemonType), typeTwo));
						}
						else
						{
							sortByTyping(dex, (Pokemon.PokemonType)Enum.Parse(typeof(Pokemon.PokemonType), typeOne));
						}
					}
					catch (ArgumentException ex)
					{
						Console.WriteLine(ex.Message);
						Console.WriteLine("No such typing exists. Keep spelling in mind.");
					}
					break;
				case 2:
					sortByDescendingAlphabet(dex);
					break;
				case 3:
					break;
				case 4:
					break;
				default:
					Console.WriteLine("No option selected.");
					Console.WriteLine("Exiting sort menu.");
					break;
			}
		}

        public void sortByTyping(List<Pokemon> list, Pokemon.PokemonType typeOne, Pokemon.PokemonType typeTwo)
		{
			List<Pokemon> temp = new List<Pokemon>();

			foreach (Pokemon p in dex)
			{
				if (p.firstType == typeOne || p.firstType == typeTwo)
				{
					if (p.secondType == typeOne || p.secondType == typeTwo)
					{
                        Console.WriteLine(p);
                        temp.Add(p);
                    }
				}
			}

			//add paramater to method so it displays which generation was just checked
			if (temp.Count == 0) {
				Console.WriteLine("In this Generation, no Pokemon with type " + typeOne + " and " + typeTwo + " exists.");
			}
		}

        public void sortByTyping(List<Pokemon> dex, Pokemon.PokemonType typeOne)
        {
            List<Pokemon> temp = new List<Pokemon>();

            foreach (Pokemon p in dex)
            {
                if (p.firstType == typeOne || p.secondType == typeOne)
                {
                    Console.WriteLine(p);
					temp.Add(p);
                }
            }

            //add paramater to method so it displays which generation was just checked
            if (temp.Count == 0)
            {
                Console.WriteLine("In this Generation, no Pokemon with type " + typeOne + " exists.");
            }
        }

		public void sortByDescendingID(List<Pokemon> list)
		{
			List<Pokemon> temp = list.ToList<Pokemon>();

			temp.Sort((s1, s2) =>
			{
				return s2.id.CompareTo(s1.id);
			});

			printDex(temp);
		}

        public void sortByDescendingAlphabet(List<Pokemon> list)
        {
            List<Pokemon> temp = list.ToList<Pokemon>();

            temp.Sort((s1, s2) =>
            {
                return s2.species.CompareTo(s1.species);
            });

            printDex(temp);
        }
    }
}

/*
				 * is fileinfo needed?
				 * also, for text files in project directory, you did this: 
				 *	- right click on .txt file -> build action -> content
				 *	- properties -> copy always
*/