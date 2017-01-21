using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public Light leftLight, rightLight, centerLight, aboveLight, belowLight = null;
    public enum Sides { Left, Right, Above, Below };
    public Sides sourceSide;
    public bool isComingFromSource = false;

	// Update is called once per frame
	void Update () {
		
	}
}
