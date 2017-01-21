using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectConnection : MonoBehaviour {

    public GameObject testObject;
    bool connected = false;
    public Color sourceColor;
    public enum Sides {None,Left, Right, Above, Below };

    public Sides side;
    bool isLit = false;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(connected)
        {
            
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
            if(collider.gameObject.GetComponent<LightManager>().isComingFromSource && !gameObject.GetComponent<LightManager>().isSource)
            {
                gameObject.GetComponent<LightManager>().isComingFromSource = true;
                gameObject.GetComponentInParent<LightManager>().sourceSide = (LightManager.Sides)side;
                sourceColor = collider.GetComponent<DetectConnection>().sourceColor;
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
