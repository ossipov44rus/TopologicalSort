var graph = new Dictionary<string, string[]>();
graph.Add("web", new string[] { "model", "common" });
graph.Add("api", new string[] { "common", "model" });
graph.Add("model", new string[] { "utils", "database" });
graph.Add("common", new string[] { "utils", "json" });
graph.Add("database", Array.Empty<string>());
graph.Add("utils", Array.Empty<string>());
graph.Add("json", Array.Empty<string>());

var colors = new Dictionary<string, string>();
colors.Add("web", "white");
colors.Add("api", "white");
colors.Add("model", "white");
colors.Add("common", "white");
colors.Add("database", "white");
colors.Add("utils", "white");
colors.Add("json", "white");

var relationship = new Dictionary<string, string>();

var queue = new Queue<string>();
colors["web"] = "gray";
queue.Enqueue("web");

while (colors["web"] != "black")
{
    string qu = queue.Peek();
    if (colors[qu] == "black")
    {
        queue.Dequeue();
    }
    else
    {
        int countNotBlack = 0;
        foreach (var i in graph[qu])
        {
            if (colors[i] != "black")
            {
                countNotBlack++;
            }
        }

        if (countNotBlack != 0)
        {
            foreach (var j in graph[qu])
            {
                if (colors[j] == "grey")
                {
                    continue;
                }
                else
                {
                    colors[j] = "grey";
                    queue.Enqueue(j);
                    relationship.Add(j, qu);
                }
            }
        }
        else
        {
            colors[qu] = "black";
            if (qu != "web")
            {
                queue.Enqueue(relationship[qu]);
            }
        }
        queue.Dequeue();
    }
}

foreach (KeyValuePair<string, string> kvp in colors)
{
    Console.WriteLine($"{kvp.Key}-{kvp.Value}");
}

