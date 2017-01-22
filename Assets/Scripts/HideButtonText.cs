using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideButtonText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(!gameObject.GetComponentInParent<Button>().interactable)
		{
			this.gameObject.SetActive(false);
		}
	}
}
