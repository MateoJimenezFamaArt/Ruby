using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;



public class RubyController : MonoBehaviour
{

  [SerializeField] private float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //Debug.log ("horizontal " + horizontal);
        //Debug.log ("vertical " + vertical);
        float vertical = Input.GetAxis("Vertical");
       


        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal*Time.deltaTime;
        position.y = position.y + speed * vertical*Time.deltaTime;
        transform.position = position;
    }
}
