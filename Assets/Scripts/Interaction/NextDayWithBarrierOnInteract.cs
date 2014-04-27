using UnityEngine;
using System.Collections;

public class NextDayWithBarrierOnInteract : OnInteract
{
    public string barrierTask;

    public override void Action(GameObject player)
    {
        TaskList tl = player.GetComponent<TaskList>();

        if (!tl.IsTaskDone(barrierTask))
        {
            SpeechController speechController = player.GetComponent<SpeechController>();
            speechController.UpdateTexts(tl.GetBarrierMessage(barrierTask));
            speechController.StartSpeech(player);
        }
        else
        {
            DayManager.GotoNextDay();
        }
    }
}
