using AssemblyCSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	// Data
	private KAvatar avatar;
	private KLevel levels;

	void Awake(){

		if (gameManager == null) {
			gameManager = this;
			DontDestroyOnLoad (transform.gameObject);

			avatar = new KAvatar ();
			levels = new KLevel ();

			Reinitialize ();

		} else if (gameManager != this){
			Destroy (gameObject);
			if (SceneManager.GetActiveScene ().name.Equals ("Menu")) {
				GameObject.Find ("Menu Manager").GetComponent<MenuManager> ().ChargeLvlMenu = true;
			}
		}
	}

	public KAvatar Avatar{
		set{ }
		get{ return avatar; }
	}

	public KLevel Levels{
		set{ }
		get{ return levels; }
	}

	private void Reinitialize(){
		avatar.AvatarName = "";
		levels.PassedLevels = new int[0];
	}

	public void Return2LvlMenu(){
		SceneManager.LoadScene ("Menu");
	}
}