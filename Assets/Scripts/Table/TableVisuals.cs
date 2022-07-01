using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableVisuals : MonoBehaviour
{
    [SerializeField] private GameObject[] wineGlasses = null;
    [SerializeField] private GameObject[] chairs = null;

    private List<GameObject> seatedPeople = new List<GameObject>();

    private void Start() {
        if(wineGlasses.Length == 0) Debug.LogError("TABLE VISUALS: Wine glasses models not referenced");
        if(chairs.Length == 0) Debug.LogError("TABLE VISUALS: Chair models not referenced");
    }

    public void ShowWineGlass(int index)
    {
        wineGlasses[index].SetActive(true);
    }

    public void HideWineGlasses() => StartCoroutine(DelayedHideWineGlass());

    private IEnumerator DelayedHideWineGlass()
    {
        foreach (var glass in wineGlasses)
        {
            glass.GetComponent<Animator>().SetTrigger("popOut");
        }

        yield return new WaitForSeconds(0.5f);

        foreach (var glass in wineGlasses)
        {
            glass.SetActive(false);
        }
    }

    public void ShowPersonModel(GameObject personModel)
    {
        seatedPeople.Add(personModel);

        switch (seatedPeople.Count)
        { 
            case 1:
                personModel.transform.SetParent(chairs[0].transform);
            break;

            case 2:
                personModel.transform.SetParent(chairs[1].transform);
            break;
            
            default:
                Debug.LogWarning("TABLE VISUALS: Seated people out of possible range");
            break;
        }

        personModel.GetComponent<Animator>().SetTrigger("sit");
    }

    public void RemoveModels()
    {
        foreach (var person in seatedPeople)
        {
            Destroy(person);            
        }

        seatedPeople.Clear();
    }
}
