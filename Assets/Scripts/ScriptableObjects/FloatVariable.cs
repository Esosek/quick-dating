using UnityEngine;

[CreateAssetMenu(fileName = "New Floar Variable", menuName = "Variable/Float")]
public class FloatVariable : ScriptableObject {
    public float Value { get; private set; }
    [SerializeField] private GameEvent onChangeEvent;

    public void Set(float _value) {
        Value = _value;
        if(onChangeEvent != null) onChangeEvent.Raise();
    }
}
