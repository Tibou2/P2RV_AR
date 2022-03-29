using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : MonoBehaviour
{
    public GameObject AdvancedPrerfab;
    public GameObject StandardPrefab;
    public GameObject MainMenu;

    private GameObject Parent;
    private GameObject StandardPrefabClone;
    private GameObject AdvancedPrefabClone;
    private bool standard;
    private bool advanced;

    // Start is called before the first frame update
    void Start()
    {
        Parent = GameObject.Find("MixedRealitySceneContent");
        standard = false;
        advanced = false;
    }

    public void Advanced()
    {
        if (!advanced)
        {
            advanced = !advanced;
            AdvancedPrefabClone = Instantiate(AdvancedPrerfab, transform.parent);
        }
        else
        {
            advanced = !advanced;
            Destroy(AdvancedPrefabClone.gameObject);
        }
    }

    public void Standard()
    {
        GameObject.FindGameObjectWithTag("Standard").transform.Rotate(0, 180, 0);
        if (!standard)
        {
            standard = !standard;
            StandardPrefabClone = Instantiate(StandardPrefab, transform.parent);
        }
        else
        {
            standard = !standard;
            Destroy(StandardPrefabClone.gameObject);
        }

    }

    public void Return()
    {
        Instantiate(MainMenu.gameObject, Parent.transform);
        Destroy(GameObject.FindGameObjectWithTag("Hand Menu"));
    }
}
