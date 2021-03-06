﻿using UnityEngine;
using System.Collections;

public class reParent : MonoBehaviour {
	
	void OnMouseDown(){
		Transform Parent = transform.parent;
		if (Parent != null) {
			int siblings_size = Parent.childCount;
			Transform[] siblings = new Transform[siblings_size];
			int i = 0;
			foreach (Transform child in transform.parent) {
				siblings[i] = child;
				i++;
			}
			for(i = 0; i < siblings_size; i++){
				Transform child = siblings[i];
				if(child.name != transform.name){
					child.parent = gameObject.transform;
				}
			}
			transform.parent = null;
			Parent.parent = transform;
		}

	}
}
