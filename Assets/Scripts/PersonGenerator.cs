using UnityEngine;

public class PersonGenerator : MonoBehaviour {
    [SerializeField] private GameObject personPrefab = null;
    [SerializeField] private Transform loaderTransform = null;
    [SerializeField] private GenderSO[] genderArray = null; // make sure "Any" gender has index 0
    [SerializeField] private TraitSO[] traitArray = null;

    public void Generate()
    {
        GameObject _newPerson = Instantiate(personPrefab, loaderTransform);
        // push generated data to new Person
        _newPerson.GetComponent<Person>().SetPerson(GenerateGender(), GenerateTraits(), GenerateOrientation());
    }

    GenderSO GenerateGender()
    {
        int _index = Random.Range(1, genderArray.Length);
        return genderArray[_index];
    }

    GenderSO GenerateOrientation()
    {
        int _index = Random.Range(0, genderArray.Length);
        return genderArray[_index];
    }

    TraitSO[] GenerateTraits()
    {
        List<TraitSO> traitList = new List<TraitSO>();
        return traitArray;
    }
}