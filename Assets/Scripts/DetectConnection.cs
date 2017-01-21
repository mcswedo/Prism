using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectConnection : MonoBehaviour {

    public GameObject testObject;
    bool connected = false;
    public Color sourceColor;
    public Light someLight;
    public enum Sides { Left, Right, Above, Below };
    public Sides side;
    bool isLit = false;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(connected)
        {
            testObject.transform.Rotate(new Vector3(0, 0, 5));
        }
        else
        {
           
        }
	}

    //Checks to see if is touching another connector.
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Connector")
        {
            //if so, take the color of the other connecter if it's lit. 
            connected = true;
            if(collider.gameObject.GetComponent<LightManager>().isComingFromSource)
            {
                gameObject.GetComponent<LightManager>().isComingFromSource = true;
            }

        }
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Connector")
        {
            connected = false;

        }
    }
}
