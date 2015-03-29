using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameGrid : MonoBehaviour {

	private static Dictionary<Transform, bool> gameBoard = new Dictionary<Transform, bool>();
	private bool isFilled = false;
	public float waitTime = 0.5f;

	void Start () {
		gameBoard.Add(transform, false);
		foreach(Transform child in transform) {
			gameBoard.Add(child, false);
		}
	}

	void Update () {
		if(Input.GetButtonUp("Fire1")) {
			StartCoroutine(gridWinCheck(waitTime));
		}
	}

	public static void setGridPiece(Transform tform, bool isOccupied) {
		gameBoard[tform] = isOccupied;
	}

	private void checkGridFilled() {
		bool filledChecker = true;
		foreach(KeyValuePair<Transform, bool> child in gameBoard) {
			if(child.Value == true) {
				continue;
			} else {
				filledChecker = false;
				break;
			}
		}
		isFilled = filledChecker;
	}

	private void gameWin(bool boardFilled) {
		if(boardFilled) {
			Debug.Log("Board is Full.");
		} else {
			Debug.Log("Board is NOT Full");
		}
	}

	IEnumerator gridWinCheck(float time) {
		yield return new WaitForSeconds(time);
		checkGridFilled();
		gameWin(isFilled);
	}
}
