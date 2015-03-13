using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(MeshCollider))]

public class peiceMove : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;

	public float zDragShift = -1.50F;

	void Update() {
		

	}
	
	void OnMouseDown()
	{

		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z - zDragShift));
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
		
	}

	void OnMouseUp()
	{
		Vector3 temp;
		temp = new Vector3(Mathf.Round(transform.position.x),Mathf.Round(transform.position.y),transform.position.z - zDragShift);
		transform.position = temp;
	}
	
}