using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PreviewUI : MonoBehaviour
{
    [SerializeField] private PersonVariable personPreviewAsset = null;
    [SerializeField] private GameObject title = null;
    //[SerializeField] private GameObject[] lines = null;
    [SerializeField] private Image[] iconImages = null;

    private bool isActivated = false;

    // called upon OnPreviewChange event
    public void SetPreview() {
        if(!isActivated) ActivateUI(true);

        title.GetComponent<TextMeshProUGUI>().text = personPreviewAsset.PersonName;
        /*for (int i = 0; i < lines.Length; i++)
        {
            lines[i].GetComponent<TextMeshProUGUI>().text = personPreviewAsset.TraitLines[i];
        }*/
        for (int i = 0; i < iconImages.Length; i++)
        {
            iconImages[i].sprite = personPreviewAsset.Traits[i].icon;
        }
    }

    // called upon ClosePreview event
    public void ClosePreview() => ActivateUI(false);

    void ActivateUI(bool newState) {
        isActivated = newState;
        title.SetActive(newState);
        /*foreach (var item in lines)
        {
            item.SetActive(newState);
        }*/
        foreach (var item in iconImages)
        {
            item.gameObject.SetActive(newState);
        }
    }
}
