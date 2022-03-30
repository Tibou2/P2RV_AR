using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;

public class ExplodeModelScript : MonoBehaviour
{
    enum State { agglomerated, exploding, exploded, agglomerating };



    private State etat;

    private GameObject[] pieces = new GameObject[5];

    private Vector3 posInitial = new Vector3();

    private Vector3 positionInitiale;

    private Transform camTransform;

    private float angle = 30.0f;
    private float anglePas = 0.05f;
    private int index;





    // Start is called before the first frame update
    void Start()
    {
        camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            pieces[i] = this.gameObject.transform.GetChild(i).gameObject;
        }

        EnableScripts(true, true);
        EnableScripts(false, false);

        index = 0;
        etat = State.agglomerated;
    }

    // Update is called once per frame
    void Update()
    {
        if(etat == State.exploding) Explode();
        if(etat == State.agglomerating) Agglomerate();
    }

    public void ModelDisplacement()
    {
        Debug.Log("sa rentre dedans");
        if (etat == State.agglomerated)
        {
            etat = State.exploding;
            posInitial = camTransform.position;

            EnableScripts(true, false);

        }
        else if (etat == State.exploded)
        {
            etat = State.agglomerating;
            EnableScripts(false, false);
        }
    }

    public void Explode()
    {
        Debug.Log(index * anglePas);
        if (index * anglePas <= angle)
        {
            pieces[1].transform.RotateAround(posInitial, Vector3.up, anglePas);
            pieces[2].transform.RotateAround(posInitial, Vector3.up, -anglePas);
            pieces[3].transform.RotateAround(posInitial, Vector3.up, anglePas * 2);
            pieces[4].transform.RotateAround(posInitial, Vector3.up, -anglePas * 2);

            index++;
        }
       

        else
        {
            etat = State.exploded;
            index = 0;
            EnableScripts(false, true);
        }

        Debug.Log("sorti");
    }
    public void Agglomerate()
    {
        if (index == 0) 
        {
            for (int i = 0; i < pieces.Length - 1; i++)
            {
                pieces[i].transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
        if (index * anglePas <= angle)
        {
            pieces[1].transform.RotateAround(posInitial, Vector3.up, -anglePas);
            pieces[2].transform.RotateAround(posInitial, Vector3.up, anglePas);
            pieces[3].transform.RotateAround(posInitial, Vector3.up, -anglePas * 2);
            pieces[4].transform.RotateAround(posInitial, Vector3.up, anglePas * 2);

            for (int i = 0; i < pieces.Length - 1; i++)
            {
                pieces[i].transform.GetChild(0).transform.localPosition/= 1.01f;
                pieces[i].transform.GetChild(0).transform.localScale += (new Vector3(1, 1, 1) - pieces[i].transform.GetChild(0).transform.localScale)/100.0f;
            }

            index++;
        }
        else
        {
            etat = State.agglomerated;
            index = 0;

            EnableScripts(true, true);


            for (int i = 0; i < pieces.Length - 1; i++)
            {
                pieces[i].transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
                pieces[i].transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
    
    // Désactive ou active les script permettant l'interaction avec les pieces ou la pièce assemblée parente
    public void EnableScripts(bool parent, bool enable)
    {
        if(parent)
        {
            transform.GetChild(0).GetComponent<ModelBoundingBox>().enabled = false;
            transform.GetChild(0).GetComponent<ObjectManipulator>().enabled = false;
            transform.GetChild(0).GetComponent<NearInteractionGrabbable>().enabled = false;
        }
        else
        {
            for (int i = 0; i < pieces.Length - 1; i++)
            {
                pieces[i].transform.GetChild(0).GetComponent<ModelBoundingBox>().enabled = enable;
                pieces[i].transform.GetChild(0).GetComponent<ObjectManipulator>().enabled = enable;
                pieces[i].transform.GetChild(0).GetComponent<NearInteractionGrabbable>().enabled = enable;
            }
        }
        
    }
}
  

