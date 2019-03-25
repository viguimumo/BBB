using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01 : MonoBehaviour {

	private BombManager bomb;

	public AudioClip cuack;

	public GameObject box01;
	public GameObject box02;
	public GameObject box03;
	public GameObject box04;
	public GameObject box05;
	public GameObject box06;

	public GameObject new_box01;
	public GameObject new_box02;
	public GameObject new_box03;
	public GameObject new_box04;
	public GameObject new_box05;
	public GameObject new_box06;

	public List<Screw> box_1_Screws;
	public List<Screw> box_2_Screws;
	public List<Screw> box_3_Screws;
	public List<Screw> box_4_Screws;
	public List<Screw> box_5_Screws;
	public List<Screw> box_6_Screws;

	private bool openedBox_1;
	private bool openedBox_2;
	private bool openedBox_3;
	private bool openedBox_4;
	private bool openedBox_5;
	private bool openedBox_6;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();
		openedBox_1 = false; 
		openedBox_2 = false; 
		openedBox_3 = false; 
		openedBox_4 = false; 
		openedBox_5 = false; 
		openedBox_6 = false;
	}

	void Update(){
		IsLevelOvercomed ();
	}

	private bool IsBoxOpen(List<Screw> screws){
		bool open = true;
		for (int i = 0; i < screws.Count; i++) {
			if (screws [i].IsBlocked) {
				open = false;
				break;
			}
		}

		if (open) {
			return true;
		}
		return false;
	}

	private void IsLevelOvercomed(){

		if (IsBoxOpen (box_1_Screws) == true && !openedBox_1) {
			openedBox_1 = true;
			box01.SetActive (false);
			new_box01.SetActive (true);
			bomb.AS.PlayOneShot (cuack);
		}

		if (IsBoxOpen (box_2_Screws) == true && !openedBox_2) {
			openedBox_2 = true;	
			box02.SetActive (false);
			new_box02.SetActive (true);
			bomb.AS.PlayOneShot (cuack);
		}

		if (IsBoxOpen (box_3_Screws) == true && !openedBox_3) {
			openedBox_3 = true;
			box03.SetActive (false);
			new_box03.SetActive (true);
			bomb.AS.PlayOneShot (cuack);
		}

		if (IsBoxOpen (box_4_Screws) == true && !openedBox_4) {
			openedBox_4 = true;
			box04.SetActive (false);
			new_box04.SetActive (true);
			bomb.AS.PlayOneShot (cuack);
		}	

		if (IsBoxOpen (box_5_Screws) == true && !openedBox_5) {
			openedBox_5 = true;
			box05.SetActive (false);
			new_box05.SetActive (true);
			bomb.AS.PlayOneShot (cuack);
		}

		if (IsBoxOpen (box_6_Screws) == true && !openedBox_6) {
			openedBox_6 = true;
			box06.SetActive (false);
			new_box06.SetActive (true);
			bomb.AS.PlayOneShot (cuack);
		}

		bool click = Input.GetMouseButtonDown (0);
		if (bomb.CursorName.Equals ("Hammer") && click) {
			bomb.EndOfLevel (true, 1);
		}
	}

	private bool AllOpened(){
		if (openedBox_1) {
			if (openedBox_2) {
				if (openedBox_3) {
					if (openedBox_4) {
						if (openedBox_5) {
							if (openedBox_6) {
								return true;
							}
						}
					}
				}
			}
		}

		return false;
	}
}
