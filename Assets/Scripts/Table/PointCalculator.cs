using UnityEngine;
using System.Linq;

public class PointCalculator : MonoBehaviour
{
    [SerializeField] private IntVariable scoreAsset = null;
    [SerializeField] private int tableMultiplier = 1;
    [SerializeField] private GameConfig config = null;
    
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

        scoreAsset.AddValue(config.TableRewards[matches] * tableMultiplier);
    }
}
