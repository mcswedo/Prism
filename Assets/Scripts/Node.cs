using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int tileX;
    public int tileY;
    void Update()
    {
    }


    void OnMouseDown()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, 90));

    }
}
