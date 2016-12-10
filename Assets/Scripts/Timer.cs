using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class Timer : MonoBehaviour {

    public Text timerText;
	private bool finnished = true;
    public string finalTime;
    
    private float startTime;
    
    // Use this for initialization
    void Start () {
		finnished = true;
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if (!finnished) {
			float t = Time.time - startTime;
			string minutes = ((int)t / 60).ToString ();
			string seconds = (t % 60).ToString ("f2");
			timerText.text = minutes + ":" + seconds;
			finalTime = minutes + ":" + seconds;
		}
    }

	public void Reset(){
		startTime = Time.time;
		finnished = false;
	}

	public void Finnish () {
		finnished = true;
		timerText.color = Color.green;
    }
}
