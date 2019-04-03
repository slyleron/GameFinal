using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripte : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void LevelExit()
    {
        Application.Quit();
    }
}
