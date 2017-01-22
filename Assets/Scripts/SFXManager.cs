using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour 
{

	public AudioClip SFX_hover;
	public AudioClip SFX_click;
	public AudioSource sfxSource;

	public void PlaySFX(string sfx)
	{
		if (sfx == "hover")
			sfxSource.PlayOneShot(SFX_hover);

		if (sfx == "click")
			sfxSource.PlayOneShot(SFX_click);
	}
}
