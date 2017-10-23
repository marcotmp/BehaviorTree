using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatForever : Task {
    private Task childTask;

    public RepeatForever(string name) : base(name)
    {
    }

    public void SetChildTask(Task task)
    {
        childTask = task;
    }

    public override ReturnCode Update()
    {
        if (childTask.Update() == ReturnCode.Succeed)
        {
            childTask.Restart();
        }

        return base.Update();
    }
}
