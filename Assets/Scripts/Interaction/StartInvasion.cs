using UnityEngine;
using System.Collections.Generic;

public class StartInvasion : SpeechDoneTrigger
{
    public List<CostumeBuilder> morphingNPCs = new List<CostumeBuilder>();
    public List<GameObject> enableObjects = new List<GameObject>();
    public List<GameObject> destroyObjects = new List<GameObject>();
    public AudioClip fightMusic;

    public override void SpeechDone(GameObject player)
    {
        foreach (CostumeBuilder cb in morphingNPCs)
            if (cb != null) cb.clothing = CostumeBuilder.Clothing.ALIEN;
        foreach (GameObject go in enableObjects)
            if (go != null) go.SetActive(true);
        foreach (GameObject go in destroyObjects)
            if(go != null) DestroyObject(go);

        AudioSource audio = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();
        audio.clip = fightMusic;
        audio.Play();
    }
}
