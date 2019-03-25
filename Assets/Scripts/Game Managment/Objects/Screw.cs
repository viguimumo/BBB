using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour {

	private BombManager bomb;

	private bool isBlocked = true;

	private BoxCollider colliderScrew;
	private Rigidbody rigidbodyScrew;

	public AudioClip myClip;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();

		colliderScrew = gameObject.AddComponent<BoxCollider> ();
		rigidbodyScrew = gameObject.AddComponent<Rigidbody> ();

		rigidbodyScrew.useGravity = false;
	}
	
	void Update () {
		
	}

	void OnMouseDown(){
		if (bomb.CursorName.Equals ("Screwdriver")) {
			bomb.AS.PlayOneShot (myClip);
			rigidbodyScrew.useGravity = true;
			rigidbodyScrew.AddForce (Vector3.up * 10f, ForceMode.Impulse);
			isBlocked = false;
		}
	}

	public bool IsBlocked{
		set{ isBlocked = value; }
		get{ return isBlocked; }
	}
}
