using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeTask : Task {

    public List<Task> tasks;

    public CompositeTask(string name) : base(name) { }

    public CompositeTask AddTask(CompositeTask task)
    {
        tasks.Add(task);
        return this;
    }
}
