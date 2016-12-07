using UnityEngine;
using System.Collections;

public class TimerStop : MonoBehaviour {


	public GameManager gameManager;
	public Timer theNewScript;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && gameManager.isThereAFire){
			theNewScript.Finnish();
			//GameObject.Find("EthanBody").SendMessage("Finnish");
		}
	}

}
