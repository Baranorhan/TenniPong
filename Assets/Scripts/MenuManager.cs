using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private static MenuManager instance=null;
    
    public void LoadMainMenu()
    {
        
        SceneManager.LoadScene("Menu");
    } public void LoadAI()
    {
        SceneManager.LoadScene("AI");
    } public void LoadMultiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }
    public void LoadML()
    {
    SceneManager.LoadScene("ML");
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
            Destroy(this);
    }
    
}
