using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalMade : MonoBehaviour
{

    public GoalGate LeftWall;
    public GoalGate RightWall;
    public GameObject[] Positions;

    public void Goal(GoalGate Wall)
    {
        Debug.Log(Wall.name);

        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("SampleScene");


    }
}

