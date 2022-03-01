using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Apple : Fruits
{
    private int score = 15;
    public override void fruitScore()
    {
        setScore(getScore() + score);
    }
   
}
