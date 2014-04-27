using UnityEngine;
using System.Collections;

public class TriggerSpeech : MonoBehaviour
{
    private SpeechController speechController;

    void Awake()
    {
        speechController = GetComponent<SpeechController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(speechController != null)
            speechController.StartSpeech(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
    }
}
