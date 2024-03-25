# MyFriendGreeter `console application`

This is a little console application for greeting my friends, whose names are Jill, Bob, and Alice, and who speak different languages, each in their own language.

This application was developed as a way of learning the Autofac DI container and using the Composition Root pattern for the very first time in my career, as a learning exercise.

I do admit that ChatGPT, with GPT 3.5, helped me out a little bit.

## Development

### Configuration File

First off, I needed to create a JSON-formatted configuration file for the application.  This configuration file, called `friends.json`, lists my friends.  For each of my friends, it lists the individual's name and the language that the individual speaks:

```json
[
    {
        "Name": "Jill",
        "Language": "English"
    },
    {
        "Name": "Bob",
        "Language": "French"
    },
    {
        "Name": "Alice",
        "Language": "Spanish"
    }
]
```
**Listing 1.** Contents of the `friends.json` file.

My first step is to begin writing a Strategy Pattern.  The pattern consists of different strategy objects, one for each of the languages spoken.  It's each strategy's job to speak the correct language to the corresponding friend.

To do so, first of all, we have to have a way, in code, to select which strategy object to obtain.  We will so by creating an `enum` called `Language`.  Since our JSON configuration file specifies languages using strings for the name of each language, we'll also have to use the `System.Runtime.Serialization` assembly to help Newtonsoft.Json map strings to enum values and vice-versa.

Here is the definition of the `Language` enum:

```C#
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MyFriendGreeter
{
    public enum Language
    {
        [Description("English"), EnumMember(Value = "English")]
        English,

        [Description("French"), EnumMember(Value = "French")]
        French,

        [Description("Spanish"), EnumMember(Value = "Spanish")]
        Spanish,

        [Description("Italian"), EnumMember(Value = "Italian")]
        Italian,

        Unknown = -1
    }
}
```
**Listing 2.** Definition of the `Language` enumeration.

And so on...