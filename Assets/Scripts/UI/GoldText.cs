using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldText : TextUI
{
    private void Update()
    {
        if (Gold.Amount.ToString() != UIComponent.text) {
            UIComponent.text = Gold.Amount.ToString();
        }
    }
}
