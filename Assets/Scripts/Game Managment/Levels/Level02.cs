using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level02 : MonoBehaviour {

	private BombManager bomb;

	// First Step
	private bool firstStep;
	public GameObject winkFace;
	public GameObject riddleCanvas;
	public Button exitRiddleBtn;
	public InputField answer;
	public GameObject screwObject;

	// Second Step
	private bool secondStep;
	public GameObject box02;
	public List<Screw> screws;

	// Third Step
	private bool thirdStep;
	public GameObject openedBox02;
	public Puzzle puzzle;
	public GameObject puzzleCanvas;
	public GameObject box05;

	// Fourth Step
	private bool fourthStep;
	public GameObject openedBox05;
	public List<GameObject> wrongButtons;
	public GameObject rightButton;
	public GameObject paperCode;

	// Fifth Step
	private bool fifthStep;
	public GameObject openedBox03;
	private List<GameObject> musicBtns;
	public GameObject box06;

	//Sixth Step
	private bool sixthStep;
	public GameObject openedBox06;
	public List<GameObject> NumberButtons;
	public List<GameObject> spheres;
	private List<GameObject> numberBtns;
	private string[] combination = new string[] {"3", "6", "2", "7"};

	// Seventh Step
	private bool seventhStep;
	public GameObject box01;
	public GameObject firstBtn_Box01;
	public GameObject secondBtn_Box02;
	public GameObject openedBox01;

	// Last Step
	private bool lastStep;
	public GameObject correctWire;
	public List<GameObject> wrongWire;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();
		musicBtns = new List<GameObject> ();
		numberBtns = new List<GameObject> ();

		firstStep = secondStep = thirdStep = fourthStep = fifthStep = sixthStep = seventhStep = false;
	}
	
	void Update () {
		IsLvlOvercomed ();
	}

	private void IsClicked(string name, GameObject canvas){
		RaycastHit ray;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray)){
			if (ray.collider.transform.parent.name.Equals(name)){
				canvas.SetActive(true);
			}
		}		
	}

	public void ProcessMusicButtons(string name){
		RaycastHit ray;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray)){
			if (ray.collider.transform.parent.name.Equals(name)){
				if (ray.collider.tag.Equals("Music Button")) {

					musicBtns.Add (ray.collider.gameObject);
					if (musicBtns.Count == 5) {

						if (musicBtns [0].name.Equals ("Btn 01") &&
						    musicBtns [1].name.Equals ("Btn 04") &&
						    musicBtns [2].name.Equals ("Btn 02") &&
						    musicBtns [3].name.Equals ("Btn 03") &&
							musicBtns [4].name.Equals ("Btn 02")) {

							fifthStep = true;
						} else {
							musicBtns = new List<GameObject> ();
						}
					}
				}
			}
		}		
	}

	public void ProcessNumberButtons(string name){
		RaycastHit ray;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out ray)) {
			if (ray.collider.transform.parent.name.Equals (name)) {
				if (ray.collider.tag.Equals ("Number Button")) {

					numberBtns.Add (ray.collider.gameObject);

					if (numberBtns.Count > 0) {
						if (numberBtns [0].name.Equals (combination [0])) {
							spheres [0].GetComponent<Renderer> ().material.color = Color.green;

							if (numberBtns.Count > 1) {
								if (numberBtns [1].name.Equals (combination [1])) {
									spheres [1].GetComponent<Renderer> ().material.color = Color.green;

									if (numberBtns.Count > 2) {
										if (numberBtns [2].name.Equals (combination [2])) {
											spheres [2].GetComponent<Renderer> ().material.color = Color.green;

											if (numberBtns.Count > 3) {
												if (numberBtns [3].name.Equals (combination [3])) {
													spheres [3].GetComponent<Renderer> ().material.color = Color.green;
													sixthStep = true;
												}
												else {
													spheres [0].GetComponent<Renderer> ().material.color = Color.red;
													spheres [1].GetComponent<Renderer> ().material.color = Color.red;
													spheres [2].GetComponent<Renderer> ().material.color = Color.red;
													spheres [3].GetComponent<Renderer> ().material.color = Color.red;
													numberBtns = new List<GameObject> ();
												}
											}
										} else {
											spheres [0].GetComponent<Renderer> ().material.color = Color.red;
											spheres [1].GetComponent<Renderer> ().material.color = Color.red;
											spheres [2].GetComponent<Renderer> ().material.color = Color.red;
											numberBtns = new List<GameObject> ();
										}
									}
								} else {
									spheres [0].GetComponent<Renderer> ().material.color = Color.red;
									spheres [1].GetComponent<Renderer> ().material.color = Color.red;
									numberBtns = new List<GameObject> ();
								}
							}
						} else {
							spheres [0].GetComponent<Renderer> ().material.color = Color.red;
							numberBtns = new List<GameObject> ();
						}
					}
				}
			}
		}
	}

	private void IsLvlOvercomed(){
		if (!firstStep) {
			bool click = Input.GetMouseButtonDown (0);
			if (bomb.CursorName.Equals ("None") && click) {
				IsClicked ("Opened Box 04", riddleCanvas);	
			}
		} 

		if (!secondStep) {
			if (!screws [0].IsBlocked && !screws [1].IsBlocked && !screws [2].IsBlocked && !screws [3].IsBlocked) {		
				secondStep = true;

				box02.SetActive (false);
				openedBox02.SetActive (true);
			}
		}

		if (!thirdStep) {
			bool click = Input.GetMouseButtonDown (0);
			if (bomb.CursorName.Equals ("None") && click && !puzzleCanvas.activeSelf) {
				IsClicked ("Opened Box 02", puzzleCanvas);	
			}

			if (puzzle.Finished) {
				thirdStep = true;

				box05.SetActive (false);
				puzzleCanvas.SetActive (false);
				openedBox05.SetActive (true);
				//Imagen puzzle bien hecho.
			}
		}

		if (!fourthStep) {
			bool click = Input.GetMouseButtonDown (0);
			if (bomb.CursorName.Equals ("None") && click) {
				RaycastHit ray;
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out ray)) {
					if (ray.collider.transform.parent.name.Equals ("Opened Box 05")) {
						if (wrongButtons.Contains (ray.collider.gameObject)) {
							//la bomba explota
						} else {
							if (rightButton.Equals (ray.collider.gameObject)) {
								fourthStep = true;

								firstBtn_Box01.GetComponent<Renderer> ().material.color = Color.green;
								paperCode.transform.localPosition += Vector3.left * 7;
							}
						}
					}
				}
			}
		}
		
		if (!fifthStep) {
			bool click = Input.GetMouseButtonDown (0);
			if (bomb.CursorName.Equals ("None") && click) {
				ProcessMusicButtons ("Opened Box 03");
			}

			if (fifthStep) {
				box06.SetActive (false);
				openedBox06.SetActive (true);
			}
		}

		if (!sixthStep) {
			bool click = Input.GetMouseButtonDown (0);
			if (bomb.CursorName.Equals ("None") && click) {
				ProcessNumberButtons ("Opened Box 06");
			}

			if (sixthStep) {
				secondBtn_Box02.GetComponent<Renderer> ().material.color = Color.green;
			}
		}

		if (firstBtn_Box01.GetComponent<Renderer> ().material.color == Color.green &&
		    secondBtn_Box02.GetComponent<Renderer> ().material.color == Color.green) {
			box01.SetActive (false);
			openedBox01.SetActive (true);
			seventhStep = true;
		}

		if (seventhStep) {
			foreach (GameObject wire in wrongWire) {
				if (wire.GetComponent<WireFather> ().IsCutt) {
					bomb.EndOfLevel (false, -1);
					break;
				}
			}

			if (correctWire.GetComponent<WireFather> ().IsCutt) {
				bomb.EndOfLevel (true, 2);
			}
		}
	}

	public void ExitRiddleCanvas(){
		riddleCanvas.SetActive (false);
	}

	public void OnEndEdit(InputField a){
		if (a.text == "piojo") {
			firstStep = true;
			screwObject.SetActive (true);
			ExitRiddleCanvas ();
		}
	}
}
