# Cut the Tree

There is an undirected tree where each vertex is numbered from 1 to n, and each contains a data value. The sum of a tree is the sum of all its nodes' data values. If an edge is cut, two smaller trees are formed. The difference between two trees is the absolute value of the difference in their sums.Given a tree, determine which edge to cut so that the resulting trees have a minimal difference between them, then return that difference.
Example

data = [1, 2, 3, 4, 5, 6]

edges = [(1, 2), (1, 3), (2, 6), (3, 4), (3,5)]

The values are calculated as follows:

  Edge   Tree 1  Tree 2 Absolute 
  
  Cut    Sum     Sum    Difference
  
  1      8       13       5
  
  2      9       12       3
  
  3      6       15       9
  
  4      4       17       13
  
  5      5       16       11

The minimum absolute difference is 3.
Note: The given tree is always rooted at vertex 1.


Function Description 
Complete the cutTheTree function in the editor below. cutTheTree has the following parameter(s): 
• int data[n]: an array of integers that represent node values 
• int edges[n-1][2]: an 2 dimensional array of integer pairs where each pair represents nodes connected by the edge 


Returns 
• int: the minimum achievable absolute difference of tree sums 
