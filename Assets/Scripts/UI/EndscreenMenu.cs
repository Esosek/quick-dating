using UnityEngine;
using TMPro;

public class EndscreenMenu : DisplayableMenu {

    [SerializeField] private StringVariable playerNameVariable = null;
    [SerializeField] private TMP_InputField nameInputText = null;

    public override void Show()
    {
        FillPlayerName();
        base.Show();
    }

    private void FillPlayerName()
    {
        if(playerNameVariable == null || nameInputText == null) return; // null check
        nameInputText.text = playerNameVariable.Value;
    }
}