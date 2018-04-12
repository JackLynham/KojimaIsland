using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnterScript : MonoBehaviour
{

    public GameObject Tank;
    public GameObject Player;
    public GameObject PlayerBackup;
    private bool inVehicle = false;
    public Tank_Movement TankScript;
    public Game_States Gamestate;
    private float elapsedTime;
    public bool test;
    void Start()
    {
     //Gamestate

        //PlayerBackup.SetActive(false);

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Gamestate.inTank == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
           // Player.SetActive(true);
            Player.transform.parent = null;
           // PlayerBackup.SetActive(false);
           // TankScript.enabled = false;
            Gamestate.inTank = false;
            Gamestate.charMove = true;
          
        }

        else if (other.gameObject.tag == "Player" && Gamestate.inTank == false && Input.GetKeyUp(KeyCode.E))
        {

            //PlayerBackup.SetActive(true);
            //Player.SetActive(false);
            Player.transform.parent = Tank.transform;
            //TankScript.enabled = true;
            //inVehicle = true;
            Gamestate.inTank = true;
            Gamestate.charMove = false;
            



        }

    }


    void Update()
    {
        
    }
}
