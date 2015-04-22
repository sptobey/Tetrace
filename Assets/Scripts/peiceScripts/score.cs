using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {
    
    public int scoring = 50000;
    private IEnumerator scoredown;
    private string s;
    private bool scoreGot;
    
	// Use this for initialization
    
	void Start () {
        scoreGot = false;
	}
    
    void Update () {
        if (scoring > 0) {
            scoring = scoring - 1;
            s = string.Concat("Score:  ", scoring.ToString());
        }
        if (scoreGot) {
            killSelf();
        }
    }
    
    void getScore () {
        scoreGot = true;
        PlayerPrefs.SetInt("Current Score", scoring);
        if (scoring > PlayerPrefs.GetInt("HighscoreLevel" + (Application.loadedLevel-2))) {
            PlayerPrefs.SetInt("HighscoreLevel" + (Application.loadedLevel - 2), scoring);
        }
    }
    
    void killSelf () {
        Destroy(this);
    }
    
    
    
    void OnGUI() {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), s);
    }
}
