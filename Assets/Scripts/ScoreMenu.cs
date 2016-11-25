// to be deleted
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreMenu : MonoBehaviour {

    public string scoretxtFile = "score";
    public string timetxtFile = "time";
    string txtContents;
    string txtContents1;
    public Text time;
    public Text score;
    
    // Use this for initialization
    void Start () {
        TextAsset txtAssets = (TextAsset)Resources.Load(scoretxtFile);
        txtContents = txtAssets.text;
        TextAsset txtAssets1 = (TextAsset)Resources.Load(timetxtFile);
        txtContents1 = txtAssets1.text;
    }

    // Update is called once per frame
    void Update () {
        score.text = "Score : " + score;
        time.text = "Time : " + txtContents1;
    }
}
