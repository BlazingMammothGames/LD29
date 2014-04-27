using UnityEngine;
using System.Collections;

public class HintTrigger : MonoBehaviour {
    private tk2dTextMesh uiText;
    private OnInteract[] onInteracts;

    void Awake()
    {
        uiText = GameObject.FindGameObjectWithTag("UI Text").GetComponent<tk2dTextMesh>();
        onInteracts = GetComponents<OnInteract>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiText.text = transform.name;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                foreach (OnInteract interact in onInteracts)
                    interact.Action(other.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiText.text = "";
        }
    }
}
