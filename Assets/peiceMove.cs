using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(MeshCollider))]

public class peiceMove : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private bool keydown = false;
	public float smooth = 2.0F;
	public float tiltAngle = 60.0F;

	void Update() {
		float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
		Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
	}
	
	void OnMouseDown()
	{
		keydown = true;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		if (Input.GetKeyDown(KeyCode.A)){
			float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
			Quaternion target = Quaternion.Euler(tiltAroundZ, 0, 0);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		}

	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		transform.position = curPosition;
		
	}

	void OnMouseUp()
	{
		keydown = false;
		Vector3 temp;
		temp = new Vector3(Mathf.Round(transform.position.x),Mathf.Round(transform.position.y),transform.position.z);
		transform.position = temp;
	}
	
}