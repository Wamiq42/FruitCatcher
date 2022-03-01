using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Fruits
{
    private int score = 10;
    public override void fruitScore()
    {
        setScore(getScore() + score);
    }
   
    
}
