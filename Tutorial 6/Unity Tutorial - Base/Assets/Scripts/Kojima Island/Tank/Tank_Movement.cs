using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{
    [Range(0f, 2f)]
    public float Speed;
    [Range(0f, 2f)]
    public float rotateSpeed;

    public bool outTank;
    public Game_States game_state;
    GameObject charActive;
    public float sensitivityX = 1.0f;


    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        charActive = GameObject.FindGameObjectWithTag("Player");
        MovementManager();
        SetParent(player);
        DetachFromParent();
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


    void Rotating(float mouseXInput)
    {
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        Quaternion deltaRotation = Quaternion.Euler(0f, (Input.GetAxis("Mouse X") * sensitivityX), 0f);

        ourBody.MoveRotation(ourBody.rotation * deltaRotation);
    }

        void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && outTank == false && (Input.GetKeyUp("left shift" )))
        {
            game_state.charMove = false;

            outTank = true;

            
        }

        if (!game_state.charMove && outTank == true && (Input.GetKeyDown("left shift")))
        {
            game_state.charMove = true;
        }
    }


    public void SetParent(GameObject Newer)
    {
         player.transform.parent = Newer.transform;
    }

    public void DetachFromParent()
    {
        if (!game_state.charMove && (Input.GetKeyDown("left shift")))
        {
            transform.parent = null;
        }

    }
}




