using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    public ScoreManager scmanager;
    public Timer timer;
    public int scor;
    public string tim;
    public Transform end;
    public Text time;
    public Text score;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            End();
        }
    }

    public void End()
    {
        if (end.gameObject.activeInHierarchy == false)
        {
            end.gameObject.SetActive(true);
            Time.timeScale = 0;
            scor = scmanager.score;
            tim = timer.finalTime;
            score.text = "Score : " + scor;
            time.text = "Time : " + tim;
        }
    }

    public void MainMenu()
    {
        Application.LoadLevel("Main_Menu");
    }

    public void NextLevel()
    {
        Application.LoadLevel("Main_Menu");
    }
}
