# DotNetExtras libraries
This repository contains the source code of the .NET Core libraries intended to simplify common tasks in .NET Core projects. The libraries are organized into several projects, each serving a specific purpose.

## DotNetExtras library projects

### DotNetExtras.Common library
Implements general-purpose classes for common tasks such as retrieving error information from the immediate and inner exceptions, simple JSON serialization and deserialization, string functions making it easier to generate tokenized strings from collections, deep object cloning and comparison, setting object properties and getting property values using compound (nested) property names, etc.

### DotNetExtras.Mail library
Provides functionality simplifying the use of localized email templates for sending email notifications.

### DotNetExtras.OData library
Offers functions for parsing and validating OData search filters.

### DotNetExtras.Security library
Simplifies security operations such as hashing, encryption, random password generation, etc.

### DotNetExtras.Testing library
Contains helper classes that can be used in unit tests including assertion operations and mocking configuration settings. 

### DotNetExtras.Web library
Defines helper methods for REST API client operations such as automatic refresh of the access tokens, parsing of the common error structures implemented by different providers (Azure, Apigee, OAuth, SCIM, etc.). 

## DotNetExtras API documentation
The complete API documentation and code samples are available at https://alekdavis.github.io/dotnet-extras.