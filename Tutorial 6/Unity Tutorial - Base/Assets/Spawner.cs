using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnProjectile : MonoBehaviour
{

    public GameObject Projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(Projectile, transform.position, transform.rotation);
        }
    }
}