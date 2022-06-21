using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAnimation : MonoBehaviour
{
    [SerializeField] private int idleAnimationsCount = 3;
    [SerializeField] private int sitAnimationCount = 2;

    [SerializeField] private Animator anim = null;

    private void Start() => SetAnimationsVariation(); // to randomize starting state

    void SetAnimationsVariation() {
        int _newIdleIndex = Random.Range(0, idleAnimationsCount);
        anim.SetInteger("standVariant", _newIdleIndex);

        int _newSitIndex = Random.Range(0, sitAnimationCount);
        anim.SetInteger("sitVariant", _newSitIndex);
    }
}
