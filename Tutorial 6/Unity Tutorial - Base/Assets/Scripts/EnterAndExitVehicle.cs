using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnterAndExitVehicle : MonoBehaviour
{

	public GameObject Tank;
	public GameObject Player;
	public GameObject PlayerBackup;
	private bool inVehicle = false;
	Tank_Movement TankScript;
	GameObject Camera;

	void Start()
	{
		TankScript = GetComponent<Tank_Movement>();
		TankScript.enabled = false;
		PlayerBackup.SetActive (false);

	}

	void OnTriggerStay(Collider other)
	{


		if (other.gameObject.tag == "Player" && inVehicle == false && Input.GetKey (KeyCode.E)) 
		{
			
			PlayerBackup.SetActive (true);
			Player.SetActive (false);
			Player.transform.parent = Tank.transform;
			TankScript.enabled = true;
			inVehicle = true;
		}
	}


	void Update()
	{
		if (inVehicle == true && Input.GetKey(KeyCode.F))
		{
			Player.SetActive (true);
			Player.transform.parent = null;
			PlayerBackup.SetActive (false);
			TankScript.enabled = false;
			inVehicle = false;
		}
	}
}
