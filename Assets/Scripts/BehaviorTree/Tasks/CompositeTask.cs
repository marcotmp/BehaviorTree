using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeTask : Task {

    public List<Task> tasks;

    public CompositeTask(string name) : base(name) {
        tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }
}
