using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectConnection : MonoBehaviour {

    public GameObject testObject;
    bool connected = false;
    public Color sourceColor;
    public enum Sides {None,Left, Right, Above, Below };

    public Sides side;
    //bool isLit = false;
    

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
            if(collider.gameObject.GetComponentInParent<LightManager>().isComingFromSource && !gameObject.GetComponentInParent<LightManager>().isSource)
            {
                gameObject.GetComponentInParent<LightManager>().isComingFromSource = true;
                gameObject.GetComponentInParent<LightManager>().areLightsEnabled = true;
                gameObject.GetComponentInParent<LightManager>().sourceSide = (LightManager.Sides)side;
                sourceColor = collider.GetComponent<DetectConnection>().sourceColor;
                gameObject.GetComponentInParent<LightManager>().colorSource = sourceColor;
            }
            if(collider.gameObject.GetComponentInParent<LightManager>().isSource)
            {
                gameObject.GetComponentInParent<LightManager>().isComingFromSource = true;
                gameObject.GetComponentInParent<LightManager>().areLightsEnabled = true;
                gameObject.GetComponentInParent<LightManager>().sourceSide = (LightManager.Sides)side;
                sourceColor = collider.GetComponentInParent<LightManager>().colorSource;
                gameObject.GetComponentInParent<LightManager>().colorSource = sourceColor;
            }

        }
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Connector")
        {
            connected = false;
            
                gameObject.GetComponentInParent<LightManager>().areLightsEnabled = false;
                gameObject.GetComponentInParent<LightManager>().isComingFromSource = false;
            
            
        }
    }
}
