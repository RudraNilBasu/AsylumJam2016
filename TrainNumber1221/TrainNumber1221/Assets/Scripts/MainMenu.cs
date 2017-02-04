using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public static MainMenu reference;
	// Use this for initialization
	void Start () {
	    if(reference==null)
        {
            reference = this;
        }
	}

    public void startGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
