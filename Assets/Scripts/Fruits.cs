using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private int scoreCount;



    public virtual void fruitScore()
    {
        scoreCount = 0;
    }

    public void setScore(int score)
    {
        scoreCount = score;
        Debug.Log(scoreCount);
    }
    public int getScore()
    {
        return scoreCount;
    }
  
}
