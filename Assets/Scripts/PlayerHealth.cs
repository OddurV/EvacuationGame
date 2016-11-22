using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public Text healthText;
    public int startingHealth;
    public int currentHealth;
    public bool harmed = false;
    
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
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
