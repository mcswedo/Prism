﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour 
{

	public AudioClip MUS_menu;

	public static MusicManager Instance
	{
		get
		{
			return instance;
		}
	}

	private AudioSource aSource;

	private static MusicManager instance;

	void Awake () 
	{
		if(!instance)
			instance = this;
		else
			Destroy(this.gameObject);
		
		DontDestroyOnLoad(this);
	}

	void Start () 
	{
		aSource = gameObject.GetComponent<AudioSource>();

		if(!aSource.isPlaying) 
		{
			aSource.clip = MUS_menu;
			aSource.Play();
		}	
	}
}
