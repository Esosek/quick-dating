using UnityEngine;
using UnityEngine.EventSystems;

public class TableDropzone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        // check if dragging something
        //if (!eventData.dragging) return;
        Debug.Log("DROPZONE: Entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!eventData.dragging) return;
        Debug.Log("DROPZONE: Exited");

    }
}
