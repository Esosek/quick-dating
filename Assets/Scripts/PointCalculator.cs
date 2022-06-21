using UnityEngine;
using System.Linq;

public class PointCalculator : MonoBehaviour
{
    [SerializeField] private IntVariable scoreAsset = null;
    [SerializeField] private int tableMultiplier = 1;
    [SerializeField] private int[] pointTableDistribution = { -400, 0, 200, 600 }; // GameConfig scriptable object?
    public void Calculate(Person firstPerson, Person secondPerson)  // called from TableManager
    {
        int matches = 0;
        
        // counts number of matches
        foreach (var trait in firstPerson.traits)
        {
            if(secondPerson.traits.Contains(trait))
            {
                matches++;
            }
        }

        scoreAsset.AddValue(pointTableDistribution[matches] * tableMultiplier);
    }
}
