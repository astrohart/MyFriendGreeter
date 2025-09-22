using System.Diagnostics;
namespace MyFriendGreeter
{
    public class ItalianGreetingStrategy : IGreetingStrategy
    {
        public Language Language { [DebuggerStepThrough] get; } = Language.Italian;

        public string Greet(string name)
            => $"Ciao, mondo, {name}!";
    }
}