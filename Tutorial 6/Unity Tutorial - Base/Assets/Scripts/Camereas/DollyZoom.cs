using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyZoom : MonoBehaviour
{
    public Transform target;
    public Camera zoomCamerea;

    private float initheightatdistance;
    private bool dollyzoomEnabled;
	// Use this for initialization
	void Start ()
    {
		  StartdollyZoomEffect ();
	}
	
	// Update is called once per frame
	void Update ()
    {
      if (dollyzoomEnabled)
        {
            var currdistance = Vector3.Distance(transform.position, target.position);
            zoomCamerea.fieldOfView = FOVforHeightandDistance(initheightatdistance, currdistance);
        }
        transform.Translate(Input.GetAxis("AltVertical") * Vector3.forward * Time.deltaTime * 5f);
	}
    float FrustrumheightatDistance(float distance)
    {
        return 2.0f * distance * Mathf.Tan(zoomCamerea.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }

    float FOVforHeightandDistance(float height, float distance)
    {
        return 2.0f * Mathf.Atan(initheightatdistance * 0.5f/distance)* Mathf.Rad2Deg;
    }

    void StartdollyZoomEffect()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        initheightatdistance = FrustrumheightatDistance(distance);
        dollyzoomEnabled = true;
    }

    void Stopdollyzoom()
    {
        dollyzoomEnabled = false;
    }
}
