# FosterScript
This project aims to make a library for genetic evolution of virtual species. It's a form of adaptation of the [NEAT algorithm](https://en.wikipedia.org/wiki/Neuroevolution_of_augmenting_topologies), but made to be highly dynamic.

The essential features of this library is:
- Scriptable neurons. Possibility to make a new type of neuron with a different calculation.
- Scriptable "modules". Modules that are made to add features to actors/creatures.
- Propagation. All neurons transmit signals at one step at a time, which allows for back-propagation, but also adds a delay between input and output which felt realistic at the time.

## Planned usage
I'm planning to make a server hosted implementation of this library, that will have a web GUI where you can see the creature attempt to survive live. The way I have made the library currently would allow the creatures to live indefinitely.

## Progress
- ![80%](https://progress-bar.dev/80) Structure
- ![100%](https://progress-bar.dev/100) Neuron
- ![25%](https://progress-bar.dev/25) Actor
- ![5%](https://progress-bar.dev/5) Actor subtypes
- ![10%](https://progress-bar.dev/10) Module
- ![0%](https://progress-bar.dev/0) Module subtypes (might not have subtypes)
- ![0%](https://progress-bar.dev/0) World
- ![0%](https://progress-bar.dev/0) World subtypes

## Inspiration
The main inspiration is by a video from David Randall Miller: https://www.youtube.com/watch?v=N3tRFayqVtk

Points of interest:
- Neural network structure
- Diversity of input and output nodes
- Weighting system
- Graphing of network
