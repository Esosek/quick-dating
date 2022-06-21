using UnityEngine;

public class PersonPreview : MonoBehaviour
{
    [SerializeField] private PersonVariable previewPersonAsset = null;

    private Person person = null;

    void Start() => person = this.gameObject.GetComponent<Person>();

    public void SetPreviewPerson() {
        if(previewPersonAsset != null) {
            previewPersonAsset.Set(person);
        }
        else Debug.LogWarning("PERSON PREVIEW: Person preview variable asset is not set");
    }
}
