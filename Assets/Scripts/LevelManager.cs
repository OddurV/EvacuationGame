using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {

    public Transform mainMenu, optionsMenu;

	public void LoadScene(string name){
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
	}
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptionsMenu (bool clicked)
    {
        if (clicked == true)
        {
            optionsMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(!clicked);
        }
        else
        {
            optionsMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }

    public void OpenItemOptionsMenu()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "ButtonControls":
                
                break;
            case "ButtonPlayerSettings":
                
                break;
            case "ButtonMusic":

                break;
            case "ButtonRules":

                break;

        }
    }
}
