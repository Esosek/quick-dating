using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    private List<Person> activePeople = new List<Person>();

    // gender references
    [SerializeField] private GenderSO anyGender, maleGender, femaleGender = null;
    [SerializeField] private GameEvent personSeatedEvent = null;

    private TableSound sounds = null;
    private TableVisuals visualHandler = null;
    private PointCalculator resolver = null;

    private void Start()
    {
        resolver = GetComponent<PointCalculator>();
        visualHandler = GetComponent<TableVisuals>();
        sounds = GetComponent<TableSound>();
    }


    // returns true if Person accepted
    public bool Sit(Person newPerson) {
        // table is empty => accept any person
        if(activePeople.Count == 0) {
            activePeople.Add(newPerson);
            visualHandler.ShowWineGlass(0);
            visualHandler.DisplaySeatedPersonNeeds(activePeople[0]); // display icons of seated person needs and orientation
            if(personSeatedEvent != null) personSeatedEvent.Raise();                
            return true;
        }
        
        // table is full => decline any person
        else if(activePeople.Count == 2) {
            return false;
        }

        // table has 1 person => check orientation compatibility
        else if(activePeople.Count == 1) {
            bool isCompatible = CheckCompatibility(newPerson);

            if(isCompatible)
            {
                if(personSeatedEvent != null) personSeatedEvent.Raise();
                visualHandler.ShowWineGlass(1);
                sounds.GreetingsSound(activePeople);
            } 
                
            return isCompatible;
        }

        else return false;
    }

    // if true => start table resolving
    private bool CheckCompatibility(Person newPerson) {

        bool _personOneCompatible = CheckOrientation(activePeople[0], newPerson);
        bool _personTwoCompatible = CheckOrientation(newPerson, activePeople[0]);

        // these people are orientation compatible -> resolve them
        if(_personOneCompatible && _personTwoCompatible) {
            activePeople.Add(newPerson);
            resolver.Calculate(activePeople[0], activePeople[1]);
            visualHandler.HideSeatedPersonNeeds(); // hide visuals for seated person needs
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

    public void ResetTable() 
    {
        activePeople.Clear();

        visualHandler.HideWineGlasses();
        visualHandler.RemoveModels();
    }
}
