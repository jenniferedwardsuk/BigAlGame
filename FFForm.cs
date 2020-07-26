using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FFForm : MonoBehaviour
{
    [SerializeField] Canvas thiscanvas;
    [SerializeField] Text labelcount;
    [SerializeField] Text labelFF;
    [SerializeField] Dropdown comboBox1;
    [SerializeField] Text comboBox1Text;
    [SerializeField] Image pictureFF;

    public GameObject comboBoxtemplate;

    public void Awake()
    {
        Color textcolour = comboBox1Text.color;
        textcolour.a = 0;
        comboBox1Text.color = textcolour;

        comboBox1.gameObject.SetActive(false);
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

        Color textcolour = comboBox1Text.color;
        textcolour.a = 1;
        comboBox1Text.color = textcolour;

        comboBox1.gameObject.SetActive(true);

        List<AlEnemies> EnemiesSeen = GameData.Enemies.FindAll(x => x.Seen);
        int seencount = EnemiesSeen.Count;
        int totalenemies = GameData.Enemies.Count;
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
            comboBox1.value = EnemiesSeen.IndexOf(GameData.Enemies.Find(x => x.Name == AlGlobalVar.currFF));
            comboBox1.RefreshShownValue();

            int FFimageID = GameData.Enemies.Find(x => x.Name == AlGlobalVar.currFF).ImageID;
            pictureFF.enabled = true;
            pictureFF.sprite = Resources.Load("pictureFF" + FFimageID, typeof(Sprite)) as Sprite;

            labelFF.enabled = true;
            labelFF.text = GameData.AlFactFiles.Find(x => x.Name == AlGlobalVar.currFF).Facts;
        }
    }

    public void comboBox1_SelectedIndexChanged()
    {
        List<AlEnemies> EnemiesSeen = GameData.Enemies.FindAll(x => x.Seen);

       string FFitem = EnemiesSeen[comboBox1.value].Name;
        AlGlobalVar.currFF = FFitem;

        int FFimageID = GameData.Enemies.Find(x => x.Name == AlGlobalVar.currFF).ImageID;
        pictureFF.enabled = true;
        pictureFF.sprite = Resources.Load("pictureFF" + FFimageID, typeof(Sprite)) as Sprite;

        labelFF.enabled = true;
        labelFF.text = GameData.AlFactFiles.Find(x => x.Name == AlGlobalVar.currFF).Facts;
    }

    public void CloseButtonClicked()
    {
        thiscanvas.gameObject.SetActive(false);

        Color textcolour = comboBox1Text.color;
        textcolour.a = 0;
        comboBox1Text.color = textcolour;

        comboBox1.gameObject.SetActive(false);
    }
}
