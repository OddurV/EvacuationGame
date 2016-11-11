using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quest : MonoBehaviour {

    public Text messageText;

    // Use this for initialization
	void Start () {
        messageText.text = "Go to quest A";
	}
	
    
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Player")
        {
			messageText.text = "You finished Quest A";
			Destroy(this.gameObject);
        }
	}
}

