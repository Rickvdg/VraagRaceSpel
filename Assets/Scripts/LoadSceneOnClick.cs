using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour
{

	public InputField usernamefield;

	public void LoadByIndex(int sceneIndex)
	{
		if (!string.IsNullOrEmpty(VariableManager.Username) || !string.IsNullOrEmpty(usernamefield.text))
		{
			SceneManager.LoadScene(sceneIndex);
		}
	}
	
	public void ExitGame() {
	    Application.Quit();
	}

	public void SetUsername()
	{
		if (!string.IsNullOrEmpty(usernamefield.text))
			VariableManager.Username = usernamefield.text;
	}
}
