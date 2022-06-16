using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonColors : MonoBehaviour
{
    [SerializeField] private GameObject hair = null;
    [SerializeField] private GameObject shoes = null;
    [SerializeField] private GameObject dress = null;
    [SerializeField] private GameObject jeans = null;

    [SerializeField] private Material[] hairMaterialPool = null;
    [SerializeField] private Material[] shoesMaterialPool = null;
    [SerializeField] private Material[] dressMaterialPool = null;
    [SerializeField] private Material[] jeansMaterialPool = null;
}
