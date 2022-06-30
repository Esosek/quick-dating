using UnityEngine;
using System.Linq;
using System.Collections;

public class PointCalculator : MonoBehaviour
{
    [SerializeField] private IntVariable scoreAsset = null;
    [SerializeField] private int tableMultiplier = 1;
    [SerializeField] private GameConfig config = null;

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

        int _scoreToAdd = config.TableRewards[matches] * tableMultiplier;
        float _timeToWait = tableMultiplier * config.BaseTableTime * 0.75f; // multiplied by 0.75 to better suit wait times for higher multipliers
        StartCoroutine(DelayResolve(_timeToWait, _scoreToAdd));
        
    }

    private IEnumerator DelayResolve(float timeToWait, int scoreValue)
    {
        yield return new WaitForSeconds(timeToWait);
        scoreAsset.AddValue(scoreValue);
        tableManager.ResetTable();
    }
}
