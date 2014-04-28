using UnityEngine;
using System.Collections;

public class HeartMonitor : MonoBehaviour {
    public TakeDamage damageTaker;
    public int healthLevel = 1;

    private tk2dSprite sprite;

    void Awake()
    {
        sprite = GetComponent<tk2dSprite>();
    }

    void Update()
    {
        if (damageTaker.health < healthLevel)
            sprite.SetSprite("hearts/1");
    }
}
