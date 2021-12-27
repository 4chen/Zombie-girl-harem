using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUpPiceStats : MonoBehaviour
{
    public TMP_Text piceName;
    public TMP_Text stats;
    public TMP_Text abil;

    public string so_piceName;
    public int so_move;
    public int so_atk;
    public int so_def;
    public string so_abil;

    
    void Start()
    {
        piceName.text = so_piceName;
        stats.text = "Move :" + so_move.ToString() + "x" + "\n" + "Attack : " + so_atk.ToString() + "\n" + "Defence : " + so_def.ToString();
        abil.text = "Ability : " + so_abil.ToString();
    }

}
