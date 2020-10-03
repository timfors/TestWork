using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    private Image _image = null;
    // Update is called once per frame

    private void Start()
    {
        _image = GetComponent<Image>();
    }
    public void UpdateHealth(float fill)
    {
        _image.fillAmount = fill;
    }
}
