using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameGrid : MonoBehaviour {

	private Dictionary<Transform, bool> gameBoard = new Dictionary<Transform, bool>();
	private bool isFilled = false;

	void Start () {
		gameBoard.Add(transform, false);
		foreach(Transform child in transform) {
			gameBoard.Add(child, false);
		}
	}

	void Update () {
	
	}
	
	public void gridWinCheck() {
		isFilled = isGridFilled();
		gameWin(isFilled);
	}

	private bool isGridFilled() {
		bool filledChecker = true;
		foreach(KeyValuePair<Transform, bool> child in gameBoard) {
			if(child.Value == true) {
				continue;
			} else {
				filledChecker = false;
				break;
			}
		}
		return filledChecker;
	}

	private void gameWin(bool boardFilled) {
		if(boardFilled) {
			Debug.Log("Board is Full.");
		} else {
			Debug.Log("Board is NOT Full");
		}
	}

}
