namespace MyFriendGreeter
{
    public class FrenchGreetingStrategy : IGreetingStrategy
    {
        public Language Language { get; } = Language.French;

        public string Greet(string name)
            => $"Bonjour, monde, {name}!";
    }
}