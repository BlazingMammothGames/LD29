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
        else if (Input.GetKey(KeyCode.LeftArrow))
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
    }
}
