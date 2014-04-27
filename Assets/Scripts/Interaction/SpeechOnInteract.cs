using UnityEngine;
using System.Collections;

public class SpeechOnInteract : OnInteract
{
    private SpeechController speechController;
    void Awake()
    {
        speechController = GetComponent<SpeechController>();
    }

    public override void Action(GameObject player)
    {
        if (speechController != null)
            speechController.StartSpeech(player);
    }
}
