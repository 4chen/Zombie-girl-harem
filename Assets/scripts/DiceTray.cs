using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTray : MonoBehaviour
{
    public Sprite[] diceRools;

    [SerializeField] PointIncreeser givePoints;
    int points;
    public void OnClickDice(Image dice)
    {
        dice.GetComponent<Button>().enabled = false;
        var diceRoll = Random.Range(0,6);
        points += diceRoll + 1;
        dice.sprite = diceRools[diceRoll];
        givePoints.pointIncreesed = points;
        dice.GetComponent<Animator>().Play("DiceRoll");        
    }
}
