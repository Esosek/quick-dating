using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour {

    [SerializeField] private GameObject maleObject = null;
    [SerializeField] private GameObject femaleObject = null;
    [SerializeField] private Image orientationImage = null;

    [SerializeField] private GenderSO maleGenderAsset = null;
    [SerializeField] private GenderSO femaleGenderAsset = null;

    private string personName = "Alex";
    public GenderSO gender { get; private set; }
    public TraitSO[] traits { get; private set; }
    public GenderSO orientation { get; private set; }

    public void SetPerson(string _name, GenderSO _gender, TraitSO[] _traits, GenderSO _orientation)
    {
        gender = _gender;
        traits = _traits;
        orientation = _orientation;
        personName = _name;

        orientationImage.sprite = orientation.icon;

        Debug.Log("PERSON: Generated person");

        ShowModel();
    }

    void ShowModel() {
        if(gender == maleGenderAsset) maleObject.SetActive(true);
        else if (gender == femaleGenderAsset) femaleObject.SetActive(true);
        else Debug.LogError("PERSON: Invalid gender, no model was shown");
    }

}