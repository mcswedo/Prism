﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActivator : MonoBehaviour {

    public bool activate = false;
    public bool redActive = false;
    public bool greenActive = false;
    public bool blueActive = false;
    Color activeColor;

    public GameObject[] lights = new GameObject[5];
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (redActive && blueActive && greenActive)
        {
            activeColor =Colors.white;
        }
        else if (redActive && blueActive)
        {
            activeColor = Colors.magenta;
        }
        else if (redActive && greenActive)
        {
            activeColor = Colors.yellow;
        }
        else if (greenActive && blueActive)
        {
            activeColor = Colors.cyan;
        }
        else if (greenActive)
        {
            activeColor = Colors.green;
        }
        else if (blueActive)
        {
            activeColor = Colors.blue;
        }
        else if (redActive)
        {
           activeColor = Colors.red;
        }


        for(int i = 0; i < lights.Length; i++)
        {
            if (lights[i] != null)
            {
                lights[i].SetActive(activate);
                lights[i].GetComponent<Light>().color = activeColor;
                
            }
        }
        activate = false;
        
	}
}
