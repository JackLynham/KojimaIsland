using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    [Range(0f, 2f)]
    public float Speed;
    [Range(0f, 2f)]
    public float rotateSpeed;

    public bool test;
    public Game_States game_state;
    GameObject charActive;

    // Update is called once per frame
    void Update()
    {
        charActive = GameObject.FindGameObjectWithTag("Player");
        MovementManager();
    }

    void FixedUpdate()
    {

    }

    void MovementManager()
    {

        if (!game_state. charMove)
        {
          
                // forward
                if (Input.GetAxis("Vertical") > 0)
                {
                    transform.Translate(Vector3.forward * Speed);

                }
                //Backwards
                if (Input.GetAxis("Vertical") < 0)
                {
                    transform.Translate(Vector3.back * Speed);
                }

                //Turning Left 
                if (Input.GetAxis("Horizontal") < 0)
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

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && (Input.GetKeyUp("left shift")))
        {
            game_state.charMove = false;
        }
   
    }



}




