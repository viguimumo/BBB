using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour {

	BombManager bomb;

	public GameObject toolBox;

	private bool toolBoxOpened;
	private bool helpPanelOpened;

	public float dist;
	public GameObject Help;
	public GameObject Instructions;
	public GameObject Quit;

	public Button toolsBtn;
	public Button helpBtn;
	public Button quitBtn;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();
		toolBoxOpened = helpPanelOpened = false;
	}
	
	void Update () {

		if (Input.mousePosition.x < transform.position.x - dist && toolBoxOpened) {
			CloseToolBox ();
		}
	}

//	public void AddTool2Box(GameObject tool){
//		tool.transform.SetParent (toolBox.transform);
//	}

	public void ToolBox(){
		if (toolBoxOpened) {
			CloseToolBox ();
		} else {
			if (!helpPanelOpened) {
				OpenToolBox ();
			}
		}
	}

	private void OpenToolBox(){
		transform.localPosition += Vector3.left * dist;
		toolBoxOpened = true;
	}

	private void CloseToolBox(){
		transform.localPosition += Vector3.right * dist;
		toolBoxOpened = false;
	}

	public void HelpPanel(){
		if (helpPanelOpened) {
			CloseHelpPanel ();
		} else {
			if (!toolBoxOpened) {
				OpenHelpPanel ();
			}

		}
	}

	private void OpenHelpPanel(){
		bomb.minutsLabel.gameObject.SetActive (false);
		bomb.secondsLabel.gameObject.SetActive (false);

		Help.SetActive (true);
		Instructions.SetActive (true);
		helpPanelOpened = true;
	}

	private void CloseHelpPanel(){
		bomb.minutsLabel.gameObject.SetActive (true);
		bomb.secondsLabel.gameObject.SetActive (true);

		Help.SetActive (false);
		Instructions.SetActive (false);
		helpPanelOpened = false;
	}

	public void OpenQuitOptions(){
		Quit.SetActive (true);
	}

	public void ExitQuitOptions(){
		Quit.SetActive (false);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void Return2LvlMenu(){
		SceneManager.LoadScene ("Menu");
	}

}
