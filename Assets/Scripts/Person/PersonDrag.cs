using UnityEngine;
using UnityEngine.EventSystems;

public class PersonDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float offset = 30f;

    [SerializeField] private GameObject maleModel, femaleModel = null;

    [SerializeField] private GameObject orientationIcon = null;
    [SerializeField] private BoolVariable gameState = null;

    private Camera personLoaderCamera = null;
    private GameObject activeModel = null;
    private Vector3 modelStartPos = Vector3.zero;
    private float distanceToScreen = 0f;

    private void Start()
    {
        personLoaderCamera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();

        // decide which model is active for dragging purposes
        if (maleModel.activeSelf == true)
            activeModel = maleModel;
        else
            activeModel = femaleModel;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!gameState.IsActive) 
        { 
            eventData.pointerDrag = null;
            return; 
        }
        
        Debug.Log("DRAG: Begin");
        modelStartPos = activeModel.transform.position;
        orientationIcon.SetActive(false);
        distanceToScreen = personLoaderCamera.WorldToScreenPoint(activeModel.transform.position).z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        activeModel.transform.position = personLoaderCamera.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y - offset, distanceToScreen)
        );
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("DRAG: End");
        // check the dropzone here
        if (CheckDropzone()) { 
            Destroy(this.gameObject);
        }
        else
        {
            // return
            orientationIcon.SetActive(true);
            activeModel.transform.position = modelStartPos;
        }
    }

    private bool CheckDropzone() // 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.CompareTag("Table"))
            {
                bool isSeated = hit.collider.GetComponent<TableManager>().Sit(this.GetComponent<Person>());
                if(isSeated)
                {
                    hit.collider.GetComponent<TableVisuals>().ShowPersonModel(activeModel);
                    ResetModelTransform();
                } 
                return isSeated;
            }
            else
                return false;
        }
        return false;
    }

    private void ResetModelTransform()
    {
        activeModel.transform.localPosition = Vector3.zero;
        activeModel.transform.localRotation = Quaternion.identity;
        activeModel.transform.localScale = new Vector3(1,1,1);
    }
}
