﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestSystem : MonoBehaviour {

    public ScoreManager scManager;
    public Text messageText;
	public GameObject[] quests;
	public int questCounter = 0;
	public GameObject fireManager;

	void Start(){
		quests = GameObject.FindGameObjectsWithTag ("Quest");
		// Deactivate all quests
		for (int i = 0; i < quests.Length; i++) {
			//Debug.Log ("Quest Number " + i + " is named" + quests [i].name);
			quests [i].SetActive (false);
		}
		// Activate the first quest
		quests [0].SetActive (true);
		messageText.text = "Go to "+quests[0];
	}

	//Use:  QuestCompleted()
	//Pre:  questCounter is an int representing how many quests have been completed
	//		quests is an array of quest gameObjects
	//Post: The next quest has been activated
	public void QuestCompleted(){
		questCounter++;
        scManager.ScoreAddition();
		if (questCounter >= quests.Length) {
			messageText.text = "All quests completed";
			fireManager.GetComponent<FireStart> ().StartFire ();
			return;
		}
		quests [questCounter].SetActive (true);
		messageText.text = "Go to "+quests[questCounter];
	}
}