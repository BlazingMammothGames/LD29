using UnityEngine;
using System.Collections;

public class ProjectileThrower : MonoBehaviour {
    public Projectile projectilePrefab;
    private KinematicBody body;

    public float throwVelocity = 16f;

    void Awake()
    {
        body = transform.parent.GetComponent<KinematicBody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Projectile p = (Projectile)Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            switch (body.facingDirection)
            {
                case KinematicBody.FacingDirection.RIGHT:
                    p.velocity.x = throwVelocity;
                    break;

                case KinematicBody.FacingDirection.DOWN:
                    p.velocity.y = -throwVelocity;
                    break;

                case KinematicBody.FacingDirection.LEFT:
                    p.velocity.x = -throwVelocity;
                    break;

                case KinematicBody.FacingDirection.UP:
                    p.velocity.y = throwVelocity;
                    break;
            }
        }
    }
}
