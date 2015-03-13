using UnityEngine;
using System.Collections;

public class pieceRotate : MonoBehaviour {
	public string left;
	public string right;
	//public string click;
	private bool keydown = false;
	private float startAngle = 0.0f;
	private float tiltAngle = 90.0f;
	public float smooth = 2.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A) && keydown == true) {
			transform.Rotate (0, 0, 90f);
		}
		if (Input.GetKeyDown (KeyCode.D) && keydown == true) {
			transform.Rotate (0, 0, -90f);
		}
	}
	 
	void OnMouseDown(){
		keydown = true;
	}

	void OnMouseUp(){
		keydown = false;
	}
}
