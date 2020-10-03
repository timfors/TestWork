using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScore : TextUI
{
    public void UpdateValues()
    {
        UIComponent.text = WaveController.EnemyKillCount.ToString();
    }
}
