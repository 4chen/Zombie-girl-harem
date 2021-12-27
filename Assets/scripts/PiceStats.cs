using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PiceInfo")]

public class PiceStats : ScriptableObject
{
    public string piceName;
    public int movement;
    public int attack;
    public int defence;
    public string ability;

}
