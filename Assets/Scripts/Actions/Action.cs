using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : Task {
    private ActionDelegate actionDelegate;

    public Action(string name, ActionDelegate actionDelegate)
    {
        if (actionDelegate == null)
            throw new UnassignedReferenceException();

        this.actionDelegate = actionDelegate;
    }


    public override ReturnCode Update()
    {
        return actionDelegate();
    }
}

public delegate ReturnCode ActionDelegate();