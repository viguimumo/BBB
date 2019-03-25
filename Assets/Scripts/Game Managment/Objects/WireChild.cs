using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireChild : MonoBehaviour {

	WireFather wireFather;

	private BoxCollider colliderWire;

	private GameObject normalWire;
	private GameObject cuttWire;

	void Start () {
		wireFather = transform.parent.gameObject.GetComponent<WireFather> ();

		colliderWire = gameObject.AddComponent<BoxCollider> ();
	}

	void OnMouseDown(){
		if (wireFather.bomb.CursorName.Equals ("Pliers")) {
			wireFather.CuttWire ();
		}
	}
}