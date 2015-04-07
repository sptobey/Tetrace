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
	public void Classic() {
		Application.LoadLevel (1);
	}
	public void Marathon(){
		Application.LoadLevel (3);
	}
	public void Insruc() {
		Application.LoadLevel (2);
	}
	public void Level1(){
		Application.LoadLevel (4);
	}
	public void eraseAllData() {
		PlayerPrefs.DeleteAll();
		Application.LoadLevel(Application.loadedLevel);
	}
}
