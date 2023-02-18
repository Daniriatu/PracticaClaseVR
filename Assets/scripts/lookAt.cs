using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///Motores Multiplataforma II
/// Este fichero se tiene que copiar dentro de Assets, en la carpeta que se haya destinado a los scripts
/// Sirve para que un elemento se oriente simpre mirando a un punto definido por camtransform.position
/// Se asigna al elemento que se quiere orientar mirando a cámara
/// En el editor hay que asignar la variable pública camtranform, en este caso Player/SteamVRObjects/VRCamera
/// </summary>
public class lookAt : MonoBehaviour
{
    public Transform camtransform;

    void Update()
    {
        transform.LookAt(camtransform.position);
    }
}

