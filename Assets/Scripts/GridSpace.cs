using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
	public Button button;
	public Text buttonText;
	//public GameObject imageX;
	//public GameObject imageO;
	public Sprite playerX;
	public Sprite playerO;

	private GameController gameController;

	void Start()
	{
		
	}

	void Update()
	{

	}

	public void SetSpace()
	{
		
		buttonText.text = gameController.GetPlayerSide();

		// CHECK ME OUT YO

/*		if (gameController.GetPlayerSide = playerX)
		{
			gameController.imageX.SetActive (true);
		}
			
		else if (gameController.GetPlayerSide = playerO)
		{
			gameController.imageO.SetActive (true);
		}
*/			
			
		button.interactable = false;
		gameController.EndTurn();
	}

	public void SetGameControllerReference (GameController controller)
	{
		gameController = controller;
	}
}