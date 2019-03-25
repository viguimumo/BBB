using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {

	int number;
	bool overcomed;
	bool aviable;
	Sprite icon;

	public Level (int number, Sprite icon){
		this.number = number;
		this.icon = icon;
		overcomed = aviable = false;
	}

	public int GetNumber() {
		return number;
	}

	public Sprite GetIcon(){
		return icon;
	}

	public bool Overcomed{
		set{ overcomed = value; }
		get{ return overcomed; }
	}

	public bool Aviable{
		set{ aviable = value; }
		get{ return aviable; }
	}
}
