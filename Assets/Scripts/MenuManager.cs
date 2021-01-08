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
        SceneManager.LoadScene(0);
    } public void LoadAI()
    {
        SceneManager.LoadScene(1);
    } public void LoadMultiplayer()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadML()
    {
    SceneManager.LoadScene(3);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
            Destroy(this.gameObject);
    }
    
}
