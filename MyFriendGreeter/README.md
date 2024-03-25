<a name='assembly'></a>
# MyFriendGreeter

## Contents

- [ConvertFriends](#T-MyFriendGreeter-ConvertFriends 'MyFriendGreeter.ConvertFriends')
  - [Settings](#F-MyFriendGreeter-ConvertFriends-Settings 'MyFriendGreeter.ConvertFriends.Settings')
  - [#cctor()](#M-MyFriendGreeter-ConvertFriends-#cctor 'MyFriendGreeter.ConvertFriends.#cctor')
  - [FromJson(json)](#M-MyFriendGreeter-ConvertFriends-FromJson-System-String- 'MyFriendGreeter.ConvertFriends.FromJson(System.String)')
- [Friend](#T-MyFriendGreeter-Friend 'MyFriendGreeter.Friend')
  - [#ctor()](#M-MyFriendGreeter-Friend-#ctor 'MyFriendGreeter.Friend.#ctor')
  - [#cctor()](#M-MyFriendGreeter-Friend-#cctor 'MyFriendGreeter.Friend.#cctor')
- [Get](#T-MyFriendGreeter-Program-Get 'MyFriendGreeter.Program.Get')
  - [LOG_FILE_PATH_TERMINATOR](#F-MyFriendGreeter-Program-Get-LOG_FILE_PATH_TERMINATOR 'MyFriendGreeter.Program.Get.LOG_FILE_PATH_TERMINATOR')
  - [AssemblyCompany](#P-MyFriendGreeter-Program-Get-AssemblyCompany 'MyFriendGreeter.Program.Get.AssemblyCompany')
  - [AssemblyProduct](#P-MyFriendGreeter-Program-Get-AssemblyProduct 'MyFriendGreeter.Program.Get.AssemblyProduct')
  - [AssemblyTitle](#P-MyFriendGreeter-Program-Get-AssemblyTitle 'MyFriendGreeter.Program.Get.AssemblyTitle')
  - [ApplicationProductName()](#M-MyFriendGreeter-Program-Get-ApplicationProductName 'MyFriendGreeter.Program.Get.ApplicationProductName')
  - [LogFilePath()](#M-MyFriendGreeter-Program-Get-LogFilePath 'MyFriendGreeter.Program.Get.LogFilePath')
- [Program](#T-MyFriendGreeter-Program 'MyFriendGreeter.Program')
  - [Main()](#M-MyFriendGreeter-Program-Main 'MyFriendGreeter.Program.Main')

<a name='T-MyFriendGreeter-ConvertFriends'></a>
## ConvertFriends `type`

##### Namespace

MyFriendGreeter

##### Summary

Exposes static methods that are to be used in order to serialize and
deserialize the `Friend` data to/from JSON.

<a name='F-MyFriendGreeter-ConvertFriends-Settings'></a>
### Settings `constants`

##### Summary

Reference to an instance of
[JsonSerializerSettings](#T-Newtonsoft-Json-JsonSerializerSettings 'Newtonsoft.Json.JsonSerializerSettings') that specifies JSON
configuration settings for the conversion operation.

<a name='M-MyFriendGreeter-ConvertFriends-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [ConvertFriends](#T-MyFriendGreeter-ConvertFriends 'MyFriendGreeter.ConvertFriends') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-MyFriendGreeter-ConvertFriends-FromJson-System-String-'></a>
### FromJson(json) `method`

##### Summary

Parses the specified `json` content and, if successful,
returns a collection of references to instances of
[Friend](#T-MyFriendGreeter-Friend 'MyFriendGreeter.Friend') that encapsulate each of the entries in
the specified `json`.

##### Returns

Collection of references to instances of
[Friend](#T-MyFriendGreeter-Friend 'MyFriendGreeter.Friend') from the entries found in the specified
`json`, or the empty collection otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| json | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | (Required.) String containing the JSON content to be parsed. |

<a name='T-MyFriendGreeter-Friend'></a>
## Friend `type`

##### Namespace

MyFriendGreeter

<a name='M-MyFriendGreeter-Friend-#ctor'></a>
### #ctor() `constructor`

##### Summary

Creates a new instance of [Friend](#T-MyFriendGreeter-Friend 'MyFriendGreeter.Friend') and returns a
reference to it.

##### Parameters

This constructor has no parameters.

<a name='M-MyFriendGreeter-Friend-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [Friend](#T-MyFriendGreeter-Friend 'MyFriendGreeter.Friend') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.



We've decorated this constructor with the `[Log(AttributeExclude = true)]`
attribute in order to simplify the logging output.

<a name='T-MyFriendGreeter-Program-Get'></a>
## Get `type`

##### Namespace

MyFriendGreeter.Program

##### Summary

Exposes static methods to obtain data from various data sources.

<a name='F-MyFriendGreeter-Program-Get-LOG_FILE_PATH_TERMINATOR'></a>
### LOG_FILE_PATH_TERMINATOR `constants`

##### Summary

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') containing the final piece of the path of the
log file.

<a name='P-MyFriendGreeter-Program-Get-AssemblyCompany'></a>
### AssemblyCompany `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the product name defined
for this application.

##### Remarks

This property is really an alias for the
[AssemblyCompany](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyCompany 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyCompany')
property.

<a name='P-MyFriendGreeter-Program-Get-AssemblyProduct'></a>
### AssemblyProduct `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the product name defined
for this application.

##### Remarks

This property is really an alias for the
[ShortProductName](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-ShortProductName 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.ShortProductName')
property.

<a name='P-MyFriendGreeter-Program-Get-AssemblyTitle'></a>
### AssemblyTitle `property`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the assembly title defined
for this application.

##### Remarks

This property is really an alias for the
[AssemblyTitle](#P-xyLOGIX-Core-Assemblies-Info-AssemblyMetadata-AssemblyTitle 'xyLOGIX.Core.Assemblies.Info.AssemblyMetadata.AssemblyTitle')
property --- except that all whitespace is replace with underscores.

<a name='M-MyFriendGreeter-Program-Get-ApplicationProductName'></a>
### ApplicationProductName() `method`

##### Summary

Gets a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains a user-friendly name for
the software product of which this application or class library is a part.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains a user-friendly name for the
software product of which this application or class library is a part.

##### Parameters

This method has no parameters.

<a name='M-MyFriendGreeter-Program-Get-LogFilePath'></a>
### LogFilePath() `method`

##### Summary

Obtains a [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified
pathname of the file that should be used for logging messages.

##### Returns

A [String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') that contains the fully-qualified pathname of
the file that should be used for logging messages.

##### Parameters

This method has no parameters.

<a name='T-MyFriendGreeter-Program'></a>
## Program `type`

##### Namespace

MyFriendGreeter

##### Summary

Defines the behaviors of the application.

<a name='M-MyFriendGreeter-Program-Main'></a>
### Main() `method`

##### Summary

The entry point of the application.

##### Parameters

This method has no parameters.
