using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTunnelScript : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;

    void OnTriggerEnter(Collider col)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Tank");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();

        if (col.tag == "Tank")
        {
            triggeredCam.enabled = true;
            liveCam.enabled = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        triggeredCam.enabled = false;
        liveCam.enabled = true;
    }

    void OnTriggerStay(Collider col)
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}