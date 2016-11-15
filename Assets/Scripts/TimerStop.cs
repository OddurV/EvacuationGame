using UnityEngine;
using System.Collections;

public class TimerStop : MonoBehaviour {



	public Timer theNewScript;

	private void OnTriggerEnter(Collider other)
	{
		theNewScript.Finnish();
		//GameObject.Find("EthanBody").SendMessage("Finnish");

	}

}
