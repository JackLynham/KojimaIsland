using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhosTheDaddy : MonoBehaviour
{
    private GameObject player;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = this.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
