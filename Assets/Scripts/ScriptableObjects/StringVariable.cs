using UnityEngine;

[CreateAssetMenu(fileName = "New String Variable", menuName = "Variable/String")]
public class StringVariable : ScriptableObject {

    public string Value { get { return currentValue; } private set { currentValue = value; } }
    [SerializeField] private string currentValue;
    public GameEvent onChangeEvent;

    public void SetValue(string _value)
    {
        Value = _value;
        LogEvent();
    }

    void LogEvent()
    {
        Debug.Log(this.name + " variable changed to " + Value);
        if(onChangeEvent != null) onChangeEvent.Raise();
    }
}