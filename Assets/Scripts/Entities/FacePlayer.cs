using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {
    public Transform player;

    public float angle = 0;
    private KinematicBody body;

    void Awake()
    {
        body = GetComponent<KinematicBody>();
    }

    void Update()
    {
        angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        if (angle >= 45 && angle < 135)
        {
            body.facingDirection = KinematicBody.FacingDirection.UP;
        }
        else if (angle < 45 && angle >= -45)
        {
            body.facingDirection = KinematicBody.FacingDirection.RIGHT;
        }
        else if (angle < -45 && angle >= -135)
        {
            body.facingDirection = KinematicBody.FacingDirection.DOWN;
        }
        else
        {
            body.facingDirection = KinematicBody.FacingDirection.LEFT;
        }
    }
}
