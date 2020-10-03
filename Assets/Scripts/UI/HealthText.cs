using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthText : TextUI
{
    [SerializeField]
    private Player player = null;

    public void UpdateValues()
    {
        UIComponent.text = player.Health.ToString();
    }
}
