using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using state;

public class GenerateOrDetectModel : MonoBehaviour
{
    public GameObject Model;
    public GameObject Hand_Menu;
    public GameObject poubelle;

    private GameObject Parent;
    private GameObject Modelchoisi;
    SelectOrDetect selectOrDetect = new SelectOrDetect();

    private void Start()
    {
        // Rechercher dans la scene le parent MixedRealitySceneContent où on va charger les modèles
        Parent = GameObject.Find("MixedRealitySceneContent");
    }

    private void Update()
    {
        if (!selectOrDetect.Select)
        {
            // On supprime le modèle généré
            Destroy(Modelchoisi.gameObject);
        }
    }

    public void Generate_Or_Detect_Model()
    {

        if (selectOrDetect.Select)
        {
            Modelchoisi = Instantiate(Model, Parent.transform);
            poubelle.GetComponent<DeleteModels>().Objet = Modelchoisi;
        }
        else if (selectOrDetect.Detect)
        {
            // Si on est dans le mode detect on stocke l'objet choisi
            Modelchoisi = Model;
            //on instancie le Hand menu et on suprimme le main menu
            Instantiate(Hand_Menu.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Main Menu"));
        }
    }

}
