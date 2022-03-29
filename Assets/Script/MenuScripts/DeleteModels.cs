using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class DeleteModels : MonoBehaviour
{
    private GameObject objectChoisi;
    private GameObject[] container = new GameObject[100];
    private int index = 0;

    public GameObject Objet
    {
        get { return objectChoisi; }
        set { objectChoisi = value; }
    }

    private void Update()
    {
        
        if (objectChoisi != null)
        {
            Debug.Log(objectChoisi);
            container[index] = objectChoisi;
            index++;
            objectChoisi = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    public void DeleteAll()
    {
        Debug.Log("Dedans");
        if (container.Length > 0)
        {
            foreach (GameObject go in container)
            {
                Destroy(go);
            }
        }
        index = 0;
    }
}

