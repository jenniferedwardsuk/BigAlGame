using UnityEngine;

public class HowToscreen : MonoBehaviour
{
    [SerializeField] Canvas thiscanvas;
    [SerializeField] Canvas introcanvas;
    
    public void button1_Click() // play game
    {     
        thiscanvas.gameObject.SetActive(false);
        introcanvas.gameObject.SetActive(true);
    }
}
