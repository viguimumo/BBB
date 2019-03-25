using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButton : MonoBehaviour {

	private BombManager bomb;

	private bool isPressed = false;
	private float timePressed = 0.1f;
	public float pressedDistance;

	private BoxCollider colliderSimpleBtn;
	private Rigidbody rigidbodySimpleBtn;

	public AudioClip myClip;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();

		colliderSimpleBtn = gameObject.AddComponent<BoxCollider> ();
		rigidbodySimpleBtn = gameObject.AddComponent<Rigidbody> ();

		rigidbodySimpleBtn.useGravity = false;
	}

	void Update () {

	}

	void OnMouseDown(){
		if (bomb.CursorName.Equals ("None")) {
			bomb.AS.PlayOneShot (myClip);
			Vector3 newPosition = new Vector3 (transform.position.x, transform.position.y - pressedDistance, transform.position.z);
			rigidbodySimpleBtn.MovePosition (newPosition);
			StartCoroutine (BackToPlace(timePressed));
			isPressed = true;
		}
	}

	void OnMouseExit(){
		isPressed = false;
	}

	public bool IsPressed{
		set{ isPressed = value; }
		get{ return isPressed; }
	}

	IEnumerator BackToPlace(float s){
		yield return new WaitForSecondsRealtime (s);
		Vector3 newPosition = new Vector3 (transform.position.x, transform.position.y + pressedDistance, transform.position.z);
		rigidbodySimpleBtn.MovePosition (newPosition);
	}
}
