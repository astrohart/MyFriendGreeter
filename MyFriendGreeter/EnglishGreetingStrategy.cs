namespace MyFriendGreeter
{
    public class EnglishGreetingStrategy : IGreetingStrategy
    {
        public Language Language { [DebuggerStepThrough] get; } = Language.English;

        public string Greet(string name)
            => $"Hello, world, {name}!";
    }
}