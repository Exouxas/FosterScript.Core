Running X amount of cycles: Instance of FiniteWorld
Running until software is stopped: Instance of IndefiniteWorld

Hard-coding an AI: Inherit from Actor
Self-learning AI: Instance of Learner

Creating a module for AI: Inherit from Module

Creating a custom neuron: Inherit from HiddenNode or InputNode


Utilizing the world/surrounding as an AI: Add an input or output node linked to a Module (Create all the logic in the Module)


Using the dynamic loader:
- Create an instance of Loader with the path to the nodes and modules. 
- Whenever a new Actor or Learner is made, link the loader when creating, so that the loader can add the relevant modules and neurons. 