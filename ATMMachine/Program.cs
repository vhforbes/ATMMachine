using ATMMachine.Models;
using ATMMachine.Utils;
using ATMMachine.Enums;


List<User> Users = new List<User>()
{
    new User() { Id = 0, Name = "Rebeca", AvaiableAmmount = 1000, Password = "1234" },
    new User() { Id = 1, Name = "Victor", AvaiableAmmount = 2000, Password = "1234" },
    new User() { Id = 2, Name = "Elon Musk", AvaiableAmmount = 5000, Password = "tesla" },
};

Operations operations = new Operations();

Console.WriteLine("------------Welcome to The ATM------------\n");
Console.WriteLine("Please enter your name to make a operation:");

string nameInput = Console.ReadLine();
User currentUser = Users.Find(user => user.Name == nameInput);

// Force user to input a valid name
while (currentUser == null)
{
    Console.WriteLine("Please enter a valid user name: ");
    nameInput = Console.ReadLine();
    currentUser = Users.Find(user => user.Name == nameInput);
}

Console.WriteLine($"\rWelcome {currentUser.Name}!\r");
Console.WriteLine($"Please input your password:\r");


string inputPassword = Console.ReadLine();
bool validPassword = false;
bool loggedIn = false;

if (currentUser.Password == inputPassword)
{
    validPassword = true;
}

while (!validPassword)
{
    Console.WriteLine($"Please input a valid password:\r");
    inputPassword = Console.ReadLine();
    if (currentUser.Password == inputPassword)
    {
        validPassword = true;
        loggedIn = true;
    }
}

Console.WriteLine($"You are authenticated! What type of operation would you like to perform?");

// Enters while loop that forces correct operation
OperationTypes selectedOperation = operations.RequestOperation();

// Make operation

while (selectedOperation != OperationTypes.LogOut)
{
    switch (selectedOperation)
    {
        case OperationTypes.Withdraw:
            operations.Withdraw(currentUser);
            selectedOperation = operations.RequestOperation();
            break;
        case OperationTypes.Deposit:
            operations.Deposit(currentUser);
            selectedOperation = operations.RequestOperation();

            break;
        case OperationTypes.Transfer:
            operations.Transfer(currentUser, Users);
            selectedOperation = operations.RequestOperation();

            break;
        case OperationTypes.CheckBalance:
            operations.CheckBalance(currentUser);
            selectedOperation = operations.RequestOperation();

            break;
    }
}

Console.WriteLine("You loged out succesfully!");

// Request operation again if loggedn, Else it should quit the app.





