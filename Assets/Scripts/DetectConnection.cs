using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectConnection : MonoBehaviour {

    
    public Color sourceColor;
    public enum Sides {None,Left, Right, Above, Below };

    public Sides side;
    //bool isLit = false;
    

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    //Checks to see if is touching another connector.
    void OnTriggerStay2D(Collider2D collider)
    {
        if(gameObject.tag == "Blank")
        {
            return;
        }
        if (collider.gameObject.tag == "Connector" )
        {

            switch (gameObject.GetComponentInParent<LightManager>().Block)
            {
                case LightManager.BlockType.Source:
                    gameObject.GetComponentInParent<LightManager>().adjacentNodes[0] = collider.transform.parent.gameObject;
                    break;
                case LightManager.BlockType.L:
                    switch (side)
                    {
                        case Sides.Left:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[0] = collider.transform.parent.gameObject;
                            break;
                        case Sides.Above:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[1] = collider.transform.parent.gameObject;
                            break;
                        case Sides.Right:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[2] = null;
                            break;
                        case Sides.Below:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[3] = null;
                            break;
                        default:
                            break;
                    }
                    break;
                case LightManager.BlockType.Line:
                    switch (side)
                    {
                        case Sides.Left:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[0] = collider.transform.parent.gameObject;
                            break;
                        case Sides.Above:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[1] = null;
                            break;
                        case Sides.Right:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[2] = collider.transform.parent.gameObject;
                            break;
                        case Sides.Below:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[3] = null;
                            break;
                        default:
                            break;
                    }
                    break;
                case LightManager.BlockType.T:
                    switch (side)
                    {
                        case Sides.Left:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[0] = collider.transform.parent.gameObject;
                            break;
                        case Sides.Above:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[1] = collider.transform.parent.gameObject;
                            break;
                        case Sides.Right:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[2] = collider.transform.parent.gameObject;
                            break;
                        case Sides.Below:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[3] = null;
                            break;
                        default:
                            break;
                    }
                    break;
                case LightManager.BlockType.Cross:
                    switch (gameObject.GetComponentInParent<LightManager>().sourceSide)
                    {
                        case LightManager.Sides.Left:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[0] = collider.transform.parent.gameObject;
                            break;
                        case LightManager.Sides.Above:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[1] = collider.transform.parent.gameObject;
                            break;
                        case LightManager.Sides.Right:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[2] = collider.transform.parent.gameObject;
                            break;
                        case LightManager.Sides.Below:
                            gameObject.GetComponentInParent<LightManager>().adjacentNodes[3] = collider.transform.parent.gameObject;
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }   
    }    
}
