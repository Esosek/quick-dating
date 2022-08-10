using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameConfig config = null;
    [SerializeField] private BoolVariable gameActiveState = null;

    [Header("Events")]
    [SerializeField] private GameEvent generatePersonEvent = null;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        if(config != null) 
        {
            for (int i = 0; i < config.StartPersonNumber; i++) 
            {
                if(generatePersonEvent != null) generatePersonEvent.Raise();
            }
        }

        else Debug.LogWarning("GAME MANAGER: No config asset found!");  

        if(gameActiveState != null) gameActiveState.Set(true);
    }

    public void SetConfig(GameConfig newConfig)
    {
        config = newConfig;
    }
}
