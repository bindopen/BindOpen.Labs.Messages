# BindOpen.Messages

![BindOpen logo](https://storage.bindopen.org/img/logos/logo_bindopen.png)

![Github release version](https://img.shields.io/nuget/v/BindOpen.Kernel.Abstractions.svg?style=plastic)


BindOpen is a framework that enables the construction of highly extensible applications. It allows you to enhance your .NET projects with custom script functions, connectors, entities, and tasks.

## About

BindOpen.Messages provides a unified mechanism for sending and receiving messages.

It is composed of the following modules:

* __Messages.Email__ for email messages (supporting Pop3, Smtp and Imap protocoles).
* __Messages.Feeds__ for feed messages (like Atom).

A [full list of all the BindOpen repos](https://github.com/bindopen?tab=repositories) is available as well.


## Install

To get started, install the BindOpen.Messages module you want to use.

Note: We recommend that later on, you install only the package you need.

### From Visual Studio

| Module | Instruction |
|--------|-----|
| [BindOpen.Messages.Email](https://www.nuget.org/packages/BindOpen.Messages.Email) | ```PM> Install-Package BindOpen.Messages.Email``` |
| [BindOpen.Messages.Feeds](https://www.nuget.org/packages/BindOpen.Messages.Feeds) | ```PM> Install-Package BindOpen.Messages.Feeds``` |

### From .NET CLI

| Module | Instruction |
|--------|-----|
| [BindOpen.Messages.Email](https://www.nuget.org/packages/BindOpen.Messages.Email) | ```> dotnet add package BindOpen.Messages.Email``` |
| [BindOpen.Messages.Feeds](https://www.nuget.org/packages/BindOpen.Messages.Feeds) | ```> dotnet add package BindOpen.Messages.Feeds``` |

## Get started

### Feeds

```csharp
var meta = BdoData.NewMeta("host", DataValueTypes.Text, "my-test-host");
```

### Email

```csharp
var meta = BdoData.NewMeta("host", DataValueTypes.Text, "my-test-host");
```


## License

This project is licensed under the terms of the MIT license. [See LICENSE](https://github.com/bindopen/BindOpen.Messages/blob/master/LICENSE).

## Packages

This repository contains the code of the following Nuget packages:

| Package | Provision |
|----------|-----|
| [BindOpen.Messages](https://www.nuget.org/packages/BindOpen.Messages) | Core message management |
| [BindOpen.Messages.Abstractions](https://www.nuget.org/packages/BindOpen.Messages.Abstractions) | Interfaces and enumerations |
| [BindOpen.Messages.Email](https://www.nuget.org/packages/BindOpen.Messages.Email) | Email message management |
| [BindOpen.Messages.Feeds](https://www.nuget.org/packages/BindOpen.Messages.Feeds) | Feed message management |

The atomicity of these packages allows you install only what you need respecting your solution's architecture.

All of our NuGet packages are available from [our NuGet.org profile page](https://www.nuget.org/profiles/bindopen).


## Other repos and Projects

[BindOpen.Plus](https://github.com/bindopen/BindOpen.Plus) is a collection of projects based on BindOpen.Kernel.


A [full list of all the repos](https://www.nuget.org/packages?q=bindopen.Labs) is available as well.


## Documentation and Further Learning

### [BindOpen Docs](https://docs.bindopen.org/)

The BindOpen Docs are the ideal place to start if you are new to BindOpen. They are categorized in 3 broader topics:

* [Articles](https://docs.bindopen.org/articles) to learn how to use BindOpen;
* [Notes](https://docs.bindopen.org/notes) to follow our releases;
* [Api](https://docs.bindopen.org/api) to have an overview of BindOpen APIs.

### [BindOpen Blog](https://www.bindopen.org/blog)

The BindOpen Blog is where we announce new features, write engineering blog posts, demonstrate proof-of-concepts and features under development.


## Feedback

If you're having trouble with BindOpen, file a bug on the [BindOpen Issue Tracker](https://github.com/bindopen/BindOpen.Plus.Messgaes/issues). 

## Donation

You are welcome to support this project. All donations are optional but are greatly appreciated.

[![Please donate](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/donate/?hosted_button_id=PHG3WSUFYSMH4)


