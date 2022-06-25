using UnityEngine;
using UnityEngine.EventSystems;

public class PersonPreview : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PersonVariable previewPersonAsset = null;
    [SerializeField] private GameEvent closePreviewEvent = null;

    private Person person = null;

    void Start() => person = this.gameObject.GetComponent<Person>();

    public void SetPreviewPerson() {
        if(previewPersonAsset != null) {
            previewPersonAsset.Set(person);
        }
        else Debug.LogWarning("PERSON PREVIEW: Person preview variable asset is not set");
    }

    public void OnPointerEnter(PointerEventData eventData) => SetPreviewPerson();
    public void OnPointerExit(PointerEventData eventData) {
        if(closePreviewEvent != null) closePreviewEvent.Raise();
    }
}
