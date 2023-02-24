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
    bool broken = true;
    Animator animator;

    public int maxHealthE = 2;
    public int currentHealthE;

    Rigidbody2D rigidbody2D;

    public ParticleSystem smokeEffect;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        currentHealthE = 2;
    }

    private void Update()
    {
        if (!broken)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer <0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Fix();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }

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

    public void Fix()
    {
        if (currentHealthE == 0)
        {
            broken = false;
            smokeEffect.Stop();
            rigidbody2D.simulated = false;
            animator.SetTrigger("Fixed");
        }

    }

    public void ChangeHealthE(int amount)
    {
        currentHealthE = Mathf.Clamp(currentHealthE + amount, 0, maxHealthE);

    }


    public void Kill()
    {
        broken = false;
        rigidbody2D.simulated = false;
        smokeEffect.Stop();
        animator.SetTrigger("Killed");

        Destroy(gameObject);
    }
}
