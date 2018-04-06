using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    public bool TankActive;
    [Range(0f, 2f)]
    public float Speed;
   
    // Update is called once per frame
    void Update()
    {

    }
    void MovementManager()
    {
        
        if (TankActive)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                // forward
                transform.Translate(Vector3.forward * Speed);
            }
        }
    }

    void OnCollisionEnter(Collision Player)
    {
        Player.gameObject.CompareTag("Tank");
        TankActive = true;
    }
}
