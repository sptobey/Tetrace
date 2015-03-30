using UnityEngine;
using System.Collections;

public class reParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		Debug.Log ("I am alive");
		Transform Parent = transform.parent;
		if (transform.parent == null) {
						Debug.Log ("I am a dummy");
				}
		foreach (Transform child in transform.parent) {
			Debug.Log(child.name);
			if(child != transform){
				Debug.Log("good Things");
				child.parent = gameObject.transform;
			}
		}
		Parent.SetParent(gameObject.transform);

	}
}
