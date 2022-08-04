using UnityEngine;

public class DisplayableMenu : MonoBehaviour {

    [SerializeField] protected GameObject menuObject = null;
    [SerializeField] protected BoolVariable gameActiveState = null;

    protected bool isActive = false;

    public virtual void Show() // called from events
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
}