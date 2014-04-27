using UnityEngine;
using System.Collections.Generic;

public class TaskList : MonoBehaviour {
    public List<string> tasks = new List<string>();
    public List<bool> completed = new List<bool>();
    public List<string> barrierMessages = new List<string>();

    void Awake()
    {
        if (tasks.Count != completed.Count || tasks.Count != barrierMessages.Count)
            Debug.LogError("Task list doesn't match completed list!");
    }

    public void CompleteTask(string task)
    {
        int ndx = tasks.IndexOf(task);
        completed[ndx] = true;
    }

    public bool IsTaskDone(string task)
    {
        int ndx = tasks.IndexOf(task);
        return completed[ndx];
    }

    public string GetBarrierMessage(string task)
    {
        int ndx = tasks.IndexOf(task);
        return barrierMessages[ndx];
    }
}
