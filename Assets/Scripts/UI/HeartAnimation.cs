using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAnimation : MonoBehaviour
{
    [SerializeField] private float minShakeSpeed = 0.2f;
    [SerializeField] private float maxShakeSpeed = 2f;

    private float shakeSpeed = 1f;
    private Animator anim = null;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        shakeSpeed = Random.Range(minShakeSpeed, maxShakeSpeed);
        anim.speed = shakeSpeed;
    }
}
