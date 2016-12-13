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
	public float healthTimer = 5;
    
	public Transform smokeFail;
	public Transform fireFail;

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
		if (smokeCounter > healthTimer) {// You have spent too long in smoke
			//reason.text = "You inhaled too much smoke";
			smokeFail.gameObject.SetActive(true);
			levelEndFail.Fail ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Fire") {
			//reason.text = "Stay away from the fire!";
			fireFail.gameObject.SetActive(true);
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
