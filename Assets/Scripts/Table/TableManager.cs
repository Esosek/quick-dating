using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    private List<Person> activePeople = new List<Person>();

    // gender references
    [SerializeField] private GenderSO anyGender, maleGender, femaleGender = null;


    private PointCalculator resolver = null;
    private void Start() => resolver = GetComponent<PointCalculator>();


    // returns true if Person accepted
    public bool Sit(Person newPerson) {
        // table is empty => accept any person
        if(activePeople.Count == 0) {
            activePeople.Add(newPerson);
            return true;
        }
        
        // table is full => decline any person
        else if(activePeople.Count == 2) {
            return false;
        }

        // table has 1 person => check orientation compatibility
        else if(activePeople.Count == 1) {
            return (CheckCompatibility());
        }

        else return false;
    }

    // if true => start table resolving
    private bool CheckCompatibility() {

        bool _personOneCompatible = CheckOrientation(activePeople[0], activePeople[1]);
        bool _personTwoCompatible = CheckOrientation(activePeople[1], activePeople[0]);

        // final verdict
        if(_personOneCompatible && _personTwoCompatible) {
            resolver.Calculate(activePeople[0], activePeople[1]);
            return true;            
        }

        else return false;
    }

    private bool CheckOrientation(Person who, Person against) {

        if(who.Orientation == anyGender) {
            return true;
        }
        else if(who.Orientation == maleGender) {
            if(against.Gender == maleGender) return true;
            else return false;
        }
        else if(who.Orientation == femaleGender) {
            if(against.Gender == femaleGender) return true;
            else return false;
        }
        else return false;
    }

    public void ResetTable() => activePeople.Clear();
}
