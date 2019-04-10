# Lab3 - Behavioral patterns

## Tasks
Create an application using 5 design behavioral patterns.
  * Command
  * Observer
  * NullObject
  * State
  * Template method

### Command

Command is a behavioral design pattern that turns a request into a stand-alone object that contains all information about the request. This transformation lets you parameterize methods with different requests, delay or queue a request’s execution, and support undoable operations.

This pattern was used to create different kinds of Transactions.

~~~C#
interface ITransaction
{
    void ExecuteTransaction();
}
~~~

### Template method

Template Method is a behavioral design pattern that defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps of the algorithm without changing its structure.

This pattern was used to do some extra operations before and after a transaction is executed.

~~~C#
public abstract class BaseTransaction : ITransaction
{
    protected readonly IMoneyRepository moneySource;
    protected readonly IAccount account;

    protected BaseTransaction(IMoneyRepository moneySource, IAccount account)
    {
        this.moneySource = moneySource;
        this.account = account;
    }

    public void ExecuteTransaction()
    {
        Console.WriteLine("Transaction is being executed...");
        CoreTransactionExecution();
        Console.WriteLine("Transaction has ended");
    }

    protected abstract void CoreTransactionExecution();
}
~~~

### State

State is a behavioral design pattern that lets an object alter its behavior when its internal state changes. It appears as if the object changed its class.

The ATM has 2 different states: LoggedIn and LoggedOut.

~~~C#
public class CashMachine
{
    private ICashMachineState state;

    public CashMachine()
    {
        SetState(new LoggedOutState(this));
    }

    public void SetState(ICashMachineState state)
    {
        this.state = state;
    }

    public void LogIn(IAccount account)
    {
        state.LogIn(account);
    }

    public void LogOut()
    {
        state.LogOut();
    }

    public void ExecuteTransaction(ITransaction transaction)
    {
        state.ExecuteTransaction(transaction);
    }

    public void DisplayAccountBalance()
    {
        state.DisplayAccountBalance();
    }
}
~~~

Where `LoggedOutState.LogIn()` looks like this:

~~~C#
void LogIn(IAccount account)
{
    Console.WriteLine("Logging in...");
    context.SetState(new LoggedInState(context, account));
}
~~~

### Observer

Observer is a behavioral design pattern that lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.

Observers are used  here to log information when someone tries to log in.

~~~C#
public void LogIn(IAccount account)
{
    state.LogIn(account);
    loginObservers.ToList().ForEach(x => x.OnLoggedIn(account));
}
~~~

### NullObject

When instead of returning `null` it's ok to return a dummy object that doesn't do much. It's handy thing if you're looking for a way to get rid of null checks.

~~~C#
public class NullTransaction : ITransaction
{
    public void ExecuteTransaction()
    {
        // Do nothing
    }
}
~~~

## Conclusion

The State design pattern is pretty good for reducing the amount of conditionals.
