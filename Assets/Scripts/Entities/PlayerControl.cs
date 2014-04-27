using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float moveSpeed = 2f;

    private KinematicBody body;

    void Awake()
    {
        body = GetComponent<KinematicBody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.velocity.y = moveSpeed;
            body.facingDirection = KinematicBody.FacingDirection.UP;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            body.velocity.y = -moveSpeed;
            body.facingDirection = KinematicBody.FacingDirection.DOWN;
        }
        else
            body.velocity.y = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity.x = -moveSpeed;
            body.facingDirection = KinematicBody.FacingDirection.LEFT;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity.x = moveSpeed;
            body.facingDirection = KinematicBody.FacingDirection.RIGHT;
        }
        else
            body.velocity.x = 0;

        // limit the speed diagonally
        if (body.velocity.x != 0 && body.velocity.y != 0)
        {
            body.velocity.x *= 0.70710678118654752440084436210485f;
            body.velocity.y *= 0.70710678118654752440084436210485f;
        }
    }
}
