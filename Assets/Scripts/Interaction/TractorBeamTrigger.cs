using UnityEngine;
using System.Collections.Generic;

public class TractorBeamTrigger : SpeechDoneTrigger
{
    public List<GameObject> destroyOnComplete = new List<GameObject>();
    public float tractorBeamTime = 1;

    private bool animating = false;
    private float startTime = 0;

    public override void SpeechDone(GameObject player)
    {
        renderer.enabled = true;
        startTime = Time.time;
        animating = true;
    }

    void Update()
    {
        if (animating && (Time.time - startTime >= tractorBeamTime))
        {
            animating = false;
            renderer.enabled = false;
            foreach(GameObject go in destroyOnComplete)
                DestroyObject(go);
            DestroyObject(this.gameObject);
        }
    }
}
