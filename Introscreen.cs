using UnityEngine;

public class Introscreen : MonoBehaviour
{
    Canvas thiscanvas;

    public void Awake()
    {
        GameObject popupholder = GameObject.Find("Popups");
        thiscanvas = AlGlobalVar.FindObject(popupholder, "IntroscreenCanvas").GetComponent<Canvas>();
        thiscanvas.gameObject.SetActive(true);
        GameObject.Find("GameController").GetComponent<BigAlGame>().pause = true;
    }

    public void button1_Click() // howto screen
    {
        GameObject popupholder = GameObject.Find("Popups");
        Canvas howtocanvas = AlGlobalVar.FindObject(popupholder, "HowToscreenCanvas").GetComponent<Canvas>();
        if (howtocanvas)
        {
            howtocanvas.gameObject.SetActive(true);
            thiscanvas.gameObject.SetActive(false);
        }
    }

    public void button2_Click() // play game
    {
        thiscanvas.gameObject.SetActive(false);      
        GameObject.Find("GameController").GetComponent<BigAlGame>().setupscreen();
    }

    public void button3_Click() // close window
    {
        Application.Quit();
    }   
}
