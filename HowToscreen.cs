using UnityEngine;

public class HowToscreen : MonoBehaviour
{
    Canvas thiscanvas;
    Canvas introcanvas;

    public void Awake()
    {
        GameObject popupholder = GameObject.Find("Popups");
        thiscanvas = AlGlobalVar.FindObject(popupholder, "HowToscreenCanvas").GetComponent<Canvas>();
        introcanvas = AlGlobalVar.FindObject(popupholder, "IntroscreenCanvas").GetComponent<Canvas>();
    }
    
    public void button1_Click() // play game
    {
        if (!thiscanvas)
            Awake();        
        thiscanvas.gameObject.SetActive(false);
        introcanvas.gameObject.SetActive(true);
    }
}
