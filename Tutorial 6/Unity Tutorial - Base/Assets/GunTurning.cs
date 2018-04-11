using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurning : MonoBehaviour
{
    [Range(0f, 1f)]
    public float rotateSpeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementManager();
    }

    void MovementManager()
    {
        if(Input.GetKeyUp("g"))
        {
            if (Input.GetKeyUp("left"))
            {
                transform.Rotate(Vector3.up * rotateSpeed);

            }
            //Turning Right
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Rotate(Vector3.down * rotateSpeed);
            }
        }
    }
}
