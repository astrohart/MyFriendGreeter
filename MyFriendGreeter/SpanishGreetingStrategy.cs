namespace MyFriendGreeter
{
    public class SpanishGreetingStrategy : IGreetingStrategy
    {
        public Language Language { get; } = Language.Spanish;

        public string Greet(string name)
            => $"¡Hola, mundo, {name}!";
    }
}