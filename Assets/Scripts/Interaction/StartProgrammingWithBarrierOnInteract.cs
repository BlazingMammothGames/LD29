using UnityEngine;
using System.Collections;

public class StartProgrammingWithBarrierOnInteract : OnInteract {
    public string barrierTask;

    public GameObject computer;

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
            //player.GetComponent<PlayerControl>().freezeInput = true;
            player.SetActive(false);
            computer.SetActive(true);
        }
    }
}
