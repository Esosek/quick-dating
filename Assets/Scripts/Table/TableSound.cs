using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TableSound : MonoBehaviour {

    [SerializeField] private Sound[] manGreetings;
    [SerializeField] private Sound[] womanGreetings;
    [SerializeField] private Sound womanTraits03, womanTraits00, manTraits00, manTraits03;

    [SerializeField] private GenderSO femaleGender;
    private AudioManager audioManager = null;

    private void Start() {
        audioManager = AudioManager.instance;
    }

    public void GreetingsSound(List<Person> people)
    {
        if(audioManager == null)
        {
            Debug.LogWarning("TABLE SOUND: Missing AudioManager reference!");
            return;
        }

        StartCoroutine(GreetingsSoundCor(people));
    }

    private IEnumerator GreetingsSoundCor(List<Person> people)
    {
        if(people[0].Gender == femaleGender)
        {
            audioManager.Play(womanGreetings[0]);
        }
        else audioManager.Play(manGreetings[0]);

        yield return new WaitForSeconds(1f);

        if(people[1].Gender == femaleGender)
        {
            audioManager.Play(womanGreetings[1]);
        }
        else audioManager.Play(manGreetings[1]);
    }

    public void ResolveSound(Person person, int sharedTraits)
    {
        if(audioManager == null)
        {
            Debug.LogWarning("TABLE SOUND: Missing AudioManager reference!");
            return;
        }

        if(sharedTraits == 3)
        {
            if(person.Gender == femaleGender)
            {
                audioManager.Play(womanTraits03);
            }
            else audioManager.Play(manTraits03);

        }

        else if(sharedTraits == 0)
        {
            if(person.Gender == femaleGender)
            {
                audioManager.Play(womanTraits00);
            }
            else audioManager.Play(manTraits00);
        }
    }

}