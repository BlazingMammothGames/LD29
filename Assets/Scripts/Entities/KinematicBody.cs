using UnityEngine;
using System.Collections;

public class KinematicBody : MonoBehaviour {
    public Vector3 velocity;

    public enum FacingDirection { UP, RIGHT, DOWN, LEFT };
    public FacingDirection facingDirection = FacingDirection.RIGHT;

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
