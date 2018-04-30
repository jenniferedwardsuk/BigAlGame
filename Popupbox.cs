using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays a popup window (canvas) with customisable buttons and text.
/// </summary>
public class Popupbox : MonoBehaviour
{
    Canvas thiscanvas;

    public void Awake()
    {
        GameObject popupholder = GameObject.Find("Popups");
        thiscanvas = FindObject(popupholder, "PopupCanvas").GetComponent<Canvas>();
    }

    public GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }

    public void showPopupbox()
    {
        dopopup("POPUP MESSAGE NOT FOUND", "OH NO", "nevermind", "", "");
    }

    public void showPopupbox(string message, string buttonText1, string buttonText2)
    {
        dopopup(message, buttonText1, buttonText2, "", "");
    }

    public void showPopupbox(string message, string buttonText1, string buttonText2, string buttonText3, string buttonText4)
    {
        dopopup(message, buttonText1, buttonText2, buttonText3, buttonText4);
    }


    private void dopopup(string message, string buttonText1, string buttonText2, string buttonText3, string buttonText4)
    {
        if (!thiscanvas)
        {
            GameObject popupholder = GameObject.Find("Popups");
            thiscanvas = FindObject(popupholder, "PopupCanvas").GetComponent<Canvas>();
        }
        thiscanvas.gameObject.SetActive(true);
        GameObject.Find("PopupButton1").GetComponent<Image>().enabled = true;
        GameObject.Find("PopupButtonText1").GetComponent<Text>().enabled = true;
        GameObject.Find("PopupButton2").GetComponent<Image>().enabled = true;
        GameObject.Find("PopupButtonText2").GetComponent<Text>().enabled = true;
        GameObject.Find("PopupButton3").GetComponent<Image>().enabled = true;
        GameObject.Find("PopupButtonText3").GetComponent<Text>().enabled = true;
        GameObject.Find("PopupButton4").GetComponent<Image>().enabled = true;
        GameObject.Find("PopupButtonText4").GetComponent<Text>().enabled = true;
        GameObject.Find("PopupText").GetComponent<Text>().text = message;
        GameObject.Find("PopupButtonText1").GetComponent<Text>().text = buttonText1;
        GameObject.Find("PopupButtonText2").GetComponent<Text>().text = buttonText2;
        GameObject.Find("PopupButtonText3").GetComponent<Text>().text = buttonText3;
        GameObject.Find("PopupButtonText4").GetComponent<Text>().text = buttonText4;
        if (buttonText1 == "")
        {
            GameObject.Find("PopupButton1").GetComponent<Image>().enabled = false;
            GameObject.Find("PopupButtonText1").GetComponent<Text>().enabled = false;
        };
        if (buttonText2 == "")
        {
            GameObject.Find("PopupButton2").GetComponent<Image>().enabled = false;
            GameObject.Find("PopupButtonText2").GetComponent<Text>().enabled = false;
        };
        if (buttonText3 == "")
        {
            GameObject.Find("PopupButton3").GetComponent<Image>().enabled = false;
            GameObject.Find("PopupButtonText3").GetComponent<Text>().enabled = false;
        };
        if (buttonText4 == "")
        {
            GameObject.Find("PopupButton4").GetComponent<Image>().enabled = false;
            GameObject.Find("PopupButtonText4").GetComponent<Text>().enabled = false;
        };
    }
    public event EventHandler Button1Clicked;
    public event EventHandler Button2Clicked;
    public event EventHandler Button3Clicked;
    public event EventHandler Button4Clicked;

    public void button1_Click()
    {
        EventArgs e = new EventArgs();
        Button1Clicked(this, e);
        thiscanvas.gameObject.SetActive(false);
    }

    public void button2_Click()
    {
        EventArgs e = new EventArgs();
        Button2Clicked(this, e);
        thiscanvas.gameObject.SetActive(false);
    }

    public void button3_Click()
    {
        EventArgs e = new EventArgs();
        Button3Clicked(this, e);
        thiscanvas.gameObject.SetActive(false);
    }

    public void button4_Click()
    {
        EventArgs e = new EventArgs();
        Button4Clicked(this, e);
        thiscanvas.gameObject.SetActive(false);
    }
}
