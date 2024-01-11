using System;

class Program
{
    //Application exceution starts here
    public static void Main()
    {
        //display title
        System.Console.WriteLine("******* Simone Bank *******");
        System.Console.WriteLine("::Login page::");

        //declare variables to store username and password;
        string userName = null;
        string password = null;

        //read username from input keyboard
        System.Console.WriteLine("Username:");
        userName = System.Console.ReadLine();

        //read password from input keyboard only if username is entered
        if (userName != null && userName != "")
        {
            System.Console.WriteLine("Password:");
            password = System.Console.ReadLine();
        }
        else
        {
            System.Console.WriteLine("Error, username is not valid");
        }

        if (userName == "admin" && password == "default")
        {
            //variable for the menu choice
            int input = -1;
            Console.WriteLine($"\n::::LOGIN SUCCEDED::::");
            do
            {
                Console.WriteLine($"\nWelcome *{userName}*" +
                    $"\n:::MAIN MENU:::" +
                    $"\n.1: Costumers" +
                    $"\n.2: Accounts" +
                    $"\n.3: Funds Transfer" +
                    $"\n.4: Funds Transfer Statement" +
                    $"\n.5: Account Statement" +
                    $"\n.0: Exit");

                System.Console.WriteLine("Enter choice:");
                //int.Parse è un metodo predefinito che converte il valore da un tipo stringa a un tipo numerico
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        //TO DO DISPLAY CUSTOMERS MENU
                        CustomersMenu();
                        break;
                    case 2:
                        //TO DO DISPLAY ACCOUNTS MENU
                        AccountsMenu();
                        break;
                    case 3:
                        //TO DO DISPLAY FUNDS TRANSFER MENU
                        FundsTransferMenu();
                        break;
                    case 4:
                        //TO DO DISPLAY FUNDS TRANSFER STATEMENT MENU
                        FundsTransferStatement();
                        break;
                    case 5:
                        //TO DO DISPLAY ACCOUNT STATEMENT MENU
                        AccountStatement();
                        break;
                    default:
                        Console.WriteLine("Error please enter a proper number from the menu list");
                        break;
                }
            } while (input != 0);
        }
    }

    private static void AccountStatement()
    {
        throw new NotImplementedException();
    }

    private static void FundsTransferStatement()
    {
        throw new NotImplementedException();
    }

    private static void FundsTransferMenu()
    {
        throw new NotImplementedException();
    }

    private static void AccountsMenu()
    {
        //variable to store customers menu choice
        int accountrMenuChoice = -1;

        //do-while loop starts
        do
        {
            //print account menu
            Console.WriteLine($"\n:::WELCOME TO THE *ACCOUNTS* MENU:::" +
                    $"\n.1: Add Account" +
                    $"\n.2: Delete Account" +
                    $"\n.3: Update Account" +
                    $"\n.4: View Account" +
                    $"\n.0: Back to Main Menu");

            System.Console.WriteLine("Enter choice:");
            accountrMenuChoice = int.Parse(Console.ReadLine());

            switch (accountrMenuChoice)
            {
                case 1:
                    //TO DO ADD ACCOUNT
                    break;
                case 2:
                    //TO DO DELETE ACCOUNT
                    break;
                case 3:
                    //TO DO UPDATE ACCOUNT
                    break;
                case 4:
                    //TO DO VIEW ACCOUNT
                    break;
                default:
                    Console.WriteLine("Error please enter a proper number from the menu list");
                    break;
            }
        } while (accountrMenuChoice != 0);
    }

    public static void CustomersMenu() 
    {
        //variable to store customers menu choice
        int customerMenuChoice = -1;

        //do-while loop starts
        do 
        {
            //print customers menu
            Console.WriteLine($"\n:::WELCOME TO THE *CUSTOMERS* MENU:::" +
                    $"\n.1: Add Custumer" +
                    $"\n.2: Delete Custumer" +
                    $"\n.3: Update Custumer" +
                    $"\n.4: View Customer" +
                    $"\n.0: Back to Main Menu");

            System.Console.WriteLine("Enter choice:");
            customerMenuChoice = int.Parse(Console.ReadLine());

            switch (customerMenuChoice)
            {
                case 1:
                    //TO DO ADD CUSTOMER
                    break;
                case 2:
                    //TO DO DELETE CUSTOMER
                    break;
                case 3:
                    //TO DO UPDATE CUSTOMER
                    break;
                case 4:
                    //TO DO VIEW CUSTOMER
                    break;
                default:
                    Console.WriteLine("Error please enter a proper number from the menu list");
                    break;
            }
        } while (customerMenuChoice != 0);
    }
}
