using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New PersonVariable", menuName = "Variables/PersonVariable")]
public class PersonVariable : ScriptableObject {

    public string PersonName { get; private set; }
    public GenderSO Gender { get; private set; }
    public GenderSO Orientation { get; private set; }
    public TraitSO[] Traits { get; private set;}   
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