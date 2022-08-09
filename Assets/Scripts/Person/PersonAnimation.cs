using UnityEngine;

public class PersonAnimation : MonoBehaviour
{
    [SerializeField] private int idleAnimationsCount = 3;
    [SerializeField] private int sitAnimationCount = 2;

    [SerializeField] private Animator anim = null;
    [SerializeField] private bool startSeated = false;

    private void Start() {
        SetAnimationsVariation(); // to randomize starting state
        if(startSeated) anim.SetTrigger("sit"); // people start seated in menu
    }

    void SetAnimationsVariation() {
        int _newIdleIndex = Random.Range(0, idleAnimationsCount);
        anim.SetInteger("standVariant", _newIdleIndex);

        int _newSitIndex = Random.Range(0, sitAnimationCount);
        anim.SetInteger("sitVariant", _newSitIndex);
    }
}
