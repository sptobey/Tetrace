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

	public void notifyGrid(bool occupied) {
		gameGrid.setGridPiece(transform.position, occupied);
	}
	
	void OnCollisionEnter(Collision collision) {
		/*
		Debug.Log("Grid piece at (" +
		          transform.position.x + ", " + transform.position.y +
		          ") Collided with " +
		          collision.transform.name);
		*/
		setIsOccupied(true);
		notifyGrid(true);
	}

	void OnCollisionExit(Collision collision) {
		/*
		Debug.Log("Grid piece at (" +
		          transform.position.x + ", " + transform.position.y +
		          ") Stopped colliding with " +
		          collision.transform.name);
		*/
		setIsOccupied(false);
		notifyGrid(false);
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
