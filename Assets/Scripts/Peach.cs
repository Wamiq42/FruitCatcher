using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peach : Fruits
{
    private int score = 25;
    public override void fruitScore()
    {
        setScore(getScore() + score);
    }
   
}
