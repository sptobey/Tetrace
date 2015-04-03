using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	public void MainMenu(){
		Application.LoadLevel (0);
	}
	public void Reset() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
