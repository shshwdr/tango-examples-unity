﻿using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime*0.1f;
	}
}