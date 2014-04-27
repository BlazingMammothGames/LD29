using UnityEngine;
using System.Collections;

public class KinematicBody : MonoBehaviour {
    public Vector3 velocity;
    public Vector3 truePosition = Vector3.zero;

    public enum FacingDirection { UP, RIGHT, DOWN, LEFT };
    public FacingDirection facingDirection = FacingDirection.RIGHT;

    private CharacterCollider characterCollider = null;

    void Awake()
    {
        characterCollider = GetComponent<CharacterCollider>();
        truePosition = transform.position;
    }

    void Update()
    {
        if (characterCollider != null) characterCollider.AdjustVelocity(Time.deltaTime);
        truePosition += velocity * Time.deltaTime;

        // lock it to pixels
        transform.position = new Vector3(Mathf.Round(truePosition.x * 8) / 8f, Mathf.Round(truePosition.y * 8) / 8, truePosition.z);
    }
}
