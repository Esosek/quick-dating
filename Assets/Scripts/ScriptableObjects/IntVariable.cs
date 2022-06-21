using UnityEngine;

[CreateAssetMenu(fileName = "New Int Variable", menuName = "Variable/Int")]
public class IntVariable : ScriptableObject {

    public int Value { get; private set; }
    public GameEvent onChangeEvent;

    public void SetValue(int _value)
    {
        Value = _value;
        LogEvent();
    }

    public void AddValue(int _value)
    {
        Value += _value;
        LogEvent();
    }

    public void Reset() {
        Value = 0;
        LogEvent();
    }

    void LogEvent()
    {
        Debug.Log(this.name + " variable changed to " + Value);
        if(onChangeEvent != null) onChangeEvent.Raise();
    }
}