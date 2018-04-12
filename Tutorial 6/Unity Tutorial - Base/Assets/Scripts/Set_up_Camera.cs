using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_up_Camera : MonoBehaviour
{
    public Game_States game_state;
    public Camera FollowCam;
    public Camera StaticCam;
    public Camera MinimapCam;
    public Camera TankCam;
    public Camera firstTrackCam;
    public Camera SecondTrackCam;
    public Camera GunCam;
    public Camera TunnelCam;
    public Camera SmallTunnelCam;
    // Use this for initialization

    void Start()
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        FollowCam.enabled = true;
        StaticCam.enabled = false;
        MinimapCam.enabled = false;
        TunnelCam.enabled = false;
        SmallTunnelCam.enabled = false;


        PlayerCharacter.GetComponent<AudioListener>().enabled = true;
        StaticCam.GetComponent<AudioListener>().enabled = false;

        GameObject TankChracter = GameObject.FindGameObjectWithTag("Tank");
        TankCam.enabled = false;
        firstTrackCam.enabled = false;
        SecondTrackCam.enabled = false;
        GunCam.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyUp("m"))
        {
            MinimapCam.enabled = !MinimapCam.enabled;
            FollowCam.enabled = !FollowCam.enabled;
        }

        if (Input.GetKeyUp("e"))
        {
            FollowCam.enabled = !FollowCam.enabled;
            TankCam.enabled = !TankCam.enabled;
        }


        if (Input.GetKeyUp("t"))
        { 
            firstTrackCam.enabled = !firstTrackCam.enabled;
            FollowCam.enabled = !FollowCam.enabled;
        }

        if (Input.GetKeyUp("y"))
        {
            SecondTrackCam.enabled = !SecondTrackCam.enabled;
            FollowCam.enabled = !FollowCam.enabled;
        }

        if (Input.GetKeyUp("g"))
        {
            FollowCam.enabled = !FollowCam.enabled;
            GunCam.enabled = !GunCam.enabled;
            
        }


    }

    

}
