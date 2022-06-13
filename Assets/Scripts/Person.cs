using UnityEngine;

public class Person : MonoBehaviour {

    private string personName = "Alex";
    private GenderSO gender = null;
    private TraitSO[] traits = null;
    private GenderSO orientation = null;

    private string[] maleNames = new string[] {"Michael", "Mark", "Paul", "Frank", "Lucas", "Alfred", "Eduard", "Noah", "Henry", "Mateo", "Ethan" };
    private string[] femaleNames = new string[] {"Kate", "Alice", "Josie", "Mary", "Eleanor", "Charlotte", "Emma", "Mia", "Ava", "Chloe" };

    public void SetPerson(GenderSO _gender, TraitSO[] _traits, GenderSO _orientation)
    {
        gender = _gender;
        traits = _traits;
        orientation = _orientation;
        GenerateName();
    }

    void GenerateName()
    {
        if(gender.name == "Male") {
            int _index = Random.Range(0, maleNames.Length);
            personName = maleNames[_index];
        }
        else if (gender.name == "Female") {
            int _index = Random.Range(0, femaleNames.Length);
            personName = femaleNames[_index];
        }
        else Debug.LogWarning("PERSON: Generating name failed, no such gender");
    }
}