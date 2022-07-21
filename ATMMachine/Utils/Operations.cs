using ATMMachine;
using ATMMachine.Models;
using ATMMachine.Enums;


namespace ATMMachine.Utils
{
    public class Operations
    {
        public void Withdraw(User user)
        {

            Console.WriteLine($"\n{user.Name} you have {user.AvaiableAmmount} avaiable.\n");
            try
            {
                bool validOperation = false;
                while (!validOperation)
                {
                    Console.WriteLine($"\nHow much would you like to withdraw?");
                    int value = int.Parse(Console.ReadLine());
                    if (user.AvaiableAmmount >= value)
                    {
                        user.AvaiableAmmount -= value;
                        validOperation = true;
                    }
                    else Console.WriteLine($"The amount must me smaller than {user.AvaiableAmmount}");
                }

                Console.WriteLine("\nWithdraw complete!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nOperation failed :(");
            }

            Console.WriteLine("What you would like to do next?\n");
        }

        public void Deposit(User user)
        {
            Console.WriteLine($"\nHow much would you like to deposit?");
            int value = 0;

            try
            {
                value = int.Parse(Console.ReadLine());
                user.AvaiableAmmount += value;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"\nYou deposited {value}. Your new balance is ${user.AvaiableAmmount}");
            Console.WriteLine("What you would like to do next?\n");
        }

        public void Transfer(User user, List<User> usersList)
        {
            string transferTo;
            User user2 = null;
            try
            {
                while (user2 == null || user2?.Name == user.Name)
                {
                    Console.WriteLine($"\nTo what user would you like to transfer?");

                    transferTo = Console.ReadLine();
                    user2 = usersList.Find(user => user.Name == transferTo);

                    if (user2?.Name == user.Name)
                    {
                        Console.WriteLine("You cant transfer to yourself");

                    }

                    if (user2 == null)
                    {
                        Console.WriteLine("User not found");
                    }
                }

                bool validOperation = false;
                while (!validOperation)
                {
                    Console.WriteLine($"\nHow much would you like to transfer?");
                    int value = int.Parse(Console.ReadLine());
                    if (user.AvaiableAmmount >= value)
                    {
                        user.AvaiableAmmount -= value;
                        user2.AvaiableAmmount += value;
                        validOperation = true;
                        Console.WriteLine($"You transfered ${value} to {user2.Name}");
                    }
                    else Console.WriteLine($"The amount must me smaller than {user.AvaiableAmmount}");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void CheckBalance(User user)
        {
            Console.WriteLine($"You have {user.AvaiableAmmount} avaiable");
        }


        public OperationTypes RequestOperation()
        {
            bool validoperation = false;

            Console.WriteLine($"0 - Withdraw");
            Console.WriteLine($"1 - Depoist");
            Console.WriteLine($"2 - Transfer");
            Console.WriteLine($"3 - Check balance");
            Console.WriteLine($"4 - Log Out\r");

            string operation = Console.ReadLine();

            if (operation == "0" || operation == "1" || operation == "2" || operation == "3" || operation == "4")
            {
                validoperation = true;
            }
            else
            {
            }

            while (!validoperation)
            {
                if (operation == "0" || operation == "1" || operation == "2" || operation == "3" || operation == "4")
                {
                    validoperation = true;
                }
                else
                {
                    Console.WriteLine($"Operation {operation} is invalid. Select one of the valid operations: ");
                    Console.WriteLine($"0 - Withdraw");
                    Console.WriteLine($"1 - Depoist");
                    Console.WriteLine($"2 - Transfer");
                    Console.WriteLine($"3 - Check balance");
                    Console.WriteLine($"4 - Log Out\r");

                    operation = Console.ReadLine();
                }


            }

            return (OperationTypes)int.Parse(operation);
        }
    }
}
