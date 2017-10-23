using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorTask : Task {

    protected Task task;

    public DecoratorTask(string name) : base(name) { }

    public void AddTask(Task task)
    {
        this.task = task;
    }
}
