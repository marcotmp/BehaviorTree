public class Conditional : Task {
    private ConditionalDelegate conditionalDelegate;

    public Conditional(string name, ConditionalDelegate conditionalDelegate) : base(name)
    {
        this.conditionalDelegate = conditionalDelegate;
    }

    public override ReturnCode Update()
    {
        var value = conditionalDelegate();
        if (value)
        {
            return ReturnCode.Succeed;
        }
        else
        {
            return ReturnCode.Fail;
        }
    }
}

public delegate bool ConditionalDelegate();