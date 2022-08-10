using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private int tutorialPhase = 0;
    [SerializeField] private GameObject[] tutorialTexts = null;

    [Header("References")]
    [SerializeField] private PersonVariable katePerson = null;
    [SerializeField] private PersonVariable alexPerson = null;
    [SerializeField] private PersonGenerator personGenerator = null;
    [SerializeField] private GameObject bonusPointsUI = null;
    [SerializeField] private GameObject pointsTracker = null;
    [SerializeField] private GameObject[] extraTables = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private GameConfig productionConfig = null;
    [SerializeField] private PointCalculator tutorialTableReference = null;
    [SerializeField] private GameObject navigationButtons = null;
    

    private void Start() {
        personGenerator.Generate(katePerson);
        tutorialTexts[0].SetActive(true);
    }

    public void OnPersonPreview() // called OnPreviewChange event
    {
        if(tutorialPhase != 0) return;

        tutorialPhase++;
        tutorialTexts[0].SetActive(false);
        tutorialTexts[1].SetActive(true);
    }

    public void OnKateSeated() // called OnPersonSeated event
    {
        if(tutorialPhase != 1) return;

        tutorialPhase++;
        tutorialTexts[1].SetActive(false);
        tutorialTexts[2].SetActive(true);
        personGenerator.Generate(alexPerson);
    }

    public void OnTableResolved() // called OnScoreChanged event
    {
        if(tutorialPhase != 2) return;

        tutorialPhase++;
        tutorialTexts[2].SetActive(false);
        tutorialTexts[3].SetActive(true);
        bonusPointsUI.SetActive(true);
        extraTables[0].SetActive(true);
        extraTables[1].SetActive(true);
        
        for (int i = 0; i < pointsTracker.transform.childCount; i++)
        {
            pointsTracker.transform.GetChild(i).gameObject.SetActive(true);
        }

        // show ui to return to menu or keep playing
        navigationButtons.SetActive(true);
    }

    public void SetupFreePlay() // called OnKeepPlaying event
    {
        tutorialTexts[3].SetActive(false);
        gameManager.SetConfig(productionConfig);
        tutorialTableReference.SetConfig(productionConfig);
        gameManager.Setup();
        navigationButtons.SetActive(false);

        personGenerator.GetComponent<GameEventListener>().enabled = true;
    }

}
