using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FFForm : MonoBehaviour
{
    Canvas thiscanvas;
    Text labelcount;
    Text labelFF;
    Dropdown comboBox1;
    Image pictureFF;

    public GameObject comboBoxtemplate;

    public void Awake()
    {
        GameObject popupholder = GameObject.Find("Popups");
        thiscanvas = AlGlobalVar.FindObject(popupholder, "FFCanvas").GetComponent<Canvas>();

        labelcount = AlGlobalVar.FindObject(thiscanvas.gameObject, "labelcount").GetComponent<Text>();
        labelFF = AlGlobalVar.FindObject(thiscanvas.gameObject, "labelFF").GetComponent<Text>();

        pictureFF = AlGlobalVar.FindObject(thiscanvas.gameObject, "pictureFF").GetComponent<Image>();
        
        Canvas dropdowncanvas = GameObject.Find("DropdownCanvas").GetComponent<Canvas>();
        comboBox1 = AlGlobalVar.FindObject(dropdowncanvas.gameObject, "comboBox1").GetComponent<Dropdown>();

        Color textcolour = comboBox1.GetComponentInChildren<Text>().color;
        textcolour.a = 0;
        comboBox1.GetComponentInChildren<Text>().color = textcolour;

        ColorBlock dropdowncolours = comboBox1.colors;
        Color normalcolour = comboBox1.colors.disabledColor;
        Color normalcolour2 = comboBox1.colors.highlightedColor;
        Color normalcolour3 = comboBox1.colors.normalColor;
        Color normalcolour4 = comboBox1.colors.pressedColor;
        normalcolour.a = 0;
        normalcolour2.a = 0;
        normalcolour3.a = 0;
        normalcolour4.a = 0;
        dropdowncolours.disabledColor = normalcolour;
        dropdowncolours.highlightedColor = normalcolour2;
        dropdowncolours.normalColor = normalcolour3;
        dropdowncolours.pressedColor = normalcolour4;
        comboBox1.colors = dropdowncolours;
    }

    public void showFFForm()
    {
        setupscreen();
    }
    public void setupscreen()
    {
        if (!thiscanvas)
        {
            Awake();
        }
        thiscanvas.gameObject.SetActive(true);
        comboBox1.enabled = true;

        Color textcolour = comboBox1.GetComponentInChildren<Text>().color;
        textcolour.a = 255;
        comboBox1.GetComponentInChildren<Text>().color = textcolour;

        ColorBlock dropdowncolours = comboBox1.colors;
        Color normalcolour = comboBox1.colors.disabledColor;
        Color normalcolour2 = comboBox1.colors.highlightedColor;
        Color normalcolour3 = comboBox1.colors.normalColor;
        Color normalcolour4 = comboBox1.colors.pressedColor;
        normalcolour.a = 255;
        normalcolour2.a = 255;
        normalcolour3.a = 255;
        normalcolour4.a = 255;
        dropdowncolours.disabledColor = normalcolour;
        dropdowncolours.highlightedColor = normalcolour2;
        dropdowncolours.normalColor = normalcolour3;
        dropdowncolours.pressedColor = normalcolour4;
        comboBox1.colors = dropdowncolours;

        List<AlEnemies> EnemiesSeen = AlGlobalVar.Enemies.FindAll(x => x.Seen);
        int seencount = EnemiesSeen.Count;
        int totalenemies = AlGlobalVar.Enemies.Count;
        labelcount.text = "You have encountered " + seencount + " out of " + totalenemies + " species in the game.";

        comboBox1.options.Clear();
        for (int n = 0; n < EnemiesSeen.Count(); n++)
        {
            string c = EnemiesSeen[n].Name;
            comboBox1.options.Add(new Dropdown.OptionData() { text = c });
            comboBox1.RefreshShownValue();
        }
        if (AlGlobalVar.currFF == "Missingno")
        {
            pictureFF.enabled = false;
            labelFF.enabled = false;
        }
        else
        {
            comboBox1.value = EnemiesSeen.IndexOf(AlGlobalVar.Enemies.Find(x => x.Name == AlGlobalVar.currFF));
            comboBox1.RefreshShownValue();

            int FFimageID = AlGlobalVar.Enemies.Find(x => x.Name == AlGlobalVar.currFF).ImageID;
            pictureFF.enabled = true;
            pictureFF.sprite = Resources.Load("pictureFF" + FFimageID, typeof(Sprite)) as Sprite;

            labelFF.enabled = true;
            labelFF.text = AlGlobalVar.AlFactFiles.Find(x => x.Name == AlGlobalVar.currFF).Facts;
        }
    }

    public void comboBox1_SelectedIndexChanged()
    {
        List<AlEnemies> EnemiesSeen = AlGlobalVar.Enemies.FindAll(x => x.Seen);

       string FFitem = EnemiesSeen[comboBox1.value].Name;
        AlGlobalVar.currFF = FFitem;

        int FFimageID = AlGlobalVar.Enemies.Find(x => x.Name == AlGlobalVar.currFF).ImageID;
        pictureFF.enabled = true;
        pictureFF.sprite = Resources.Load("pictureFF" + FFimageID, typeof(Sprite)) as Sprite;

        labelFF.enabled = true;
        labelFF.text = AlGlobalVar.AlFactFiles.Find(x => x.Name == AlGlobalVar.currFF).Facts;
    }

    public void CloseButtonClicked()
    {
        thiscanvas.gameObject.SetActive(false);

        Color textcolour = comboBox1.GetComponentInChildren<Text>().color;
        textcolour.a = 0;
        comboBox1.GetComponentInChildren<Text>().color = textcolour;

        ColorBlock dropdowncolours = comboBox1.colors;
        Color normalcolour = comboBox1.colors.disabledColor;
        Color normalcolour2 = comboBox1.colors.highlightedColor;
        Color normalcolour3 = comboBox1.colors.normalColor;
        Color normalcolour4 = comboBox1.colors.pressedColor;
        normalcolour.a = 0;
        normalcolour2.a = 0;
        normalcolour3.a = 0;
        normalcolour4.a = 0;
        dropdowncolours.disabledColor = normalcolour;
        dropdowncolours.highlightedColor = normalcolour2;
        dropdowncolours.normalColor = normalcolour3;
        dropdowncolours.pressedColor = normalcolour4;
        comboBox1.colors = dropdowncolours;
    }
}
