using UnityEngine;
using System.Collections.Generic;

public class PersonGenerator : MonoBehaviour {
    [SerializeField] private GameObject personPrefab = null;
    [SerializeField] private Transform loaderTransform = null;
    [SerializeField] private GenderSO[] genderArray = null; // make sure "Any" gender has index 0
    [SerializeField] private TraitSO[] traitArray = null;

    [SerializeField] private GenderSO maleGenderAsset = null;
    [SerializeField] private GenderSO femaleGenderAsset = null;

    private string[] maleNames = new string[] {"Michael", "Mark", "Paul", "Frank", "Lucas", "Alfred", "Eduard", "Noah", "Henry", "Mateo", "Ethan" };
    private string[] femaleNames = new string[] {"Kate", "Alice", "Josie", "Mary", "Eleanor", "Charlotte", "Emma", "Mia", "Ava", "Chloe" };

    public void Generate()
    {
        GameObject _newPerson = Instantiate(personPrefab, loaderTransform);
        // store gender to use it in name generator
        GenderSO _gender = GenerateGender();
        // push generated data to new Person
        _newPerson.GetComponent<Person>().SetPerson(GenerateName(_gender), _gender, GenerateOrientation(), GenerateTraits(3));
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

    TraitSO[] GenerateTraits(int _numberOfTraits)
    {
        List<TraitSO> _traitList = new List<TraitSO>(traitArray);
        List<TraitSO> _selectedTraits = new List<TraitSO>();

        for (int i = 0; i < _numberOfTraits; i++)
        {
            int _randomTraitIndex = Random.Range(0, _traitList.Count);
            _selectedTraits.Add(_traitList[_randomTraitIndex]);
            _traitList.Remove(_traitList[_randomTraitIndex]);
        }

        return _selectedTraits.ToArray();
    }

    string GenerateName(GenderSO _gender)
    {
        if(_gender == maleGenderAsset) {
            int _index = Random.Range(0, maleNames.Length);
            return maleNames[_index];
        }
        else if (_gender == femaleGenderAsset) {
            int _index = Random.Range(0, femaleNames.Length);
            return femaleNames[_index];
        }
        else Debug.LogWarning("PERSON GENERATOR: Generating name failed, no such gender");
        return "Alex";
    }
    
}