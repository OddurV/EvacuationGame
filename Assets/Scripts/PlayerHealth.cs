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
    
    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
        healthText.text = "Health: " + currentHealth;
	}

    void OnTriggerEnter(Collider other){
        if (other.tag == "Smoke"){
        harmed = true;
            InvokeRepeating("Damage", 1.0f, 1.0f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Smoke"){
        harmed = false;
        }
    }

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
