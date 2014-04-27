using UnityEngine;
using System.Collections;

public class OnInteract : MonoBehaviour {
    public virtual void Action(GameObject player)
    {
        Debug.LogWarning("Empty interaction!");
    }
}
