using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereaScript : MonoBehaviour
{
    public GameObject target;
    void Awake ()
    {
        this.transform.RotateAround(target.transform.position, Vector3.up, 90f);
    }
}
