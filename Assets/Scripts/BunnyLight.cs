using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyLight : MonoBehaviour {

    public GameObject endNode;
    int intensity = 1;
    bool redApplied = false;
    bool blueApplied = false;
    bool greenApplied = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponentInChildren<Light>().color = endNode.GetComponentInChildren<Light>().color;
        if(endNode.GetComponent<LightActivator>().redActive && !redApplied)
        {
            intensity++;
            redApplied = true;
        }
        if (endNode.GetComponent<LightActivator>().greenActive && !greenApplied)
        {
            intensity++;
            greenApplied = true;
        }
        if (endNode.GetComponent<LightActivator>().blueActive && !blueApplied)
        {
            intensity++;
            blueApplied = true;
        }

        gameObject.GetComponentInChildren<Light>().range *= intensity;
        if (gameObject.GetComponentInChildren<Light>().range > 100) { gameObject.GetComponentInChildren<Light>().range = 100; }
		
	}
}
