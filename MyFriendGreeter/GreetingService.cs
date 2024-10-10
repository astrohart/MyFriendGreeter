using System;
using System.Collections.Generic;

namespace MyFriendGreeter
{
    public class GreetingService
    {
        private readonly IList<Friend> _friends;
        private readonly IGreetingStrategyFactory _strategyFactory;

        public GreetingService(
            IList<Friend> friends,
            IGreetingStrategyFactory strategyFactory
        )
        {
            _friends = friends;
            _strategyFactory = strategyFactory;
        }

        public void GreetFriends()
        {
            foreach (var friend in _friends)
            {
                if (friend == null || string.IsNullOrWhiteSpace(friend.Name))
                {
                    Console.WriteLine("Invalid friend data.");
                    continue;
                }

                try
                {
                    var strategy =
                        _strategyFactory.GetGreetingStrategy(friend.Language);
                    var greeting = strategy.Greet(friend.Name);
                    Console.WriteLine(greeting);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Error greeting {friend.Name}: {ex.Message}"
                    );
                }
            }
        }
    }
}