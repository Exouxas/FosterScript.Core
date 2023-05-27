# FosterScript.Core
This project aims to make a library for genetic evolution of virtual species. It's a form of adaptation of the [NEAT algorithm](https://en.wikipedia.org/wiki/Neuroevolution_of_augmenting_topologies), but made to be highly dynamic.

The essential features of this library is:
- Scriptable neurons. Possibility to make a new type of neuron with a different calculation.
- Scriptable "modules". Modules that are made to add features to agents.
- Propagation. All neurons transmit signals at one step at a time, which allows for back-propagation, but also adds a delay between input and output which felt realistic at the time.

## Planned usage
I'm planning to make a server hosted implementation of this library, that will have a web GUI where you can see the agents attempt to survive live.

## Progress
My attempt at tracking progress of the different classes to make development more effective.
- ![100%](https://progress-bar.dev/100) Overall architecture/design
- ![100%](https://progress-bar.dev/100) NeuralNetwork
  - ![100%](https://progress-bar.dev/100) Neuron
  - ![100%](https://progress-bar.dev/100) InputNode
  - ![100%](https://progress-bar.dev/100) HiddenNode
  - ![100%](https://progress-bar.dev/100) OutputNode
  - ![100%](https://progress-bar.dev/100) NeuralConnection
  - ![100%](https://progress-bar.dev/100) Brain
- ![100%](https://progress-bar.dev/100) Agents
  - ![100%](https://progress-bar.dev/100) Actor
  - ![100%](https://progress-bar.dev/100) Module
- ![100%](https://progress-bar.dev/100) Environments
  - ![100%](https://progress-bar.dev/100) World
  - ![100%](https://progress-bar.dev/100) IndefiniteWorld
  - ![100%](https://progress-bar.dev/100) FiniteWorld


## Inspiration
The main inspiration is by a video from David Randall Miller: https://www.youtube.com/watch?v=N3tRFayqVtk

Points of interest from the video:
- Neural network structure
- Diversity of input and output nodes
- Weighting system
- Graphing of network
