using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeModelScript : MonoBehaviour
{
    private GameObject[] pieces = new GameObject[6];
    private Vector3[] vecteurs = new Vector3[6];
    private Vector3 positionInitiale;



    private float distance = 1;
    private int index = 0;
    private float pas = 0.01f;

    public Transform camTransform;

    bool explosion = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            pieces[i] = this.gameObject.transform.GetChild(i).gameObject;
        }

        // Vraiment pas génial
        vecteurs[0] = new Vector3(1, 0, 0);
        vecteurs[1] = new Vector3(0.5f, 0, 0.866f);
        vecteurs[2] = new Vector3(-0.5f, 0, 0.866f);
        vecteurs[3] = new Vector3(-1, 0, 0);
        vecteurs[4] = new Vector3(-0.5f, 0, -0.866f);
        vecteurs[5] = new Vector3(0.5f, 0, -0.866f);
    }

    // Update is called once per frame
    void Update()
    {
        if (explosion)
        {
            ExplodeModel();
        }
    }

    public void ExplodeModel()
    {
        if (index == 0)
        {
            explosion = true;
            positionInitiale = gameObject.transform.position;
            gameObject.transform.position = camTransform.position - new Vector3(0, 0.2f, 0);
            Debug.Log(pieces.Length);
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].transform.localPosition = new Vector3(0,0,0);
            }
        }
        else
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].transform.localPosition += vecteurs[i] * distance * pas;
            }
        }

        if((float)((index-1)*pas) == distance)
        {
            Debug.Log("if");
            explosion = false;
            index = 0;
        }
        else
        {
            Debug.Log("else");
            index++;
        }
    }

    public void Agglomerate()
    {
        

        
    }

}
