using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitGame : MonoBehaviour 
{
	public Button exitBtn;

	// Use this for initialization
	void Start () 
	{
		Button exit = exitBtn.GetComponent<Button>();
		exit.onClick.AddListener(ExitGame);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void ExitGame ()
	{
		//Debug.Log("EXIT THE GAME!");
		Application.Quit();
	}
}
