using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void LaunchDeadlyBullet(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Kill();
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
}
