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
		if (transform.parent == null) {
			foreach (Transform child in transform) {
				preventOverlap childOverlapScript = child.gameObject.GetComponent<preventOverlap> ();
				if(childOverlapScript.getSelected() != isSelected)
					childOverlapScript.setSelected (isSelected);
			}
		} else {
			preventOverlap parentOverlapScript = transform.parent.GetComponent<preventOverlap> ();
			parentOverlapScript.setSelected (isSelected);
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
		if((collision.gameObject.layer == selfLayer || collision.gameObject.layer == bufferLayer) && isSelected){
			Debug.Log("overlap detected");
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
