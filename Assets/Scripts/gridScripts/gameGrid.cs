using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameGrid : MonoBehaviour {

	private static Dictionary<Vector3, bool> gameBoard = new Dictionary<Vector3, bool>();
	private bool isFilled = false;
	public float checkWinEverySeconds = 2.0f;
	private bool isChecking = false;

	void Start () {
		foreach(Transform child in transform) {
			Vector3 posChild = child.position;
			gameBoard.Add(posChild, false);
		}
	}

	void Update () {

		if(!isChecking) {
			StartCoroutine(waitCheckWin(checkWinEverySeconds));
		}

		// A different way to check wins
		/*
		if(Input.GetButtonUp("Fire1")) {
			gridWinCheck();
		}
		*/
	}

	public static void setGridPiece(Vector3 gridPiecePos, bool isOccupied) {
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
		} else {
			Debug.Log("Board is NOT Full");
		}
	}

	private void gridWinCheck() {
		checkGridFilled();
		gameWin();
	}

	IEnumerator waitCheckWin(float waitTtime) {
		isChecking = true;
		yield return new WaitForSeconds(waitTtime);
		gridWinCheck();
		isChecking = false;
	}
}
