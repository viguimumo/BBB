using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireFather : MonoBehaviour {

	public BombManager bomb;
	private WireChild wire;

	private GameObject normalWire;
	private GameObject cuttWire;

	private bool isCutt = false;

	public AudioClip myClip;

	void Start () {
		bomb = GameObject.Find ("Bomb").GetComponent<BombManager> ();

		normalWire = transform.GetChild (0).gameObject;
		cuttWire = transform.GetChild (1).gameObject;

		wire = transform.GetChild (0).gameObject.AddComponent<WireChild> ();
	}

	public void CuttWire(){
		bomb.AS.PlayOneShot (myClip);

		isCutt = true;

		normalWire.SetActive (false);
		cuttWire.SetActive (true);
	}
		
	public bool IsCutt{
		set{ isCutt = value; }
		get{ return isCutt; }
	}
}