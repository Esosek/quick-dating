using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuObject = null;
    [SerializeField] private BoolVariable gameActiveState = null;

    private bool isActive = false;

    private void Start() {
        if(gameActiveState == null) Debug.LogWarning("SETTINGS: Missing game active state reference");
    }

    public void Show() // called from events
    {
        menuObject.SetActive(true);
        isActive = true;
        gameActiveState.Set(false);
    }

    public void Hide()
    {
        menuObject.SetActive(false);
        isActive = false;
        gameActiveState.Set(true);
    }

    private void Update() {
        if(menuObject != null && Input.GetKeyUp(KeyCode.Escape))
        {
            if(isActive) Hide();
            else Show();
        }
    }
}
