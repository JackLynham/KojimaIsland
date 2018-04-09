using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    [Range(0f, 2f)]
    public float Speed;
    [Range(0f, 2f)]
    public float rotateSpeed;

    public Game_States game_state;

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

        if (game_state.charMove == true)
        {
            game_state.tankMove = false;
        }
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
                    transform.Rotate(Vector3.down * rotateSpeed);

                }

                //Turning Right
                if (Input.GetAxis("Horizontal") > 0)
                {
                    transform.Rotate(Vector3.up * rotateSpeed);
                }
            }

        
    }

    void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name == "char_ethan")
            {
            game_state.charMove = false;
            game_state.tankMove = true;
            }
        }



  }




