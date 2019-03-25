using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour {

	private int currentPage;
	private int totalPages;
	public Button nextPage, previousPage;
	List<GameObject> pgs;

	void Start () {
		currentPage = 1;
		totalPages = 0;
		pgs = new List<GameObject> ();

		Text[] pages = transform.GetComponentsInChildren<Text> ();
		for (int i = 0; i < pages.Length; i++){
			if (pages [i].gameObject.tag.Equals ("Page")) {
				pgs.Add (pages [i].gameObject);
				totalPages++;
			}
		}

		for (int i = 1; i < pgs.Count; i++){
			pgs [i].SetActive (false);
		}
	}
	
	void Update () {
	}

	public void NextPage(){
		if (currentPage != totalPages) {
			if (currentPage == totalPages - 1) {
				nextPage.interactable = false;
			} else if (currentPage == 1) {
				previousPage.interactable = true;
			}
			pgs [currentPage - 1].SetActive (false);
			currentPage++;
			pgs [currentPage - 1].SetActive (true);
		}
	}

	public void PreviousPage(){
		if (currentPage != 1) {
			if (currentPage == 2) {
				previousPage.interactable = false;
			} else if (currentPage == totalPages) {
				nextPage.interactable = true;
			}
			pgs [currentPage - 1].SetActive (false);
			currentPage--;
			pgs [currentPage - 1].SetActive (true);
		}

	}
}
