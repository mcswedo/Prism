using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.AnimatedLineRenderer
{
    public class CreateLight : MonoBehaviour {

        public AnimatedLineRenderer AnimatedLine;
        public GameObject wayPoint1;
        public GameObject wayPoint2;
        public GameObject wayPoint3;
        float timer = 0;

	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
            timer += Time.deltaTime;

            if(AnimatedLine == null)
            {
                return;
            }
            else if (timer > 3)
            {
                
                AnimatedLine.Enqueue(wayPoint1.transform.position);
                
            }
            else if(timer > 8)
            {
                Vector3 pos = wayPoint2.transform.position;
                pos = Camera.main.ScreenToViewportPoint(new Vector3(pos.x, pos.y, AnimatedLine.transform.position.z));
                AnimatedLine.Enqueue(pos);
            }
            else if (timer > 13)
            {
                Vector3 pos = wayPoint3.transform.position;
                pos = Camera.main.ScreenToViewportPoint(new Vector3(pos.x, pos.y, AnimatedLine.transform.position.z));
                AnimatedLine.Enqueue(pos);
            }


		
	    }
    }
}