using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
     Rigidbody2D rigidbody2d;
    bool isBullet = false;
    float bulletTimer = 1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
        isBullet = true;    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController hit = other.collider.GetComponent<EnemyController>();
            if (hit != null)
            {
                    hit.ChangeHealthE(-1);
            }

        Destroy(gameObject);
    }

    private void Update()
    {
        if (isBullet)
        {
            Debug.Log("Bullet fired");
            bulletTimer -= Time.deltaTime;

            if (bulletTimer < 0)
            {
                isBullet = false;
                Destroy(gameObject);
            }
        }

    }



    

    

}
