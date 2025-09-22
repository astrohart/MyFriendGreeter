using System.Diagnostics;
namespace MyFriendGreeter
{
    public class SpanishGreetingStrategy : IGreetingStrategy
    {
        public Language Language { [DebuggerStepThrough] get; } = Language.Spanish;

        public string Greet(string name)
            => $"¡Hola, mundo, {name}!";
    }
}