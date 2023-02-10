using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool vertical;
    public float speed;
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;

    Animator animator;

    Rigidbody2D rigidbody2D;
   


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move_X", 0);
            animator.SetFloat("Move_Y", direction);
        }
        else
        {
        position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move_X", direction);
            animator.SetFloat("Move_Y", 0);
        }


        rigidbody2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player!= null)
        {
            player.ChangeHealth(-1);
        }
    }
}