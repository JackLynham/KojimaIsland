using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowdoor : MonoBehaviour
{
    private Rigidbody hitme;
    public float force = 30.0f;
    public float tourqueforce = 30.0f;
    public Vector3 forceDirection = new Vector3(0f, -1f, 0f);
	// Use this for initialization
	void Start ()
    {
        hitme = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown ()
    {
        hitme.AddForce(forceDirection * force, ForceMode.Force);

        hitme.AddTorque(this.transform.right * tourqueforce);
    }
}
