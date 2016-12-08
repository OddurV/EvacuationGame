using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public Text healthText;
	public Text reason;
    public int startingHealth;
    public int currentHealth;
    public bool harmed = false;
	public LevelEndFail levelEndFail;
	public float smokeCounter = 0;
    
    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
        healthText.text = "Health: " + currentHealth;
	}

    /*void OnTriggerEnter(Collider other){
        if (other.tag == "Smoke"){
        harmed = true;
            InvokeRepeating("Damage", 1.0f, 1.0f);
        }
    }*/

	void OnTriggerStay (Collider other){
		if (other.tag == "Smoke") {
			smokeCounter += Time.deltaTime;
		}
		if (smokeCounter > 5) {// You have spent a minute in smoke
			reason.text = "You inhaled too much smoke";
			levelEndFail.Fail ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Fire") {
			reason.text = "Stay away from the fire!";
			levelEndFail.Fail ();
		}
	}

    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == "Smoke"){
        harmed = false;
        }
    }*/

    public void Damage(){
        if (harmed) {
            currentHealth = currentHealth - 1;
            healthText.text = "Health: " + currentHealth;
            if (currentHealth == 0 ){
				reason.text = "Smoking can harm you and the others around you.";
				levelEndFail.Fail ();
            }
        }
    }
}
