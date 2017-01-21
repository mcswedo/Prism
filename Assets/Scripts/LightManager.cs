using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public Light leftLight, rightLight, centerLight, aboveLight, belowLight = null;
    public enum Sides {None,Left, Right, Above, Below };
    public Sides sourceSide;
    public enum BlockType { T, L, Line, Cross };
    public BlockType Block;
    public bool isComingFromSource = false;
    public bool isSource = false;
    public enum SourceColor { red, blue, green };
    public SourceColor sColor;

    void Start()
    {
        if(sColor == SourceColor.red)
        {
            GetComponent<SpriteRenderer>().color = Colors.red;
        }
        if (sColor == SourceColor.blue)
        {
            GetComponent<SpriteRenderer>().color = Colors.blue;
        }
        if (sColor == SourceColor.green)
        {
            GetComponent<SpriteRenderer>().color = Colors.green;
        }
        
    }

	// Update is called once per frame
	void Update () {
		
	}
}
