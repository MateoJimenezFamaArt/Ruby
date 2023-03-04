using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeedScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        RubyController controller = other.GetComponent<RubyController>();
        Debug.Log("Esta funcionando el Trigger: ");

        if (controller != null)
        {
                Destroy(gameObject);
                controller.isHigh = true;
        }



    }
}
