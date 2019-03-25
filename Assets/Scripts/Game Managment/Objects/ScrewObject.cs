using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewObject : MonoBehaviour {

	private BombManager bomb;

	public GameObject screwTool;

	public float velocity;
	public float timeFloating;
	private float timer;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();

		gameObject.AddComponent<BoxCollider> ();
		timer = 0f;
	}
	
	void Update () {
		timer += Time.deltaTime;

		if (timer > timeFloating) {
			velocity = -velocity;
			timer = 0f;
		}

		transform.position += Vector3.up * (Time.deltaTime * velocity);
	}

	void OnMouseOver(){
		Debug.Log ("entro");
		if (Input.GetMouseButtonDown (0)) {
			
			screwTool.SetActive (true);
			Destroy (this.gameObject);
		}
	}
}
