using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseController : MonoBehaviour {
    public Transform pause;
	private bool paused = false;
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			paused = !paused;
			Pause();
        }
		if (paused) {
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				Application.LoadLevel("Tutorial_Level_1");
			}
			if(Input.GetKeyDown(KeyCode.Alpha2)){
				Application.LoadLevel("Tutorial_Level_2");
			}
			if(Input.GetKeyDown(KeyCode.Alpha3)){
				Application.LoadLevel("Tutorial_Level_3");
			}
			if(Input.GetKeyDown(KeyCode.Alpha4)){
				Application.LoadLevel("Main");
			}
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

	public void QuitGame()
	{
        Application.LoadLevel("Main_Menu");
    }
}
