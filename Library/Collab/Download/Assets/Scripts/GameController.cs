using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player
{
	public Image panel;
	public Text text;
	public Button button;
}

[System.Serializable]
public class PlayerColor
{
	public Color panelColor;
	public Color textColor;
}

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
	public GameObject gameOverPanel;
	public Text gameOverText;
	public GameObject restartButton;
	public GameObject startInfo;
	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;
	public GameObject img;
	public Button backToMenu;
	//public GameObject imageX;
	//public GameObject imageO;


	private string playerSide;
	private int moveCount;

    void Awake ()
    {
        SetGameControllerReferenceOnButtons();
		gameOverPanel.SetActive (false);
		moveCount = 0;
		restartButton.SetActive (false);
		img.SetActive (false);
	//	imageX.SetActive (false);
	//	imageO.SetActive (false);

	}

    void SetGameControllerReferenceOnButtons ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
			buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }


    public string GetPlayerSide ()
    {
		return playerSide;
	}
    

	public void EndTurn ()
    {
		moveCount++;
		if (moveCount >= 9)
		{
			GameOver ("draw");
		}

		if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
		{
			GameOver (playerSide);
		}
		else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
		{
			GameOver (playerSide);
		}
		else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver (playerSide);
		}
		else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver (playerSide);
		}
		else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
		{
			GameOver (playerSide);
		}
		else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver (playerSide);
		}
		else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
		{
			GameOver (playerSide);
		}
		else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
		{
			GameOver (playerSide);
		}

		else if (moveCount < 9)
			ChangeSides();
    }

	void GameOver (string winningPlayer)
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			SetBoardInteractable (false);
		}

		if (winningPlayer == "draw")
		{
			SetGameOverText ("It's a draw!");
			SetPlayerColorsInactive ();
		}
		else
			SetGameOverText(playerSide + " Wins!");

		restartButton.SetActive (true);
		img.SetActive (true);
	}

	void ChangeSides ()
	{
		playerSide = (playerSide == "X") ? "O" : "X";
		if (playerSide == "X")
		{
			SetPlayerColors (playerX, playerO);
		}
		else
		{
			SetPlayerColors (playerO, playerX);
		}
	}

	void SetGameOverText(string value)
	{
		gameOverPanel.SetActive (true);
		gameOverText.text = value;
	}

	public void RestartGame()
	{
		moveCount = 0;
		gameOverPanel.SetActive (false);
		restartButton.SetActive (false);
		SetPlayerButtons (true);
		SetPlayerColorsInactive ();
		startInfo.SetActive (true);
		img.SetActive (false);

		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].text = "";
		}
	}

	void SetBoardInteractable(bool toggle)
	{
		for (int i = 0; i < buttonList.Length; i++)
		{
			buttonList [i].GetComponentInParent<Button> ().interactable = toggle;
		}
	}

	void SetPlayerColors(Player newPlayer, Player oldPlayer)
	{
		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;

		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}

	public void SetStartingSide (string startingSide)
	{
		playerSide = startingSide;

		if (playerSide == "X")
			SetPlayerColors (playerX, playerO);
		else
			SetPlayerColors (playerO, playerX);

		StartGame ();
	}

	void StartGame()
	{
		SetBoardInteractable (true);
		SetPlayerButtons (false);
		startInfo.SetActive (false);
	}

	void SetPlayerButtons(bool toggle)
	{
		playerX.button.interactable = toggle;
		playerO.button.interactable = toggle;
	}

	void SetPlayerColorsInactive()
	{
		playerX.panel.color = inactivePlayerColor.panelColor;
		playerX.text.color = inactivePlayerColor.textColor;

		playerO.panel.color = inactivePlayerColor.panelColor;
		playerO.text.color = inactivePlayerColor.textColor;
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene (0);
		Screen.orientation = ScreenOrientation.AutoRotation;
	}
}
