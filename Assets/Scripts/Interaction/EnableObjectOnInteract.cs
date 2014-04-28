using UnityEngine;
using System.Collections;

public class EnableObjectOnInteract : OnInteract
{
    public GameObject target;

    public override void Action(GameObject player)
    {
        target.SetActive(true);
    }
}
