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

        if (game_state.tankMove == true)
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
           if (other == charActive)
           {

            if (Input.GetKeyUp("left shift"))
            {
                if (game_state.charMove)
                {
                    charActive.SetActive(false);
                    game_state.charMove = false;
                    game_state.tankMove = true;
                }
                //else if (game_state.tankMove)
                //{
                //    charActive.SetActive(true);
                //    game_state.charMove = true;
                //    game_state.tankMove = false;
                //}
            }

        }
    }



  }




