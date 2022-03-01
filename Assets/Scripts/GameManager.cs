using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;

    public void setScore(int score)
    {
        this.score = score;
    }
    public int getScore()
    {
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score is : " + score);
    }
}
