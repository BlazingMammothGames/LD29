using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TeleportOnInteract))]
public class TeleportOnInteractEditor : Editor {
    TeleportOnInteract teleportOnInteract;

    public void OnEnable()
    {
        teleportOnInteract = (TeleportOnInteract)target;
    }

    public void OnSceneGUI()
    {
        teleportOnInteract.destination = Handles.PositionHandle(teleportOnInteract.destination, Quaternion.identity);
    }
}
