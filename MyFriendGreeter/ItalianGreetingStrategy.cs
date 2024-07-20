namespace MyFriendGreeter
{
    public class ItalianGreetingStrategy : IGreetingStrategy
    {
        public Language Language { get; } = Language.Italian;

        public string Greet(string name)
            => $"Ciao, mondo, {name}!";
    }
}