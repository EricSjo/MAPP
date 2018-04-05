using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	void Awake()
	{
		Screen.autorotateToPortrait = true;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.orientation = ScreenOrientation.AutoRotation;
	}

	public void StartGame()
	{
		SceneManager.LoadScene (1);
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
