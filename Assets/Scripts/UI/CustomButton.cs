using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color highlightedColor = Color.white;
    [SerializeField] private float transitionDuration = 0.1f;
    
    private Image image = null;
    private float transitionTime = 0f;
    private Color startingColor = Color.white;
    private Color endColor = Color.white;

    private void Start() => image = GetComponent<Image>();

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
        if(transitionTime > 1) return;
        
        transitionTime += Time.deltaTime / transitionDuration;
        image.color = Color.Lerp(startingColor, endColor, transitionTime);
    }
}
