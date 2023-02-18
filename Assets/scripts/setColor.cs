using UnityEngine;

public class setColor : MonoBehaviour
{
    public pintador ObjContenedor;
    public void setC()
    {
        ObjContenedor.color = this.GetComponent<UnityEngine.UI.Image>().color;
    }
}
