using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Fruits
{
    private int score = 30;
    public override void fruitScore()
    {
        setScore(getScore() + score);
    }
    
}
