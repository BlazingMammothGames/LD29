using UnityEngine;
using System.Collections;

public class HintTrigger : MonoBehaviour {
    private tk2dTextMesh uiText;

    void Awake()
    {
        uiText = GameObject.FindGameObjectWithTag("UI Text").GetComponent<tk2dTextMesh>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiText.text = transform.name;
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
