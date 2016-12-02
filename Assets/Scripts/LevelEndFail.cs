﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEndFail : MonoBehaviour {

	public ScoreManager scmanager;
	public GameManager gameManager;

	public Transform endFail;

	public void Fail()
	{
		if (endFail.gameObject.activeInHierarchy == false)
		{
			endFail.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
	}

	public void MainMenu()
	{
		Application.LoadLevel("Main_Menu");
	}

	public void RetryLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
