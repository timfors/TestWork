using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Gold
{
    private static int _amount = 0;

    public static int Amount
    {
        get
        {
            return _amount;
        }
        private set
        {
            _amount = value > 0 ? value : 0;
        }
    }

    public static bool TrySpend(int expenses)
    {
        if (expenses > Amount)
        {
            return false;
        }
        else
        {
            Amount -= expenses;
            return true;
        }
    }

    public static void SetAmount(int value) => Amount = value;
    public static void Add(int value) => Amount += value;
    
}
