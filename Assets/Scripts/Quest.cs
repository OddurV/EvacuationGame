using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quest : MonoBehaviour {

	public QuestSystem questSystem;
	public string type;

	public questSoundPlayer soundPlayer;
    
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Player")
        {
    		questSystem.QuestCompleted();
            //Destroy(this.gameObject);

			if (type == "coffee") {
				soundPlayer.PlayCoffeeSound();
			}
			if (type == "letter") {
				soundPlayer.PlayPaperSound();
			}
			if (type == "questMarker") {
				soundPlayer.PlayNPCSound();
			} 
			//else {
			//	soundPlayer.PlayQuestSound();
			//}

			
			this.gameObject.SetActive(false); //Makes it reuseable


        }
	}
}