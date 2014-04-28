using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public Vector2 velocity = Vector2.zero;
    public Vector2 truePosition = Vector2.zero;
    public float lifeTime = 1f;
    private float endTime = 0;

    void Start()
    {
        truePosition = transform.position;
        endTime = Time.time + lifeTime;
    }

    void Update()
    {
        if (Time.time >= endTime)
        {
            DestroyObject(this.gameObject);
            return;
        }

        truePosition += velocity * Time.deltaTime;
        transform.position = new Vector3(Mathf.Round(truePosition.x * 8) / 8f, Mathf.Round(truePosition.y * 8) / 8, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == (1 << LayerMask.NameToLayer("Walls")))
        {
            DestroyObject(this.gameObject);
        }

        if (!(other.transform.parent != null && other.transform.parent.CompareTag("Player")) && !other.transform.CompareTag("Player") && other.GetComponent<TakeDamage>() != null)
        {
            other.GetComponent<TakeDamage>().Damage();
            DestroyObject(this.gameObject);
        }
    }
}
