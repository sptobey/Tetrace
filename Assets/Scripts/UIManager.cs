using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public int levelMainMenu = 0;
	public int levelClassicMode = 1;
	public int levelMarathonMode = 3;
	public int levelInstructions = 2;
	private int levelReset;

	void Start() {
		levelReset = Application.loadedLevel;
	}

	public void MainMenu(){
		Application.LoadLevel (levelMainMenu);
	}
	public void Reset() {
		Application.LoadLevel (levelReset);
	}
	public void Classic() {
		Application.LoadLevel (levelClassicMode);
	}
	public void Marathon(){
		Application.LoadLevel (levelMarathonMode);
	}
	public void Insruc() {
		Application.LoadLevel (levelInstructions);
	}
	public void Level1(){
		Application.LoadLevel (4);
	}
	public void eraseAllData() {
		PlayerPrefs.DeleteAll();
		Application.LoadLevel(levelReset);
	}
}
