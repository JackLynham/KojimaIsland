using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    private float mouseX;
    private float MouseY;
    private float MouseZ;

    public float RotationSpeed = 4;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        mouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        MouseZ = Input.GetAxis("Mouse ScrollWheel");

        Movement(mouseX, MouseY, MouseZ);
    
    }

    void Movement(float mouseX, float MouseY, float MouseZ)
    {
        if(Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.up * RotationSpeed);
        }

        if(Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.down * RotationSpeed);
        }
        if (MouseZ > 0)
        {
            transform.Rotate(Vector3.left * RotationSpeed);

        }
        if (MouseZ < 0)
        {
            transform.Rotate(Vector3.right * RotationSpeed);

        }


    }
}
