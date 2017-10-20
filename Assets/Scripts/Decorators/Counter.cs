﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : Task {
    public Task task;

    private int count = 0;
    private int i = 0;

    public Counter(string name, int count) : base(name)
    {
        this.count = count;
    }

    public override ReturnCode Update()
    {
        var returnCode = task.Update();
        if (returnCode == ReturnCode.Succeed)
        {
            i++;
            if (i > count)
                return ReturnCode.Succeed;

            task.Restart();
        }

        return returnCode;
    }

    public override void Restart()
    {
        i = 0;
    }
}
