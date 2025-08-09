# DotNetExtras
`DotNetExtras` is a collection of libraries intended to make the lives of .NET Core application developers easier. The libraries are organized into several projects, each serving a specific purpose.

## DotNetExtras.Common library
Implements general-purpose classes for such common tasks as retrieving error information from the immediate and inner exceptions, simple JSON serialization and deserialization, string functions making it easier to generate tokenized strings from collections, deep object cloning and comparison, setting object properties and getting property values using compound (nested) property names, and a lot more.

## DotNetExtras.Configuration library
Offers an easy way to read and transform application settings.

## DotNetExtras.Mail library
Allows applications to easily find supported translations of localized email templates and merge them with the message-specific data.

## DotNetExtras.OData library
Implements capabilities to parse and validate OData search filters.

## DotNetExtras.Retry
Provides a simple and consistent way of retrying failed operations.

## DotNetExtras.Security
Simplifies security operations such as hashing, encryption, random password generation, etc.

## DotNetExtras.Testing
Implements helper classes that can be used in unit tests including assertion operations and mocking configuration settings. 

## DotNetExtras.Web
Defines helper methods for REST API client operations such as automatic refresh of the access tokens, parsing of the common error structures implemented by different providers (Azure, Apigee, OAuth, SCIM, etc.). 

# DotNetExtras documentation
The complete API documentation is available at https://alekdavis.github.io/dotnet-extras.