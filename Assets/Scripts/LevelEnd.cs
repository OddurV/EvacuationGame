﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    public ScoreManager scmanager;
	public GameManager gameManager;
	public LevelEndFail levelEndFail;
	public Text reason;
    public Timer timer;
    public int scor;
    public string tim;
    public Transform end;
    public Text time;
    public GameObject oneStar;
    public GameObject twoStars;
    public GameObject threeStars;
    
    GameObject gos;

    void Start()
    {
        GameObject oneStar = GameObject.FindGameObjectWithTag("1Star");
        GameObject twoStars = GameObject.FindGameObjectWithTag("2Stars");
        GameObject threeStars = GameObject.FindGameObjectWithTag("3Stars");
        //oneStar.SetActive(false);
        //twoStars.SetActive(false);
        //threeStars.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
		if (other.tag == "Player" && gameManager.isThereAFire && gameManager.isTheAlarmOn)
        {
            End();
		}else if (other.tag == "Player" && gameManager.isThereAFire && !gameManager.isTheAlarmOn){
			reason.text = "Hey, what happened to the alarm?";
			levelEndFail.Fail ();
		}
    }

    public void End()
    {
        if (end.gameObject.activeInHierarchy == false)
        {
            end.gameObject.SetActive(true);
            Time.timeScale = 0;
            scor = scmanager.score;
            tim = timer.finalTime;
            //score.text = "Score : " + scor;
            time.text = "Time : " + tim;
            if (scor == 1)
            {
                oneStar.SetActive(true);
            }
            if (scor == 2)
            {
                twoStars.SetActive(true);
            }
            if (scor == 3)
            {
                threeStars.SetActive(true);
            }
        }
    }

    public void MainMenu()
    {
        Application.LoadLevel("Main_Menu");
    }

    public void Tutorial2()
    {
        Application.LoadLevel("Tutorial_Level_2");
    }

	public void Tutorial3()
	{
		Application.LoadLevel("Tutorial_Level_3");
	}

	public void Level5()
	{
		Application.LoadLevel("Main");
	}
}
