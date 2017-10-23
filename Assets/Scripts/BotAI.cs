using UnityEngine;
using UnityEngine.UI;

public class BotAI : MonoBehaviour {

    public Text text;
    public Transform pointA;
    public Transform pointB;
    public Transform player;
    public float botSpeed = 1;
    public float chaseMinimunDistance = 1;
    public float chaseMaximunDistance = 1;


    private RepeatForever ai;
    private Transform target;

    void Start() {
        target = pointA;

        /*
         Repeate Forever
            Sequence
                patrol -> move to a, move to b
                chase -> move until is far
         */

        ai = new RepeatForever("AI Loop");
        var stateList = new Sequence("AI Sequence");
        var patrol = new Action("Patrol", Patrol);
        var sayBackoff = new Action("Say Backoff", delegate() { Say("Back off!"); return ReturnCode.Succeed; });
        var chase = new Action("Chase", Chase);
        var sayThankYou = new Action("Say Thank you", delegate () { Say("Thank you"); return ReturnCode.Succeed; });
        stateList.AddTask(patrol);
        stateList.AddTask(sayBackoff);
        stateList.AddTask(chase);
        stateList.AddTask(sayThankYou);
        ai.SetChildTask(stateList);

    }

    // Update is called once per frame
    void Update () {
        ai.Update();
    }

    public ReturnCode Patrol()
    {
        // move from point a to point b and back to point a

        // Look at the target point
        transform.LookAt(target);

        // move forward
        transform.position += botSpeed * transform.forward * Time.deltaTime;
        
        // Is close enough to the point
        var distance = Vector3.Distance(target.position, transform.position);
        if (distance < 0.01f)
        {
            // swap the target point
            if (target == pointA)
                target = pointB;
            else
                target = pointA;
        }

        // Is close enough to the player?
        var playerDistance = Vector3.Distance(player.position, transform.position);
        if (playerDistance < chaseMinimunDistance)
            // if so, then fail
            return ReturnCode.Succeed; 
        else
            // keep running until fail
            return ReturnCode.Running;
    }

    public ReturnCode Chase()
    {
        // move toward the player

        // Look at the target point
        transform.LookAt(player);

        // move forward
        transform.position += botSpeed * transform.forward * Time.deltaTime;

        // fail if player is too far
        var playerDistance = Vector3.Distance(player.position, transform.position);
        if (playerDistance > chaseMaximunDistance)
            // if so, then fail
            return ReturnCode.Succeed;
        else
            // keep running until fail
            return ReturnCode.Running;
    }

    public void Say(string message)
    {
        text.text = message;
    }

    
}
