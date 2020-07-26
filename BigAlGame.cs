using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BigAlGame : MonoBehaviour {

    // Unity object equivalents for the Windows Forms controls that were originally used:
    // images
    public Image compassimage;
    // text
    public Text label1;
    public Text labelenergy;
    public Text labelscore;
    public Text labellevel;
    public Text labelweight;
    public Text labelfitness;
    public Text labeldesc;
    public Text labelenemy1;
    public Text labelenemyname1;
    public Text labelenemy1data;
    public Text labelenemy2;
    public Text labelenemyname2;
    public Text labelenemy2data;
    public Text labelenemy3;
    public Text labelenemyname3;
    public Text labelenemy3data;
    public Text labelenemy4;
    public Text labelenemyname4;
    public Text labelenemy4data;
    // buttons
    public Button buttonpause;
    public Button attackbutton1;
    public Button attackbutton2;
    public Button attackbutton3;
    public Button attackbutton4;
    public Button FFbutton1;
    public Button FFbutton2;
    public Button FFbutton3;
    public Button FFbutton4;
    // SpriteRenderers
    public GameObject newpictureBox1;
    public GameObject newpicturemap84;
    public GameObject newpicturealfitnessred;
    public GameObject newpicturealfitnessgreen;
    public GameObject newpicturealfitnessyellow;
    public GameObject newpicturealenergyred;
    public GameObject newpicturealenergygreen;
    public GameObject newpicturealenergyyellow;
    public GameObject newpicturealweight;
    public GameObject newpictureenemy1;
    public GameObject newpicturee1energybar;
    public GameObject newpicturee1fiercebar;
    public GameObject newpicturee1agilitybar;
    public GameObject newpictureenemy2;
    public GameObject newpicturee2energybar;
    public GameObject newpicturee2fiercebar;
    public GameObject newpicturee2agilitybar;
    public GameObject newpictureenemy3;
    public GameObject newpicturee3energybar;
    public GameObject newpicturee3fiercebar;
    public GameObject newpicturee3agilitybar;
    public GameObject newpictureenemy4;
    public GameObject newpicturee4energybar;
    public GameObject newpicturee4fiercebar;
    public GameObject newpicturee4agilitybar;

    // forms-to-unity converted controls/objects:
    [HideInInspector] FormsObject pictureBox1;
    [HideInInspector] FormsObject picturemap84;
    [HideInInspector] FormsObject picturealfitnessred;
    [HideInInspector] FormsObject picturealfitnessgreen;
    [HideInInspector] FormsObject picturealfitnessyellow;
    [HideInInspector] FormsObject picturealenergyred;
    [HideInInspector] FormsObject picturealenergygreen;
    [HideInInspector] FormsObject picturealenergyyellow;
    [HideInInspector] FormsObject picturealweight;
    [HideInInspector] FormsObject pictureenemy1;
    [HideInInspector] FormsObject picturee1energybar;
    [HideInInspector] FormsObject picturee1fiercebar;
    [HideInInspector] FormsObject picturee1agilitybar;
    [HideInInspector] FormsObject pictureenemy2;
    [HideInInspector] FormsObject picturee2energybar;
    [HideInInspector] FormsObject picturee2fiercebar;
    [HideInInspector] FormsObject picturee2agilitybar;
    [HideInInspector] FormsObject pictureenemy3;
    [HideInInspector] FormsObject picturee3energybar;
    [HideInInspector] FormsObject picturee3fiercebar;
    [HideInInspector] FormsObject picturee3agilitybar;
    [HideInInspector] FormsObject pictureenemy4;
    [HideInInspector] FormsObject picturee4energybar;
    [HideInInspector] FormsObject picturee4fiercebar;
    [HideInInspector] FormsObject picturee4agilitybar;
    [HideInInspector] FormsObject formobjectscript;

    Vector2 picturealweightposition = new Vector2(0, 193.5f);
    Vector2 picturealweightminsize = new Vector2(138 * 0.2f, 207 * 0.2f);
    Vector2 picturealweightfullsize = new Vector2(138, 207);

    [HideInInspector] Hashtable controlHashtable = new Hashtable();
    
    public float newfivetimer;
    public float neweventimer;

    [SerializeField] GameObject popupholder; //Popups
    [SerializeField] GameObject popupcanvas; //PopupCanvas
    [SerializeField] Popupbox Popupbox;
    [SerializeField] FFForm FFForm;
    [SerializeField] GameObject introcanvas;
    [SerializeField] GameObject howtocanvas;
    [SerializeField] GameObject FFcanvas;

    public void Start()
    {
        pause = true; // pause game while intro screen is displayed

        // generate map objects
        MapGenerator mapcreator = GetComponent<MapGenerator>();
        mapcreator.createmapsquares();

        // add support for Forms properties
        newpicturemap84 = GameObject.Find("picturemap84"); // starting square
        pictureBox1 = new FormsObject(newpictureBox1.name);
        picturemap84 = new FormsObject(newpicturemap84.name);
        picturealfitnessgreen = new FormsObject(newpicturealfitnessgreen.name);
        picturealenergygreen = new FormsObject(newpicturealenergygreen.name);
        picturealweight = new FormsObject(newpicturealweight.name);
        Vector2 alsize = newpicturealweight.GetComponent<RectTransform>().sizeDelta;
        picturealweightminsize = new Vector2(alsize.x * 0.2f, alsize.y * 0.2f);
        picturealweightfullsize = alsize;
        picturealweightposition = newpicturealweight.GetComponent<RectTransform>().position;
        pictureenemy1 = new FormsObject(newpictureenemy1.name);
        picturee1energybar = new FormsObject(newpicturee1energybar.name);
        picturee1fiercebar = new FormsObject(newpicturee1fiercebar.name);
        picturee1agilitybar = new FormsObject(newpicturee1agilitybar.name);
        pictureenemy2 = new FormsObject(newpictureenemy2.name);
        picturee2energybar = new FormsObject(newpicturee2energybar.name);
        picturee2fiercebar = new FormsObject(newpicturee2fiercebar.name);
        picturee2agilitybar = new FormsObject(newpicturee2agilitybar.name);
        pictureenemy3 = new FormsObject(newpictureenemy3.name);
        picturee3energybar = new FormsObject(newpicturee3energybar.name);
        picturee3fiercebar = new FormsObject(newpicturee3fiercebar.name);
        picturee3agilitybar = new FormsObject(newpicturee3agilitybar.name);
        pictureenemy4 = new FormsObject(newpictureenemy4.name);
        picturee4energybar = new FormsObject(newpicturee4energybar.name);
        picturee4fiercebar = new FormsObject(newpicturee4fiercebar.name);
        picturee4agilitybar = new FormsObject(newpicturee4agilitybar.name);

        // setup control quick-access
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);
        foreach (GameObject c in rootObjects)
        {
            Transform[] objectwithchildren = c.GetComponentsInChildren<Transform>(true);
            for (int n = 0; n < objectwithchildren.Count(); n++)
            {
                GameObject foundobject = objectwithchildren[n].gameObject;
                this.controlHashtable.Add(foundobject.name, foundobject);
            }
        }
        controlsetup();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            buttonpause_Click();
        }
        if (!pause && CanClick(checkClickCooldown: false))
        {
            CheckInput();
            updatetimer();
        }

        if (currentClickCooldown > 0)
            currentClickCooldown -= Time.deltaTime;
    }

    public void SetCompassImage()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Keypad5) )
        {
            compassimage.sprite = Resources.Load("compasswait", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            compassimage.sprite = Resources.Load("compassnorth", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Keypad2))
        {
            compassimage.sprite = Resources.Load("compasssouth", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Keypad4))
        {
            compassimage.sprite = Resources.Load("compasswest", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Keypad6))
        {
            compassimage.sprite = Resources.Load("compasseast", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Keypad7))
        {
            compassimage.sprite = Resources.Load("compassnwest", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Keypad9))
        {
            compassimage.sprite = Resources.Load("compassneast", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Keypad1))
        {
            compassimage.sprite = Resources.Load("compassswest", typeof(Sprite)) as Sprite;
        }
        else if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Keypad3))
        {
            compassimage.sprite = Resources.Load("compassseast", typeof(Sprite)) as Sprite;
        }
        else
        {
            compassimage.sprite = Resources.Load("compassbig", typeof(Sprite)) as Sprite;
        }

    }


    public void CheckInput()
    {
        SetCompassImage();
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            buttonwait_Click();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            buttonnorth_Click();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            buttonsouth_Click();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            buttonwest_Click();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            buttoneast_Click();
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            buttonnwest_Click();
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            buttonneast_Click();
        }
        else if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            buttonswest_Click();
        }
        else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            buttonseast_Click();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (pictureenemy1.GetSpriteRenderer().enabled)
                    attackbutton_Click(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (pictureenemy2.GetSpriteRenderer().enabled)
                    attackbutton_Click(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (pictureenemy3.GetSpriteRenderer().enabled)
                    attackbutton_Click(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (pictureenemy4.GetSpriteRenderer().enabled)
                    attackbutton_Click(4);
            }
        }
    }
    

    public GameObject GetControlByName(string name)
    {
        if (this.controlHashtable[name] == null)
        {
            Debug.Log("Control not found for " + name);
            Debug.Log("Control count = " + controlHashtable.Count);
        }
        return this.controlHashtable[name] as GameObject;
    }


    [HideInInspector] static System.Random random = new System.Random();
    [HideInInspector] static int alcloc1 = 8;
    [HideInInspector] static int alcloc2 = 4;
    [HideInInspector] static int mloc1 = 8;
    [HideInInspector] static int mloc2 = 4;
    [HideInInspector] public bool pause;
    [HideInInspector] static bool[,] lastlvlmap = new bool[10, 17]; // holds state of map at start of each level, used for 'restart level'
    [HideInInspector] static bool[,] lvlmap = new bool[10, 17]; // holds state of map for mum movement
    [HideInInspector] static List<String> enemylist = new List<String>(4);
    [HideInInspector] public bool atkdone = true;
    [HideInInspector] public bool Popupbox1 = false;
    [HideInInspector] public bool Popupbox2 = false;
    [HideInInspector] public bool Popupbox3 = false;
    [HideInInspector] public bool Popupbox4 = false;
    [HideInInspector] public bool allevelup = false;

    #region levelspecific variables
    // level 1
    private bool mumexists = false;
    private bool mumwait = false;
    private bool mumknows = true;
    // level 3
    private int matecount = 0;
    private int packsize1 = 0;
    private int packsize2 = 0;
    private int currpacksize = 0;
    private bool lvl3cap = false; // used to show lvl3 hint only once
    private bool diplohunted = false;
    // throughout
    private bool explorebonus = false;
    private bool seenbonus = false;
    #endregion levelspecific variables

    #region timer
    [HideInInspector] public static bool fivetimer = false;
    [HideInInspector] public static int fivecount = 0;
    [HideInInspector] public bool eventimer = true;
    [HideInInspector] public bool timerstarted = false;
    float timechange = 0;

    public void updatetimer()
    {
        timechange += Time.deltaTime;
        if (timechange > 2f) // time interval of 4 seconds
        {
            timechange = 0;
            TimerEventProcessor();
        }
    }

    // fivetimer is used to decide when enemies will flee or attack, and when mum will move
    public void resetfiveTimer()
    {
        fivetimer = false;
        fivecount = 0;
    }

    // timer tick method
    public void TimerEventProcessor()
    {
        // al's energy decreases on every other tick. enemy/mum behaviour is checked on every tick (if al didn't die yet)
        eventimer = !eventimer;
        if (eventimer == true && AlGlobalVar.EnergyValue < 1 && AlGlobalVar.FitnessValue > 0) // check if al has just starved
        {
            AlGlobalVar.EnergyValue = 0;
            labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
            gameover("You have died of starvation.");
        }
        else if (AlGlobalVar.FitnessValue == 0) // if al is dead, do nothing
        { }
        else
        {
            if (eventimer == true)
            {
                AlGlobalVar.EnergyValue = AlGlobalVar.EnergyValue - 1;
                labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
            }
            if (fivetimer == true)
            {
                fivecount = fivecount + 1;
                if (fivecount == 4 || fivecount == 8)
                {
                    fleefightenemies();
                    if (fivecount == 8)
                        fivecount = 0;
                }
                if (fivecount == 6 && AlGlobalVar.LevelValue == 1 && mumexists)
                {
                    setmumloc();
                }
            }
        }
    }
    #endregion timer
    
    public void setupscreen() // sets up the game screen for a new game
    {
        // reset vars
        gameovercheck = false;
        pause = false;
        mumwait = false;
        mumknows = true;
        mumexists = false;
        matecount = 0;
        packsize1 = 0;
        packsize2 = 0;
        currpacksize = 0;
        lvl3cap = false;
        diplohunted = false;
        SpriteRenderer maprender2 = picturemap84.GetSpriteRenderer();
        maprender2.enabled = true;
        maprender2.color = new Color(maprender2.color.r, maprender2.color.g, maprender2.color.b, 255);

        // reset stats
        AlGlobalVar.ScoreValue = 0;
        labelscore.text = "Score: 0";
        AlGlobalVar.lastlvlScore = AlGlobalVar.ScoreValue;
        AlGlobalVar.LevelValue = 1;
        labellevel.text = "Level: 1";
        AlGlobalVar.WeightValue = 0.2;
        labelweight.text = "Weight: 0.2kg";
        AlGlobalVar.FitnessValue = 100;
        labelfitness.text = "Fitness: 100%";
        AlGlobalVar.EnergyValue = 100;
        labelenergy.text = "Energy: 100%";
        AlGlobalVar.algrowspeed = AlGlobalVar.GetAlGrowSpeed();
        
        // reset location
        alcloc1 = 8; // default al starting location
        alcloc2 = 4;
        mloc1 = 8; // default mum starting location
        mloc2 = 4;
        AlGlobalVar.lastlvlcloc1 = alcloc1; // default al's saved location (later used for 'restart level')
        AlGlobalVar.lastlvlcloc2 = alcloc2;


        // save map
        for (int c1 = 1; c1 < 11; c1++)
            for (int c2 = 1; c2 < 18; c2++)
            {
                SpriteRenderer maprender3 = GetControlByName("picturemap" + c1 + c2).GetComponent<SpriteRenderer>();
                if (maprender3.color.a == 255)
                {
                    lastlvlmap[c1 - 1, c2 - 1] = true;
                }
                else
                {
                    lastlvlmap[c1 - 1, c2 - 1] = false;
                }
            }
        lastlvlmap[7, 3] = true;
        lvlmap[7, 3] = true;
        string scloc = "" + alcloc1 + alcloc2;
        int scloc2 = int.Parse(scloc);
        labeldesc.text = "You are " + GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Name;
        labeldesc.color = Color.white;
        labeldesc.fontStyle = FontStyle.Normal;

        updatelocscreen(alcloc1, alcloc2);
        setupenemies();
        updateAlstats();

        // hide enemies
        for (int n = 1; n < 5; n++)
        {
            GetControlByName("pictureenemy" + n).GetComponent<SpriteRenderer>().enabled = false;
            GetControlByName("labelenemy" + n).GetComponent<Text>().enabled = false;
            GetControlByName("labelenemyname" + n).GetComponent<Text>().enabled = false;
            GetControlByName("labelenemy" + n + "data").GetComponent<Text>().enabled = false;
            GetControlByName("attackbutton" + n).GetComponentInChildren<Text>().enabled = false;
            GetControlByName("FFbutton" + n).GetComponentInChildren<Text>().enabled = false;
            GetControlByName("attackbutton" + n).GetComponent<Image>().enabled = false;
            GetControlByName("FFbutton" + n).GetComponent<Image>().enabled = false;
            GetControlByName("picturee" + n + "energybar").GetComponent<Image>().enabled = false;
            GetControlByName("picturee" + n + "fiercebar").GetComponent<Image>().enabled = false;
            GetControlByName("picturee" + n + "agilitybar").GetComponent<Image>().enabled = false;
        }
        picturealfitnessgreen.SetSpriteImage("aloutlinegreen");
        Image currimage = picturealfitnessgreen.GetImage();
        currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);

        picturealenergygreen.SetSpriteImage("aloutlinegreen");
        Image currimage2 = picturealenergygreen.GetImage();
        currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);

        labelfitness.color = Color.white;
        labelenergy.color = Color.white;

        // reset al
        AlGlobalVar.LevelValue = 0;

        // DEBUG
        //alcloc1 = 1;
        //alcloc2 = 12;
        //AlGlobalVar.LevelValue = 4;
        //AlGlobalVar.WeightValue = 3000;
        //matecount = 10;

        StartCoroutine("levelup");

        fivecount = 0;
        if (timerstarted == false)
        {
            timerstarted = true;
        }
    }

    public bool gameovercheck = false;
    public void gameover(String ftext)
    {
        gameovercheck = true;
        labeldesc.color = Color.red;
        labeldesc.text = "Game Over!\r\nFinal score: " + AlGlobalVar.ScoreValue + "\r\n" + ftext;
        labeldesc.fontStyle = FontStyle.Bold;
    }

    #region levelling
    public IEnumerator levelup()
    {
        pause = true;
        labeldesc.text = "Game paused.";
        labeldesc.color = Color.red;
        labeldesc.fontStyle = FontStyle.Bold;
        buttonpause.GetComponentInChildren<Text>().color = Color.red;

        if (AlGlobalVar.LevelValue < 4)
        {
            if (AlGlobalVar.LevelValue > 1)
            {
                pictureBox1.SetSpriteImage("levelup");
                if (AlGlobalVar.LevelValue == 3)
                {
                    labeldesc.text = "\r\nYou and your pack have killed the Diplodocus!\r\nYou ate the Diplodocus.\r\nLevel up!";
                }
                else
                {
                    labeldesc.text = "Level up!";
                }
                labeldesc.color = Color.white;
                labeldesc.fontStyle = FontStyle.Normal;
            }
            // level
            AlGlobalVar.LevelValue = AlGlobalVar.LevelValue + 1;
            labellevel.text = "Level: " + AlGlobalVar.LevelValue;
            AlGlobalVar.GetAlGrowSpeed();

            // score
            AlGlobalVar.ScoreValue = AlGlobalVar.ScoreValue + 100;
            labelscore.text = "Score: " + AlGlobalVar.ScoreValue;
            AlGlobalVar.lastlvlScore = AlGlobalVar.ScoreValue;

            // energy
            AlGlobalVar.EnergyValue = 100;
            labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";

            // weight
            if (AlGlobalVar.LevelValue == 1)
            {
                AlGlobalVar.WeightValue = 0.2;
                label1.text = "Hint:\r\nEat to grow - grow to\r\nmove on to Level 2";
            }
            else if (AlGlobalVar.LevelValue == 2)
            {
                if (AlGlobalVar.level1choice == 1
                && GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().sprite == GetControlByName("picturemap9900").GetComponent<SpriteRenderer>().sprite)
                {
                    togglemapbordermum(mloc1, mloc2);
                    mumexists = false;
                }
                AlGlobalVar.WeightValue = 100;
                label1.text = "You are now a juvenile!\r\nHint:\r\nExplore new areas for\r\nbigger prey";
            }
            else if (AlGlobalVar.LevelValue == 3)
            {
                AlGlobalVar.WeightValue = 1000;
                label1.text = "You are a sub-adult!\r\nHint:\r\nGain hunting experience\r\nto move on to Level 4";
            }
            else if (AlGlobalVar.LevelValue == 4)
            {
                AlGlobalVar.WeightValue = 2000;
                label1.text = "You are an adult!\r\nHint:\r\nSurvive as long as you\r\ncan and look for females\r\nto boost your score";
            }
            labelweight.text = "Weight: " + AlGlobalVar.WeightValue + "kg";
            if (AlGlobalVar.WeightValue < 3000)
            {
                picturealweight.SetRectWidthHeight(
                new Vector2(picturealweightminsize.x + ((float)AlGlobalVar.WeightValue / 3000)*(picturealweightfullsize.x - picturealweightminsize.x),
                picturealweightminsize.y + ((float)AlGlobalVar.WeightValue / 3000) * (picturealweightfullsize.y - picturealweightminsize.x)));
            }

            // save map
            AlGlobalVar.lastlvlcloc1 = alcloc1;
            AlGlobalVar.lastlvlcloc2 = alcloc2;
            for (int c1 = 1; c1 < 11; c1++)
            {
                for (int c2 = 1; c2 < 18; c2++)
                {
                    lastlvlmap[c1 - 1, c2 - 1] = lvlmap[c1 - 1, c2 - 1];
                }
            }

            // level features
            bool answered = false;
            string message = "UNKNOWN ERROR";
            string button1 = "";
            string button2 = "";

            Popupbox1 = false;
            Popupbox2 = false;
            bool popped = false;

            while (!answered)
            {
                if (AlGlobalVar.LevelValue == 1)
                {
                    message = "Let's get started! At each level you will be asked about the path ahead of you...\r\nDo you think Allosaurus mothers protected their hatchlings, or abandoned them?";
                    button1 = "Protected!";
                    button2 = "Freedom!";
                }
                else if (AlGlobalVar.LevelValue == 2)
                {
                    message = "Do you think Allosauruses grew quickly or slowly?";
                    button1 = "Fast!";
                    button2 = "Slow!";
                }
                else if (AlGlobalVar.LevelValue == 3)
                {
                    message = "What pack size do you think Allosauruses hunted with?";
                    button1 = "Small (3 to 4)";
                    button2 = "Large (6 to 8)";
                }
                else if (AlGlobalVar.LevelValue == 4)
                {
                    message = "You're old enough to mate! Mate as many times as you can to increase your score. \r\nWatch out: female Allosauruses can be aggressive.";
                    button1 = "Okay!";
                }
                pause = true;
                labeldesc.text = "Game paused.";
                labeldesc.color = Color.red;
                labeldesc.fontStyle = FontStyle.Bold; 
                buttonpause.GetComponentInChildren<Text>().color = Color.red;
                if (!popped) // bugfix - don't re-show popup if answered in prev frame
                {
                    Popupbox.showPopupbox(message, button1, button2);
                    Popupbox.Button1Clicked += new EventHandler(frm_Button1Clicked);
                    Popupbox.Button2Clicked += new EventHandler(frm_Button2Clicked);
                    popped = true;
                }
                labeldesc.text = "";
                labeldesc.color = Color.white;
                labeldesc.fontStyle = FontStyle.Normal; 
                buttonpause.GetComponentInChildren<Text>().color = Color.green;

                if (Popupbox1 == true || Popupbox2 == true) 
                {
                    pause = false;
                    answered = true;
                    if (AlGlobalVar.LevelValue == 1)
                    {
                        if (Popupbox1)
                        {
                            AlGlobalVar.level1choice = 1;
                            mumexists = true;
                            GetControlByName("picturemap000").GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap00").GetComponent<SpriteRenderer>().sprite;
                            showmother();
                            message = "Your mother is watching over you. Fierce enemies won't attack you while she's around. But if you stray too far from her... she might not recognise you next time you meet!\r\nIf you're not with her but not far away, a red square on the map shows you where she is.";
                            button1 = "Okay!";
                            button2 = "";
                            pause = true;
                            labeldesc.text = "Game paused.";
                            labeldesc.color = Color.red;
                            labeldesc.fontStyle = FontStyle.Bold; 
                            buttonpause.GetComponentInChildren<Text>().color = Color.red;
                            Popupbox.showPopupbox(message, button1, button2);
                            Popupbox.Button1Clicked += new EventHandler(frm_Button1Clicked);
                            Popupbox.Button2Clicked += new EventHandler(frm_Button2Clicked);
                            pause = false;
                            labeldesc.text = "";
                            labeldesc.color = Color.white;
                            labeldesc.fontStyle = FontStyle.Normal; 
                            buttonpause.GetComponentInChildren<Text>().color = Color.green;
                        }
                        else
                        {
                            AlGlobalVar.level1choice = 2;
                            message = "You're alone in the world... but at least you're not in danger of being eaten by your mother.";
                            button1 = "Okay!";
                            button2 = "";
                            pause = true;
                            labeldesc.text = "Game paused.";
                            labeldesc.color = Color.red;
                            labeldesc.fontStyle = FontStyle.Bold; 
                            buttonpause.GetComponentInChildren<Text>().color = Color.red;
                            Popupbox.showPopupbox(message, button1, button2);
                            Popupbox.Button1Clicked += new EventHandler(frm_Button1Clicked);
                            Popupbox.Button2Clicked += new EventHandler(frm_Button2Clicked);
                            pause = false;
                            labeldesc.text = "";
                            labeldesc.color = Color.white;
                            labeldesc.fontStyle = FontStyle.Normal; 
                            buttonpause.GetComponentInChildren<Text>().color = Color.green;
                        }
                    }
                    else if (AlGlobalVar.LevelValue == 2)
                    {
                        if (Popupbox1) { AlGlobalVar.level2choice = 1; }
                        else { AlGlobalVar.level2choice = 2; }
                        AlGlobalVar.GetAlGrowSpeed();
                    }
                    else if (AlGlobalVar.LevelValue == 3)
                    {
                        if (Popupbox1)
                        {
                            AlGlobalVar.level3choice = 1;
                            packsize1 = 3;
                            packsize2 = 4;
                        }
                        else
                        {
                            AlGlobalVar.level3choice = 2;
                            packsize1 = 7;
                            packsize2 = 8;
                        }
                    }
                    Popupbox1 = false;
                    Popupbox2 = false;
                }
                yield return new WaitForSeconds(0.5f);
            }
            generateenemies();
        }
        fivecount = 0;
        pause = false;
        labeldesc.text = "";
        labeldesc.color = Color.white;
        labeldesc.fontStyle = FontStyle.Normal; 
        buttonpause.GetComponentInChildren<Text>().color = Color.green;
    }


    void showmother()
    {
        updateAlstats();
        int imageID = GameData.Enemies.Find(x => x.Name == "mother Allosaurus").ImageID;
        pictureenemy1.SetSpriteImage("pictureFF" + imageID);
        labelenemyname1.text = GameData.Enemies.Find(x => x.Name == "mother Allosaurus").Name;
        labelenemy1data.text = String.Format("{0:0.00}", GameData.Enemies.Find(x => x.Name == "mother Allosaurus").bFierceness)
            + "\r\n" + String.Format("{0:0.00}", GameData.Enemies.Find(x => x.Name == "mother Allosaurus").bAgility)
            + "\r\n" + String.Format("{0:0.00}", GameData.Enemies.Find(x => x.Name == "mother Allosaurus").bEnergy);
        picturee1energybar.SetRectWidth((int)(40 * (GameData.Enemies.Find(x => x.Name == "mother Allosaurus").bEnergy / GameData.Enemies.Find(x => x.Name == "mother Allosaurus").Energy)));
        if (picturee1energybar.GetRectWidth() > 40)
            picturee1energybar.SetRectWidth(40);
        picturee1energybar.SetSpriteColor(new Color(0, 1, 0, 1)); // lime
        picturee1fiercebar.SetRectWidth((int)(40 * (GameData.Enemies.Find(x => x.Name == "mother Allosaurus").bFierceness / 1000)));
        picturee1agilitybar.SetRectWidth((int)(40 * (GameData.Enemies.Find(x => x.Name == "mother Allosaurus").bAgility)));
        if (GameData.Enemies.Find(x => x.Name == "mother Allosaurus").bFierceness > AlGlobalVar.Alfierceness)
        {
            GetControlByName("labelenemy1" + "data").GetComponent<Text>().color = Color.red;
            picturee1fiercebar.SetSpriteColor(Color.red);
        }
        else
        {
            GetControlByName("labelenemy1" + "data").GetComponent<Text>().color = Color.white;
            picturee1fiercebar.SetSpriteColor(new Color(0, 1, 0, 1)); // lime
        }
        if (GetControlByName("pictureenemy1").GetComponent<SpriteRenderer>().enabled == false)
        {
            toggleenemy(1, true);
        }
        GameData.Enemies.Find(x => x.Name == "mother Allosaurus").Seen = true;
        e1 = "mother Allosaurus";
        enemylist[0] = "mother Allosaurus";
        int count = 0;
        if (e1 != "Missingno")
            count = count + 1;
        if (e2 != "Missingno")
            count = count + 1;
        if (e3 != "Missingno")
            count = count + 1;
        if (e4 != "Missingno")
            count = count + 1;
        doflavourtext();
    }


    private void domating(int enemynum)
    {
        string enemynums = "" + enemynum;
        int success = random.Next(5);
        if (success < 2) //success - 2/5 chance
        {
            if (matecount < 4)
            {
                AlGlobalVar.ScoreValue = AlGlobalVar.ScoreValue + 200;
                labelscore.text = "Score: " + AlGlobalVar.ScoreValue;
                labeldesc.text = "You successfully mated with the female Allosaurus!";
                matecount = matecount + 1;

                pause = false;
                if (labeldesc.text == "Game paused.")
                    labeldesc.text = "";
                labeldesc.color = Color.white;
                labeldesc.fontStyle = FontStyle.Normal;
                buttonpause.GetComponentInChildren<Text>().color = Color.green;
            }
            else
            {
                StartCoroutine(domatingQuestion(enemynum, enemynums));                
            }
        }
        else // fail
        {
            AlGlobalVar.EnergyValue = AlGlobalVar.EnergyValue - 5;
            labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
            if (AlGlobalVar.EnergyValue < 40)
            {
                labelenergy.color = Color.red;
                picturealenergygreen.SetSpriteImage("aloutlinered");
                Image currimage2 = picturealenergygreen.GetImage();
                currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
            }
            else if (AlGlobalVar.EnergyValue < 70)
            {
                labelenergy.color = Color.yellow;
                picturealenergygreen.SetSpriteImage("aloutlineyellow");
                Image currimage2 = picturealenergygreen.GetImage();
                currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
            }
            else
            {
                labelenergy.color = Color.white;
                picturealenergygreen.SetSpriteImage("aloutlinegreen");
                Image currimage2 = picturealenergygreen.GetImage();
                currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
            }
            updateAlstats();
            dobattle(GameData.Enemies.Find(x => x.Name == enemylist[enemynum - 1]), enemynums, AlGlobalVar.Alfierceness, AlGlobalVar.Alagility, AlGlobalVar.Alhealth);
            updateAlstats();
            generateenemies();
            labeldesc.text = "Bad luck! The female attacked you and left.";
        }
    }

    IEnumerator domatingQuestion(int enemynum, string enemynums)
    {
        Popupbox1 = false;
        Popupbox2 = false;
        Popupbox3 = false;
        Popupbox4 = false;
        int ques = random.Next(GameData.PQs.Count);
        string message = "The Allosaurus is willing to mate... \r\nif you can answer this paleontology question correctly!\r\n" + GameData.PQs[ques].Question;
        string button1 = GameData.PQs[ques].A1;
        string button2 = GameData.PQs[ques].A2;
        string button3 = GameData.PQs[ques].A3;
        string button4 = GameData.PQs[ques].A4;
        pause = true;
        labeldesc.text = "Game paused.";
        labeldesc.color = Color.red;
        labeldesc.fontStyle = FontStyle.Bold;
        buttonpause.GetComponentInChildren<Text>().color = Color.red;

        bool answered = false;
        bool popped = false;
        while (!answered)
        {
            if (!popped) // only display popup when starting
            {
                Popupbox.showPopupbox(message, button1, button2, button3, button4);
                Popupbox.Button1Clicked += new EventHandler(frm_Button1Clicked);
                Popupbox.Button2Clicked += new EventHandler(frm_Button2Clicked);
                Popupbox.Button3Clicked += new EventHandler(frm_Button3Clicked);
                Popupbox.Button4Clicked += new EventHandler(frm_Button4Clicked);
                popped = true;
            }
            if (Popupbox1 || Popupbox2 || Popupbox3 || Popupbox4) // player has answered
            {
                answered = true;
                if ((Popupbox1 && GameData.PQs[ques].Answer == "1")
                    || (Popupbox2 && GameData.PQs[ques].Answer == "2")
                    || (Popupbox3 && GameData.PQs[ques].Answer == "3")
                    || (Popupbox4 && GameData.PQs[ques].Answer == "4"))
                {
                    AlGlobalVar.ScoreValue = AlGlobalVar.ScoreValue + 200;
                    labelscore.text = "Score: " + AlGlobalVar.ScoreValue;
                    labeldesc.text = "Correct!\r\nYou successfully mated with the female Allosaurus!";
                    matecount = matecount + 1;
                }
                else
                {
                    AlGlobalVar.EnergyValue = AlGlobalVar.EnergyValue - 5;
                    labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
                    if (AlGlobalVar.EnergyValue < 1)
                    {
                        gameover("You have died of starvation.");
                    }
                    if (AlGlobalVar.EnergyValue < 40)
                    {
                        labelenergy.color = Color.red;
                        picturealenergygreen.SetSpriteImage("aloutlinered");
                        Image currimage2 = picturealenergygreen.GetImage();
                        currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
                    }
                    else if (AlGlobalVar.EnergyValue < 70)
                    {
                        labelenergy.color = Color.yellow;
                        picturealenergygreen.SetSpriteImage("aloutlineyellow");
                        Image currimage2 = picturealenergygreen.GetImage();
                        currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
                    }
                    else
                    {
                        labelenergy.color = Color.white;
                        picturealenergygreen.SetSpriteImage("aloutlinegreen");
                        Image currimage2 = picturealenergygreen.GetImage();
                        currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
                    }
                    updateAlstats();
                    dobattle(GameData.Enemies.Find(x => x.Name == enemylist[enemynum - 1]), enemynums, AlGlobalVar.Alfierceness, AlGlobalVar.Alagility, AlGlobalVar.Alhealth);
                    updateAlstats();
                    generateenemies();
                    labeldesc.text = "Incorrect answer! The female attacked you and left.";
                }
            }
            yield return new WaitForSeconds(0);
        }
        pause = false;
        if (labeldesc.text == "Game paused.")
            labeldesc.text = "";
        labeldesc.color = Color.white;
        labeldesc.fontStyle = FontStyle.Normal;
        buttonpause.GetComponentInChildren<Text>().color = Color.green;
    }
    #endregion levelling

    #region popup code
    public void frm_Button1Clicked(object o, EventArgs e)
    {
        Popupbox1 = true;
    }
    public void frm_Button2Clicked(object o, EventArgs e)
    {
        Popupbox2 = true;
    }
    public void frm_Button3Clicked(object o, EventArgs e)
    {
        Popupbox3 = true;
    }
    public void frm_Button4Clicked(object o, EventArgs e)
    {
        Popupbox4 = true;
    }
    #endregion popup code

    #region movement

    public void setmapvis(int cloc1, int cloc2)
    {
        SpriteRenderer maprender = GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>();
        maprender.enabled = true;
        maprender.color = new Color(maprender.color.r, maprender.color.g, maprender.color.b, 255);
    }


    public void controlsetup()
    {
        if (GetControlByName("picturemap84").GetComponent<SpriteRenderer>().sprite != GetControlByName("picturemap9999").GetComponent<SpriteRenderer>().sprite)
        {
            GetControlByName("picturemap00").GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap84").GetComponent<SpriteRenderer>().sprite;
            GetControlByName("picturemap84").GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap9999").GetComponent<SpriteRenderer>().sprite;
        }
    }


    public void togglemapborder(int cloc1, int cloc2)
    {
        //9999 = yellow square, 00 = storage
        if (GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite != GetControlByName("picturemap9999").GetComponent<SpriteRenderer>().sprite) // if not yellow
        {
            lvlmap[cloc1 - 1, cloc2 - 1] = true;

            if (GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite == GetControlByName("picturemap9900").GetComponent<SpriteRenderer>().sprite) // if red
            {
                GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite = Resources.Load("map/map" + cloc1 + cloc2, typeof(Sprite)) as Sprite;
                GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap9999").GetComponent<SpriteRenderer>().sprite; // make yellow
            }
            else if (mloc1 == cloc1 && mloc2 == cloc2 && mumexists == true) // not yellow and mum's loc => moved next to mum
            {
                GetControlByName("picturemap00").GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite; // get backup from map
                GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap9900").GetComponent<SpriteRenderer>().sprite; // make red
            }
            else
            {
                GetControlByName("picturemap00").GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite; // get backup from map
                GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap9999").GetComponent<SpriteRenderer>().sprite; // make yellow
            }
        }
        else
        {
            if (mloc1 == cloc1 && mloc2 == cloc2 && mumexists == true) // not yellow and mum's loc => moved away from mum
            {
                GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap9900").GetComponent<SpriteRenderer>().sprite; // make red
                if ((cloc1 == alcloc1 || cloc1 == alcloc1+1 || cloc1 == alcloc1-1)
                    && (cloc2 == alcloc2 || cloc2 == alcloc2 + 1 || cloc2 == alcloc2 - 1))
                {
                    GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color =
                        new Color(GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color.r,
                                    GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color.g,
                                    GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color.b,
                                    255);
                }

            }
            else
            {
                GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().sprite = Resources.Load("map/map" + cloc1 + cloc2, typeof(Sprite)) as Sprite; // bugfix - backup doesn't work if mum moved alongside al previously
                if (lvlmap[cloc1 - 1, cloc2 - 1])
                {
                    GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color =
                        new Color(GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color.r,
                                    GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color.g,
                                    GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color.b,
                                    255);
                }
                else
                {
                    GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color =
                        new Color(GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color.r,
                                    GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color.g,
                                    GetControlByName("picturemap" + cloc1 + cloc2).GetComponent<SpriteRenderer>().color.b,
                                    0);
                }
            }
        }
    }


    public void togglemapbordermum(int mloc1, int mloc2)
    {
        //9900 = red square, 000 = storage
        if ((GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().sprite != GetControlByName("picturemap9999").GetComponent<SpriteRenderer>().sprite)) // only when al isn't there
        {
            if (GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().sprite != GetControlByName("picturemap9900").GetComponent<SpriteRenderer>().sprite) // if not red
            {
                GetControlByName("picturemap000").GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().sprite; // backup image
                GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap9900").GetComponent<SpriteRenderer>().sprite; // make red
                if (!lvlmap[mloc1 - 1, mloc2 - 1]
                    && (mloc1 == alcloc1 || mloc1 == alcloc1 + 1 || mloc1 == alcloc1 - 1 || mloc1 == alcloc1 + 2 || mloc1 == alcloc1 - 2)
                    && (mloc2 == alcloc2 || mloc2 == alcloc2 + 1 || mloc2 == alcloc2 - 1 || mloc2 == alcloc2 + 2 || mloc2 == alcloc2 - 2)) // make visible if necessary                                                                                                                                                               //make visible:
                    GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().color = new Color(
                                GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().color.r,
                                GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().color.g,
                                GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().color.b,
                                255
                    );
            }
            else if (GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().sprite == GetControlByName("picturemap9900").GetComponent<SpriteRenderer>().sprite)//if red
            {
                GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().sprite = Resources.Load("map/map" + mloc1 + mloc2, typeof(Sprite)) as Sprite;
                if (!lvlmap[mloc1 - 1, mloc2 - 1]) // make invisible if necessary
                    GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().color = new Color(
                                GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().color.r,
                                GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().color.g,
                                GetControlByName("picturemap" + mloc1 + mloc2).GetComponent<SpriteRenderer>().color.b,
                                0
                    );
            }
        }
    }

    private System.Random mrng = new System.Random();
    public void setmumloc()
    {
        if (!(mumwait))
        {
            int loc1 = mrng.Next(3);
            int loc2 = mrng.Next(3);
            loc1 = loc1 - 1;
            loc2 = loc2 - 1;
            int ml1 = mloc1 + loc1;
            int ml2 = mloc2 + loc2;
            if (((loc1 < 0 & mloc1 > 1) || (loc1 > 0 & mloc1 < 10) || (loc1 == 0)) && ((loc2 < 0 & mloc2 > 1) || (loc2 > 0 & mloc2 < 17) || (loc2 == 0)))
            {
                string smloc = "" + ml1 + ml2;
                int smloc2 = int.Parse(smloc);
                int newZone = GameData.Zones.Find(x => Array.IndexOf(x.Maps, smloc2) >= 0).Zone;
                int[] validZones = new int[] { 1, 2, 21, 8 };
                if (validZones.Contains(newZone))
                {
                    movemum(loc1, loc2);
                    if (e1 == "mother Allosaurus" && (alcloc1 != mloc1 || alcloc2 != mloc2))
                    {
                        e1 = "Missingno";
                        toggleenemy(1, false);
                        doflavourtext();
                    }

                }
            }
            mumwait = true;
        }
        else
        {
            mumwait = false;
        }
    }


    public void moveAl(int c1, int c2)
    {
        if (AlGlobalVar.EnergyValue < 6)
        {
            AlGlobalVar.EnergyValue = 0;
            labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
            gameover("You have died of starvation.");
        }
        else if (AlGlobalVar.FitnessValue == 0)
        { }
        else
        {
            if (pictureenemy1.GetSpriteRenderer().enabled == true)
                toggleenemy(1, false);
            if (pictureenemy2.GetSpriteRenderer().enabled == true)
                toggleenemy(2, false);
            if (pictureenemy3.GetSpriteRenderer().enabled == true)
                toggleenemy(3, false);
            if (pictureenemy4.GetSpriteRenderer().enabled == true)
                toggleenemy(4, false);
            int cloc1old = alcloc1;
            int cloc2old = alcloc2;
            AlGlobalVar.EnergyValue = AlGlobalVar.EnergyValue - (5 * AlGlobalVar.GetAlGrowSpeed());
            labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
            if (AlGlobalVar.EnergyValue < 40)
            {
                labelenergy.color = Color.red;
                picturealenergygreen.SetSpriteImage("aloutlinered");
                Image currimage2 = picturealenergygreen.GetImage();
                currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
            }
            else if (AlGlobalVar.EnergyValue < 70)
            {
                labelenergy.color = Color.yellow;
                picturealenergygreen.SetSpriteImage("aloutlineyellow");
                Image currimage2 = picturealenergygreen.GetImage();
                currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
            }
            else
            {
                labelenergy.color = Color.white;
                picturealenergygreen.SetSpriteImage("aloutlinegreen");
                Image currimage2 = picturealenergygreen.GetImage();
                currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
            }

            if ((c1 < 0 & alcloc1 > 1) || (c1 > 0 & alcloc1 < 10))
                alcloc1 = alcloc1 + c1;
            if ((c2 < 0 & alcloc2 > 1) || (c2 > 0 & alcloc2 < 17))
                alcloc2 = alcloc2 + c2;
            if ((alcloc1 != cloc1old) || (alcloc2 != cloc2old))
            {
                togglemapborder(cloc1old, cloc2old);
                setmapvis(alcloc1, alcloc2);
                togglemapborder(alcloc1, alcloc2);
                updatelocscreen(alcloc1, alcloc2);
                string sclocold = "" + cloc1old + cloc2old;
                int sclocold2 = int.Parse(sclocold);
                string scloc = "" + alcloc1 + alcloc2;
                int scloc2 = int.Parse(scloc);
                if (AlGlobalVar.LevelValue < 2
                    && GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Zone == 3) //river
                {
                    AlGlobalVar.EnergyValue = 0;
                    AlGlobalVar.FitnessValue = 0;
                    gameover("You have been swept away!\r\nYou were too small to cross the river.");
                }
                else if (AlGlobalVar.LevelValue > 2
                    && GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Zone == 4
                    && GameData.Zones.Find(x => Array.IndexOf(x.Maps, sclocold2) >= 0).Zone == 4) //swamp
                {
                    AlGlobalVar.EnergyValue = 0;
                    AlGlobalVar.FitnessValue = 0;
                    gameover("You have sunk into the swamp!\r\nYou were too heavy to free yourself.");
                }
                else
                {
                    labeldesc.text = "You are " + GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Name;
                    labeldesc.color = Color.white;
                    labeldesc.fontStyle = FontStyle.Normal; 
                    generateenemies();
                    int loccount = 0;
                    for (int l1 = 1; l1 < 11; l1++)
                    {
                        for (int l2 = 1; l2 < 18; l2++)
                        {
                            if (GetControlByName("picturemap" + l1 + l2).GetComponent<SpriteRenderer>().color.a == 255)
                            {
                                    loccount = loccount + 1;
                            }
                        }
                    }
                    if (loccount == 170 && explorebonus == false)
                    {
                        pause = true;
                        labeldesc.text = "Game paused.";
                        labeldesc.color = Color.red;
                        labeldesc.fontStyle = FontStyle.Bold;  
                        buttonpause.GetComponentInChildren<Text>().color = Color.red;
                        explorebonus = true;
                        AlGlobalVar.ScoreValue = AlGlobalVar.ScoreValue + 2000;
                        labelscore.text = "Score: " + AlGlobalVar.ScoreValue;
                        string message = "Congratulations! You've explored the whole map!\r\nScore bonus: 2000 points";
                        string button1 = "Okay!";
                        string button2 = "";
                        Popupbox.showPopupbox(message, button1, button2);
                        Popupbox.Button1Clicked += new EventHandler(frm_Button1Clicked);
                        Popupbox.Button2Clicked += new EventHandler(frm_Button2Clicked);
                        pause = false;
                        labeldesc.text = "";
                        labeldesc.color = Color.white;
                        labeldesc.fontStyle = FontStyle.Normal; 
                        buttonpause.GetComponentInChildren<Text>().color = Color.green;
                    }
                }
                int mloc1old = mloc1;
                int mloc2old = mloc2;
                if (AlGlobalVar.LevelValue == 1 && AlGlobalVar.level1choice == 1)
                {
                    setmumloc();
                }
                if (mloc1old == cloc1old && mloc2old == cloc2old)
                {
                    GetControlByName("picturemap" + cloc1old + cloc2old).GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }


    public void movemum(int c1, int c2)
    {
        int mloc1old = mloc1;
        int mloc2old = mloc2;
        if ((c1 < 0 & mloc1 > 1) || (c1 > 0 & mloc1 < 10))
            mloc1 = mloc1 + c1;
        if ((c2 < 0 & mloc2 > 1) || (c2 > 0 & mloc2 < 17))
            mloc2 = mloc2 + c2;
        if ((mloc1 != mloc1old) || (mloc2 != mloc2old))
        {
            togglemapbordermum(mloc1old, mloc2old);
            togglemapbordermum(mloc1, mloc2);
            if ((mloc1 < alcloc1 - 3) || (mloc1 > alcloc1 + 3) || (mloc2 < alcloc2 - 3) || (mloc2 > alcloc2 + 3))
            {
                mumknows = false;
            }
        }
    }

    // displays current zone picture
    public void updatelocscreen(int cloc1, int cloc2)
    {
        string scloc = "" + cloc1 + cloc2;
        int scloc2 = int.Parse(scloc);
        int currZone = GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Zone;
        pictureBox1.SetSpriteImage("zone" + currZone);
    }
    #endregion movement

    #region buttons
    #region movebuttons

    public void buttonwait_Click()
    {
        if (pause == false)
        {
            if (AlGlobalVar.EnergyValue < 6)
            {
                AlGlobalVar.EnergyValue = 0;
                labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
                gameover("You have died of starvation.");
            }
            else if (AlGlobalVar.FitnessValue == 0)
            { }
            else
            {
                if (AlGlobalVar.FitnessValue < 100)
                {
                    AlGlobalVar.FitnessValue = AlGlobalVar.FitnessValue + 10;
                    if (AlGlobalVar.FitnessValue > 100)
                        AlGlobalVar.FitnessValue = 100;
                    labelfitness.text = "Fitness: " + AlGlobalVar.FitnessValue + "%";
                    if (AlGlobalVar.FitnessValue < 40)
                    {
                        labelfitness.color = Color.red;
                        picturealfitnessgreen.SetSpriteImage("aloutlinered");
                        Image currimage = picturealfitnessgreen.GetImage();
                        currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
                    }
                    else if (AlGlobalVar.FitnessValue < 70)
                    {
                        labelfitness.color = Color.yellow;
                        picturealfitnessgreen.SetSpriteImage("aloutlineyellow");
                        Image currimage = picturealfitnessgreen.GetImage();
                        currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
                    }
                    else
                    {
                        labelfitness.color = Color.white;
                        picturealfitnessgreen.SetSpriteImage("aloutlinegreen");
                        Image currimage = picturealfitnessgreen.GetImage();
                        currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
                    }
                }
                string scloc = "" + alcloc1 + alcloc2;
                int scloc2 = int.Parse(scloc);
                labeldesc.text = "You are " + GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Name;
                labeldesc.color = Color.white;
                labeldesc.fontStyle = FontStyle.Normal; 
                AlGlobalVar.EnergyValue = AlGlobalVar.EnergyValue - (5 * AlGlobalVar.GetAlGrowSpeed());
                labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
                if (AlGlobalVar.EnergyValue < 40)
                {
                    labelenergy.color = Color.red;
                    picturealenergygreen.SetSpriteImage("aloutlinered");
                    Image currimage2 = picturealenergygreen.GetImage();
                    currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
                }
                else if (AlGlobalVar.EnergyValue < 70)
                {
                    labelenergy.color = Color.yellow;
                    picturealenergygreen.SetSpriteImage("aloutlineyellow");
                    Image currimage2 = picturealenergygreen.GetImage();
                    currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
                }
                else
                {
                    labelenergy.color = Color.white;
                    picturealenergygreen.SetSpriteImage("aloutlinegreen");
                    Image currimage2 = picturealenergygreen.GetImage();
                    currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
                }
                bool attacked = false;
                string[] currenemies = new string[] { e1, e2, e3, e4 };
                updateAlstats();
                for (int a = 0; a < 4; a++)
                {
                    int b = a + 1;
                    string enemynum = "" + b;
                    if (currenemies[a] != "Missingno")
                    {
                        if (GameData.Enemies.Find(x => x.Name == currenemies[a]).Fierceness > AlGlobalVar.Alfierceness)
                        {
                            if (e1 != "mother Allosaurus" || mumknows == false)
                            {
                                attacked = true;
                                dobattle(GameData.Enemies.Find(x => x.Name == currenemies[a]), enemynum, AlGlobalVar.Alfierceness, AlGlobalVar.Alagility, AlGlobalVar.Alhealth);
                                updateAlstats();
                            }
                        }
                    }
                }

                if (AlGlobalVar.FitnessValue == 0)
                    return;

                if (!attacked)
                    generateenemies();
                if (AlGlobalVar.LevelValue == 1 && AlGlobalVar.level1choice == 1)
                {
                    setmumloc();
                }
                if (AlGlobalVar.LevelValue == 3
                    && (currenemies.Contains("Allosaurus (male)") || currenemies.Contains("Allosaurus (female)"))
                    && GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Zone == 7)
                {
                    int cps = currpacksize;
                    for (int a = 0; a < 4; a++)
                    {
                        if (currenemies[a] == "Allosaurus (male)" || currenemies[a] == "Allosaurus (female)")
                        {
                            int rng = random.Next(3);
                            if (rng < 2)
                                currpacksize = currpacksize + 1;
                        }
                    }
                    generateenemies();
                    if (cps != currpacksize)
                    {
                        if (currpacksize > packsize2)
                        {
                            currpacksize = 0;
                            labeldesc.text = "Waited too long!\r\nThe allosauruses in your pack have gone to hunt elsewhere.\r\nPack size: " + currpacksize;
                        }
                        else if (currpacksize <= packsize2)
                        {
                            labeldesc.text = "New recuits!\r\nYour pack has gotten larger. Is it time to hunt?\r\nPack size: " + currpacksize;
                        }
                    }
                }
            }
        }
    }


    public void buttonnorth_Click()
    {
        if (pause == false)
        {
            if (CanClick())
            {
                ActivateClickCooldown();
                if (alcloc1 > 1)
                    moveAl(-1, 0);
            }
        }
    }
    public void buttonwest_Click()
    {
        if (pause == false)
        {
            if (alcloc2 > 1)
                moveAl(0, -1);
        }
    }
    public void buttonsouth_Click()
    {
        if (pause == false)
        {
            if (alcloc1 < 10)
                moveAl(1, 0);
        }
    }
    public void buttoneast_Click()
    {
        if (pause == false)
        {
            if (alcloc2 < 17)
                moveAl(0, 1);
        }
    }
    public void buttonnwest_Click()
    {
        if (pause == false)
        {
            if (alcloc1 > 1 && alcloc2 > 1)
                moveAl(-1, -1);
        }
    }
    public void buttonneast_Click()
    {
        if (pause == false)
        {
            if (alcloc1 > 1 && alcloc2 < 17)
                moveAl(-1, 1);
        }
    }
    public void buttonswest_Click()
    {
        if (pause == false)
        {
            if (alcloc1 < 10 && alcloc2 > 1)
                moveAl(1, -1);
        }
    }
    public void buttonseast_Click()
    {
        if (pause == false)
        {
            if (alcloc1 < 10 && alcloc2 < 17)
                moveAl(1, 1);
        }
    }
    #endregion movebuttons
    #region otherbuttons

    public void buttonpause_Click()
    {
        if (!gameovercheck)
        {
            if (CanClick())
            {
                ActivateClickCooldown();
                pause = !pause;
                if (pause)
                {
                    labeldesc.text = "Game paused.\r\nClick pause again to continue.";
                    labeldesc.color = Color.red;
                    labeldesc.fontStyle = FontStyle.Bold; 
                    buttonpause.GetComponentInChildren<Text>().color = Color.red;
                }
                else
                {
                    labeldesc.text = "";
                    labeldesc.color = Color.white;
                    labeldesc.fontStyle = FontStyle.Normal; 
                    buttonpause.GetComponentInChildren<Text>().color = Color.green;
                }
            }
        }
    }


    public void buttonrestartlvl_Click()
    {
        if (CanClick())
        {
            ActivateClickCooldown();
            // reset vars
            gameovercheck = false;
            pause = false;
            mumwait = false;
            mumknows = true;
            matecount = 0;
            currpacksize = 0;
            lvl3cap = false;
            diplohunted = false;
            SpriteRenderer maprender = picturemap84.GetSpriteRenderer();
            maprender.enabled = true;
            maprender.color = new Color(maprender.color.r, maprender.color.g, maprender.color.b, 255);

            // reset enemies
            clearenemies();
            e1 = "Missingno";
            e2 = "Missingno";
            e3 = "Missingno";
            e4 = "Missingno";
            if (pictureenemy1.GetSpriteRenderer().enabled)
                toggleenemy(1, false);
            if (pictureenemy2.GetSpriteRenderer().enabled)
                toggleenemy(2, false);
            if (pictureenemy3.GetSpriteRenderer().enabled)
                toggleenemy(3, false);
            if (pictureenemy4.GetSpriteRenderer().enabled)
                toggleenemy(4, false);
            labeldesc.text = "Level restarted.";
            labeldesc.color = Color.white;
            labeldesc.fontStyle = FontStyle.Normal; 

            // reset map
            togglemapborder(alcloc1, alcloc2); // unset yellow square at pre-restart location
            alcloc1 = AlGlobalVar.lastlvlcloc1;
            alcloc2 = AlGlobalVar.lastlvlcloc2;
            for (int c1 = 1; c1 < 11; c1++) // reset map visibility and images
            {
                for (int c2 = 1; c2 < 18; c2++)
                {
                    lvlmap[c1 - 1, c2 - 1] = lastlvlmap[c1 - 1, c2 - 1];
                    SpriteRenderer maprender3 = GetControlByName("picturemap" + c1 + c2).GetComponent<SpriteRenderer>();
                    maprender3.sprite = Resources.Load("map/map" + c1 + c2, typeof(Sprite)) as Sprite;
                    if (lastlvlmap[c1 - 1, c2 - 1])
                    {
                        maprender3.color = new Color(maprender3.color.r, maprender3.color.g, maprender3.color.b, 255);
                    }
                    else
                    {
                        maprender3.color = new Color(maprender3.color.r, maprender3.color.g, maprender3.color.b, 0);
                    }
                }
            }
            if (AlGlobalVar.LevelValue != 1)
            {
                togglemapborder(alcloc1, alcloc2); // set yellow square at reset location // the if is a bugfix - can't use toggle for edge case: if mum was at reset spot beforehand
            }
            else
            {
                GetControlByName("picturemap00").GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap84").GetComponent<SpriteRenderer>().sprite; //get backup from map
                GetControlByName("picturemap84").GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap9999").GetComponent<SpriteRenderer>().sprite; //make yellow
                lvlmap[7, 3] = true;
            }

            updatelocscreen(alcloc1, alcloc2); //reset location details
            mumknows = true;
            mloc1 = 8;
            mloc2 = 4;
            if (mumexists == true)
            {
                showmother();
                GetControlByName("picturemap000").GetComponent<SpriteRenderer>().sprite = GetControlByName("picturemap00").GetComponent<SpriteRenderer>().sprite;
            }
            SpriteRenderer maprender2 = picturemap84.GetSpriteRenderer();
            maprender2.enabled = true;
            maprender2.color = new Color(maprender2.color.r, maprender2.color.g, maprender2.color.b, 255);
            
            // reset stats
            AlGlobalVar.ScoreValue = AlGlobalVar.lastlvlScore;
            labelscore.text = "Score: " + AlGlobalVar.ScoreValue;
            AlGlobalVar.EnergyValue = 100;
            labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
            labelenergy.color = Color.white;
            picturealenergygreen.SetSpriteImage("aloutlinegreen");
            Image currimage2 = picturealenergygreen.GetImage();
            currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
            AlGlobalVar.FitnessValue = 100;
            labelfitness.text = "Fitness: " + AlGlobalVar.FitnessValue + "%";
            labelfitness.color = Color.white;
            picturealfitnessgreen.SetSpriteImage("aloutlinegreen");
            Image currimage = picturealfitnessgreen.GetImage();
            currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
            if (AlGlobalVar.LevelValue == 1)
            {
                AlGlobalVar.WeightValue = 0.2;
                labelweight.text = "Weight: " + AlGlobalVar.WeightValue + "kg";
            }
            else if (AlGlobalVar.LevelValue == 2)
            {
                AlGlobalVar.WeightValue = 100;
                labelweight.text = "Weight: " + AlGlobalVar.WeightValue + "kg";
            }
            else if (AlGlobalVar.LevelValue == 3)
            {
                AlGlobalVar.WeightValue = 1000;
                labelweight.text = "Weight: " + AlGlobalVar.WeightValue + "kg";
            }
            else if (AlGlobalVar.LevelValue == 4)
            {
                AlGlobalVar.WeightValue = 2000;
                labelweight.text = "Weight: " + AlGlobalVar.WeightValue + "kg";
            }
            picturealweight.SetRectWidthHeight(
                new Vector2(picturealweightminsize.x + ((float)AlGlobalVar.WeightValue / 3000) * (picturealweightfullsize.x - picturealweightminsize.x),
                picturealweightminsize.y + ((float)AlGlobalVar.WeightValue / 3000) * (picturealweightfullsize.y - picturealweightminsize.x)));
        }
    }


    public void buttonrestartg_Click()
    {
        if (CanClick())
        {
            ActivateClickCooldown();
            gameovercheck = false;
            clearenemies();
            e1 = "Missingno";
            e2 = "Missingno";
            e3 = "Missingno";
            e4 = "Missingno";
            labeldesc.text = "Game restarted.";
            labeldesc.color = Color.white;
            labeldesc.fontStyle = FontStyle.Normal;

            // hide map
            for (int c1 = 1; c1 < 11; c1++)
            {
                for (int c2 = 1; c2 < 18; c2++)
                {
                    SpriteRenderer maprender = GetControlByName("picturemap" + c1 + c2).GetComponent<SpriteRenderer>();
                    maprender.sprite = Resources.Load("map/map" + c1 + c2, typeof(Sprite)) as Sprite;

                    GetControlByName("picturemap" + c1 + c2).GetComponent<SpriteRenderer>().color =
                        new Color(GetControlByName("picturemap" + c1 + c2).GetComponent<SpriteRenderer>().color.r,
                                    GetControlByName("picturemap" + c1 + c2).GetComponent<SpriteRenderer>().color.g,
                                    GetControlByName("picturemap" + c1 + c2).GetComponent<SpriteRenderer>().color.b,
                                    0);

                    lastlvlmap[c1 - 1, c2 - 1] = false;
                    lvlmap[c1 - 1, c2 - 1] = false;
                }
            }
            
            // set first location
            alcloc1 = 8;
            alcloc2 = 4;
            mloc1 = 8;
            mloc2 = 4;
            AlGlobalVar.level1choice = 0;
            AlGlobalVar.level2choice = 0;
            AlGlobalVar.level3choice = 0;
            updatelocscreen(alcloc1, alcloc2);
            controlsetup();

            // others
            setupscreen();
        }
    }


    public void buttonquit_Click()
    {
        Application.Quit();
    }

    public void buttonFFs_Click()
    {
        if (!FFcanvas.activeSelf && !popupcanvas.activeSelf && !introcanvas.activeSelf && !howtocanvas.activeSelf)
        {
            pause = true;
            labeldesc.text = "Game paused.";
            labeldesc.color = Color.red;
            labeldesc.fontStyle = FontStyle.Bold;  
            AlGlobalVar.currFF = enemylist[0];
            FFForm.showFFForm();
            pause = false;
            labeldesc.text = "";
            labeldesc.color = Color.white;
            labeldesc.fontStyle = FontStyle.Normal; 
        }
    }

    public void showFF(int enemynum)
    {
        pause = true;
        labeldesc.text = "Game paused.";
        labeldesc.color = Color.red;
        labeldesc.fontStyle = FontStyle.Bold; 
        buttonpause.GetComponentInChildren<Text>().color = Color.red;
        AlGlobalVar.currFF = enemylist[enemynum];
        FFForm.showFFForm();
        pause = false;
        labeldesc.text = "";
        labeldesc.color = Color.white;
        labeldesc.fontStyle = FontStyle.Normal; 
        buttonpause.GetComponentInChildren<Text>().color = Color.green;
    }


    public void FFbutton1_Click()
    {
        if (CanClick())
        {
            ActivateClickCooldown();
            if (enemylist[0] == "Missingno")
            { }
            else if (enemylist[0] == "Allosaurus (female)" && AlGlobalVar.LevelValue == 4)
            {
                domating(1);
            }
            else
            {
                showFF(0);
            }
        }
    }
    public void FFbutton2_Click()
    {
        if (CanClick())
        {
            ActivateClickCooldown();
            if (enemylist[1] == "Missingno")
            { }
            else if (enemylist[1] == "Allosaurus (female)" && AlGlobalVar.LevelValue == 4)
            {
                domating(2);
            }
            else
            {
                showFF(1);
            }
        }
    }
    public void FFbutton3_Click()
    {
        if (CanClick())
        {
            ActivateClickCooldown();
            if (enemylist[2] == "Missingno")
            { }
            else if (enemylist[2] == "Allosaurus (female)" && AlGlobalVar.LevelValue == 4)
            {
                domating(3);
            }
            else
            {
                showFF(2);
            }
        }
    }
    public void FFbutton4_Click()
    {
        if (CanClick())
        {
            ActivateClickCooldown();
            if (enemylist[3] == "Missingno")
            { }
            else if (enemylist[3] == "Allosaurus (female)" && AlGlobalVar.LevelValue == 4)
            {
                domating(4);
            }
            else
            {
                showFF(3);
            }
        }
    }
    
    public bool CanClick(bool checkClickCooldown = true)
    {
        if ((!checkClickCooldown || currentClickCooldown <= 0)
            && !FFcanvas.activeSelf && !popupcanvas.activeSelf && !introcanvas.activeSelf && !howtocanvas.activeSelf)
        {
            currentClickCooldown = checkClickCooldown ? 0 : currentClickCooldown;
            return true;
        }
        else
            return false;
    }

    private void ActivateClickCooldown()
    {
        currentClickCooldown = clickCooldownTime;
    }

    float clickCooldownTime = 0.1f; //don't allow >10 clicks per second
    float currentClickCooldown = 0f;
    public void attackbutton_Click(int buttonNum)
    {
        if (CanClick())
        {
            ActivateClickCooldown();
            doattack(buttonNum.ToString());
        }
    }

    private void doattack(string enemynum)
    {
        atkdone = true; // to chain attack text when more than one enemy. true = don't chain
        if (pause == false)
        {
            if (AlGlobalVar.EnergyValue < 6)
            {
                AlGlobalVar.EnergyValue = 0;
                labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
                gameover("You have died of starvation.");
            }
            else if (AlGlobalVar.FitnessValue == 0)
            { }
            else
            {
                AlGlobalVar.EnergyValue = AlGlobalVar.EnergyValue - 5;
                labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
                if (AlGlobalVar.EnergyValue < 40)
                {
                    labelenergy.color = Color.red;
                    picturealenergygreen.SetSpriteImage("aloutlinered");
                    Image currimage2 = picturealenergygreen.GetImage();
                    currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
                }
                else if (AlGlobalVar.EnergyValue < 70)
                {
                    labelenergy.color = Color.yellow;
                    picturealenergygreen.SetSpriteImage("aloutlineyellow");
                    Image currimage2 = picturealenergygreen.GetImage();
                    currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
                }
                else
                {
                    labelenergy.color = Color.white;
                    picturealenergygreen.SetSpriteImage("aloutlinegreen");
                    Image currimage2 = picturealenergygreen.GetImage();
                    currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
                }
                updateAlstats();

                // check for fiercer enemies
                int enumint;
                Int32.TryParse(enemynum, out enumint);
                string[] earray = new string[] { e1, e2, e3, e4 };
                if (AlGlobalVar.FitnessValue > 0)
                    dobattle(GameData.Enemies.Find(x => x.Name == earray[enumint - 1]), enemynum, AlGlobalVar.Alfierceness, AlGlobalVar.Alagility, AlGlobalVar.Alhealth);
                for (int a = 0; a < 4; a++)
                {
                    int b = a + 1;
                    string enemy2num = "" + b;
                    if (earray[a] != "Missingno")
                    {
                        // al gets attacked if:
                        if (GameData.Enemies.Find(x => x.Name == earray[a]).bFierceness > AlGlobalVar.Alfierceness // enemy more fierce
                            && (e1 != "mother Allosaurus" || mumknows == false) // mum isn't there or doesn't know al
                            && (earray.Contains("Diplodocus") && currpacksize > 0) == false) // not hunting a diplo
                        {
                            atkdone = false;
                            if (allevelup == false)
                                dobattle(GameData.Enemies.Find(x => x.Name == earray[a]), enemy2num, AlGlobalVar.Alfierceness, AlGlobalVar.Alagility, AlGlobalVar.Alhealth);
                            updateAlstats();
                        }
                    }
                }
                atkdone = true;
            }
        }
    }
    #endregion otherbuttons
    #endregion buttons

    #region battling

    private void updateAlstats()
    {
        AlGlobalVar.Alfierceness = (AlGlobalVar.WeightValue * (AlGlobalVar.FitnessValue / 100) + 10 * AlGlobalVar.LevelValue) / (5 - AlGlobalVar.LevelValue);
        AlGlobalVar.Alagility = (AlGlobalVar.FitnessValue - 5) / 100;
        AlGlobalVar.Alhealth = 100 + AlGlobalVar.WeightValue;
    }


    public void setupenemies()
    {
        enemylist.Add("Missingno");
        enemylist.Add("Missingno");
        enemylist.Add("Missingno");
        enemylist.Add("Missingno");
    }
    
    public void clearenemies()
    {
        if (enemylist[0] != "Missingno" && pictureenemy1.GetSpriteRenderer().enabled == true)
        {
            toggleenemy(1, false);
        }
        if (enemylist[1] != "Missingno" && pictureenemy2.GetSpriteRenderer().enabled == true)
        {
            toggleenemy(2, false);
        }
        if (enemylist[2] != "Missingno" && pictureenemy3.GetSpriteRenderer().enabled == true)
        {
            toggleenemy(3, false);
        }
        if (enemylist[3] != "Missingno" && pictureenemy4.GetSpriteRenderer().enabled == true)
        {
            toggleenemy(4, false);
        }
    }

    private void dobattle(AlEnemies Enemy, string enemynum, double alfierceness, double alagility, double alhealth)
    {
        double alhealthfull = alhealth;
        bool enemyDefeated = false;
        bool alDefeated = false;
        updatelocscreen(alcloc1, alcloc2);
        if (atkdone == false)
        {
            labeldesc.text = labeldesc.text + "\r\nAttacked!";
        }
        else
        {
            labeldesc.text = "Battle!";
        }
        if (Enemy.bAgility > alagility) // enemy attacks first
        {
            doEnemyAttack(Enemy, enemynum, alfierceness, alhealth, alhealthfull, false, out alDefeated);
            if (!alDefeated)
            {
                //al attacks
                doAlAttack(Enemy, enemynum, alfierceness, alhealth, alhealthfull, out enemyDefeated);
            }
        }
        else // al attacks first
        {
            doAlAttack(Enemy, enemynum, alfierceness, alhealth, alhealthfull, out enemyDefeated);
            if (!enemyDefeated)
            {
                // enemy attacks
                doEnemyAttack(Enemy, enemynum, alfierceness, alhealth, alhealthfull, true, out alDefeated);
            }
        }
        AlGlobalVar.Alhealth = alhealth;
    }

    void doAlAttack(AlEnemies Enemy, string enemynum, double alfierceness, double alhealth, double alhealthfull, out bool enemyDefeated)
    {
        double damage = 0;
        if (AlGlobalVar.LevelValue == 3) // pack dynamics
        {
            string zcloc = "" + alcloc1 + alcloc2;
            int zcloc2 = int.Parse(zcloc);
            if ((currpacksize == packsize1 || currpacksize == packsize2) && Enemy.Name == "Diplodocus")
            {
                damage = 0.75 * ((0.5 * alfierceness) / (Enemy.bFierceness + 0.1)) * (alhealth / 9) + (1000 * currpacksize / 4);
                Enemy.bEnergy = Enemy.bEnergy - damage;
            }
            else if (currpacksize > 0 && GameData.Zones.Find(x => Array.IndexOf(x.Maps, zcloc2) >= 0).Zone != 7) // if hunting away from the mig path, pack leaves
            {
                damage = 0.75 * ((0.5 * alfierceness) / (Enemy.bFierceness + 0.1)) * (alhealth / 9);
                Enemy.bEnergy = Enemy.bEnergy - damage;
                currpacksize = 0;
                labeldesc.text = labeldesc.text + "\r\nYour pack has left to hunt elsewhere!\r\nPack size: " + currpacksize;
            }
            else
            {
                damage = 0.75 * ((0.5 * alfierceness) / (Enemy.bFierceness + 0.1)) * (alhealth / 9);
                Enemy.bEnergy = Enemy.bEnergy - damage;
            }
        }
        else
        {
            damage = 0.75 * ((0.5 * alfierceness) / (Enemy.bFierceness + 0.1)) * (alhealth / 9);
            Enemy.bEnergy = Enemy.bEnergy - damage;
        }

        if (Enemy.bEnergy <= 0)
        {
            EnemyDefeated(Enemy, enemynum);
            enemyDefeated = true;
        }
        else
        {
            FormsObject picturee0energybar = new FormsObject(GetControlByName("picturee" + enemynum + "energybar").name);
            GetControlByName("labelenemy" + enemynum + "data").GetComponent<Text>().text = String.Format("{0:0.00}", Enemy.bFierceness)
                + "\r\n" + String.Format("{0:0.00}", Enemy.bAgility)
                + "\r\n" + String.Format("{0:0.00}", Enemy.bEnergy);
            picturee0energybar.SetRectWidth((int)(40 * (Enemy.bEnergy / Enemy.Energy)));
            if (picturee0energybar.GetRectWidth() > 40)
                picturee0energybar.SetRectWidth(40);
            if (picturee0energybar.GetRectWidth() < 20)
                picturee0energybar.SetSpriteColor(Color.red);
            else
                picturee0energybar.SetSpriteColor(new Color(0, 1, 0, 1)); // lime
            if ((currpacksize == packsize1 || currpacksize == packsize2) && Enemy.Name == "Diplodocus" && AlGlobalVar.LevelValue == 3)
            {
                labeldesc.text = labeldesc.text + "\r\nYou and your pack attacked the " + Enemy.Name + ".";
            }
            else
            {
                labeldesc.text = labeldesc.text + "\r\nYou attacked the " + Enemy.Name + ".";
            }
            labeldesc.color = Color.white;
            enemyDefeated = false;
        }
    }

    void doEnemyAttack(AlEnemies Enemy, string enemynum, double alfierceness, double alhealth, double alhealthfull, bool alFirst, out bool alDefeated)
    {
        double damage = 0;
        damage = 0.75 * ((Enemy.bFierceness + 0.1) / alfierceness) * (Enemy.bEnergy / 5);
        alhealth = alhealth - damage;
        double healthchange = (alhealth * 100) / alhealthfull;
        AlGlobalVar.FitnessValue = AlGlobalVar.FitnessValue - (100 - (int)healthchange);
        labelfitness.text = "Fitness: " + AlGlobalVar.FitnessValue + "%";
        if (AlGlobalVar.FitnessValue < 40)
        {
            labelfitness.color = Color.red;
            picturealfitnessgreen.SetSpriteImage("aloutlinered");
            Image currimage = picturealfitnessgreen.GetImage();
            currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
        }
        else if (AlGlobalVar.FitnessValue < 70)
        {
            labelfitness.color = Color.yellow;
            picturealfitnessgreen.SetSpriteImage("aloutlineyellow");
            Image currimage = picturealfitnessgreen.GetImage();
            currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
        }
        else
        {
            labelfitness.color = Color.white;
            picturealfitnessgreen.SetSpriteImage("aloutlinegreen");
            Image currimage = picturealfitnessgreen.GetImage();
            currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
        }
        if (AlGlobalVar.FitnessValue <= 0)
        {
            AlGlobalVar.FitnessValue = 0;
            labelfitness.text = "Fitness: " + AlGlobalVar.FitnessValue + "%";
            gameover("You have been killed by the " + Enemy.Name + "!");
            alDefeated = true;
        }
        else
        {
            if (alFirst)
                labeldesc.text = labeldesc.text + "\r\nThe " + Enemy.Name + " attacked you!";
            else
            {
                labeldesc.text = labeldesc.text + "\r\nThe " + Enemy.Name + " attacked first!";
                labeldesc.color = Color.red;
            }
            alDefeated = false;
        }
    }

    void EnemyDefeated(AlEnemies Enemy, string enemynum)
    {
        GameData.Enemies.Find(x => x.Name == Enemy.Name).bEnergy = GameData.Enemies.Find(x => x.Name == Enemy.Name).Energy;
        if (enemynum == "1")
        {
            toggleenemy(1, false);
            e1 = "Missingno";
        }
        if (enemynum == "2")
        {
            toggleenemy(2, false);
            e2 = "Missingno";
        }
        if (enemynum == "3")
        {
            toggleenemy(3, false);
            e3 = "Missingno";
        }
        if (enemynum == "4")
        {
            toggleenemy(4, false);
            e4 = "Missingno";
        }
        if ((currpacksize == packsize1 || currpacksize == packsize2) && Enemy.Name == "Diplodocus" && AlGlobalVar.LevelValue == 3)
        {
            diplohunted = true;
        }
        labeldesc.text = labeldesc.text + "\r\nYou have killed the " + Enemy.Name + "!\r\nYou ate the " + Enemy.Name + ". \r\nKeep growing!";
        labeldesc.color = Color.white;
        AlGlobalVar.WeightValue = AlGlobalVar.WeightValue + (GameData.Enemies.Find(x => x.Name == Enemy.Name).Energy / 10) * AlGlobalVar.GetAlGrowSpeed();
        AlGlobalVar.ScoreValue = AlGlobalVar.ScoreValue
            + (int)(GameData.Enemies.Find(x => x.Name == Enemy.Name).Energy / 100
            + GameData.Enemies.Find(x => x.Name == Enemy.Name).Fierceness / 10);
        labelscore.text = "Score: " + AlGlobalVar.ScoreValue;
        if (AlGlobalVar.LevelValue == 1 && AlGlobalVar.WeightValue > 100)
        {
            StartCoroutine("levelup");
            allevelup = true;
        }
        if (AlGlobalVar.LevelValue == 2 && AlGlobalVar.WeightValue > 1000)
        {
            StartCoroutine("levelup");
            allevelup = true;
        }
        if (AlGlobalVar.LevelValue == 3 && AlGlobalVar.WeightValue > 2000 && diplohunted == true)
        {
            StartCoroutine("levelup");
            allevelup = true;
        }
        else if (AlGlobalVar.LevelValue == 3 && AlGlobalVar.WeightValue > 2000 && lvl3cap == false)
        {
            string message = "You've gotten pretty big! But you don't know everything yet...\r\nJoin a pack and take down a diplodocus to reach level 4.";
            string button1 = "Okay...";
            pause = true;
            labeldesc.text = "Game paused.";
            labeldesc.color = Color.red;
            labeldesc.fontStyle = FontStyle.Bold;
            buttonpause.GetComponentInChildren<Text>().color = Color.red;
            Popupbox.showPopupbox(message, button1, "");
            Popupbox.Button1Clicked += new EventHandler(frm_Button1Clicked);
            pause = false;
            labeldesc.text = "";
            labeldesc.color = Color.white;
            labeldesc.fontStyle = FontStyle.Normal;
            buttonpause.GetComponentInChildren<Text>().color = Color.green;
            lvl3cap = true;
        }
        if (AlGlobalVar.WeightValue > 3000)
        {
            AlGlobalVar.WeightValue = 3000;
            labelweight.text = "Weight: " + AlGlobalVar.WeightValue + "kg";
            picturealweight.SetRectWidthHeight(
            new Vector2(picturealweightminsize.x + ((float)AlGlobalVar.WeightValue / 3000) * (picturealweightfullsize.x - picturealweightminsize.x),
            picturealweightminsize.y + ((float)AlGlobalVar.WeightValue / 3000) * (picturealweightfullsize.y - picturealweightminsize.x)));
        }
        labelweight.text = "Weight: " + AlGlobalVar.WeightValue + "kg";
        if (AlGlobalVar.WeightValue < 3000)
        {
            picturealweight.SetRectWidthHeight(
            new Vector2(picturealweightminsize.x + ((float)AlGlobalVar.WeightValue / 3000) * (picturealweightfullsize.x - picturealweightminsize.x),
            picturealweightminsize.y + ((float)AlGlobalVar.WeightValue / 3000) * (picturealweightfullsize.y - picturealweightminsize.x)));
        }
        string scloc = "" + alcloc1 + alcloc2;
        int scloc2 = int.Parse(scloc);
        AlGlobalVar.FitnessValue = AlGlobalVar.FitnessValue + 10
            * (GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Zone / (AlGlobalVar.LevelValue * 2))
            * AlGlobalVar.GetAlGrowSpeed();
        if (AlGlobalVar.FitnessValue > 100)
            AlGlobalVar.FitnessValue = 100;
        labelfitness.text = "Fitness: " + AlGlobalVar.FitnessValue + "%";
        if (AlGlobalVar.FitnessValue < 40)
        {
            labelfitness.color = Color.red;
            picturealfitnessgreen.SetSpriteImage("aloutlinered");
            Image currimage = picturealfitnessgreen.GetImage();
            currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
        }
        else if (AlGlobalVar.FitnessValue < 70)
        {
            labelfitness.color = Color.yellow;
            picturealfitnessgreen.SetSpriteImage("aloutlineyellow");
            Image currimage = picturealfitnessgreen.GetImage();
            currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
        }
        else
        {
            labelfitness.color = Color.white;
            picturealfitnessgreen.SetSpriteImage("aloutlinegreen");
            Image currimage = picturealfitnessgreen.GetImage();
            currimage.fillAmount = (float)(AlGlobalVar.FitnessValue / 100);
        }
        AlGlobalVar.EnergyValue = Math.Min(AlGlobalVar.EnergyValue + 20, Math.Ceiling(AlGlobalVar.EnergyValue + 10
            * ((GameData.Enemies.Find(x => x.Name == Enemy.Name).Energy / AlGlobalVar.WeightValue) + 3
            * (((alcloc2 - alcloc1) + 10) / (AlGlobalVar.LevelValue))) * AlGlobalVar.GetAlGrowSpeed()));
        if (AlGlobalVar.EnergyValue > 100)
            AlGlobalVar.EnergyValue = 100;
        labelenergy.text = "Energy: " + AlGlobalVar.EnergyValue + "%";
        if (AlGlobalVar.EnergyValue < 40)
        {
            labelenergy.color = Color.red;
            picturealenergygreen.SetSpriteImage("aloutlinered");
            Image currimage2 = picturealenergygreen.GetImage();
            currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
        }
        else if (AlGlobalVar.EnergyValue < 70)
        {
            labelenergy.color = Color.yellow;
            picturealenergygreen.SetSpriteImage("aloutlineyellow");
            Image currimage2 = picturealenergygreen.GetImage();
            currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
        }
        else
        {
            labelenergy.color = Color.white;
            picturealenergygreen.SetSpriteImage("aloutlinegreen");
            Image currimage2 = picturealenergygreen.GetImage();
            currimage2.fillAmount = (float)(AlGlobalVar.EnergyValue / 100);
        }
    }

    [HideInInspector] public string e1 = "Missingno";
    [HideInInspector] public string e2 = "Missingno";
    [HideInInspector] public string e3 = "Missingno";
    [HideInInspector] public string e4 = "Missingno";
    private void doflavourtext()
    {
        int count = 0;
        if (e1 != "Missingno")
            count = count + 1;
        if (e2 != "Missingno")
            count = count + 1;
        if (e3 != "Missingno")
            count = count + 1;
        if (e4 != "Missingno")
            count = count + 1;

        #region flavourtext
        string eflavtext = "";
        if (count > 0)
            eflavtext = "\r\nYou can see ";
        if (e1 != "Missingno")
        {
            eflavtext = eflavtext + GameData.Enemies.Find(x => x.Name == e1).textName + GameData.Enemies.Find(x => x.Name == e1).Name + GameData.Enemies.Find(x => x.Name == e1).Flavtext;
            count = count - 1;
            eflavtext = appendflavourtext(eflavtext, count);
        }
        if (e2 != "Missingno")
        {
            eflavtext = eflavtext + GameData.Enemies.Find(x => x.Name == e2).textName + GameData.Enemies.Find(x => x.Name == e2).Name + GameData.Enemies.Find(x => x.Name == e2).Flavtext;
            count = count - 1;
            eflavtext = appendflavourtext(eflavtext, count);
        }
        if (e3 != "Missingno")
        {
            eflavtext = eflavtext + GameData.Enemies.Find(x => x.Name == e3).textName + GameData.Enemies.Find(x => x.Name == e3).Name + GameData.Enemies.Find(x => x.Name == e3).Flavtext;
            count = count - 1;
            eflavtext = appendflavourtext(eflavtext, count);
        }
        if (e4 != "Missingno")
        {
            eflavtext = eflavtext + GameData.Enemies.Find(x => x.Name == e4).textName + GameData.Enemies.Find(x => x.Name == e4).Name + GameData.Enemies.Find(x => x.Name == e4).Flavtext;
            count = count - 1;
            eflavtext = appendflavourtext(eflavtext, count);
        }
        string scloc = "" + alcloc1 + alcloc2;
        int scloc2 = int.Parse(scloc);
        labeldesc.text = "You are " + GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Name;
        labeldesc.text = labeldesc.text + eflavtext;
        #endregion flavourtext
    }
    private string appendflavourtext(string eflavtext, int count)
    {
        if (count > 0)
        {
            if (count == 1)
                eflavtext = eflavtext + ", \r\nand ";
            else
                eflavtext = eflavtext + ", \r\n";
        }
        else
        {
            eflavtext = eflavtext + ".";
        }
        return eflavtext;
    }


    public void generateenemies()
    {
        resetfiveTimer(); // reset enemy timer
        clearenemies();

        // reset enemy stats
        for (int a = 0; a < GameData.Enemies.Count; a++)
        {
            if (GameData.Enemies[a].Name != "mother Allosaurus")
            {
                GameData.Enemies[a].bEnergy = (double)random.Next(Convert.ToInt32(GameData.Enemies[a].Energy - GameData.Enemies[a].Energy * 0.2),
                    Convert.ToInt32(GameData.Enemies[a].Energy + GameData.Enemies[a].Energy * 0.2))
                    + GameData.Enemies[a].Energy * 0.4 * ((alcloc2 - alcloc1) / 17);
                GameData.Enemies[a].bAgility = GameData.Enemies[a].Agility
                    + GameData.Enemies[a].Agility * 0.4 * ((alcloc2 - alcloc1) / 17);
                GameData.Enemies[a].bFierceness = (double)random.Next(Convert.ToInt32(GameData.Enemies[a].Fierceness - GameData.Enemies[a].Fierceness * 0.2),
                    Convert.ToInt32(GameData.Enemies[a].Fierceness + GameData.Enemies[a].Fierceness * 0.2))
                    + GameData.Enemies[a].Fierceness * 0.4 * ((alcloc2 - alcloc1) / 17);
            }
        }

        // generate new enemies
        string scloc = "" + alcloc1 + alcloc2;
        int scloc2 = int.Parse(scloc);
        int currZone = GameData.Zones.Find(x => Array.IndexOf(x.Maps, scloc2) >= 0).Zone;
        List<AlEnemies> CurrEnemies = GameData.Enemies.FindAll(x => (x.CommonZone1 == currZone) || (x.CommonZone2 == currZone));
        List<string> possEnemies = new List<string>
        {
            "Missingno"
        };
        for (int a = CurrEnemies.Count - 1; a >= 0; a--)
        {
            possEnemies.Add(CurrEnemies[a].Name);
        };
        for (int a = CurrEnemies.Count - 1; a >= 0; a--)
        {
            possEnemies.Add(CurrEnemies[a].Name);
        };
        CurrEnemies.AddRange(GameData.Enemies.FindAll(x => (x.RareZone1 == currZone) || (x.RareZone2 == currZone)));
        for (int a = CurrEnemies.Count - 1; a >= 0; a--)
        {
            possEnemies.Add(CurrEnemies[a].Name);
        };
        AlGlobalVar.Shuffle(possEnemies);
        if (possEnemies.Count > 4)
            possEnemies.RemoveRange(3, possEnemies.Count - 4);
        e1 = possEnemies[random.Next(0, possEnemies.Count)];
        e2 = possEnemies[random.Next(0, possEnemies.Count)];
        e3 = possEnemies[random.Next(0, possEnemies.Count)];
        e4 = possEnemies[random.Next(0, possEnemies.Count)];
        enemylist.RemoveAll(e => e.Length > 0);

        CurrEnemies.RemoveAll(e => e.Name != "");
        for (int a = possEnemies.Count - 1; a >= 0; a--)
        {
            CurrEnemies.Add(GameData.Enemies.Find(x => x.Name == possEnemies[a]));
        };
        int disappear1 = random.Next(0, CurrEnemies.Count);
        int disappear2 = random.Next(0, CurrEnemies.Count);
        int disappear3 = random.Next(0, CurrEnemies.Count);
        int disappear4 = random.Next(0, CurrEnemies.Count);

        // chance to disappear
        if (disappear1 < CurrEnemies.Count - 1)
            e1 = "Missingno";
        if (disappear2 < CurrEnemies.Count - 2)
            e2 = "Missingno";
        if (disappear3 < CurrEnemies.Count - 1)
            e3 = "Missingno";
        if (disappear4 < CurrEnemies.Count - 2)
            e4 = "Missingno";
        enemylist.Add(e1);
        enemylist.Add(e2);
        enemylist.Add(e3);
        enemylist.Add(e4);
        CurrEnemies.RemoveAll(item => 1 == 1);
        CurrEnemies.Add(GameData.Enemies.Find(x => x.Name == e1));
        CurrEnemies.Add(GameData.Enemies.Find(x => x.Name == e2));
        CurrEnemies.Add(GameData.Enemies.Find(x => x.Name == e3));
        CurrEnemies.Add(GameData.Enemies.Find(x => x.Name == e4));
        for (int a = CurrEnemies.Count - 1; a >= 0; a--)
        {
            if (enemylist[a] == "Missingno")
                CurrEnemies.RemoveAt(a);
        }
        int count = 0;
        if (e1 != "Missingno")
            count = count + 1;
        if (e2 != "Missingno")
            count = count + 1;
        if (e3 != "Missingno")
            count = count + 1;
        if (e4 != "Missingno")
            count = count + 1;
        doflavourtext();
        string[] earray = new string[] { e1, e2, e3, e4 };
        for (int a = 0; a < 4; a++)
        {
            int b = a + 1;
            if (earray[a] != "Missingno")
            {
                updateAlstats();
                FormsObject picturee0energybar = new FormsObject(GetControlByName("picturee" + b + "energybar").name);
                FormsObject picturee0fiercebar = new FormsObject(GetControlByName("picturee" + b + "fiercebar").name);
                FormsObject picturee0agilitybar = new FormsObject(GetControlByName("picturee" + b + "agilitybar").name);
                int imageID = GameData.Enemies.Find(x => x.Name == earray[a]).ImageID;
                GetControlByName("pictureenemy" + b).GetComponent<SpriteRenderer>().sprite = Resources.Load("pictureFF" + imageID, typeof(Sprite)) as Sprite;
                GetControlByName("labelenemyname" + b).GetComponent<Text>().text = GameData.Enemies.Find(x => x.Name == earray[a]).Name;
                GetControlByName("labelenemy" + b + "data").GetComponent<Text>().text = String.Format("{0:0.00}", GameData.Enemies.Find(x => x.Name == earray[a]).bFierceness)
                    + "\r\n" + String.Format("{0:0.00}", GameData.Enemies.Find(x => x.Name == earray[a]).bAgility)
                    + "\r\n" + String.Format("{0:0.00}", GameData.Enemies.Find(x => x.Name == earray[a]).bEnergy);
                picturee0energybar.SetRectWidth((int)(40 * (GameData.Enemies.Find(x => x.Name == earray[a]).bEnergy / GameData.Enemies.Find(x => x.Name == earray[a]).Energy)));
                if (picturee0energybar.GetRectWidth() > 40)
                    picturee0energybar.SetRectWidth(40);
                picturee0energybar.SetSpriteColor(new Color(0, 1, 0, 1)); // lime
            picturee0fiercebar.SetRectWidth((int)(40 * (GameData.Enemies.Find(x => x.Name == earray[a]).bFierceness / 1000)));
                picturee0agilitybar.SetRectWidth((int)(40 * (GameData.Enemies.Find(x => x.Name == earray[a]).bAgility)));
                if (GameData.Enemies.Find(x => x.Name == earray[a]).bFierceness > AlGlobalVar.Alfierceness)
                {
                    GetControlByName("labelenemy" + b + "data").GetComponent<Text>().color = Color.red;
                    picturee0fiercebar.SetSpriteColor(Color.red);
                }
                else
                {
                    GetControlByName("labelenemy" + b + "data").GetComponent<Text>().color = Color.white;
                    picturee0fiercebar.SetSpriteColor(new Color(0, 1, 0, 1)); //lime
            }
                if (GetControlByName("pictureenemy" + b).GetComponent<SpriteRenderer>().enabled == false)
                {
                    toggleenemy(b, true);
                }
                GameData.Enemies.Find(x => x.Name == earray[a]).Seen = true;
                if (earray[a] == "Allosaurus (female)" && AlGlobalVar.LevelValue == 4)
                {
                    GetControlByName("FFbutton" + b).GetComponentInChildren<Text>().text = "Mate";
                    GetControlByName("FFbutton" + b).GetComponentInChildren<Text>().color = Color.red;
                }
                else
                {
                    GetControlByName("FFbutton" + b).GetComponentInChildren<Text>().text = "Fact File";
                    GetControlByName("FFbutton" + b).GetComponentInChildren<Text>().color = Color.white;
                }
            }
            else
            {
                if (GetControlByName("pictureenemy" + b).GetComponent<SpriteRenderer>().enabled)
                {
                    toggleenemy(b, false);
                }
            }
            if (AlGlobalVar.LevelValue == 1 && AlGlobalVar.level1choice == 1 && alcloc1 == mloc1 && alcloc2 == mloc2)
            {
                showmother();
            }

            // 'seen all' bonus
            int seencount = 0;
            for (int s = 0; s < GameData.Enemies.Count; s++)
            {
                if (GameData.Enemies[s].Seen == true)
                {
                    seencount = seencount + 1;
                }
            }
            if (seencount == GameData.Enemies.Count && seenbonus == false
                || (seencount == GameData.Enemies.Count - 1 && GameData.Enemies.Find(x => x.Name == "mother Allosaurus").Seen == false && seenbonus == false))
            {
                seenbonus = true;
                AlGlobalVar.ScoreValue = AlGlobalVar.ScoreValue + 1000;
                labelscore.text = "Score: " + AlGlobalVar.ScoreValue;
                string message = "Congratulations! You've encountered all the species in the game!\r\nScore bonus: 1000 points";
                string button1 = "Okay!";
                string button2 = "";
                pause = true;
                labeldesc.text = "Game paused.";
                labeldesc.color = Color.red;
                labeldesc.fontStyle = FontStyle.Bold; 
                buttonpause.GetComponentInChildren<Text>().color = Color.red;
                Popupbox.showPopupbox(message, button1, button2);
                Popupbox.Button1Clicked += new EventHandler(frm_Button1Clicked);
                Popupbox.Button2Clicked += new EventHandler(frm_Button2Clicked);
                pause = false;
                labeldesc.text = "";
                labeldesc.color = Color.white;
                labeldesc.fontStyle = FontStyle.Normal; 
                buttonpause.GetComponentInChildren<Text>().color = Color.green;
            }
        }
        fivetimer = true; // start enemy timer
    }

    public void toggleenemy(int enemyNumber, bool show)
    {
        for (int n = enemyNumber; n < (enemyNumber + 1); n++)
        {
            GetControlByName("pictureenemy" + n).GetComponent<SpriteRenderer>().enabled = show;
            GetControlByName("labelenemy" + n).GetComponent<Text>().enabled = show;
            GetControlByName("labelenemyname" + n).GetComponent<Text>().enabled = show;
            GetControlByName("labelenemy" + n + "data").GetComponent<Text>().enabled = show;
            GetControlByName("attackbutton" + n).GetComponentInChildren<Text>().enabled = show;
            GetControlByName("FFbutton" + n).GetComponentInChildren<Text>().enabled = show;
            GetControlByName("attackbutton" + n).GetComponent<Image>().enabled = show;
            GetControlByName("FFbutton" + n).GetComponent<Image>().enabled = show;
            GetControlByName("picturee" + n + "energybar").GetComponent<Image>().enabled = show;
            GetControlByName("picturee" + n + "fiercebar").GetComponent<Image>().enabled = show;
            GetControlByName("picturee" + n + "agilitybar").GetComponent<Image>().enabled = show;
        }
    }
    

    public void fleefightenemies()
    {
        allevelup = false;
        string[] earray = new string[] { e1, e2, e3, e4 };
        if (AlGlobalVar.FitnessValue == 0 || AlGlobalVar.EnergyValue == 0)
        { }
        else
        {
            for (int a = 0; a < 4; a++)
            {
                int b = a + 1;
                string enemy2num = "" + b;
                if (earray[a] != "Missingno" && earray[a] != "Dinosaur Egg" && earray[a] != "mother Allosaurus")
                {
                    updateAlstats();
                    if ((GameData.Enemies.Find(x => x.Name == earray[a]).bFierceness < AlGlobalVar.Alfierceness || e1 == "mother Allosaurus"))
                    {
                        if (a == 0)
                        {
                            if (pictureenemy1.GetSpriteRenderer().enabled)
                            {
                                toggleenemy(1, false);
                                e1 = "Missingno";
                            }
                        }
                        else if (a == 1)
                        {
                            if (pictureenemy2.GetSpriteRenderer().enabled)
                            {
                                toggleenemy(2, false);
                                e2 = "Missingno";
                            }
                        }
                        else if (a == 2)
                        {
                            if (pictureenemy3.GetSpriteRenderer().enabled)
                            {
                                toggleenemy(3, false);
                                e3 = "Missingno";
                            }
                        }
                        else if (a == 3)
                        {
                            if (pictureenemy4.GetSpriteRenderer().enabled)
                            {
                                toggleenemy(4, false);
                                e4 = "Missingno";
                            }
                        }
                        labeldesc.text = labeldesc.text + "\r\nThe " + earray[a] + " fled!";
                    }
                    else if (GameData.Enemies.Find(x => x.Name == earray[a]).bFierceness > AlGlobalVar.Alfierceness && (e1 != "mother Allosaurus" || mumknows == false))
                    {
                        b = a + 1;
                        string enemynum = "" + b;
                        atkdone = false;
                        if (allevelup == false)
                            dobattle(GameData.Enemies.Find(x => x.Name == earray[a]), enemynum, AlGlobalVar.Alfierceness, AlGlobalVar.Alagility, AlGlobalVar.Alhealth);
                        updateAlstats();
                    }
                }
            }
            allevelup = false;
        }
    }
    #endregion battling    
}
