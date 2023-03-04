using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRecovery : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        //Debug.Log("Esta funcionando el Trigger: " + collision);
        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(controller.maxHealth);
                Destroy(gameObject);
            }

        }
    }


}
