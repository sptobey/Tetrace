using UnityEngine;
using System.Collections;

// Ensures that there is only one "current piece" selected.
// This is used to make pieces not overlap.

public static class currentPiece {

	private static GameObject tetrisPiece = null;

	public static void setCurrentPiece(GameObject tetrisPiece) {
		if(currentPiece.tetrisPiece == null) {
			currentPiece.tetrisPiece = tetrisPiece;
			preventOverlap theOverlapScript = tetrisPiece.GetComponent<preventOverlap>();
			theOverlapScript.setSelected(true);
		} else {
			preventOverlap oldOverlapScript = currentPiece.tetrisPiece.GetComponent<preventOverlap>();
			oldOverlapScript.setSelected(false);
			currentPiece.tetrisPiece = tetrisPiece;
			preventOverlap newOverlapScript = tetrisPiece.GetComponent<preventOverlap>();
			newOverlapScript.setSelected(true);
		}
		//Debug.Log("Selected Piece: " + currentPiece.tetrisPiece);
	}

	public static GameObject getCurrentPiece() {
		//Debug.Log("Selected Piece: " + currentPiece.tetrisPiece);
		return currentPiece.tetrisPiece;
	}
}
