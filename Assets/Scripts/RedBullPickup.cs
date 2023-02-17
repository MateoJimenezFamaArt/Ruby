using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        //Debug.Log("Esta funcionando el Trigger: " + collision);
        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(2);
                controller.speed = 6;
                Destroy(gameObject);
            }

        }
    }
}
