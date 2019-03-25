using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03 : MonoBehaviour {

	private BombManager bomb;

	public GameObject dragon_01;
	public GameObject dragon_02;
	public GameObject dragon_03;
	public GameObject dragon_04;
	public GameObject dragon_05;
	public GameObject dragon_06;

	public GameObject selected;

	// Puzzle 01
	private bool isPuzzleOpen_01;
	public GameObject openedBox01;
	public Puzzle puzzle01;
	public GameObject puzzleCanvas01;

	// Puzzle 02
	private bool isPuzzleOpen_02;
	public GameObject openedBox02;
	public Puzzle puzzle02;
	public GameObject puzzleCanvas02;

	// Puzzle 03
	private bool isPuzzleOpen_03;
	public GameObject openedBox03;
	public Puzzle puzzle03;
	public GameObject puzzleCanvas03;

	// Puzzle 04
	private bool isPuzzleOpen_04;
	public GameObject openedBox04;
	public Puzzle puzzle04;
	public GameObject puzzleCanvas04;

	// Puzzle 05
	private bool isPuzzleOpen_05;
	public GameObject openedBox05;
	public Puzzle puzzle05;
	public GameObject puzzleCanvas05;

	// Puzzle 06
	private bool isPuzzleOpen_06;
	public GameObject openedBox06;
	public Puzzle puzzle06;
	public GameObject puzzleCanvas06;

	public List<GameObject> canvas;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();

		selected = null;

		isPuzzleOpen_01 = isPuzzleOpen_02 = isPuzzleOpen_03 = isPuzzleOpen_04 = isPuzzleOpen_05 = isPuzzleOpen_06 = false;

		canvas = new List<GameObject> ();
		canvas.Add (puzzleCanvas01);
		canvas.Add (puzzleCanvas02);
		canvas.Add (puzzleCanvas03);
		canvas.Add (puzzleCanvas04);
		canvas.Add (puzzleCanvas05);
		canvas.Add (puzzleCanvas06);
	}

	void Update () {
		IsLvlOvercomed ();
	}

	private bool CanvasAlreadyOpen(GameObject c){
		foreach (GameObject can in canvas) {
			if (can.activeSelf && !can.Equals (c)) {
				return true;
			}
		}
		return false;
	}

	private void IsLvlOvercomed(){

			if (!isPuzzleOpen_01) {
				bool click = Input.GetMouseButtonDown (0);
				if (bomb.CursorName.Equals ("None") && click && !puzzleCanvas01.activeSelf && !CanvasAlreadyOpen (puzzleCanvas01)) {
					IsClicked ("Opened Box 01", puzzleCanvas01);	
				}

				if (puzzle01.Finished) {
					isPuzzleOpen_01 = true;

					puzzleCanvas01.SetActive (false);

					openedBox01.transform.GetChild (0).gameObject.SetActive (false);
					openedBox01.transform.GetChild (1).gameObject.SetActive (true);

					// cambio de pieza
					//Imagen puzzle bien hecho.
				}
			}

			if (!isPuzzleOpen_02) {
				bool click = Input.GetMouseButtonDown (0);
				if (bomb.CursorName.Equals ("None") && click && !puzzleCanvas02.activeSelf && !CanvasAlreadyOpen (puzzleCanvas02)) {
					IsClicked ("Opened Box 02", puzzleCanvas02);	
				}

				if (puzzle02.Finished) {
					isPuzzleOpen_02 = true;

					puzzleCanvas02.SetActive (false);

					openedBox02.transform.GetChild (0).gameObject.SetActive (false);
					openedBox02.transform.GetChild (1).gameObject.SetActive (true);
					// cambio de pieza
					//Imagen puzzle bien hecho.
				}
			}

			if (!isPuzzleOpen_03) {
				bool click = Input.GetMouseButtonDown (0);
				if (bomb.CursorName.Equals ("None") && click && !puzzleCanvas03.activeSelf && !CanvasAlreadyOpen (puzzleCanvas03)) {
					IsClicked ("Opened Box 03", puzzleCanvas03);	
				}

				if (puzzle03.Finished) {
					isPuzzleOpen_03 = true;

					puzzleCanvas03.SetActive (false);

					openedBox03.transform.GetChild (0).gameObject.SetActive (false);
					openedBox03.transform.GetChild (1).gameObject.SetActive (true);
					// cambio de pieza
					//Imagen puzzle bien hecho.
				}
			}

			if (!isPuzzleOpen_04) {
				bool click = Input.GetMouseButtonDown (0);
				if (bomb.CursorName.Equals ("None") && click && !puzzleCanvas04.activeSelf && !CanvasAlreadyOpen (puzzleCanvas04)) {
					IsClicked ("Opened Box 04", puzzleCanvas04);	
				}

				if (puzzle04.Finished) {
					isPuzzleOpen_04 = true;

					puzzleCanvas04.SetActive (false);

					openedBox04.transform.GetChild (0).gameObject.SetActive (false);
					openedBox04.transform.GetChild (1).gameObject.SetActive (true);
					// cambio de pieza
					//Imagen puzzle bien hecho.
				}
			}

			if (!isPuzzleOpen_05) {
				bool click = Input.GetMouseButtonDown (0);
				if (bomb.CursorName.Equals ("None") && click && !puzzleCanvas05.activeSelf && !CanvasAlreadyOpen (puzzleCanvas05)) {
					IsClicked ("Opened Box 05", puzzleCanvas05);	
				}

				if (puzzle05.Finished) {
					isPuzzleOpen_05 = true;

					puzzleCanvas05.SetActive (false);

					openedBox05.transform.GetChild (0).gameObject.SetActive (false);
					openedBox05.transform.GetChild (1).gameObject.SetActive (true);
					// cambio de pieza
					//Imagen puzzle bien hecho.
				}
			}

			if (!isPuzzleOpen_06) {
				bool click = Input.GetMouseButtonDown (0);
				if (bomb.CursorName.Equals ("None") && click && !puzzleCanvas06.activeSelf && !CanvasAlreadyOpen (puzzleCanvas06)) {
					IsClicked ("Opened Box 06", puzzleCanvas06);	
				}

				if (puzzle06.Finished) {
					isPuzzleOpen_06 = true;

					puzzleCanvas06.SetActive (false);

					openedBox06.transform.GetChild (0).gameObject.SetActive (false);
					openedBox06.transform.GetChild (1).gameObject.SetActive (true);
					// cambio de pieza
					//Imagen puzzle bien hecho.
				}
			}
	
		if (isPuzzleOpen_01 == true && isPuzzleOpen_02 == true && isPuzzleOpen_03 == true && isPuzzleOpen_04 == true
			&& isPuzzleOpen_05 == true && isPuzzleOpen_06 == true){
			bool newClick = Input.GetMouseButtonDown (0);
			if (bomb.CursorName.Equals ("None") && newClick) {
				RaycastHit ray;
				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray)){
					if (ray.collider.tag.Equals("Dragon Piece")){

						if (selected == null) {
							selected = ray.collider.gameObject;
						} else {

							Material aux = selected.GetComponent<Renderer> ().material;
							selected.GetComponent<Renderer> ().material = ray.collider.GetComponent<Renderer> ().material;
							ray.collider.GetComponent<Renderer> ().material = aux;

							selected = null;

							if (Check ()) {
								bomb.EndOfLevel (true, 3);
							}
						}
					}
				}	
			}	
		}
	}

	private bool Check(){
		if (dragon_01.GetComponent<Renderer> ().material.name.Contains ("Dragon01")) {
			if (dragon_02.GetComponent<Renderer> ().material.name.Contains ("Dragon02")){
				if (dragon_03.GetComponent<Renderer> ().material.name.Contains ("Dragon03")){
					if (dragon_04.GetComponent<Renderer> ().material.name.Contains ("Dragon04")){
						if (dragon_05.GetComponent<Renderer> ().material.name.Contains ("Dragon05")){
							if (dragon_06.GetComponent<Renderer> ().material.name.Contains ("Dragon06")){
								return true;
							}
						}
					}
				}
			}
		}
		return false;
	}

	private void IsClicked(string name, GameObject canvas){
		RaycastHit ray;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray)){
			if (ray.collider.transform.parent.name.Equals(name)){
				canvas.SetActive(true);
			}
		}		
	}

}
