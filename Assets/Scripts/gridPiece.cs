using UnityEngine;
using System.Collections;

public class gridPiece : MonoBehaviour {

	private bool isOccupied;

	void Start () {
		isOccupied = false;
	}
	
	void Update () {
	
	}

	public bool getIsOccupied() {
		return isOccupied;
	}
	public void setIsOccupied(bool isOccupied) {
		this.isOccupied = isOccupied;
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("Grid piece at (" + 
		          transform.position.x + ", " + transform.position.y 
		          + ") Collided with " +
		          collision.transform.name);
		setIsOccupied(true);
	}

	void OnCollsionExit(Collision collision) {
		Debug.Log("Grid piece at (" + 
		          transform.position.x + ", " + transform.position.y 
		          + ") Stopped Colliding with " +
		          collision.transform.name);
		setIsOccupied(false);
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
