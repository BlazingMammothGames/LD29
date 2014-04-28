using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {
    public int health = 3;
    public float flickerTime = 0.25f;
    public float dyingTime = 2;

    private bool dying = false;
    private float startTime = 0;

    private tk2dSprite[] sprites;

    public float unColourTime = 0;

    void Awake()
    {
        sprites = transform.parent.GetComponentsInChildren<tk2dSprite>();
    }

    public void Damage()
    {
        if (dying || Time.time < unColourTime)
            return;

        health--;

        foreach (tk2dSprite sprite in sprites)
            sprite.color = Color.red;
        unColourTime = Time.time + flickerTime;

        if (health <= 0)
        {
            if (transform.parent.CompareTag("Player"))
            {
                startTime = Time.time;
                dying = true;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<TaskList>().aliensRemaining--;
                //.GetComponent<TaskList>().aliensRemaining++;
                DestroyObject(transform.parent.gameObject);
            }
        }
    }

    void Update()
    {
        if (Time.time >= unColourTime)
        {
            foreach (tk2dSprite sprite in sprites)
                sprite.color = Color.white;
        }

        if (dying && Time.time - startTime >= dyingTime)
        {
            Application.LoadLevel("gameover");
        }
    }
}
