using UnityEngine;
using System.Collections;

public class BlackoutTrigger : MonoBehaviour {
    public string playerTag = "Player";

    void Awake()
    {
        if (renderer != null)
            renderer.enabled = true;
        else
        {
            MeshRenderer[] renderers = transform.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer rend in renderers)
                rend.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (renderer != null)
                renderer.enabled = false;
            else
            {
                MeshRenderer[] renderers = transform.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer rend in renderers)
                    rend.enabled = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(renderer != null)
                renderer.enabled = true;
            else
            {
                MeshRenderer[] renderers = transform.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer rend in renderers)
                    rend.enabled = true;
            }
        }
    }
}
