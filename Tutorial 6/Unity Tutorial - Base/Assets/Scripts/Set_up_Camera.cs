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

        if(game_state.charMove == true)
        {
            FollowCam.enabled = true;
        }
        else if(!game_state.charMove)
        {
            FollowCam.enabled = false;
        }

        if(game_state.inTank == true)
        {
            TankCam.enabled = true;
            FollowCam.enabled = false;
        }
        else if(!game_state.inTank)
        {
            TankCam.enabled = false;
        }
        
        //if (Input.GetKeyUp("left shift"))
        //{


        //FollowCam.enabled = !FollowCam.enabled;
        //TankCam.enabled = !TankCam.enabled;
        //StaticCam.enabled = false;
        //MinimapCam.enabled = false;
        //firstTrackCam.enabled = false;
        //SecondTrackCam.enabled = false;
        //GunCam.enabled = false;
        //TunnelCam.enabled = false;
        //SmallTunnelCam.enabled = false;

        //}


        if (Input.GetKeyUp("t"))
        {
            TankCam.enabled = !TankCam.enabled;
            firstTrackCam.enabled = !firstTrackCam.enabled;

        }

        if (Input.GetKeyUp("y"))
        {
            FollowCam.enabled = !FollowCam.enabled;
            SecondTrackCam.enabled = !SecondTrackCam.enabled;
        }

        if (Input.GetKeyUp("g"))
        {
            FollowCam.enabled = !FollowCam.enabled;
            GunCam.enabled = !GunCam.enabled;
        }



    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Tank" && (Input.GetKeyUp("left shift")))
    //    {
    //        game_state.charMove = false;
    //       // outTank = true;

    //    }

    //    if (!game_state.charMove && outTank == true && (Input.GetKeyDown("left shift")))
    //    {
    //        game_state.charMove = true;
    //    }
    //}

}
