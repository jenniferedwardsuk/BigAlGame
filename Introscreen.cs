using UnityEngine;

public class Introscreen : MonoBehaviour
{
    [SerializeField] Canvas thiscanvas;
    [SerializeField] BigAlGame bigAlGame;
    [SerializeField] Canvas howtocanvas;

    public void Awake()
    {
        thiscanvas.gameObject.SetActive(true);
        bigAlGame.pause = true;
    }

    public void button1_Click() // howto screen
    {
        howtocanvas.gameObject.SetActive(true);
        thiscanvas.gameObject.SetActive(false);
    }

    public void button2_Click() // play game
    {
        thiscanvas.gameObject.SetActive(false);
        bigAlGame.setupscreen();
    }

    public void button3_Click() // close window
    {
        Application.Quit();
    }   
}
