using UnityEngine;
using System.Collections;

public class gridPiece : MonoBehaviour {

	private bool isOccupied;
	public float sphereRadius = 0.25f;
	// The gameGrid script chould be on the parent object.
	private gameGrid theGameBoard;

	void Start () {
		theGameBoard = GetComponentInParent<gameGrid>();
		isOccupied = false;
	}

	public bool getIsOccupied() {
		return isOccupied;
	}
	public void setIsOccupied(bool isOccupied) {
		this.isOccupied = isOccupied;
	}

	public void notifyGrid(bool occupied) {
		theGameBoard.setGridPiece(transform.position, occupied);
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
