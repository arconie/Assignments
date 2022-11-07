using TreeBranch;

var root = RootLevels.Root();

// Depth Result
var depth = Branche.MaxDepth(root);
Branche.PrintResult(depth);

public class Branche
{
    private List<Branche> _branches;

    public Branche()
    {
        _branches = new List<Branche>();
    }

    public void AddBranch(IEnumerable<Branche> newBranche)
    {
        _branches.AddRange(newBranche);
    }

    public static int MaxDepth(Branche root)
    {
        int depth = 0;

        foreach (Branche branch in root._branches)
        {
            depth = Math.Max(MaxDepth(branch), depth);
        }

        return depth + 1;
    }

    public static void PrintResult(int result)
    {
        Console.WriteLine("The max depth of the given tree is {0}.", result.ToString());
    }
}