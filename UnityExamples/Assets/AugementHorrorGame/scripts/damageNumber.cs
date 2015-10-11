using UnityEngine;
using System.Collections;

public class damageNumber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2);
		iTween.FadeTo(gameObject,0, 2);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (0, 0.1f, 0);
	}
}
