using UnityEngine;
using System.Collections;

public class BlackoutTrigger : MonoBehaviour {
    public string playerTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered");
        if (other.CompareTag("Player"))
        {
            renderer.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exited");
        if (other.CompareTag("Player"))
        {
            renderer.enabled = true;
        }
    }
}
