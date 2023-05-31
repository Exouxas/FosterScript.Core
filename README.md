# FosterScript.Core

FosterScript.Core is a C# library that provides a framework for genetic evolution of virtual species. It is designed to facilitate the implementation of the Neuroevolution of Augmenting Topologies ([NEAT](https://en.wikipedia.org/wiki/Neuroevolution_of_augmenting_topologies)) algorithm, while offering high flexibility and dynamic behavior.

## Key Features
The essential features of this library is:
- Scriptable neurons: FosterScript.Core allows you to create custom neuron types with different calculations, enabling the development of novel neural network architectures.
- Scriptable modules: Modules are components that enhance the functionality of agents. You can define and add custom modules to your agents to incorporate specific behaviors and capabilities.
- Propagation: The library supports signal propagation where neurons transmit signals in discrete steps, allowing for back-propagation and introducing a realistic delay between input and output.

## Planned Usage
I am planning to develop a server-hosted implementation of FosterScript.Core, featuring a web-based graphical user interface. This implementation will provide a live view of the agents' survival attempts, showcasing their adaptation to dynamic events. It will serve as a tool for researchers, game developers, and individuals interested in learning about neural networks and genetic algorithms.

## Inspiration
FosterScript.Core was inspired by a video from David Randall Miller, which explores various aspects of neural networks and genetic evolution. You can watch the video [here](https://www.youtube.com/watch?v=N3tRFayqVtk). The video covers topics such as neural network structure, diverse input and output nodes, weighting systems, and network visualization.

# Getting Started
To integrate FosterScript.Core into your project, please refer to the [implementation guide](https://github.com/Exouxas/FosterScript.Core/blob/main/IMPLEMENTATION.md) for detailed instructions.

# Examples
The [FosterScript.Examples](https://github.com/Exouxas/FosterScript.Examples/) repository contains several examples demonstrating the usage of FosterScript.Core. You can explore these examples to gain insights into implementing the framework in your own projects.

# Best Practices
When creating custom modules, it is recommended to follow the best practice of inheriting the `Module` base class. Here's an example illustrating the inheritance:

```csharp
public class ExampleModule : Module
{
    // Inherited Properties
    public override string Name => "Example module";
    public override int[] Version => new int[] { 1, 0, 0 };

    // Custom Properties
    public double StoredSample
    {
        get { return _storedSample; }
        set
        {
            if (value <= 0)
            {
                // Example of how to terminate the host actor
                Body?.Kill();
            }
            _storedSample = value;
        }
    }
    private double _storedSample;

    public ExampleModule() : base()
    {
        // Pre-initialization code
    }

    public override void Initialize()
    {
        // Perform initialization tasks, including adding input and output neurons.
    }

    public override void Think()
    {
        // Observation phase: Add logic for observing the environment, such as distance calculations with other actors.
    }

    public override void Act()
    {
        // Action phase: Execute planned interactions or behaviors.
    }
}
```

# Definitions
For detailed definitions and explanations of key terms used throughout the framework, please refer to the [DEFINITIONS.md](https://github.com/Exouxas/FosterScript.Core/blob/main/DEFINITIONS.md) file. This document provides comprehensive descriptions of concepts such as modules, nodes, neural connections, actors, and more. It serves as a valuable resource for gaining a deeper understanding of the framework's components and their interactions.