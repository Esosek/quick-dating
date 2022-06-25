using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attached to Male and Female models
public class PersonColors : MonoBehaviour
{
    [SerializeField] private GameObject hair = null;
    [SerializeField] private GameObject mustache = null;
    [SerializeField] private GameObject shoes = null;
    [SerializeField] private GameObject dress = null;
    [SerializeField] private GameObject jeans = null;

    [SerializeField] private Material[] hairMaterialPool = null;
    [SerializeField] private Material[] shoesMaterialPool = null;
    [SerializeField] private Material[] dressMaterialPool = null;
    [SerializeField] private Material[] jeansMaterialPool = null;

    private void Start() {
        SetColor(hair, hairMaterialPool);
        SetColor(shoes, shoesMaterialPool);
        SetColor(dress, dressMaterialPool);
        SetColor(jeans, jeansMaterialPool);

        if(mustache == null) return;
        mustache.GetComponent<Renderer>().sharedMaterial = hair.GetComponent<Renderer>().sharedMaterial;
    }

    void SetColor(GameObject item, Material[] sourceArray) {
        if(item == null) return; // null check
        int _index = Random.Range(0, sourceArray.Length);
        item.GetComponent<Renderer>().sharedMaterial = sourceArray[_index];
    }
}
