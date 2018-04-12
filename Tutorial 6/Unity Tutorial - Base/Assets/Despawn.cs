using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn: MonoBehaviour
{

    public float despawnAfterTime = 5.0f;
    float timer = 0.0f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > despawnAfterTime)
        {
            Destroy(gameObject);
        }
    }
}
