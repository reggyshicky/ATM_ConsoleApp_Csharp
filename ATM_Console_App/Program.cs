using System;
using System.Reflection.Emit;
using System.Runtime.ExceptionServices;

public class cardHolder
{
    String cardNum { get; set; }
    int pin { get; set; }

    String firstName { get; set; }
    String lastName { get; set; }
    double balance {get; set; }

    //Initialize our constructor with parameters
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        //instantiate variables passed into the constructor as new objects
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    //getters
    public String getNum()
    {
        //method incharge of returning the card number
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    //setters
    public void setNum(String newcardNum)
    {
        cardNum = newcardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    
    public void setFirstNam(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newlastName)
    {
        lastName = newlastName;
    }
    public void setBalance(double  newBalance)
    {
        balance = newBalance;
    }

    //main method to run the actual atm
    public static void Main(String[] args) //parameter is an array of datatype String called args
    {
        //static indicates the Main method belongs to the class itself, not to instance of the classs,
        //you do not need to create an obj of the class to call the Main method, you can call it direcitly 
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        //handles deposits from users
        void deposit(cardHolder currentUser) //we pass in an obj/instance of the cardHolder class
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine($"Thank you for your $$. Your new balance is: {currentUser.getBalance()}");
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            double withdrawal = double.Parse(Console.ReadLine());
            //check if user has enough money to actuall go ahead and withdraw
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go! Thank you :)");
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine($"Current balance: {currentUser.getBalance()}");
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("5789", 1234, "John", "Doe", 500.0));
        cardHolders.Add(new cardHolder("4256", 5678, "Jane", "Smith", 1000.0));
        cardHolders.Add(new cardHolder("3798", 9876, "Alice", "Johnson", 750.0));
        cardHolders.Add(new cardHolder("5580", 4321, "Bob", "Williams", 300.0));
        cardHolders.Add(new cardHolder("7178", 7890, "Eva", "Brown", 1500.0));

        //Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert you debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;
        
        //user validation loop
        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against our db "hehehe not a real db though, up there"
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                /*The FirstOrDefault() method in C# is used to retrieve the first element from a collection (such as a List or an array) 
                 * that matches a specified condition, or it returns a default value if no matching element is found.*/
                if (currentUser != null) { break;  }
                else { Console.WriteLine("Card not recognized. Please try again"); }

            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }

        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrectpin. Please try again."); }
            }
            catch
            {
                Console.WriteLine("Incorrectpin. Please try again.");
            }
            /*The use of break in this context is essential for exiting the infinite while loop once the correct PIN is entered. Without the break statement, 
             * the loop would continue indefinitely, repeatedly prompting the user for the PIN even after it's been successfully entered. The break statement breaks out of the loop, 
             * allowing the program to continue after the loop only if the correct PIN is provided or if an exception occurs.*/
        }

        Console.WriteLine($"Welcome {currentUser.getFirstName()} :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {}
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        } while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :");
    }
       

}