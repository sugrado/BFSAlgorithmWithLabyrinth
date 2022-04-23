var nodeManager = new CustomLinkedListManager();

int[,] GetFileContent()
{
    int[,] lines;
    string[] rows;
    try
    {
        rows = File.ReadAllLines(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\graph.txt");
        lines = new int[rows.Length, rows.Length];

        for (int i = 0; i < rows.Length; i++)
        {
            var columns = rows[i].Split(' ');

            if (columns.Length != rows.Length || columns.Contains(string.Empty))
                return null;

            for (int j = 0; j < rows.Length; j++)
                lines[i, j] = Convert.ToInt32(columns[j]);
        }

        return lines;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error Message:\n" + ex.Message);
        return null;
    }
}

QueueModel<int>[] linkedLists = null;
void LoadLinkedListData()
{
    int[,] matrix = GetFileContent();
    int nodeCount = matrix.GetLength(0);
    linkedLists = new QueueModel<int>[nodeCount];
    for (int i = 0; i < linkedLists.Length; i++)
        linkedLists[i] = new QueueModel<int>();

    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(0); j++)
            if (matrix[i, j] != 0)
                nodeManager.Enqueue(linkedLists[i], j);
}

void PrintGraph(QueueModel<int>[] linkedLists)
{
    for (int i = 0; i < linkedLists.Length; i++)
    {
        Console.WriteLine($"\nNeighborhood list of node {i}:");
        nodeManager.PrintList(linkedLists[i]);
        Console.Write("\n");
    }
}

void BFS(QueueModel<int>[] linkedLists, int currentEdge)
{
    bool[] visited = new bool[linkedLists.Length];
    var queue = new QueueModel<int>();

    visited[currentEdge] = true;
    nodeManager.Enqueue(queue, currentEdge);

    Console.Write("\nVisited Nodes: ");
    while (nodeManager.HasValue(queue) != default)
    {
        currentEdge = nodeManager.Dequeue(queue);
        QueueModel<int> adjencyList = linkedLists[currentEdge];
        Console.Write(currentEdge + ", ");
        visited = nodeManager.CheckAdjencyListAndSetVisited(adjencyList, visited, queue);
    }
    Console.WriteLine();
}

LoadLinkedListData();
PrintGraph(linkedLists);
BFS(linkedLists, linkedLists.Length - 1);