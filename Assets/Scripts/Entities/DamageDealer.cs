using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour {
    public float freezeTime = 0.5f;
    public float bounceVelocity = 8f;

    void Start()
    {
        if (transform.parent.GetComponent<ChasePlayer>() != null)
            transform.parent.GetComponent<ChasePlayer>().chasing = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<TakeDamage>() != null)
        {
            other.GetComponent<TakeDamage>().Damage();

            // bump us away
            Vector2 delta = other.transform.parent.position - transform.parent.position;
            //transform.parent.GetComponent<KinematicBody>().truePosition -= 0.5f * (Vector3)delta.normalized;
            transform.parent.GetComponent<KinematicBody>().velocity -= 2f * (Vector3)delta.normalized;

            transform.parent.GetComponent<ChasePlayer>().TemporarilyDisableMotion(freezeTime);

            //transform.parent.position -= (Vector3)delta.normalized;
        }
    }
}
