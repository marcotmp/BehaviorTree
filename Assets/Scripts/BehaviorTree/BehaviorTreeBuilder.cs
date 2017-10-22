
using System;

public class BehaviorTreeBuilder
{
    public Task Build()
    {
        return null;
    }

    public BehaviorTreeBuilder Selector(string name)
    {
        return new BehaviorTreeBuilder();
    }

    public BehaviorTreeBuilder Add(Task task)
    {
        return this;
    }

    public BehaviorTreeBuilder Sequence(string name)
    {
        return new BehaviorTreeBuilder();
    }

    public Task Action(string name, Action action)
    {
        return null;
    }
}
