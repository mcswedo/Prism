using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public GameObject leftLight, rightLight, centerLight, aboveLight, belowLight = null;
    public enum Sides {None,Left, Right, Above, Below };
    public Sides sourceSide;
    public enum BlockType {Source, T, L, Line, Cross, Blank };
    public BlockType Block;
    public bool isComingFromSource = false;
    public bool isSource = false;
    public enum SourceColor {None, red, blue, green };
    public SourceColor sColor;
    public Color colorSource;
    public bool areLightsEnabled = false;
    public GameObject[] adjacentNodes = new GameObject[4];
    //public GameObject[] sides;
    public bool blueFound = false;
    public bool redFound = false;
    public bool greenFound = false;
    public bool wasSearched = false;
    Queue<GameObject> line = new Queue<GameObject>();
    List<GameObject> redList = new List<GameObject>();

    void Start()
    {
        if(sColor == SourceColor.red)
        {
            GetComponent<SpriteRenderer>().color = Colors.red;
            if (isSource)
                colorSource = Colors.red;


        }
        if (sColor == SourceColor.blue)
        {
            GetComponent<SpriteRenderer>().color = Colors.blue;
            if (isSource)
                colorSource = Colors.blue;
        }
        if (sColor == SourceColor.green)
        {
            GetComponent<SpriteRenderer>().color = Colors.green;
            if (isSource)
                colorSource = Colors.green;
        }
        
    }

	// Update is called once per frame
	void Update () {

        if(!blueFound && !redFound && !greenFound)
        {
            isComingFromSource = false;
        }
        if(!isComingFromSource)
        {
            areLightsEnabled = false;
        }
        else if(isComingFromSource)
        {
            areLightsEnabled = true;
        }
        

        
        
        if (areLightsEnabled)
        {
            if (leftLight != null)
            {
                leftLight.SetActive(true);
                leftLight.GetComponent<Light>().color = colorSource;
            }
            if (belowLight != null)
            {
                belowLight.SetActive(true);
                belowLight.GetComponent<Light>().color = colorSource;
            }
            if (rightLight != null)
            {
                rightLight.SetActive(true);
                rightLight.GetComponent<Light>().color = colorSource;
            }
            if (aboveLight != null)
            {
                aboveLight.SetActive(true);
                aboveLight.GetComponent<Light>().color = colorSource;
            }
            if (centerLight != null)
            {
                centerLight.SetActive(true);
                centerLight.GetComponent<Light>().color = colorSource;
            }

            
        }
        else if (!areLightsEnabled)
        {
            if (leftLight != null)
            {
                leftLight.SetActive(false);
               
            }
            if (belowLight != null)
            {
                belowLight.SetActive(false);
            }
            if (rightLight != null)
            {
                rightLight.SetActive(false);

            }
            if (aboveLight != null)
            {
                aboveLight.SetActive(false);

            }

            if(centerLight != null)
            {
                centerLight.SetActive(false);
            }

        }
        //Check to see which color to display
        if (redFound && blueFound && greenFound)
        {
            SetColor(Colors.white);
        }
        else if (redFound && blueFound)
        {
            SetColor(Colors.magenta);
        }
        else if (redFound && greenFound)
        {
            SetColor(Colors.yellow);
        }
        else if (greenFound && blueFound)
        {
            SetColor(Colors.cyan);
        }
        else if (greenFound)
        {
            SetColor(Colors.green);
        }
        else if (blueFound)
        {
            SetColor(Colors.blue);
        }
        else if (redFound)
        {
            SetColor(Colors.red);

        }







        for (int i = 0; i < adjacentNodes.Length; i++)
        {
            if (adjacentNodes[i] != null)
            {
                adjacentNodes[i].GetComponent<LightManager>().isComingFromSource = true;
                switch (sColor)
                {
                    case SourceColor.red:
                        adjacentNodes[i].GetComponent<LightManager>().redFound = true;
                        foreach(GameObject redCheck in redList)
                        {
                            if(redCheck == adjacentNodes[i])
                            {
                                break;
                            }
                            else
                            {
                                redList.Add(adjacentNodes[i]);
                            }
                        }
                        
                        break;
                    case SourceColor.blue:
                        adjacentNodes[i].GetComponent<LightManager>().blueFound = true;
                        break;
                    case SourceColor.green:
                        adjacentNodes[i].GetComponent<LightManager>().greenFound = true;
                        break;
                }
                line.Enqueue(adjacentNodes[i]);
                wasSearched = true;
            }
        }

        
        if (line.Count > 0)
        {
            GameObject queuedObject = line.Dequeue();
            
                for (int i = 0; i < queuedObject.GetComponent<LightManager>().adjacentNodes.Length; i++)
                {
                    if (queuedObject.GetComponent<LightManager>().adjacentNodes[i] != null)
                    {
                        queuedObject.GetComponent<LightManager>().adjacentNodes[i].GetComponent<LightManager>().isComingFromSource = true;
                        if (queuedObject.GetComponent<LightManager>().redFound)
                        {
                            queuedObject.GetComponent<LightManager>().adjacentNodes[i].GetComponent<LightManager>().redFound = true;
                        }
                        if (queuedObject.GetComponent<LightManager>().greenFound)
                        {
                            queuedObject.GetComponent<LightManager>().adjacentNodes[i].GetComponent<LightManager>().greenFound = true;
                        }
                        if (queuedObject.GetComponent<LightManager>().blueFound)
                        {
                            queuedObject.GetComponent<LightManager>().adjacentNodes[i].GetComponent<LightManager>().blueFound = true;
                        }

                    }
                    line.Enqueue(queuedObject.GetComponent<LightManager>().adjacentNodes[i]);
                }
               
                queuedObject.GetComponent<LightManager>().wasSearched = true;
            


        }
        wasSearched = false;
        if(line.Count > 100)
        {
            line.Clear();
        }
    }

    void SetColor(Color activeColor)
    {
        if (leftLight != null)
        {
            leftLight.GetComponent<Light>().color = activeColor;
        }
        if (belowLight != null)
        {
            belowLight.GetComponent<Light>().color = activeColor;
        }
        if (rightLight != null)
        {
            rightLight.GetComponent<Light>().color = activeColor;
        }
        if (aboveLight != null)
        {
            aboveLight.GetComponent<Light>().color = activeColor;
        }
        if (centerLight != null)
        {
            centerLight.GetComponent<Light>().color = activeColor;
        }

    }

    //void OnMouseDown()
    //{
    //    //searchSource(adjacentNodes);
    //}

    void OnMouseUp()
    {
        wasSearched = false;
    }
}
