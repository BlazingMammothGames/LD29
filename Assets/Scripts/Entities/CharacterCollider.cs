using UnityEngine;
using System.Collections;

public class CharacterCollider : MonoBehaviour {
    private BoxCollider2D boxCollider;
    private KinematicBody body;

    public LayerMask collisionLayers;

    void Awake()
    {
        boxCollider = (BoxCollider2D)transform.collider2D;
        body = GetComponent<KinematicBody>();
    }

    public void AdjustVelocity(float dt)
    {
        if (body.velocity.x > 0)
        {
            // cast to the right
            if (Physics2D.Raycast((Vector2)transform.position + boxCollider.center + (Vector2.right * boxCollider.size.x / 2) + (Vector2.up * boxCollider.size.y / 2), Vector2.right, body.velocity.x * dt, collisionLayers.value) || Physics2D.Raycast((Vector2)transform.position + boxCollider.center + (Vector2.right * boxCollider.size.x / 2) - (Vector2.up * boxCollider.size.y / 2), Vector2.right, body.velocity.x * dt, collisionLayers.value))
            {
                body.velocity.x = 0;
            }
        }
        else if (body.velocity.x < 0)
        {
            // cast to the left
            if (Physics2D.Raycast((Vector2)transform.position + boxCollider.center - (Vector2.right * boxCollider.size.x / 2) + (Vector2.up * boxCollider.size.y / 2), -Vector2.right, Mathf.Abs(body.velocity.x) * dt, collisionLayers.value) || Physics2D.Raycast((Vector2)transform.position + boxCollider.center - (Vector2.right * boxCollider.size.x / 2) - (Vector2.up * boxCollider.size.y / 2), -Vector2.right, Mathf.Abs(body.velocity.x) * dt, collisionLayers.value))
            {
                body.velocity.x = 0;
            }
        }
        if (body.velocity.y > 0)
        {
            // cast up
            if (Physics2D.Raycast((Vector2)transform.position + boxCollider.center + (Vector2.up * boxCollider.size.y / 2) + (Vector2.right * boxCollider.size.x / 2), Vector2.up, body.velocity.y * dt, collisionLayers.value) || Physics2D.Raycast((Vector2)transform.position + boxCollider.center + (Vector2.up * boxCollider.size.y / 2) - (Vector2.right * boxCollider.size.x / 2), Vector2.up, body.velocity.y * dt, collisionLayers.value))
            {
                body.velocity.y = 0;
            }
        }
        else if (body.velocity.y < 0)
        {
            // cast down
            if (Physics2D.Raycast((Vector2)transform.position + boxCollider.center - (Vector2.up * boxCollider.size.x / 2) + (Vector2.right * boxCollider.size.x / 2), -Vector2.up, Mathf.Abs(body.velocity.y) * dt, collisionLayers.value) || Physics2D.Raycast((Vector2)transform.position + boxCollider.center - (Vector2.up * boxCollider.size.x / 2) - (Vector2.right * boxCollider.size.x / 2), -Vector2.up, Mathf.Abs(body.velocity.y) * dt, collisionLayers.value))
            {
                body.velocity.y = 0;
            }
        }
    }
}
