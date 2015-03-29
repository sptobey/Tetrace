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

	/*
	void Update () {
		if(Physics.CheckSphere(transform.position, sphereRadius, layerMask)) {
			setIsOccupied(true);
		} else {
			setIsOccupied(false);
		}
		notifyGrid();
	}
	*/

	public bool getIsOccupied() {
		return isOccupied;
	}
	public void setIsOccupied(bool isOccupied) {
		this.isOccupied = isOccupied;
	}

	public void notifyGrid() {
		gameGrid.setGridPiece(transform, isOccupied);
	}
	
	void OnCollisionEnter(Collision collision) {
		Debug.Log("Grid piece at (" + 
		          transform.position.x + ", " + transform.position.y 
		          + ") Collided with " +
		          collision.transform.name);
		setIsOccupied(true);
		notifyGrid();
	}

	void OnCollsionExit(Collision collision) {
		Debug.Log("Grid piece at (" + 
		          transform.position.x + ", " + transform.position.y 
		          + ") Stopped Colliding with " +
		          collision.transform.name);
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
