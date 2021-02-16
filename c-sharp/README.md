# README #


### Task 1 - Fix some ugly code ###

Imagine yourself working at Joke Company™. This company has an app that gets random Chuck Norris jokes and can substitute other peoples names into the joke instead of Chuck Norris'.

Your task as a professional developer is to clean up this app and make it something you can be proud of.

*Note: This is NOT a representation of our codebase to be clear. We did have fun crafting this beauty however ;)*

### Task 2 - Write a report ###

Write a document explaining some of the improvements you made to the code, and why you did so.

### What do I need? ###

* [.NET Core](https://www.microsoft.com/net/core) - any platform

### Who do I talk to? ###

If you have any questions you can email careers@geotab.com

### Build status ###
[![Build status](https://ci.appveyor.com/api/projects/status/lsvryi8ea0n6b4xo?svg=true)](https://ci.appveyor.com/project/fleetcarma/cs-challenge)

---

# Code changes:
* Added 2 layers, one for services and another for providers.
* Added interfaces and DI for tests and mocks.
* Fixed bug with categories and number of jokes.
* Changed the follow in order to increase maintainance.
* Changed methods to async.

# Next steps:
1. Add a RESTFUL API without changing the service layer
2. Add unit tests for service and provider layers
3. Add integration tests to UI layer.
