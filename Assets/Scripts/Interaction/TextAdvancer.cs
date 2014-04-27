using UnityEngine;
using System.Collections;

public class TextAdvancer : MonoBehaviour {
    public bool ShouldTextBeAdvanced()
    {
        if (Input.GetKeyDown(KeyCode.X))
            return true;
        return false;
    }
}
