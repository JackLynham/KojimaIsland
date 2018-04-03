using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_up_Camera : MonoBehaviour
{
    public Camera FollowCam;
    public Camera StaticCam;
    public Camera PiPiCam;
	// Use this for initialization

	void Start ()
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        FollowCam.enabled = true;
        StaticCam.enabled = false;
        PiPiCam.enabled = false;

        PlayerCharacter.GetComponent<AudioListener>().enabled = true;
        StaticCam.GetComponent<AudioListener>().enabled = false;
	}

    void Update()
    {
        if(Input.GetKeyUp ("p"))
        {
            PiPiCam.enabled = !PiPiCam.enabled;
        }
    }	
}
