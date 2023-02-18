using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;

/// <summary>
/// Motores Multiplataforma II
/// Script para pintar lineas en el espacio 3D
/// Asignado al objeto vacío líneas, el cual va a servir de contenedor de líneas
/// En el editor hay que asignar:
/// 1-La acción pintarAction, en este caso puede ser default/in/InteractUI
/// 2-El prefab previamente creado que sirve para pintar individualmente cada línea
/// 3-La mano que se utilizará para pintar, por ejemplo, Player/SteamVRObjects/RightHand
/// </summary>
public class pintador : MonoBehaviour
{
    public SteamVR_Action_Boolean pintarAction;
    public GameObject prefabLinea;
    public Color color;
    public Transform hand;
    public bool bTesting = true;
    private Shader shader;
    private  List<LineRenderer> lineas = new List<LineRenderer>();
    
    void Start()
    {
        shader = prefabLinea.GetComponent<LineRenderer>().sharedMaterials[0].shader;
    }
    void Update()
    {
       if ((bTesting) || (!hand .GetComponent<SteamVR_LaserPointer>().enabled))
        {
            if (pintarAction[hand.GetComponent<Hand>().handType].stateDown)
            {
                GameObject lr = GameObject.Instantiate(prefabLinea);
                lr.transform.parent = transform;
                Material mat = new Material(shader);
                lr.GetComponent<LineRenderer>().materials[0] = mat;
                lr.GetComponent<LineRenderer>().materials[0].color = color;
                lineas.Add(lr.GetComponent<LineRenderer>());
            }
            if (pintarAction[hand.GetComponent<Hand>().handType].state)
            {
                if (lineas.Count > 0)
                {
                    lineas[lineas.Count - 1].positionCount += 1;
                    int numPoints = lineas[lineas.Count - 1].positionCount;
                    lineas[lineas.Count - 1].SetPosition(numPoints - 1, hand.position);
                }
            }
        }
    }
    
}
