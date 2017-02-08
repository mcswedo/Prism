using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public static ButtonManager Instance
	{
		get
		{
			return instance;
		}
	}

	private static ButtonManager instance;

	public void Awake()
	{
		instance = this;
	}

	public void LoadScene(int sceneToLoad)
	{
		if(SceneManager.GetActiveScene().name != "Splash")
		{
			MusicManager.Instance.PlaySFX("click");
		}
		SceneManager.LoadScene(sceneToLoad);
	}

	public void CloseGame()
	{
		Application.Quit();
	}
}
