using UnityEngine;
using System.Collections;

public class gridPiece : MonoBehaviour {

	private bool isOccupied;
	private int layerMask;
	public float sphereRadius = 0.25f;

	void Start () {
		isOccupied = false;
		layerMask = LayerMask.GetMask("TetrisPiece");
	}

	public bool getIsOccupied() {
		return isOccupied;
	}
	public void setIsOccupied(bool isOccupied) {
		this.isOccupied = isOccupied;
	}

	public void notifyGrid() {
		gameGrid.setGridPiece(transform, getIsOccupied());
	}
	
	void OnCollisionEnter(Collision collision) {
		setIsOccupied(true);
		notifyGrid();
	}

	void OnCollisionExit(Collision collision) {
		setIsOccupied(false);
		notifyGrid();
	}

	/*
	void OnCollisionStay(Collision collision) {
		Debug.Log("Grid piece at (" + 
		          transform.position.x + ", " + transform.position.y 
		          + ") is Colliding with " +
		          collision.transform.name);
	}
	*/

}
