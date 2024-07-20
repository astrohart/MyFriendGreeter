using System;
using System.Collections.Generic;

namespace MyFriendGreeter
{
    public interface IGreetingStrategyFactory
    {
        IGreetingStrategy GetGreetingStrategy(Language language);
    }

    public class GreetingStrategyFactory : IGreetingStrategyFactory
    {
        private readonly IDictionary<Language, Func<IGreetingStrategy>>
            _strategyCreators;

        public GreetingStrategyFactory(
            IDictionary<Language, Func<IGreetingStrategy>> strategyCreators
        )
            => _strategyCreators = strategyCreators;

        public IGreetingStrategy GetGreetingStrategy(Language language)
        {
            if (_strategyCreators.TryGetValue(
                    language, out var strategyCreator
                )) return strategyCreator();

            throw new ArgumentException(
                $"No strategy found for language: {language}", nameof(language)
            );
        }
    }
}