﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTrigger : MonoBehaviour
{
    public float hoverEnergy = 20.0f;
	
    void OnTriggerStay(Collider other)
    {
        Rigidbody holder = other.GetComponent<Rigidbody>();
        holder.AddForce(Vector3.up * hoverEnergy, ForceMode.Acceleration);

        Vector3 turn = new Vector3(0.3f, 0.3f, 0.3f);
        holder.AddRelativeTorque(turn);
    }
}
