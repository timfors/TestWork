using UnityEngine.UI;

public class TextUI : UI<Text, string>
{

    public override void UpdateValues(string input)
    {
        UIComponent.text = input;
    }
}
