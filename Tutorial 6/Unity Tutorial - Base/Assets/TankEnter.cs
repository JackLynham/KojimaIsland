using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnter : MonoBehaviour
{
    public Transform playerPos;
    public Transform playerExit;

    private GameObject player;

    public bool is_ethan;

	void Update ()
    {
		
	}

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.name == "tank" && Input.GetKeyUp("left shift"))
        {
            transform.SetPositionAndRotation(playerPos.position, playerPos.rotation);
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().enabled = false;

            is_ethan = true;
        }

        if (col.gameObject.name == "tank" && Input.GetKeyUp("left shift" ) && is_ethan == true)
        {
            transform.SetPositionAndRotation(playerExit.position, playerExit.rotation);
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().enabled = true;

            is_ethan = false;
        }
    }
}
