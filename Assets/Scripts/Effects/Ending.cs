using UnityEngine;
using System.Collections;

public class Ending : MonoBehaviour {
    public float displayTime = 3;

    private float startTime = 0;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime >= displayTime)
            Application.LoadLevel("mainmenu");
    }
}
