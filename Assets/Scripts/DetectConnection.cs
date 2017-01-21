using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectConnection : MonoBehaviour {

    public GameObject testObject;
    bool connected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(connected)
        {
            testObject.transform.Rotate(new Vector3(0, 0, 5));
        }
		
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Connector")
        {
            connected = true;
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
