using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DontDestroyOnLoad(transform.gameObject);
            Application.LoadLevel("Score_Menu");
        }
    }
}
