using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level00 : MonoBehaviour {

	private BombManager bomb;

	// First Step
	private bool firstStep;
	public List<Screw> screws;
	public GameObject box01;

	//Second Step
	private bool secondStep;
	public GameObject redButtonBox;
	public SimpleButton redButton;
	public GameObject box03;

	//Third Step
	private bool thirdStep;
	private bool rightCombination;
	private List<GameObject> actualCombination;
	public GameObject colorButtonsBox;
	public List<Material> colors;
	public GameObject box06;

	//Last Step
	private bool lastStep;
	public GameObject wiresBox;
	public GameObject wire;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();
		firstStep = secondStep = thirdStep = lastStep = false;
		actualCombination = new List<GameObject> ();
	}
	
	void Update () {
		IsLevelOvercomed ();

		bool click = Input.GetMouseButtonDown (0);
		if (bomb.CursorName.Equals ("None") && click) {
			RaycastHit ray;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray)){
				if (ray.collider.GetComponent<StayPressedBtn>() != null){
					ProcessColorBtn (ray.collider.gameObject);
				}
			}
		}
	}

	private void IsLevelOvercomed(){

		if (!firstStep) {
			if (!screws [0].IsBlocked && !screws [1].IsBlocked && !screws [2].IsBlocked && !screws [3].IsBlocked) {
				firstStep = true;

				bomb.PlayCorrect ();
				box01.SetActive (false);
				redButtonBox.SetActive (true);
			}
		} else {
			if (!secondStep) {
				if (redButton.IsPressed) {
					secondStep = true;

					bomb.PlayCorrect ();
					box03.SetActive (false);
					colorButtonsBox.SetActive (true);
				}
			} else {
				if (!thirdStep) {
					if (rightCombination) {
						thirdStep = true;

						bomb.PlayCorrect ();
						box06.SetActive (false);
						wiresBox.SetActive (true);
					}
				} else {
					if (!lastStep) {
						if (wire.GetComponent<WireFather>() != null){
							if (wire.GetComponent<WireFather> ().IsCutt) {
								lastStep = true;

								bomb.PlayCorrect ();
								bomb.EndOfLevel (true, 0);
							}
						}
					}
				}
			}
		}
	}

	private void ProcessColorBtn (GameObject b)
	{

		if (actualCombination.Count > 0) {
			if (!actualCombination.Contains (b)) {
				actualCombination.Add (b);
			}
		} else {
			actualCombination.Add (b);
		}

		if (!b.GetComponent<StayPressedBtn> ().IsPressed) {
			if (b.Equals (actualCombination [actualCombination.Count - 1])) {
				actualCombination.RemoveAt (actualCombination.Count - 1);
			} else {
				foreach (GameObject g in actualCombination) {
					if (!b.Equals (g)) {
						g.GetComponent<StayPressedBtn> ().PressUp ();
					}
				}
				actualCombination = new List<GameObject> ();
			}
		} 
		else {
			if (actualCombination.Count > 0) {
				if (actualCombination [0].GetComponent<StayPressedBtn> ().IsPressed) {
					if (actualCombination.Count > 1) {
						if (actualCombination [1].GetComponent<StayPressedBtn> ().IsPressed) {

							if (EqualColors (actualCombination [0], actualCombination [1])) {


								// La primera pareja es correcta
								if (actualCombination.Count > 2) {
									if (actualCombination [2].GetComponent<StayPressedBtn> ().IsPressed) {
										if (actualCombination.Count > 3) {
											if (actualCombination [3].GetComponent<StayPressedBtn> ().IsPressed) {
												if (EqualColors (actualCombination [2], actualCombination [3])) {

													//La segunda pareja es correcta
													if (actualCombination.Count > 4) {
														if (actualCombination [4].GetComponent<StayPressedBtn> ().IsPressed) {
															if (actualCombination.Count > 5) {
																if (actualCombination [5].GetComponent<StayPressedBtn> ().IsPressed && actualCombination.Count == 6) {
																	if (EqualColors (actualCombination [4], actualCombination [5])) {

																		//La tercera pareja es correcta
																		rightCombination = true;
																	} else {
																		bomb.PlayWrong ();

																		//La primera pareja no es correcta
																		foreach (GameObject g in actualCombination) {
																			g.GetComponent<StayPressedBtn> ().PressUp ();
																		}
																		actualCombination = new List<GameObject> ();
																	}
																}
															}
														} 
													}
												} else {
													bomb.PlayWrong ();

													//La primera pareja no es correcta
													foreach (GameObject g in actualCombination) {
														g.GetComponent<StayPressedBtn> ().PressUp ();
													}
													actualCombination = new List<GameObject> ();
												}
											} 
										} 
									}
								}
							} else {
								bomb.PlayWrong ();

								//La primera pareja no es correcta
								foreach (GameObject g in actualCombination) {
									g.GetComponent<StayPressedBtn> ().PressUp ();
								}
								actualCombination = new List<GameObject> ();
							}
						}
					}
				}
			}
		}
	}

	private bool EqualColors(GameObject a, GameObject b){

		// Si el color de a es verde
		if (a.GetComponent<Renderer>().material.color == colors[0].color){
			// Si el color de b es violeta
			if (b.GetComponent<Renderer>().material.color == colors [5].color)
				return true;
			return false;
		}

		// Si el color de a es veioleta
		if (a.GetComponent<Renderer>().material.color == colors[5].color){
			// Si el color de b es verde
			if (b.GetComponent<Renderer>().material.color == colors [0].color)
				return true;
			return false;
		}

		// Si el color de a es amarillo
		if (a.GetComponent<Renderer>().material.color == colors[1].color){
			// Si el color de b es azul
			if (b.GetComponent<Renderer>().material.color == colors [4].color)
				return true;
			return false;
		}

		// Si el color de a es azul
		if (a.GetComponent<Renderer>().material.color == colors[4].color){
			// Si el color de b es amarillo
			if (b.GetComponent<Renderer>().material.color == colors [1].color)
				return true;
			return false;
		}

		// Si el color de a es rojo
		if (a.GetComponent<Renderer>().material.color == colors[2].color){
			// Si el color de b es rosa
			if (b.GetComponent<Renderer>().material.color == colors [3].color)
				return true;
			return false;
		}

		// Si el color de a es rosa
		if (a.GetComponent<Renderer>().material.color == colors[3].color){
			// Si el color de b es rojo
			if (b.GetComponent<Renderer>().material.color == colors [2].color)
				return true;
			return false;
		}

		return false;
	}
		


}
