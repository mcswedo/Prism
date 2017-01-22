using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenHandler : MonoBehaviour {

	void Start () {
		StartCoroutine("DelayAndLoad");
	}
		
	IEnumerator DelayAndLoad()
	{
		Debug.Log ("start");
		yield return new WaitForSeconds(3f);
		Debug.Log ("end");

		ButtonManager.Instance.LoadScene(1);
	}
}
