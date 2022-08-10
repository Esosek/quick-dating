using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color highlightedColor = Color.white;
    [SerializeField] protected float transitionDuration = 0.1f;
    
    protected float transitionTime = 0f;
    protected Color startingColor = Color.white;
    protected Color endColor = Color.white;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Transition(normalColor, highlightedColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Transition(highlightedColor, normalColor);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(gameEvent == null) return;
        else gameEvent.Raise();
    }

    private void Transition(Color a, Color b)
    {
        startingColor = a;
        endColor = b;
        transitionTime = 0f;
    }

    private void Update() {
        TransitionUpdate();
    }

    public virtual void TransitionUpdate()
    {
        if(transitionTime > 1) return;
        
        transitionTime += Time.deltaTime / transitionDuration;
        GetComponent<Image>().color = Color.Lerp(startingColor, endColor, transitionTime);
    }
}
