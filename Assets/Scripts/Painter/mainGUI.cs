using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UpGS.Pattern;
using UpGS.Data;

public class mainGUI : MonoBehaviour {
	public GameControll	gameControll;


	string txt="Sample text";
	// Use this for initialization

	void Awake()
	{
		PlayerPrefs.SetInt ("debug", 1);
		GameControll.gameControll = gameControll;
//		gameControll.DebugLog = true;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnGUI()
	{
/*
		if (GUI.Button (new Rect (100f, 10f, 100f, 30f), "Press my")) {
			txt+="Press my\n";
			User user = new User();
			
			// Пусть он что-нибудь сделает.
			user.Compute('+', 100);
			user.Compute('-', 50);
			user.Compute('*', 10);
			user.Compute('/', 2);
			
			// Отменяем 4 команды
			user.Undo(4);
			
			// Вернём 3 отменённые команды.
			user.Redo(3);

		}
		if (GUI.Button (new Rect (210f, 10f, 100f, 30f), "Clear")) {
			txt="";
		}
		GUI.TextArea (new Rect (100f, 110f, 500f, 500f), txt);
*/		
	}
}
