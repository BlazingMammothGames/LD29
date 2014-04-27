using UnityEngine;
using System.Collections;

public class ApartmentAnimator : MonoBehaviour
{
    float startTime = 0;
    public GameObject nightBlocker;

    public float lightsOutTime = 3;
    public float blacknessTime = 5;
    public float nextSceneTime = 7;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime >= nextSceneTime)
        {
            DayManager.LoadDay();
        }
        else if (Time.time - startTime >= blacknessTime)
        {
            nightBlocker.SetActive(true);
        }
        else if (Time.time - startTime >= lightsOutTime)
        {
            renderer.material.color = Color.black;
        }
    }
}
