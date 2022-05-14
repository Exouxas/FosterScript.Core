# FosterScript.Core
This project aims to make a library for genetic evolution of virtual species. It's a form of adaptation of the [NEAT algorithm](https://en.wikipedia.org/wiki/Neuroevolution_of_augmenting_topologies), but made to be highly dynamic.

The essential features of this library is:
- Scriptable neurons. Possibility to make a new type of neuron with a different calculation.
- Scriptable "modules". Modules that are made to add features to actors/creatures.
- Propagation. All neurons transmit signals at one step at a time, which allows for back-propagation, but also adds a delay between input and output which felt realistic at the time.

## Planned usage
I'm planning to make a server hosted implementation of this library, that will have a web GUI where you can see the creature attempt to survive live. The way I have made the library currently would allow the creatures to live indefinitely.

## Progress
My attempt at tracking progress of the different classes to make development more effective.
- ![90%](https://progress-bar.dev/90) Overall architecture/design
- ![80%](https://progress-bar.dev/80) Neural network
  - ![100%](https://progress-bar.dev/100) Neuron
  - ![100%](https://progress-bar.dev/100) InputNode
  - ![100%](https://progress-bar.dev/100) HiddenNode
  - ![100%](https://progress-bar.dev/100) OutputNode
  - ![100%](https://progress-bar.dev/100) NeuralConnection
  - ![0%](https://progress-bar.dev/0) Brain
- ![33%](https://progress-bar.dev/33) Agents
  - ![90%](https://progress-bar.dev/90) Actor
  - ![5%](https://progress-bar.dev/5) Module
  - ![5%](https://progress-bar.dev/5) Learner
- ![0%](https://progress-bar.dev/0) Environments
  - ![0%](https://progress-bar.dev/0) World
  - ![0%](https://progress-bar.dev/0) IndefiniteWorld
  - ![0%](https://progress-bar.dev/0) FiniteWorld
- ![10%](https://progress-bar.dev/10) Loader


## Inspiration
The main inspiration is by a video from David Randall Miller: https://www.youtube.com/watch?v=N3tRFayqVtk

Points of interest from the video:
- Neural network structure
- Diversity of input and output nodes
- Weighting system
- Graphing of network
