using System.Collections;
using System.Collections.Generic; 
using UnityEngine;



public class RubyController : MonoBehaviour
{
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public float timeInvincible = 2.0f;
    bool isInvinicble;
    public float invincibleTimer;
    
    public float speed;
    public int maxHealth = 5;
     int currentHealth;

    public int health
    {
        get { return currentHealth; }
    }

    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;


    //Start is called before the first frame update
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    //Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
       // Debug.Log("horizontal: " + horizontal);
        vertical = Input.GetAxis("Vertical");
        //Debug.Log("vertical: " + vertical);

        Vector2 move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x,0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if (isInvinicble)
        {
            invincibleTimer -= Time.deltaTime;

            if(invincibleTimer < 0)
            {
                isInvinicble = false;
            }
        }

    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2D.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {

            animator.SetTrigger("Hit");

            if (isInvinicble)
            {
                return;
            }

            isInvinicble = true;
            invincibleTimer = timeInvincible;
 
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
