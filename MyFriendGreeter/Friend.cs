using Newtonsoft.Json;
using PostSharp.Patterns.Diagnostics;

namespace MyFriendGreeter
{
    public class Friend
    {
        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:MyFriendGreeter.Friend" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// <para />
        /// We've decorated this constructor with the <c>[Log(AttributeExclude = true)]</c>
        /// attribute in order to simplify the logging output.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static Friend() { }

        /// <summary>
        /// Creates a new instance of <see cref="T:MyFriendGreeter.Friend" /> and returns a
        /// reference to it.
        /// </summary>
        [Log(AttributeExclude = true)]
        public Friend() { }

        [JsonProperty("Language")] public Language Language { get; set; }

        [JsonProperty("Name")] public string Name { get; set; }
    }
}