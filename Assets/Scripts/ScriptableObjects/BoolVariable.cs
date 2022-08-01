using UnityEngine;

[CreateAssetMenu(fileName = "New Bool Variable", menuName = "Variable/Bool")]
public class BoolVariable : ScriptableObject {
    public bool IsActive { 
        get { return isActive; } 
        private set { isActive = value; } 
        }
        
    [SerializeField] private bool isActive = false;
    [SerializeField] private GameEvent onChangeEvent;

    public void Set(bool value) {
        IsActive = value;
        if(onChangeEvent != null) onChangeEvent.Raise();
    }
}