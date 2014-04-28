using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
            Application.LoadLevel("day1");
    }
}
