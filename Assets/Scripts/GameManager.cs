using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int startingPersonNumber = 6;

    [Header("Events")]
    [SerializeField] private GameEvent generatePersonEvent = null;

    void Start()
    {
        for (int i = 0; i < startingPersonNumber; i++)
        {
            if(generatePersonEvent != null) generatePersonEvent.Raise();
        }
    }
}
