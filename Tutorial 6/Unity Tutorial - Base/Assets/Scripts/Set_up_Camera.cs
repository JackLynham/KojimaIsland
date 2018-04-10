using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_up_Camera : MonoBehaviour
{
    public Camera FollowCam;
    public Camera StaticCam;
    public Camera PiPiCam;
    public Camera TankCam;
	// Use this for initialization

	void Start ()
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        FollowCam.enabled = true;
        StaticCam.enabled = false;
        PiPiCam.enabled = false;

        PlayerCharacter.GetComponent<AudioListener>().enabled = true;
        StaticCam.GetComponent<AudioListener>().enabled = false;

        GameObject TankChracter = GameObject.FindGameObjectWithTag("Tank");
        TankCam.enabled = false;
	}

    void Update()
    {
        if(Input.GetKeyUp ("p"))
        {
            PiPiCam.enabled = !PiPiCam.enabled;
        }

        if (Input.GetKeyUp("left shift"))
        {
            FollowCam.enabled = !FollowCam.enabled;
            TankCam.enabled = !TankCam.enabled;
            
        }

    }	
}
