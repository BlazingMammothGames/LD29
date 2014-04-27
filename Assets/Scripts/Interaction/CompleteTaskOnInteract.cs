using UnityEngine;
using System.Collections;

public class CompleteTaskOnInteract : OnInteract
{
    public string task = "";

    public override void Action(GameObject player)
    {
        TaskList taskList = player.GetComponent<TaskList>();
        taskList.CompleteTask(task);
    }
}
