using System;


Console.Write("Enter door lock passcode: ");
var initialPasscode = Console.ReadLine();

Door myDoor = new Door(initialPasscode);

while (true)
{


    Console.WriteLine("What would you like to do to the door?");
    Console.WriteLine("Press 1 to Open");
    Console.WriteLine("Press 2 to Close");
    Console.WriteLine("Press 3 to Lock");
    Console.WriteLine("Press 4 to Unlock");
    Console.WriteLine("Press 5 to Change passcode");
    Console.Write("Enter an option: ");
    var action = Console.ReadLine();
    int actionInt = Convert.ToInt32(action);

    if (actionInt == 5)
    {

        Console.Write("Enter current passcode: ");
        var passcodeGuess = Console.ReadLine();
        Console.Write("Enter new password: ");
        var newPasscode = Console.ReadLine();
        myDoor.ChangePasscode(passcodeGuess, newPasscode);
    }
    else
    {
        switch (actionInt)
        {
            case 1:
                myDoor.ChangeState(DoorState.Open);
                break;
            case 2:
                myDoor.ChangeState(DoorState.Closed);
                break;
            case 3:
                myDoor.ChangeState(DoorState.Locked);
                break;
            case 4:
                myDoor.ChangeState(DoorState.Open);
                break;
        };
    }
}

public class Door
{
    public DoorState State { get; private set; }
    private string PassCode { get; set; }

    public Door(string passCode)
    {
        this.PassCode = passCode;
        this.State = DoorState.Closed;
    }

    public void ChangeState(DoorState desiredState)
    {
        if (desiredState == DoorState.Closed && this.State == DoorState.Open )
        {
            this.State = desiredState;
        }
        else if (desiredState == DoorState.Open && this.State == DoorState.Closed)
        {
            this.State = desiredState;
        }
        else if (desiredState == DoorState.Locked && this.State == DoorState.Closed)
        {
            this.State = desiredState;
        }
        else if (desiredState == DoorState.Open && this.State == DoorState.Locked)
        {
            Console.Write("Enter the passcode: ");
            var passcodeGuess = Console.ReadLine();

            if (passcodeGuess == this.PassCode)
            {
                this.State = DoorState.Open;
            }
            else
            {
                Console.WriteLine("Passcode is incorrect");
                return;
            }
        }
        else
        {
            Console.WriteLine($"You can not {desiredState} a door when it is {this.State}");
            return;
        }

        Console.WriteLine($"Changing door state to {desiredState}");
    }

    public void ChangePasscode(string currentPasscode, string newPasscode)
    {
        if (this.PassCode == currentPasscode)
        {
            this.PassCode = newPasscode;
        }
        else
        {
            Console.WriteLine("Passcode is incorrect");
        }
    }
}

public enum DoorState { Open, Closed, Locked};
