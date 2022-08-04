using UnityEngine;

public class SettingsMenu : DisplayableMenu
{

    private void Start() {
        if(gameActiveState == null) Debug.LogWarning("SETTINGS: Missing game active state reference");
    }

    private void Update() {
        if(!isActive && !gameActiveState.IsActive) return; // disable settings while game is over
        if(menuObject != null && Input.GetKeyUp(KeyCode.Escape))
        {
            if(isActive) Hide();
            else Show();
        }
    }
}
