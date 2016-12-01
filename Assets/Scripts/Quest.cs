using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quest : MonoBehaviour {

	public QuestSystem questSystem;
    
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Player")
        {
    		questSystem.QuestCompleted();
            //Destroy(this.gameObject);
			this.gameObject.SetActive(false); //Makes it reuseable
        }
	}
}