using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PointCalculator : MonoBehaviour
{
    [SerializeField] private IntVariable scoreAsset = null;
    [SerializeField] private int tableMultiplier = 1;
    [SerializeField] private GameConfig config = null;
    [SerializeField] private Image loadingBar = null;
    [SerializeField] private GameObject pointsGainedText = null;
    [SerializeField] private BoolVariable gameActiveState = null;

    [SerializeField] private Color32 negativePointsColor = Color.red;
    [SerializeField] private Color32 positivePointsColor = Color.green;

    private bool isResolving = false;
    private float timeWaited = 0f;
    private float timeToWait = 0f;
    private int scoreToAdd = 0;

    private TableManager tableManager = null;

    private void Start() => tableManager = this.GetComponent<TableManager>();
    
    public void Calculate(Person firstPerson, Person secondPerson)  // called from TableManager
    {
        int matches = 0;
        
        // counts number of matches
        foreach (var trait in firstPerson.Traits)
        {
            if(secondPerson.Traits.Contains(trait))
            {
                matches++;
            }
        }

        scoreToAdd = config.TableRewards[matches] * tableMultiplier;
        timeToWait = tableMultiplier * config.BaseTableTime * 0.75f; // multiplied by 0.75 to better suit wait times for higher multipliers
        StartResolving();
        
    }

    private void StartResolving() 
    {
        isResolving = true;
        loadingBar.gameObject.SetActive(true);
    }

    private void Update() 
    {
        if(gameActiveState.IsActive && isResolving)
        {
            timeWaited += Time.deltaTime;
            float _progress = timeWaited / timeToWait;
            loadingBar.fillAmount = _progress;

            if(timeWaited >= timeToWait) Resolve();
        }
    }

    private void Resolve()
    {
        isResolving = false;
        timeWaited = 0f;
        scoreAsset.AddValue(scoreToAdd);
        tableManager.ResetTable();
        loadingBar.gameObject.SetActive(false);

        if(pointsGainedText != null) StartCoroutine(ShowPointsGained());
    }

    private IEnumerator ShowPointsGained()
    {
        TextMeshProUGUI _textContent = pointsGainedText.GetComponent<TextMeshProUGUI>();

        _textContent.text = scoreToAdd >= 0 ? "+" + scoreToAdd.ToString() : scoreToAdd.ToString();
        _textContent.color = scoreToAdd >= 0 ? positivePointsColor : negativePointsColor;
        pointsGainedText.SetActive(true);

        yield return new WaitForSeconds(1.3f);

        pointsGainedText.GetComponent<Animator>().SetTrigger("popOut");

        yield return new WaitForSeconds(1.5f);

        pointsGainedText.SetActive(false);
    }
}
