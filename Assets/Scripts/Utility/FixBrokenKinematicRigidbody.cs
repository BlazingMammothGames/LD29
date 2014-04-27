using UnityEngine;
using System.Collections;

public class FixBrokenKinematicRigidbody : MonoBehaviour
{
    void OnEnable()
    {
        rigidbody2D.gravityScale = 0;
    }

    void Update()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.angularVelocity = 0;
    }
}
