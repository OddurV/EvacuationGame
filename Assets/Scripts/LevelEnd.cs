using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    public ScoreManager scmanager;
	public GameManager gameManager;
	public LevelEndFail levelEndFail;
	public Text reason;
    public Timer timer;
    public int scor;
    public string tim;
    public Transform end;
    public Text time;
    public Text score;

    void OnTriggerStay(Collider other)
    {
		if (other.tag == "Player" && gameManager.isThereAFire && gameManager.isTheAlarmOn)
        {
            End();
		}else if (other.tag == "Player" && gameManager.isThereAFire && !gameManager.isTheAlarmOn){
			reason.text = "Hey, what happened to the alarm?";
			levelEndFail.Fail ();
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
