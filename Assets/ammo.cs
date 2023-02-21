using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController controller = collision.GetComponent<RubyController>();
        //Debug.Log ("Trigger funciona" + collison)

        if (controller != null)
        {
            if (controller.Ammo < controller.maxAmmo)
            {
                controller.ChangeAmmo(5);
                Destroy(gameObject);
            }
        }

    }


}
