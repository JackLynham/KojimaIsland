using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnter : MonoBehaviour
{
    public Transform playerPos;
    public Transform playerExit;

    private GameObject player;
    private GameObject tank;
    public Game_States game_state;
    public bool is_ethan;

    void Update ()
    {
		
	}

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.name == "Tank" && Input.GetKeyUp("left shift")&&is_ethan == false)
        {
         
            transform.SetPositionAndRotation(playerPos.position, playerPos.rotation);
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().enabled = false;

            tank = GameObject.FindGameObjectWithTag("Tank");
            tank.GetComponent<Tank_Movement>().enabled = true;
            is_ethan = true;
        }

        if (Input.GetKeyDown("left shift") && is_ethan == true)
        {
           // game_state.charMove = true;
            transform.SetPositionAndRotation(playerExit.position, playerExit.rotation);
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().enabled = true;

            tank = GameObject.FindGameObjectWithTag("Tank");
            //tank.GetComponent<Tank_Movement>().enabled = false;

            is_ethan = false;   
        }
    }
}
