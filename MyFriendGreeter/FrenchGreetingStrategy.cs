using System.Diagnostics;
namespace MyFriendGreeter
{
    public class FrenchGreetingStrategy : IGreetingStrategy
    {
        public Language Language { [DebuggerStepThrough] get; } = Language.French;

        public string Greet(string name)
            => $"Bonjour, monde, {name}!";
    }
}