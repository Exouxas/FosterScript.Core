# Implementation
This guide is unfortunately not fully complete, and any assistance would be appreciated.

## Step 1: Worlds
There are two premade world types; `FiniteWorld` and `IndefiniteWorld`. The first one runs for a set amount of cycles, and the second one runs on a timer until the software is stopped.

If you want to make your own world, you need to inherit from `World` and implement the `Start` and `Stop` methods. After these are implemented in some way, you can use the `Step` method to run one full cycle of the world. You can also complete specific parts of the step with the `Think` and `Act` methods. These methods will cause all the actors to execute all their modules. More on this in the next steps.

## Step 2: Actors
`Actor` is a non-abstract class that can be used as a base for your own actors. If you for example have a `Player` class, you can inherit from `Actor` and add your own properties and methods.

You can also just use the `Actor` class as is, and add modules to it. This is the recommended way to use this library, as it allows for more dynamic behavior.

## Step 3: Modules
Modules are the main way to add behavior to your actors. They are made to be as dynamic as possible, and can be used in many different ways. The most basic way to use a `Module` is to inherit from it and implement the `Think` and `Act` methods. These methods will be called every time the world is stepped, and will allow you to add your own logic to the actor.

### Names and versions
Every module needs to have the `Name` and `Version` properties. The `Name` is used to identify the module, and the `Version` is used to check if the module is compatible with the other modules. The `Version` needs to have the same Major version when checking for compatibility, but can have a higher or equal of all the other version numbers. This allows for backwards compatibility.

Example:
```
Required: [2,7,4], Module version: [2,7,3] -> Not compatible
Required: [2,7,4], Module version: [2,7,4] -> Compatible
Required: [2,7,4], Module version: [2,8,5] -> Compatible
Required: [2,7,4], Module version: [3,8,0] -> Not compatible
```

### Adding dependencies
If you want to make a module that is dependent on another module, you can add an entry to the `Dependencies` dictionary. The key is the name of the module, and the value is the minimum version required. If the module is not found, or the version is not compatible, the module will not be fully added to the actor.

### Referencing dependencies
You can reference a dependency like this by using the `DependencyReferences` dictionary. The key is the name of the module, and the value is the module itself. This dictionary is automatically populated when the module is added to an actor. Here is an example where we want to reference the `Energy` module:

```csharp
((Energy)DependencyReferences["Energy"]).EnergyStored += 1;
```

### Implementing logic
Next, you need to implement the `Initialize`, `Think`, and `Act` methods. The `Initialize` method is called when the module is added to an actor, and is used to set up the module. The `Think` method is called every time the world is stepped, and is used to add logic to the actor. The `Act` method is called every time the world is stepped, and is used to add logic to the actor.


## Step 4 `(optional)`: Brain (Neural Network)
[`Incomplete description`] Add an input or output node linked to a Module (Create all the logic in the Module)

## Step 5 `(optional)`: Nodes
[`Incomplete description`] Creating a custom neuron: Inherit from HiddenNode



## [`planned`] Step 6 `(optional)`: Dynamic Loader
- Create an instance of CachedLoader with the path to the nodes and modules. 
- Whenever a new node or module is made, the loader will automatically load it into the world.
