using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New PersonVariable", menuName = "Variable/PersonVariable")]
public class PersonVariable : ScriptableObject {

    [SerializeField] private string personName = "";
    [SerializeField] private GenderSO gender = null;
    [SerializeField] private GenderSO orientation = null;
    [SerializeField] private TraitSO[] traits = null;

    public string PersonName { get { return personName; } private set { personName = value; } }
    public GenderSO Gender { get { return gender; } private set { gender = value; } }
    public GenderSO Orientation { get { return orientation; } private set { orientation = value; } }
    public TraitSO[] Traits { get { return traits; } private set { traits = value; } }   
    public List<string> TraitLines { get; private set; }

    public GameEvent onChangeEvent = null;

    public void Set(Person _person) {
        PersonName = _person.PersonName;
        Gender = _person.Gender;
        Orientation = _person.Orientation;
        Traits = _person.Traits;
        TraitLines = _person.TraitLines;

        if (onChangeEvent != null) onChangeEvent.Raise();
    }
}