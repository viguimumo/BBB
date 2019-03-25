using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BombManager : MonoBehaviour {

	private GameManager gameManger;

	//public Interface gameInterface;

	private string cursorName;
	public Texture2D ScrewdriverImg;
	public Texture2D PliersImg;
	public Texture2D HammerImg;

	public Image avatar;
	public GameObject winCanvas, loseCanvas;

	private AudioSource audio;
	public AudioClip correctAudio;
	public AudioClip wrongAudio;

	public Text minutsLabel;
	public Text secondsLabel;
	public float minuts;
	public float seconds;
	private bool timeLeft;
	private bool startCount;

	void Awake(){
		cursorName = "None";
	}

	void Start () {
		gameManger = GameObject.Find ("Game Manager").GetComponent<GameManager> ();

		switch (gameManger.Avatar.AvatarName) {
		case "Avatar01 Button":
			avatar.sprite = Resources.Load<Sprite> ("Textures/Avatars/Avatar01");
			break;
		case "Avatar02 Button":
			avatar.sprite = Resources.Load<Sprite> ("Textures/Avatars/Avatar02");
			break;
		case "Avatar03 Button":
			avatar.sprite = Resources.Load<Sprite> ("Textures/Avatars/Avatar03");
			break;
		case "Avatar04 Button":
			avatar.sprite = Resources.Load<Sprite> ("Textures/Avatars/Avatar04");
			break;
		case "Avatar05 Button":
			avatar.sprite = Resources.Load<Sprite> ("Textures/Avatars/Avatar05");
			break;
		case "Avatar06 Button":
			avatar.sprite = Resources.Load<Sprite> ("Textures/Avatars/Avatar06");
			break;
		}
			
		audio = GetComponent<AudioSource> ();

		minutsLabel.text = minuts + ":";
		secondsLabel.text = "" + seconds;
		timeLeft = true;
		startCount = false;
		StartCoroutine (InitialDelay (7));
	}

	IEnumerator InitialDelay(float s){
		yield return new WaitForSeconds (s);
		minutsLabel.gameObject.SetActive (true);
		secondsLabel.gameObject.SetActive (true);
		startCount = true;
	}

	void Update () {

		bool mouseClick = Input.GetMouseButtonDown (1);
		if (mouseClick) {
			cursorName = "None";
			Cursor.SetCursor (null, new Vector2 (180, 200), CursorMode.Auto);
		}

		if (startCount) {
			ActualizeClock ();
		}
	}

	public string CursorName{
		set{ cursorName = value; }
		get{ return cursorName; }
	}

	public void SelectTool(Button b){
		cursorName = b.name;

		switch (cursorName) {
		case "Screwdriver":
			Cursor.SetCursor (ScrewdriverImg, new Vector2 (16, 20), CursorMode.ForceSoftware);
			break;
		case "Pliers":
			Cursor.SetCursor (PliersImg, new Vector2 (16, 20), CursorMode.ForceSoftware);
			break;
		case "Hammer":
			Cursor.SetCursor (HammerImg, new Vector2 (16, 20), CursorMode.ForceSoftware);
		break;
		}
	}

	public void EndOfLevel(bool result, int lvl){
		if (result) {

			int[] aux = gameManger.Levels.PassedLevels;

			bool alreadyPassed = false;
			for (int i = 0; i < aux.Length; i++) {
				if (aux [i] == lvl) {
					alreadyPassed = true;
					break;
				}	
			}

			if (!alreadyPassed) {
				aux = new int[gameManger.Levels.PassedLevels.Length + 1];
				for (int i = 0; i < gameManger.Levels.PassedLevels.Length; i++) {
					aux [i] = gameManger.Levels.PassedLevels [i];
				}
				aux [aux.Length - 1] = lvl;

				gameManger.Levels.PassedLevels = aux;
			}
		} 

		Cursor.SetCursor (null, new Vector2 (180, 200), CursorMode.Auto);
		StartCoroutine(FinishLevelPause (result));
	}

	public IEnumerator FinishLevelPause(bool result){
		if (result) {
			winCanvas.SetActive (true);
		} else {
			loseCanvas.SetActive (true);
		}

		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("Menu");
	}

//	public void AddTool(GameObject tool, GameObject boxTool){
//		GameObject bT = Instantiate (boxTool);
//		bT.name = tool.name;
//		gameInterface.AddTool2Box (bT);
//		bT.GetComponent<Button>().onClick.AddListener(() => SelectTool(bT.GetComponent<Button>()));
//		Destroy (tool);
//	}

	private void ActualizeClock(){
		if (seconds >= 0) {
			seconds -= Time.deltaTime;
		}

		if ((int)seconds == 0) {
			if ((int)minuts != 0) {
				minuts--;
				seconds = 59;
			} else {
				if (SceneManager.GetActiveScene ().name != "Level 0") {
					if (timeLeft) {
						timeLeft = false;
						EndOfLevel (false, -1);
					}
				}
			}

		}

		if (minuts < 10) {
			minutsLabel.text = "0" + minuts + ":";
		} else {
			minutsLabel.text = minuts + ":";
		}

		if (seconds < 10 && seconds > -1) {
			secondsLabel.text = "0" + (int)seconds;
		}

		if (seconds < 0) {
			secondsLabel.text = "00";
		}

		if (seconds >= 0) {
			secondsLabel.text = "" + (int)seconds;
		}
	}

	public AudioSource AS{
		set{ }
		get{ return audio; }
	}

	public void PlayCorrect(){
		audio.PlayOneShot (correctAudio);
	}

	public void PlayWrong(){
		audio.PlayOneShot (wrongAudio);
	}
}
