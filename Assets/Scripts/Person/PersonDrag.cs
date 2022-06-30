using UnityEngine;
using UnityEngine.EventSystems;

public class PersonDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float offset = 30f;
   [SerializeField] private GameObject maleModel, femaleModel = null;
   [SerializeField] private GameObject orientationIcon = null;
   private Camera personLoaderCamera = null;

   private GameObject activeModel = null;
   private Vector3 modelStartPos = Vector3.zero;
   private float distanceToScreen = 0f;

    private void Start() {
        personLoaderCamera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();

        // decide which model is active for dragging purposes
        if(maleModel.activeSelf == true) activeModel = maleModel;
        else activeModel = femaleModel;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("DRAG: Begin");
        modelStartPos = activeModel.transform.position;
        orientationIcon.SetActive(false);
        distanceToScreen = personLoaderCamera.WorldToScreenPoint(activeModel.transform.position).z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        activeModel.transform.position = personLoaderCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y - offset, distanceToScreen ));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("DRAG: End");
        // check the dropzone here

        // return
        orientationIcon.SetActive(true);
        activeModel.transform.position = modelStartPos;
    }
}