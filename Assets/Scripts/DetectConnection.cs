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
        while(connected)
        {
            testObject.transform.Rotate(new Vector3(0, 0, 45));
        }
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Boop");
        connected = true;
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        connected = false;
    }
}
