using UnityEngine;
using System.Collections;

public class TextAdvancer : MonoBehaviour {
    public bool ShouldTextBeAdvanced()
    {
        if (Input.GetKeyUp(KeyCode.X))
            return true;
        return false;
    }
}
