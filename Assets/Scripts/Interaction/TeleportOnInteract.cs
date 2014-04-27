using UnityEngine;
using System.Collections;

public class TeleportOnInteract : OnInteract {
    public Vector3 destination;

    public override void Action(GameObject player)
    {
        player.GetComponent<KinematicBody>().truePosition.x = destination.x;
        player.GetComponent<KinematicBody>().truePosition.y = destination.y;
    }
}
