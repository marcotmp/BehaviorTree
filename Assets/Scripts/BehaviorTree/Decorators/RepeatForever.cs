using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatForever : DecoratorTask {
    
    public RepeatForever(string name) : base(name)
    {
    }
    
    public override ReturnCode Update()
    {
        if (task.Update() == ReturnCode.Succeed)
        {
            task.Restart();
        }

        return base.Update();
    }
}
