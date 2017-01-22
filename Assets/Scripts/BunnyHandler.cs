using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyHandler : MonoBehaviour {
	public Sprite stage1;
	public Sprite stage2;
	public Sprite stage3;

	public Light bunnyLight;

	public Sprite curStage;

	private float basePulseSpeed = .25f;
	private float baseIntensity = .75f;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = stage1;
		curStage = stage1;
	}
	
	// Update is called once per frame
	void Update () {
		// handle bunny detecting state changes
		curStage = gameObject.GetComponent<SpriteRenderer>().sprite;

		// update bunny light pulsing
		if (curStage == stage1)
		{	
//			bunnyLight.color = Color.white;
			PulseLight(1);
		}
		if (curStage == stage2)
		{	
//			bunnyLight.color = Colors.blue;
			PulseLight(2);
		}
		if (curStage == stage3)
		{
//			bunnyLight.color = Colors.magenta;
			PulseLight(3);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject otherObj = other.gameObject;
		GameObject otherParent = otherObj.GetComponentInParent<SpriteRenderer>().gameObject;
		Debug.Log(otherParent.name);
		Component[] children = otherParent.GetComponentsInChildren(typeof(Transform),true);
		GameObject bgContainer;

		foreach (Component c in children)
		{
			if (c.gameObject.name == "BackgroundContainer")
			{
				bgContainer = c.gameObject;
				Debug.Log("bgc found");
				break;
			}
		}

		Component[] lights = otherParent.GetComponentsInChildren(typeof(Light),true);
		Debug.Log(lights);
		List<Color> lightColors = new List<Color>();
		Debug.Log(lightColors);
		foreach (Component l in lights)
		{
			if (l.gameObject.activeSelf == true)
			{
				Debug.Log(l.GetComponent<Light>().color);
				Debug.Log(Colors.red);
				lightColors.Add(l.GetComponent<Light>().color);
			}
		}

		foreach (Color c in lightColors)
		{
			if (IsApproximately(c.g, 1f) && IsApproximately(c.r, 1f) && IsApproximately(c.b, 1f))
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stage3;
				bunnyLight.color = Colors.white;

				// win level
			}

			if (IsApproximately(c.g, Colors.red.g))
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stage1;
				bunnyLight.color = Colors.red;
			}
			else if (IsApproximately(c.g, Colors.green.g) && !IsApproximately(c.b, 1f))
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stage1;
				bunnyLight.color = Colors.green;
			}
			else if (IsApproximately(c.g, Colors.blue.g))
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stage1;
				bunnyLight.color = Colors.blue;
			}
			else if(IsApproximately(c.g, Colors.cyan.g))
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stage2;
				bunnyLight.color = Colors.cyan;
			}
			else if(IsApproximately(c.g,Colors.magenta.g))
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stage2;
				bunnyLight.color = Colors.magenta;
			}
			else if (IsApproximately(c.b,Colors.yellow.b))
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stage2;
				bunnyLight.color = Colors.yellow;
			}
			else
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stage1;
				bunnyLight.color = Colors.white;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = stage1;
		bunnyLight.color = Colors.white;
	}


	void PulseLight(int stage) {
		if (stage == 1)
			bunnyLight.intensity = Mathf.PingPong(Time.time * basePulseSpeed, baseIntensity);
		else if (stage == 2)
			bunnyLight.intensity = Mathf.PingPong(Time.time * basePulseSpeed * 1.5f, baseIntensity * 1.25f);
		else
			bunnyLight.intensity = Mathf.PingPong(Time.time * basePulseSpeed * 3f, baseIntensity * 1.5f);
	}

	bool IsApproximately(float a, float b)
	{
		float tolerance = 0.05f;
		if (Mathf.Abs(a - b) < tolerance)
			return true;
		else return false;
	}
}
