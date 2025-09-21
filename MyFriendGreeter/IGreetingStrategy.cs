namespace MyFriendGreeter
{
    public interface IGreetingStrategy
    {
        Language Language { [DebuggerStepThrough] get; }

        string Greet(string name);
    }
}