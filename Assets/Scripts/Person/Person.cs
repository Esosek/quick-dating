using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Person : MonoBehaviour {

    [SerializeField] private GameObject maleObject = null;
    [SerializeField] private GameObject femaleObject = null;
    [SerializeField] private Image orientationImage = null;

    [SerializeField] private GenderSO maleGenderAsset = null;
    [SerializeField] private GenderSO femaleGenderAsset = null;

    public string PersonName { get; private set; } = "Alex";
    public GenderSO Gender { get; private set; }
    public TraitSO[] Traits { get; private set; }
    public GenderSO Orientation { get; private set; }
    public List<string> TraitLines { get; private set; } = new List<string>();

    public void SetPerson(string personName, GenderSO gender, GenderSO orientation, TraitSO[] traits)
    {
        Gender = gender;
        Traits = traits;
        Orientation = orientation;
        PersonName = personName;

        SetTraitLines();

        orientationImage.sprite = Orientation.icon;

        Debug.Log("PERSON: Generated person");

        ShowModel();
    }

    void ShowModel() {
        if(Gender == maleGenderAsset) maleObject.SetActive(true);
        else if (Gender == femaleGenderAsset) femaleObject.SetActive(true);
        else Debug.LogError("PERSON: Invalid gender, no model was shown");
    }

    void SetTraitLines() {
        for (int i = 0; i < Traits.Length; i++)
        {
            int _randomLineIndex = Random.Range(0, Traits[i].lines.Length);
            string _randomLine = Traits[i].lines[_randomLineIndex];
            TraitLines.Add(_randomLine);
        }
    }

}