# Definitions

## **Organ**
Logical class that controls its host. Can create input and output nodes to allow for integration into the creatures logic.

## **Node**
Calculation point in the neural network.

### **Input node**
Collects external information to create a signal that is provided to the network. Not affected by other neurons unless explicit logic is made in the organ that created it.

### **Hidden node**
Purely calculative point. Takes values from input nodes and other hidden nodes, then calculates an appropriate output that is sent to either an output node or a hidden node.

### **Output node**
Collects values from input nodes and hidden nodes, and uses a simple activation function to decide wether the output activates. Also contains logic for what the node actuates (usually closely related to the organ it was created from).

## **Neural connection**
Connection between two nodes. Has a weight (multiplier) from -4 to 4.

## **Creature**
Collection of organs and neurons.

## **Loader**
Dynamically loads organs and neurons during runtime. Can be used as a single-time load or a scheduled repeated load. 

