namespace MyFriendGreeter
{
    public interface IGreetingStrategy
    {
        Language Language { get; }

        string Greet(string name);
    }
}