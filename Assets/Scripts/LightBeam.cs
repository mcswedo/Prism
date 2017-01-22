using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour {


    public bool shootRaycast =  false;
    public bool redActive = false;
    public bool blueActive = false;
    public bool greenActive = false;
    float timer = 0;
	// Update is called once per frame
    

	void Update () 
    {
        timer += Time.deltaTime;
        Raycasting();
		
	}
    
    void Raycasting()
    {
        if (shootRaycast)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y), Vector2.right, 100, 1 << LayerMask.NameToLayer("Light"));
            if (hit.collider.gameObject.tag == "Light")
            {
                
                //Transfers over properties to keep the ray going.
                hit.collider.gameObject.GetComponent<LightActivator>().redActive = redActive;
                hit.collider.gameObject.GetComponent<LightActivator>().blueActive = blueActive;
                hit.collider.gameObject.GetComponent<LightActivator>().greenActive = greenActive;
                hit.collider.gameObject.GetComponent<LightActivator>().activate = true;
                hit.collider.gameObject.GetComponent<LightBeam>().shootRaycast = true;
                hit.collider.gameObject.GetComponent<LightBeam>().redActive = redActive;
                hit.collider.gameObject.GetComponent<LightBeam>().blueActive = blueActive;
                hit.collider.gameObject.GetComponent<LightBeam>().greenActive = greenActive;

                
            }
            RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y), Vector2.left, 100, 1 << LayerMask.NameToLayer("Light"));
            if (hit2.collider.gameObject.tag == "Light")
            {

                //Transfers over properties to keep the ray going.
                hit2.collider.gameObject.GetComponent<LightActivator>().redActive = redActive;
                hit2.collider.gameObject.GetComponent<LightActivator>().blueActive = blueActive;
                hit2.collider.gameObject.GetComponent<LightActivator>().greenActive = greenActive;
                hit2.collider.gameObject.GetComponent<LightActivator>().activate = true;
                hit2.collider.gameObject.GetComponent<LightBeam>().shootRaycast = true;
                hit2.collider.gameObject.GetComponent<LightBeam>().redActive = redActive;
                hit2.collider.gameObject.GetComponent<LightBeam>().blueActive = blueActive;
                hit2.collider.gameObject.GetComponent<LightBeam>().greenActive = greenActive;

            }
            RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y +1.5f), Vector2.up, 1000, 1 << LayerMask.NameToLayer("Light"));
            if (hit3.collider.gameObject.tag == "Light")
            {

                //Transfers over properties to keep the ray going.
                hit3.collider.gameObject.GetComponent<LightActivator>().redActive = redActive;
                hit3.collider.gameObject.GetComponent<LightActivator>().blueActive = blueActive;
                hit3.collider.gameObject.GetComponent<LightActivator>().greenActive = greenActive;
                hit3.collider.gameObject.GetComponent<LightActivator>().activate = true;
                hit3.collider.gameObject.GetComponent<LightBeam>().shootRaycast = true;
                hit3.collider.gameObject.GetComponent<LightBeam>().redActive = redActive;
                hit3.collider.gameObject.GetComponent<LightBeam>().blueActive = blueActive;
                hit3.collider.gameObject.GetComponent<LightBeam>().greenActive = greenActive;


            }
            hit = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1.5f), Vector2.down, 1000, 1 << LayerMask.NameToLayer("Light"));
            if (hit.collider.gameObject.tag == "Light")
            {

                //Transfers over properties to keep the ray going.
                hit.collider.gameObject.GetComponent<LightActivator>().redActive = redActive;
                hit.collider.gameObject.GetComponent<LightActivator>().blueActive = blueActive;
                hit.collider.gameObject.GetComponent<LightActivator>().greenActive = greenActive;
                hit.collider.gameObject.GetComponent<LightActivator>().activate = true;
                hit.collider.gameObject.GetComponent<LightBeam>().shootRaycast = true;
                hit.collider.gameObject.GetComponent<LightBeam>().redActive = redActive;
                hit.collider.gameObject.GetComponent<LightBeam>().blueActive = blueActive;
                hit.collider.gameObject.GetComponent<LightBeam>().greenActive = greenActive;


                
                
            }
        }

        
        

        
    }
}
