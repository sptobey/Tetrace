using UnityEngine;
using System.Collections;

public class hideMesh : MonoBehaviour {

	private MeshRenderer mr;

	void Start () {
		mr = GetComponent<MeshRenderer>();
		mr.enabled = false;
	}
}
