using System.IO;
using UnityEngine;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    
    void Start()
    {

        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/models");
        DirectoryInfo[] info = dir.GetDirectories("*.*");
        foreach (DirectoryInfo f in info)
        {
            print(f.Name);
        }
    }

public void OpenMlScene(){
    
    }
}
