using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    public bool tankActive;
    [Range(0f, 2f)]
    public float Speed;
   
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        MovementManager();
    }
    void MovementManager()
    {
      

        if (tankActive)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                // forward
                transform.Translate(Vector3.forward * Speed);
            }  
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "char_ethan")
        {
             tankActive = true;
        }
       
    }
}
