# DotNetExtras.Common Library

The DotNetExtras.Common library implements general-purpose classes that can simplify common tasks in various .NET Core projects.

## DotNetExtras.Common namespace
### NameOf (DotNetExtras.Common namespace)
Implements functionality similar to the [`nameof`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/nameof) expression, but also allows to generate full and partial names of nested properties. Supports original and `camelCase` formatting.

### PrimaryAssembly class
Provides static properties for the most frequently used attributes (company, copyright, product, version, title, description) of the running application's primary assembly.

### DotNetExtras.Common.Enums namespace
### AbbreviationAttribute class
Decorates `enum` fields with abbreviated versions of field names.

### ShortNameAttribute
Decorates `enum` fields with shortened versions of field names.

### EnumExtensions class
Extension methods for working with `Enum` types.

## DotNetExtras.Common.Extensions namespace
### StringExtensions class
Frequently used string extension methods, such as `ToSentence` (trims text and appends punctuation if needed), `Escape` (escapes special characters), etc.

### ObjectExtensions class
Extension methods for all object types, including deep cloning, checking equivalency, and getting/setting nested property values.

### ExceptionExtensions class
Extension methods for `Exception` types, such as retrieving error messages from current and inner exceptions.

### IEnumerableExtensions class
Extension methods for `IEnumerable` types, such as counting items and converting collections to comma-separated strings.

## DotNetExtras.Common.Extensions.Specialized namespace
### DictionaryExtensions class
Advanced extension methods for `Dictionary<TKey, TValue>` types.

### IListExtensions class
Advanced extension methods for `IList` types.

### IntegerExtensions class
Advanced extension methods for integer types.

### ObjectExtensions class
Advanced extension methods for object types, such as converting objects to dynamic objects.

### StringExtensions class
Advanced extension methods for string types.

### TypeExtensions class
Advanced extension methods for `Type` types, such as checking if a type is primitive or simple.

## DotNetExtras.Common.Json namespace 
### JsonExtensions class
Provides methods for serializing and deserializing objects to and from JSON format.

## DotNetExtras.Common.RegularExpressions namespace
### RegexExtensions class
Provides methods for working with regular expressions, such as matching patterns and extracting values.

## DotNetExtras.Common.Exceptions namespace
### SafeException class
A custom exception class that provides additional context for exceptions, such as error codes and user-friendly messages.

---
For details on each class and method, see the [API documentation](https://alekdavis.github.io/dotnet-extras).