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
	public void Level2(){
		Application.LoadLevel (5);
	}
	public void Level3(){
		Application.LoadLevel (6);
	}
	public void Level4(){
		Application.LoadLevel (7);
	}
	public void Level5(){
		Application.LoadLevel (8);
	}
	public void Level6(){
		Application.LoadLevel (9);
	}
	public void Level7(){
		Application.LoadLevel (10);
	}
	public void Level8(){
		Application.LoadLevel (11);
	}
	public void Level9(){
		Application.LoadLevel (12);
	}
	public void Level10(){
		Application.LoadLevel (13);
	}
	public void Level11(){
		Application.LoadLevel (14);
	}
	public void Level12(){
		Application.LoadLevel (15);
	}
	public void Level13(){
		Application.LoadLevel (16);
	}
	public void Level14(){
		Application.LoadLevel (17);
	}
	public void Level15(){
		Application.LoadLevel (18);
	}
	public void eraseAllData() {
		PlayerPrefs.DeleteAll();
		Application.LoadLevel(levelReset);
	}
}
