using System;

namespace PokedexCSharp;
class Program
{
    private static string menu = " _________________ Menu ________________ \n\n" +
            "\t1) Choose generation\n" +
            "\t2) View entries\n" +
            "\t3) Sort entries\n" +
            "\t4) Manage party\n" +
            "\t5) View party\n" +
            "\t6) Exit program\n\n" +
            " _______________________________________ \n";

    static void Main(string[] args)
    {

        Pokedex pokedex = new Pokedex();
        UserParty party = new UserParty();

        
        bool isRunning = true;
        while (isRunning) {
            try
            {
                Console.WriteLine(menu);
                Console.Write(">> ");

                int menuChoice = Convert.ToInt16(Console.ReadLine());
                switch (menuChoice)
                {
                    case 1:
                        Console.WriteLine("Which generation would you like to pick?");
                        bool flag = true;
                        while (flag)
                        {
                            try
                            {
                                Console.Write(">> ");
                                string filePath = pokedex.chooseGen(Console.ReadLine());
                                pokedex.loadGen(filePath);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\n" + ex.Message + "\nInput invalid.\n");
                            }
                            flag = false;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Viewing Entries");
                        pokedex.printDex(pokedex.getList());
                        pause();
                        break;
                    case 3:
                        pokedex.sortingMenu(Convert.ToInt16(Console.ReadLine()));
                        pause();
                        break;
                    case 4:
                        Console.WriteLine("add to party by id: ");
                        int choice = Convert.ToInt16(Console.ReadLine());
                        party.addToParty(pokedex.getList(), choice);
                        pause();
                        break;
                    case 5:
                        Console.WriteLine("View your party");
                        party.printParty(party.getList());
                        pause();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program.");
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Not a valid input.");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Retry with valid menu option/input.\n");
            }
        }
        


    }

    static void pause()
    {
        Console.WriteLine("\nEnter any key to view menu again.");
        Console.ReadLine();
    }
}

