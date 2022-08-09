using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPerson : MonoBehaviour
{
    void Start()
    {
        GetComponent<Animator>().SetTrigger("sit");
    }
}
