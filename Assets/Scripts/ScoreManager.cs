using UnityEngine;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour {

    public int score = 0;

    void Start()
    {
    }

    public void ScoreAddition()
    {
        score = score + 1;
        
    }

}
