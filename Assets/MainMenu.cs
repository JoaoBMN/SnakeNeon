using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
    public int Index;    
    
    public void PlayGame ()
    {
        
        SceneManager.LoadScene(Index);
    }

        public void QuitGame ()
    {

        Debug.Log("QUIT THE GAME!");
        Application.Quit();

    }
}
