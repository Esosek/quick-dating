using UnityEngine;
using UnityEditor;

#if (UNITY_EDITOR)
[CustomEditor(typeof(IntVariable))]
public class IntVariableEditor : Editor
{
    // magic for debugging raising events
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IntVariable _variable = (IntVariable) target;
        if (GUILayout.Button("Add 5"))
        {
            _variable.AddValue(5);
        }
    }
}
#endif