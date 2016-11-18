using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseController : MonoBehaviour {
    public Transform pause;
	// Update is called once per frame
	void Update () {
        
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
            if (pause.gameObject.activeInHierarchy == false)
            {
                pause.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pause.gameObject.SetActive(false);
                Time.timeScale = 1;
            }

    }
}
