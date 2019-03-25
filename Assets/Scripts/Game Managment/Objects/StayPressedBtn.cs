using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayPressedBtn : MonoBehaviour {

	private BombManager bomb;

	private bool isPressed = false;
	public float pressedDistance;

	private BoxCollider colliderSimpleBtn;
	private Rigidbody rigidbodySimpleBtn;

	private Vector3 nonPressedPos;
	private Vector3 pressedPos;

	public AudioClip myClip;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();

		colliderSimpleBtn = gameObject.AddComponent<BoxCollider> ();
		rigidbodySimpleBtn = gameObject.AddComponent<Rigidbody> ();

		rigidbodySimpleBtn.useGravity = false;

		nonPressedPos = transform.position;
		pressedPos = new Vector3 (transform.position.x, transform.position.y - pressedDistance, transform.position.z);
	}

	void Update () {

	}

	void OnMouseDown(){
		if (bomb.CursorName.Equals ("None")) {

			if (!isPressed) {
				PressDown ();
			} else {
				PressUp ();
			}
		}
	}

	public bool IsPressed{
		set{ isPressed = value; }
		get{ return isPressed; }
	}

	public void PressDown(){
		bomb.AS.PlayOneShot (myClip);
		rigidbodySimpleBtn.MovePosition (pressedPos);
		isPressed = true;
	}

	public void PressUp(){
		bomb.AS.PlayOneShot (myClip);
		rigidbodySimpleBtn.MovePosition (nonPressedPos);
		isPressed = false;
	}
}
