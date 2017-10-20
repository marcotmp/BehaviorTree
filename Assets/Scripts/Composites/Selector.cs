using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : CompositeTask {

    private int taskIndex = 0;

    public Selector(string name) : base(name) { }

    override public ReturnCode Update()
    {
        var returnCode = tasks[taskIndex].Update();
        if (returnCode == ReturnCode.Fail)
        {
            taskIndex++;
            if (taskIndex > tasks.Count)
                return ReturnCode.Fail;
            else
                return ReturnCode.Running;
        }
        else
        {
            return returnCode;
        }
    }

}
