using UnityEngine;
using System.Collections;

public class SpeechDoneTrigger : MonoBehaviour {
    public virtual void SpeechDone(GameObject player)
    {
        Debug.LogWarning("Empty speech done trigger");
    }
}
