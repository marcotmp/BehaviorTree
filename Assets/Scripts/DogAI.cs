using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAI : MonoBehaviour {

    private Task ai;

    // Use this for initialization
    void Start() {
        var bt = new BehaviorTreeBuilder();
        ai = bt.Selector("Car IA")
                .Add(
                    bt.Sequence("Stop Light")
                        .Add(bt.Action("actiono 1", null))
                        .Add(bt.Action("actiono 2", null))
                        .Add(bt.Action("actiono 3", null))
                    .Build()
                )
                //.Add()
            .Build();


        ai = new Selector("Dog AI")
        {
            tasks =
            {
                new Sequence("patrol")
                {
                    tasks = {
                        new Selector("move pattern 1")
                        {
                            tasks = {
                                new Action("walk1", Walk1),
                                new Action("walk2", Walk2)
                            }
                        },
                        new Selector("move pattern 1")
                    }
                },
                new CompositeTask("investigate task")
                {

                },
                new CompositeTask("attack task")
                {

                }
            }
        };
    }

    // Update is called once per frame
    void Update () {
        ai.Update();
    }

    public ReturnCode Walk1()
    {
        return ReturnCode.Running;
    }

    public ReturnCode Walk2()
    {
        return ReturnCode.Running;
    }

}
