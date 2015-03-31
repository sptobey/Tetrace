using UnityEngine;
using System.Collections;

public class preventOverlap : MonoBehaviour {

	private Vector3 bankPostion;
	private Quaternion bankRotation;
	private int selfLayer;
	private int bufferLayer;
	private string selfLayerName = "TetrisPiece";
	private string bufferLayerName = "BufferPiece";

	private bool isSelected;

	public void setSelected(bool isSelected) {
		this.isSelected = isSelected;

		// Set children if any
		if(transform.parent == null) {
			foreach(Transform child in transform) {
				preventOverlap childOverlapScript = child.gameObject.GetComponent<preventOverlap>();
				childOverlapScript.setSelected(isSelected);
			}
		}
	}

	public bool getSelected() { 
		return isSelected;
	}

	void Start () {
		bankPostion = transform.position;
		bankRotation = transform.rotation;
		selfLayer = LayerMask.NameToLayer(selfLayerName);
		bufferLayer = LayerMask.NameToLayer(bufferLayerName);
		isSelected = false;
	}

	void OnCollisionEnter(Collision collision) {

		/*
		Debug.Log("Selected: " + isSelected + 
		          ".  Layer: " + collision.transform.gameObject.layer + 
		          ".  Buffer: " + bufferLayer +
		          ".  Self: " + selfLayer);
		*/
			
		// isSelected is set from pieceMove.cs via mouse-clicks in currentPiece.cs
		if((collision.transform.gameObject.layer == selfLayer && isSelected) ||
		   (collision.transform.gameObject.layer == bufferLayer && isSelected)) {
			if(transform.parent != null) {
				preventOverlap parentOverlapScript = transform.parent.gameObject.GetComponent<preventOverlap>();
				parentOverlapScript.revertPosition();
			} else {
				revertPosition();
			}
		}
	}

	void revertPosition() {
		transform.position = bankPostion;
		transform.rotation = bankRotation;
	}
}
