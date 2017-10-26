public class Task {
    public string name;

    public Task(string name) { this.name = name; }

    virtual public ReturnCode Update()
    {
        return ReturnCode.Running;
    }

    virtual public void Restart() { }
}

public enum ReturnCode
{
    Fail,
    Succeed,
    Running
}