using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera triggerdcam;
    public Camera livecam;
	// Use this for initialization

    void OnTriggerEnter(Collider col)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();

        if(col == PlayerCollider)
        {
            livecam = Camera.allCameras[0];

            triggerdcam.enabled = true;
            livecam.enabled = false;

            triggerdcam.GetComponent<AudioListener>().enabled = true;
            PlayerCharacter.GetComponent<AudioListener>().enabled = false;
        }
    }

    void OnTriggerExit(Collider col)
    {

    }

    void OnTriggerStay(Collider col)
    {

    }
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
