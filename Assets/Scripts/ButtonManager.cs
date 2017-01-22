﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void LoadScene(int sceneToLoad)
	{
		SceneManager.LoadScene(sceneToLoad);
	}

	public void CloseGame()
	{
		Application.Quit();
	}
}
