
using System;

public class BehaviorTreeBuilder
{
    public BehaviorTreeBuilder parentBuilder;
    public Task parentTask;
    private Task task;
    public BehaviorTreeBuilder RepeatForever(string name)
    {
        var repeatForever = new RepeatForever(name);
        TryToAddTask(repeatForever);
        return CreateChildTreeBuilder(repeatForever);
    }

    public BehaviorTreeBuilder Sequence(string name)
    {
        var sequence = new Sequence(name);
        TryToAddTask(sequence);
        return CreateChildTreeBuilder(sequence);
    }

    public BehaviorTreeBuilder Action(string name, ActionDelegate action)
    {
        TryToAddTask(new Action(name, action));

        return this;
    }

    public BehaviorTreeBuilder RandomSelector(string name)
    {
        var selector = new RandomSelector(name);
        
        // try to add task
        TryToAddTask(selector);

        return CreateChildTreeBuilder(selector);
    }

    public BehaviorTreeBuilder End()
    {
        return this.parentBuilder;
    }

    public Task Build()
    {
        return task;
    }

    private void TryToAddTask(Task task)
    {
        if (parentTask is DecoratorTask)
        {
            DecoratorTask dt = (DecoratorTask)parentTask;
            dt.AddTask(task);
        }
        else if (parentTask is CompositeTask)
        {
            CompositeTask ct = (CompositeTask)parentTask;
            ct.AddTask(task);
        }
    }

    private BehaviorTreeBuilder CreateChildTreeBuilder(Task task)
    {
        var bt = new BehaviorTreeBuilder();
        bt.parentTask = task;
        bt.parentBuilder = this;

        this.task = task;

        return bt;
    }
}
