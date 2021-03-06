﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : CompositeTask {

    private int taskIndex = 0;

    public Sequence(string name) : base(name) { }

    override public ReturnCode Update()
    {
        if (tasks == null || tasks.Count == 0)
            return ReturnCode.Succeed;

        //var task = tasks[taskIndex];
        //if (task == null)
        //    return ReturnCode.Running;

        var returnCode = tasks[taskIndex].Update();
        if (returnCode == ReturnCode.Succeed)
        {
            taskIndex++;
            if (taskIndex >= tasks.Count)
                return ReturnCode.Succeed;
            else
                return ReturnCode.Running;
        }
        else
        {
            return returnCode;
        }
    }

    public override void Restart()
    {
        taskIndex = 0;
        base.Restart();
    }
}
