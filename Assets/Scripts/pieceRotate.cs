using UnityEngine;
using System.Collections;

public class pieceRotate : MonoBehaviour {
	public string left;
	public string right;
	//public string click;
	private bool keydown = false;
	public float totalRotation = 0;
	public float rotationAmount = 90f;
	public int temp = 0;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A) && keydown == true) {
			//transform.Rotate (0, 0, 90F*Time.fixedDeltaTime);
			StartCoroutine(Rotate(Vector3.forward*90, 1));
		}
		if (Input.GetKeyDown (KeyCode.D) && keydown == true) {
			//transform.Rotate (0, 0, -90F*Time.fixedDeltaTime);
			StartCoroutine(Rotate(Vector3.back*90, 1));
		}
	}
	 
	void OnMouseDown(){
		keydown = true;
	}

	void OnMouseUp(){
		keydown = false;
	}

	IEnumerator Rotate(Vector3 byAngles, float inTime)
	{
		var angle = transform.eulerAngles;
		Quaternion fromAngle = transform.rotation ;
		Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngles) ;
		for(float t = 0f ; t < 1f ; t += Time.deltaTime/inTime * 3)
		{
			transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t) ;
			angle = transform.eulerAngles;
			yield return null ;
		}

		//angle.x = Mathf.Round(angle.x / 90) * 90;
		//angle.y = Mathf.Round(angle.y / 90) * 90;
		angle.z = Mathf.Round(angle.z / 90) * 90;

		transform.eulerAngles = angle;

	}

}
