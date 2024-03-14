using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour{

    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject ControlsPanel;

    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Controls_Open(){
        MainMenuPanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    public void Controls_Close(){
        ControlsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void Exit(){
        //Não funciona dentro do editor!
        Debug.Log("Left the Game");
        Application.Quit();
    }
}