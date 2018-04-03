using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureinPicture : MonoBehaviour
{
    public enum hAllignment{left,center,right};
    public enum vAllignment { top, middle, bottom };

    public hAllignment horalign = hAllignment.left;
    public vAllignment vertalign = vAllignment.top;

    public enum unitsIn { pixels,screen_percentage};

    public unitsIn unit = unitsIn.pixels;

    public int width = 50;
    public int height = 50;
    public int xoffset = 0;
    public int yoffset;

    public bool update = true;
    private int hsize, vsize, hloc, vloc;

    // Use this for initialization
    void Start ()
    {
        AdjustCamerea ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(update)
        {
            AdjustCamerea();
        }
	}

    void AdjustCamerea()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        float swPercent = sw * 0.01f;
        float shPercent = sh * 0.01f;
        float xOffPercent = xoffset * swPercent;
        float YOffPercent = yoffset * shPercent;
        int xOff;
        int YOff;

        if (unit == unitsIn.screen_percentage)
        {
            hsize = width * (int)swPercent;
            vsize = height * (int)shPercent;
            xOff = (int)xOffPercent;
            YOff = (int)YOffPercent;
        }
        else
        {
            hsize = width;
            vsize = height;
            xOff = xoffset;
            YOff = yoffset;
        }
        switch (horalign)
        {
            case hAllignment.left:
                hloc = xOff;
                break;

            case hAllignment.right:

                int justifiedright = (sw - hsize);
                hloc = (justifiedright - xOff);
                break;

            case hAllignment.center:

                float justifiedcenter = (sw * 0.5f) - (hsize* 0.5f);
                hloc = (int) (justifiedcenter - xOff);
                break;
        }

        switch(vertalign)
        {

            case vAllignment.top:
                int justifiedtop = sh - vsize;
                vloc = (justifiedtop - YOff);
                break;

            case vAllignment.bottom:
                vloc = YOff;
                break;

            case vAllignment.middle:

                float justifiedmiddle = (sw * 0.5f) - (vsize * 0.5f);
                vloc = (int)(justifiedmiddle - YOff);
                break;
        }
        GetComponent<Camera>().pixelRect = new Rect(hloc, vloc, hsize, vsize);
    }
}
