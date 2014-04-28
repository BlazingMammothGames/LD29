using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject player;

    public GameObject blackout = null;

    private KinematicBody body;

    public bool chasing = false;

    private bool frozen = false;
    private float unfreezeTime = 0;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        body = GetComponent<KinematicBody>();
        player.GetComponent<TaskList>().aliensRemaining++;
    }

    public void TemporarilyDisableMotion(float time)
    {
        unfreezeTime = Time.time + time;
        frozen = true;
    }

    void Update()
    {
        // if there's a blackout, don't move
        if (blackout != null && blackout.renderer.enabled == false)
            return;

        if (frozen)
        {
            if (Time.time >= unfreezeTime)
                frozen = false;
            else
                return;
        }
        else
        {
            body.velocity = Vector2.zero;
        }

        if (chasing)
        {
            Vector2 delta = player.transform.position - transform.position;
            body.velocity = Vector2.zero;

            if (delta.y < 0)
            {
                body.facingDirection = KinematicBody.FacingDirection.DOWN;
                body.velocity.y = -moveSpeed;
            }
            else if (delta.y > 0)
            {
                body.facingDirection = KinematicBody.FacingDirection.UP;
                body.velocity.y = moveSpeed;
            }
            if (delta.x < 0)
            {
                body.facingDirection = KinematicBody.FacingDirection.LEFT;
                body.velocity.x = -moveSpeed;
            }
            else if (delta.x > 0)
            {
                body.facingDirection = KinematicBody.FacingDirection.RIGHT;
                body.velocity.x = moveSpeed;
            }

            // limit the speed diagonally
            if (body.velocity.x != 0 && body.velocity.y != 0)
            {
                body.velocity.x *= 0.70710678118654752440084436210485f;
                body.velocity.y *= 0.70710678118654752440084436210485f;
            }
        }
    }
}
