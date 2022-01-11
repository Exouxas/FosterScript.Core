# FosterScript
This project aims to make a library for genetic evolution of virtual species. It's a form of adaptation of the [NEAT algorithm](https://en.wikipedia.org/wiki/Neuroevolution_of_augmenting_topologies), but made to be highly dynamic.

The essential features of this library is:
- Scriptable neurons. Possibility to make a new type of neuron with a different calculation.
- Scriptable "organs". Organs that are made like modules to add features to creatures.
- Propagation. All neurons transmit signals at one step at a time, which allows for back-propagation, but also adds a delay between input and output which felt realistic at the time.

## Planned usage
I'm planning to make a server hosted implementation of this library, that will have a web GUI where you can see the creature attempt to survive live. The way I have made the library currently would allow the creatures to live indefinitely.

## Inspiration
The main inspiration is by a video from David Randall Miller: https://www.youtube.com/watch?v=N3tRFayqVtk

Points of interest:
- Neural network structure
- Diversity of input and output nodes
- Weighting system
- Graphing of network
