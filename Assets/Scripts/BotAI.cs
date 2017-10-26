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

        ai = new RepeatForever("AI Loop");
        var stateList = new Sequence("AI Sequence");
        var patrol = new Action("Patrol", Patrol);
        var backOffRandomSelector = new RandomSelector("Say Backoff");
        var sayBackoff1 = new Action("Say Backoff 1", delegate() { Say("Back off!"); return ReturnCode.Succeed; });
        var sayBackoff2 = new Action("Say Backoff 2", delegate() { Say("Don't touch me!"); return ReturnCode.Succeed; });
        var chase = new Action("Chase", Chase);
        var thankYouRandomSelector = new RandomSelector("Say Thank you");
        var sayThankYou1 = new Action("Say Thank you 1", delegate () { Say("Thank you!"); return ReturnCode.Succeed; });
        var sayThankYou2 = new Action("Say Thank you 2", delegate () { Say("Much better!"); return ReturnCode.Succeed; });

        backOffRandomSelector.AddTask(sayBackoff2);
        backOffRandomSelector.AddTask(sayBackoff1);
        thankYouRandomSelector.AddTask(sayThankYou2);
        thankYouRandomSelector.AddTask(sayThankYou1);

        stateList.AddTask(patrol);
        stateList.AddTask(backOffRandomSelector);
        stateList.AddTask(chase);
        stateList.AddTask(thankYouRandomSelector);

        ai.AddTask(stateList);

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
