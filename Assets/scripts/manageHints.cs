using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class manageHints : MonoBehaviour
{
    public bool bActivateHints = false;
    private bool bAnterior = true;
   
    void Update()
    {
        if (bActivateHints != bAnterior )
        {
            if (bActivateHints )
            {
                this.GetComponent<Teleport>().ShowTeleportHint();
            }
            else
            {
                this.GetComponent<Teleport>().CancelTeleportHint();
            }
        }
        bAnterior = bActivateHints;
    }
}