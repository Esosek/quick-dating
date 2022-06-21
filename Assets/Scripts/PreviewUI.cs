using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewUI : MonoBehaviour
{
    [SerializeField] private PersonVariable personPreviewAsset = null;
    [SerializeField] private GameObject title = null;
    [SerializeField] private GameObject[] lines = null;

    private bool isActivated = false;

    // called upon OnPreviewChange event
    public void SetPreview() {
        if(!isActivated) ActivateUI();

        title.GetComponent<TextMeshProUGUI>().text = personPreviewAsset.PersonName;
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].GetComponent<TextMeshProUGUI>().text = personPreviewAsset.TraitLines[i];
        }
    }

    void ActivateUI() {
        isActivated = true;
        title.SetActive(true);
        foreach (var item in lines)
        {
            item.SetActive(true);
        }
    }
}
