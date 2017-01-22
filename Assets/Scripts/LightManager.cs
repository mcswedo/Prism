using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public GameObject leftLight, rightLight, centerLight, aboveLight, belowLight = null;
    public enum Sides {None,Left, Right, Above, Below };
    public Sides sourceSide;
    public enum BlockType { T, L, Line, Cross };
    public BlockType Block;
    public bool isComingFromSource = false;
    public bool isSource = false;
    public enum SourceColor { red, blue, green };
    public SourceColor sColor;
    public Color colorSource;
    public bool areLightsEnabled = false;

    void Start()
    {
        if(sColor == SourceColor.red)
        {
            GetComponent<SpriteRenderer>().color = Colors.red;
            if (isSource)
                colorSource = Colors.red;


        }
        if (sColor == SourceColor.blue)
        {
            GetComponent<SpriteRenderer>().color = Colors.blue;
            if (isSource)
                colorSource = Colors.blue;
        }
        if (sColor == SourceColor.green)
        {
            GetComponent<SpriteRenderer>().color = Colors.green;
            if (isSource)
                colorSource = Colors.green;
        }

        
    }

	// Update is called once per frame
	void Update () {
        if(areLightsEnabled)
        {
            if(leftLight != null)
            {
                leftLight.SetActive(true);
            }
            if(belowLight != null)
            {
                belowLight.SetActive(true);
            }
            if (rightLight != null)
            {
                rightLight.SetActive(true);
            }
            if (aboveLight != null)
            {
                aboveLight.SetActive(true);
            }
            if(centerLight != null)
            {
                centerLight.SetActive(true);
            }
            
        }
        else if (!areLightsEnabled)
        {
            if (leftLight != null)
            {
                leftLight.SetActive(false);
            }
            if (belowLight != null)
            {
                belowLight.SetActive(false);
            }
            if (rightLight != null)
            {
                rightLight.SetActive(false);
            }
            if (aboveLight != null)
            {
                aboveLight.SetActive(false);
            }

            if(centerLight != null)
            {
                centerLight.SetActive(false);
            }
            
        }
        
        
        switch(sourceSide)
        {
            case Sides.None:
                break;
            case Sides.Left:
                leftLight.GetComponent<Light>().color = colorSource;
                break;
            case Sides.Right:

                rightLight.GetComponent<Light>().color = colorSource;
                break;
            case Sides.Above:

                aboveLight.GetComponent<Light>().color = colorSource;
                break;
            case Sides.Below:

                belowLight.GetComponent<Light>().color = colorSource;
                break;

            default:
                break;

        }
		
	}
}
