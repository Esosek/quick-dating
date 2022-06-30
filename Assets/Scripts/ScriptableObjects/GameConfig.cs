using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game Config")]
public class GameConfig : ScriptableObject
{
    // backing variables
    [SerializeField]
    private float timer = 180f;

    [SerializeField]
    private int startPersonNumber = 6;

    [SerializeField]
    private int baseTableTime = 2;

    [SerializeField]
    private int[] tableRewards = { -400, 100, 300, 600 };

    // properties
    public float Timer
    {
        get { return timer; }
        private set { timer = value; }
    }
    public int StartPersonNumber
    {
        get { return startPersonNumber; }
        private set { startPersonNumber = value; }
    }
    public int BaseTableTime
    {
        get { return baseTableTime; }
        private set { baseTableTime = value; }
    }
    public int[] TableRewards
    {
        get { return tableRewards; }
        private set { tableRewards = value; }
    }
}
