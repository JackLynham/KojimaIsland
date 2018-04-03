using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravityon : MonoBehaviour
{
    private Rigidbody thisRigid;
	// Use this for initialization
	void Start ()
    {
        thisRigid = this.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyUp ("g"))
        {
            thisRigid.useGravity = true;
        }
	}
}
