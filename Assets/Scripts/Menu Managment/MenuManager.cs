using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	private GameManager gameManager;

	public GameObject MainCanvas, ASelectionCanvas, LSelectionCanvas;

	public Text pageLabel;
	public GameObject lvlGridPanel;
	public Button nextPage, previousPage;

	Sprite avatar;
	LevelManager levels;
	List<GameObject> buttons;
	int currentPage;
	int totalPages;
	int numButtonsInPage;
	Button currentButton;
	Button lastButton;

	public bool ChargeLvlMenu = false;

	void Start(){
		totalPages = 3;
		numButtonsInPage = 6;
		gameManager = GameObject.Find ("Game Manager").GetComponent<GameManager> ();

		if (ChargeLvlMenu) {
			ChargeLevelMenu ();
		} else {
			BuildLevelScene ();
		}
	}

	//---MAIN MENU--------------------------------------------------------
	public void StartGame(){
		MainCanvas.SetActive (false);
		ASelectionCanvas.SetActive (true);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	//---AVATAR SELECTION MENU--------------------------------------------
	public void NextStep(){
		if (gameManager.Avatar.AvatarName != "") {
			ASelectionCanvas.SetActive (false);
			LSelectionCanvas.SetActive (true);

			BuildLevelScene ();
		}
	}

	public void ChooseAvatar(Button b){
		lastButton = b;
		gameManager.Avatar.AvatarName = b.name;
	}

	//---LEVEL SELECTION MENU---------------------------------------------
	public void PlayLevel(){
		if (currentButton != null) {
			SceneManager.LoadScene (currentButton.GetComponentInChildren<Text> ().text);
		}
	}

	public void SelectLevel(Button b){
		if (currentButton == null) {
			b.GetComponent<Image> ().color = Color.red;
			currentButton = b;
		} else {
			lastButton = currentButton;
			lastButton.GetComponent<Image> ().color = Color.white;

			currentButton = b;
			b.GetComponent<Image> ().color = Color.red;
		}
	}

	public void NextPage(){
		if (currentPage != totalPages) {
			if (currentPage == totalPages - 1) {
				nextPage.interactable = false;
			} else if (currentPage == 1) {
				previousPage.interactable = true;
			}
			currentPage++;
		}

		ActualizePage ();
	}

	public void PreviousPage(){
		if (currentPage != 1) {
			if (currentPage == 2) {
				previousPage.interactable = false;
			} else if (currentPage == totalPages) {
				nextPage.interactable = true;
			}
			currentPage--;
		}

		ActualizePage ();
	}

	private void BuildLevelScene(){
		levels = new LevelManager ();
		buttons = new List<GameObject> ();

		for (int i = 0; i < numButtonsInPage; i++) {
			buttons.Add (lvlGridPanel.transform.GetChild (i).gameObject);
			buttons [i].GetComponent<Image> ().sprite = levels.GetLevels () [i].GetIcon ();
			buttons [i].GetComponentInChildren<Text> ().text = "Level " + levels.GetLevels () [i].GetNumber ();
		}

		currentPage = 1;
		previousPage.interactable = false;
		currentButton = lastButton = null;

		ActualizePage ();
	}

	private void ActualizePage(){
		for (int i = 0; i < numButtonsInPage; i++) {
			buttons [i].GetComponent<Button> ().interactable = true;
		}

		for (int i = 0; i < levels.GetLevels().Count; i++) {
			levels.GetLevels () [i].Aviable = true;
		}

		for (int i = 0; i < gameManager.Levels.PassedLevels.Length; i++) {
			levels.GetLevels () [i].Overcomed = true;
		}

		for (int i = gameManager.Levels.PassedLevels.Length + 1; i < levels.GetLevels ().Count; i++) {
			levels.GetLevels () [i].Aviable = false;
		}

		for (int i = numButtonsInPage * (currentPage - 1), j = 0; i < numButtonsInPage * (currentPage - 1) + numButtonsInPage; i++, j++) {
			buttons [j].GetComponent<Image> ().sprite = levels.GetLevels () [i].GetIcon ();
			buttons [j].GetComponent<Image> ().color = getButtonColor (levels.GetLevels () [i]);

			if (getButtonColor(levels.GetLevels ()[i]).Equals(Color.grey)) {
				buttons [j].GetComponent<Button> ().interactable = false;
			}

			buttons [j].GetComponentInChildren<Text> ().text = "Level " + levels.GetLevels () [i].GetNumber ();
		}

		pageLabel.text = currentPage + "/" + totalPages;
	}

	private Color getButtonColor(Level lvl){
		if (lvl.Aviable) {
			if (lvl.Overcomed) {
				return Color.yellow;
			}
			return Color.white;
		}
		return Color.grey;
	}

	private void ChargeLevelMenu(){
		MainCanvas.SetActive (false);
		ASelectionCanvas.SetActive (false);
		LSelectionCanvas.SetActive (true);

		BuildLevelScene ();
	}
}