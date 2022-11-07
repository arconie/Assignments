namespace TreeBranch;

public static class RootLevels
{
    // I've included "Levels.png" file to visualize the structure of the given root tree
    public static Branche Root()
    {
        // Level 0
        var branche = new Branche();

        // Level 1
        var a = new Branche();
        var b = new Branche();
        branche.AddBranch(new[] { a, b });

        // Level 2
        var c = new Branche();
        a.AddBranch(new[] { c });

        var d = new Branche();
        var e = new Branche();
        var f = new Branche();
        b.AddBranch(new[] { d, e, f });

        // Level 3
        var g = new Branche();
        var h = new Branche();
        var i = new Branche();
        d.AddBranch(new[] { g });
        e.AddBranch(new[] { h, i });

        // Level 4
        var j = new Branche();
        h.AddBranch(new[] { j });
        
        return branche;
    }
}