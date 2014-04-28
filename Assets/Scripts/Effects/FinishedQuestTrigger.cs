using UnityEngine;
using System.Collections;

public class FinishedQuestTrigger : MonoBehaviour {
    private TaskList taskList;
    private SpeechController speechController;

    bool ran = false;

    void Awake()
    {
        taskList = GetComponent<TaskList>();
        speechController = GetComponent<SpeechController>();
    }

    void Update()
    {
        if (!ran && taskList.IsTaskDone("Kill aliens"))
        {
            ran = true;
            speechController.UpdateTexts("That's the last of them!\n\nNow to rescue Lisa!");
            speechController.StartSpeech(this.gameObject);
        }
    }
}
