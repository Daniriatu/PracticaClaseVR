using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;
/// <summary>
/// Motores Multiplataforma II
/// Permite denifir una lista de objetos que se activan/desactivan al pulsar un botón
/// Opcionalmente, pueden mostrarse solo mientras se pulsa el botón (bActivoDurante)
/// Se asigna a la mano que permite la activación de los objetos, por ejemplo, Player/SteamVRObjects/RightHand
/// En el editor hay que asignar la acción del mando, los objetos a ocultar/mostrar y si se muestran o no solo mientras se pulsa el botón
/// </summary>
public class showByAction : MonoBehaviour
{
    public SteamVR_Action_Boolean activaObjetos;
    public bool bActivoDurante = false;
    public List<GameObject> listaObjetosMostrar = new List<GameObject> ();
    void Start()
    {
        Activar(false);
    }

    void Update()
    {
        if (bActivoDurante)
        {
            if (activaObjetos[this.GetComponent<Hand>().handType].state )
            {
                Activar(true);
            }
            if (activaObjetos[this.GetComponent<Hand>().handType].stateUp)
            {
                Activar(false);
            }
        }
        else
        {
            if (activaObjetos[this.GetComponent<Hand>().handType].stateDown)
            {
                if (listaObjetosMostrar .Count >0)
                {
                    bool bState = listaObjetosMostrar[0].activeSelf;
                    Activar(!bState );
                }
            }
        }
    }

    public void Activar(bool bActivar)
    {
        for (int i = 0; i < listaObjetosMostrar.Count; i++)
        {
            listaObjetosMostrar[i].SetActive(bActivar);
        }
    }
}
