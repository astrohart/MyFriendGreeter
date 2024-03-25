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