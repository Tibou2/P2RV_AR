using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class ModelBoundingBox : MonoBehaviour
{
    private BoundingBox bbox;
    private bool Manipulated = false;

    [Header("Box Display")]
    public Material boxMaterial;
    public Material boxGrabbedMaterial;
    public bool ShowWireFrame;

    [Header("Handles")]
    public Material handleMaterial;
    public Material handleGrabbedMaterial;
    public GameObject scaleHandlePrefab;
    public GameObject scaleHandleSlatePrefab;
    public GameObject rotationHandlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        PutBoxAroundIt(transform.gameObject);
    }

    private void PutBoxAroundIt(GameObject target)
    {
        // Ajouter un Bounding Box atour du modèle
        bbox = target.AddComponent<BoundingBox>();

        // Ajouter le gameObject au target du bounding box
        bbox.Target = transform.gameObject;

        // Ajouter un Scale minimum et maximum pour le modèle
        MinMaxScaleConstraint scaleConstraint = bbox.gameObject.GetComponent<MinMaxScaleConstraint>();
        scaleConstraint.ScaleMinimum = 1.0f;
        scaleConstraint.ScaleMaximum = 2.0f;

        // Activation behaviour : Activate By Pointer = Bounding box becomes visible when it is targeted by a hand-ray pointer
        bbox.BoundingBoxActivation = BoundingBox.BoundingBoxActivationType.ActivateByPointer;

        // Ajouter le box collider du modèle comme un Box override pour le boundingBox
        BoxCollider bbox_col = target.GetComponent<BoxCollider>();
        bbox.BoundsOverride = bbox_col;

        // Assigner le style du Handle BoundingBox : HoloLens 2 style
        bbox.HandleMaterial = handleMaterial;
        bbox.HandleGrabbedMaterial = handleGrabbedMaterial;
        bbox.ScaleHandlePrefab = scaleHandlePrefab;
        bbox.ScaleHandleSlatePrefab = scaleHandleSlatePrefab;
        bbox.ScaleHandleSize = 0.016f;
        bbox.ScaleHandleColliderPadding = new Vector3(0.016f, 0.016f, 0.016f);
        bbox.RotationHandlePrefab = rotationHandlePrefab;
        bbox.RotationHandleSize = 0.016f;
        bbox.RotateHandleColliderPadding = new Vector3(0.016f, 0.016f, 0.016f);

        // Proximity effect : Hololens 2 style
        bbox.ProximityEffectActive = true;


        // Définir le style de l'affichage du bounding box (materials)
        bbox.BoxMaterial = boxMaterial;
        bbox.BoxGrabbedMaterial = boxGrabbedMaterial;
        bbox.FlattenAxis = BoundingBox.FlattenModeType.DoNotFlatten;

        // Désactiver le wireFrame
        bbox.ShowWireFrame = ShowWireFrame;

    }

    public void Manipulation()
    {
        Manipulated = !Manipulated;
    }

    public bool GetManipulation
    {
        get {return Manipulated; }
    }

}
