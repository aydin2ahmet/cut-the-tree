var data = new List<int>() { 100, 200, 100, 500, 100, 600 };
var edges = new List<List<int>>() { new List<int>() { 1, 2 }, new List<int>() { 2, 3 }, new List<int>() { 2, 5 }, new List<int>() { 4, 5 }, new List<int>() { 5, 6 } };

var result = cutTheTree(data, edges);

Console.WriteLine(result);

int cutTheTree(List<int> data, List<List<int>> edges)
{
    var idTotalDict = CalculateTotal(edges,data);

    int allDataTotal = data.Sum();
    int min = allDataTotal;

    foreach (var i in idTotalDict)
    {
        var diff = Math.Abs(allDataTotal - 2 * i.Value);

        if (min > diff)
            min = diff;
    }

    return min;
}

Dictionary<int, int> CalculateTotal(List<List<int>> edges, List<int> data)
{
    var idEdgesDict = new Dictionary<int, List<int>>();
    var idTotalDict = new Dictionary<int, int>();

    idEdgesDict[edges[0][1]] = new List<int>() { edges[0][0] };

    for (int i = 1; i < edges.Count(); i++)
    {
        if (idEdgesDict.ContainsKey(edges[i][0]))
            idEdgesDict[edges[i][0]].Add(edges[i][1]);
        else
            idEdgesDict[edges[i][0]] = new List<int>() { edges[i][1] };

        if (idEdgesDict.ContainsKey(edges[i][1]))
            idEdgesDict[edges[i][1]].Add(edges[i][0]);
        else
            idEdgesDict[edges[i][1]] = new List<int>() { edges[i][0] };
    }

    var queue = new Queue<int>();

    foreach (var i in idEdgesDict)
    {
        if (i.Value.Count() == 1)
            queue.Enqueue(i.Key);
    }

    while (queue.Count() > 0)
    {
        var id = queue.Dequeue();

        if (idEdgesDict[id].Count == 0)
            continue;

        var otherID = idEdgesDict[id][0];

        if (idTotalDict.ContainsKey(id))
            idTotalDict[id] += data[id - 1];
        else
            idTotalDict[id] = data[id - 1];

        if (idTotalDict.ContainsKey(otherID))
            idTotalDict[otherID] += idTotalDict[id];
        else
            idTotalDict[otherID] = idTotalDict[id ];

        idEdgesDict[id].Remove(otherID);

        if (!idEdgesDict.ContainsKey(otherID))
            continue;

        idEdgesDict[otherID].Remove(id);

        if (idEdgesDict[otherID].Count() == 1)
            queue.Enqueue(otherID);
    }

    return idTotalDict;
}