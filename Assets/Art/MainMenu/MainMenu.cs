using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
   	public void PlayGame(){
		SceneManager.LoadScene(1);
	}
	
	public void Settings(){
		SceneManager.LoadScene(2);
	}

	public void QuitGame(){
		Application.Quit();
	}

}
