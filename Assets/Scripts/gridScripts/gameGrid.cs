using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameGrid : MonoBehaviour {

	private Dictionary<Vector3, bool> gameBoard = new Dictionary<Vector3, bool>();
	private bool isFilled = false;
	public bool win = false;

	void Start () {
		foreach(Transform child in transform) {
			Vector3 posChild = child.position;
			gameBoard.Add(posChild, false);
		}
	}

	void Update () {
    
        /* A messy way to check wins
         * 
         * public float checkWinEverySeconds = 2.0f;
         * private bool isChecking = false;
         * 
         * 	IEnumerator waitCheckWin(float waitTtime) {
		 *		isChecking = true;
		 *		yield return new WaitForSeconds(waitTtime);
		 *		gridWinCheck();
		 *		isChecking = false;
		 *	}
         * 
		if(!isChecking) {
			StartCoroutine(waitCheckWin(checkWinEverySeconds));
		}
        */

		// A different way to check wins
		/*
		if(Input.GetButtonUp("Fire1")) {
			gridWinCheck();
		}
        */
		gridWinCheck ();
		
	}

	public void setGridPiece(Vector3 gridPiecePos, bool isOccupied) {
		gameBoard[gridPiecePos] = isOccupied;
	}

	private void checkGridFilled() {
		bool filledChecker = true;
		foreach(KeyValuePair<Vector3, bool> child in gameBoard) {
			if(child.Value == true) {
				continue;
			} else {
				filledChecker = false;
				break;
			}
		}
		isFilled = filledChecker;
	}

	private void gameWin() {
		if(isFilled) {
			Debug.Log("Board is Full.");
			PlayerPrefs.SetString("Level" + (Application.loadedLevel - 2), "Tetrace");
			//Application.LoadLevel (Application.loadedLevel + 1);
            gameObject.SendMessage("getScore");
			win = true;
		} else {
			Debug.Log("Board is NOT Full");
		}
	}

	private void gridWinCheck() {
		checkGridFilled();
		gameWin();
	}

	void OnGUI()
	{
		if (win)
		{
			GUI.Window(0, new Rect((Screen.width/2)-150, (Screen.height/2)-75
			                       , 300, 250), ShowGUI, "Level Complete \n Score:  " + PlayerPrefs.GetInt("Current Score"));
		}
	}
	
	void ShowGUI(int windowID)
	{
		GUI.Label(new Rect(125, 40, 200, 30), "CONTINUE?");
		if (GUI.Button(new Rect(50, 150, 75, 30), "Yes"))
		{
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		if (GUI.Button(new Rect(200, 150, 75, 30), "No"))
		{
			Application.LoadLevel (0);
		}
	}
}
