using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour {

	private List<Button> buttons;
	private Button currentPressed;
	private bool finished;

	void Start () {
		finished = false;

		buttons = new List<Button> ();
		Button[] buttonArray = transform.GetComponentsInChildren<Button> ();
		foreach (Button b in buttonArray) {
			buttons.Add (b);
		}

		currentPressed = null;
	}

	public void ChangePiece(Button b){
		if (currentPressed == null) {
			currentPressed = b;
		} else {
			Sprite aux = currentPressed.gameObject.GetComponent<Image>().sprite;
			currentPressed.gameObject.GetComponent<Image>().sprite = b.gameObject.GetComponent<Image>().sprite;
			b.image.sprite = aux;

			currentPressed = null;

			finished = CheckPuzzle ();
		}
	}

	private bool CheckPuzzle(){
		bool solved = true;
		for (int i = 0; i < buttons.Count; i++) {
			if (!buttons [i].name.Equals (buttons [i].gameObject.GetComponent<Image>().sprite.name)) {
				solved = false;
			}
		}

		return solved;
	}

	public bool Finished{
		set{ }
		get{ return finished; }
	}
}
