using System;

ChestState state = ChestState.Open;

while (true)
{
    Console.Write($"The chest is {state}. What do you want to do? ");
    var chestAction = Console.ReadLine();
    state = AssertAction(chestAction, state);
}

ChestState AssertAction(string Action, ChestState state)
{
    if (state == ChestState.Open && Action == "close")
    {
        state = ChestState.Closed;
    }
    else if (state == ChestState.Closed && Action == "lock")
    {
        state = ChestState.Locked;
    }
    else if (state == ChestState.Closed && Action == "open")
    {
        state = ChestState.Open;
    }
    else if (state == ChestState.Locked && Action == "unlock")
    {
        state = ChestState.Closed;
    }

    return state;
}

enum ChestState { Open, Closed, Locked };
