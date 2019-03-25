using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFall : MonoBehaviour {

	public Animator bombAnimator;
	public GameObject animationObjects;
	public GameObject levelScene;
	public GameObject PSFog;
	public GameObject levelCanvas;

	public AudioClip blow;
	public float InitialDelay;
	private float timer;
	private bool hasBeenPlayed;

	void Start(){
		timer = 0f;
		hasBeenPlayed = false;
	}

	void Update () {

		timer += Time.deltaTime;

		if (timer >= InitialDelay && !hasBeenPlayed) {
			GetComponent<AudioSource> ().PlayOneShot (blow);
			hasBeenPlayed = true;
		}

		if (bombAnimator.GetCurrentAnimatorStateInfo(0).IsName("Exit")) {
			StartCoroutine (LittlePause(3.5f));
			animationObjects.SetActive (false);
			levelScene.SetActive (true);
		}
	}

	IEnumerator LittlePause(float s){
		yield return new WaitForSecondsRealtime(s);
		levelCanvas.SetActive (true);
	}
}
