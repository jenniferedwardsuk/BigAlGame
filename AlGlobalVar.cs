﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlGlobalVar {
    
    static string _currFF;
    static int _score;
    static int _lastlvlScore;
    static double _level;
    static double _weight;
    static double _energy;
    static double _fitness;
    public static double Alfierceness;
    public static double Alagility;
    public static double Alhealth;
    public static double algrowspeed;
    static int _lastlvlcloc1;
    static int _lastlvlcloc2;
    public static int level1choice = 0;
    public static int level2choice = 0;
    public static int level3choice = 0;
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list) // from stackoverflow
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    // game data arrays
    public static List<AlMapZones> Zones = new List<AlMapZones>
    {
        new AlMapZones() {Zone=0, Name = "in an unknown location... how did you get here?", Maps = new int[] {0}}, //dummy
        new AlMapZones() {Zone=1, Name = "in the forest.", Maps = new int[20] {11,12,22,33,34,43,44,54,62,63,64,72,73,74,81,82,83,91,92,101}}, //forest
        new AlMapZones() {Zone=11, Name = "deep in the forest.", Maps = new int[9] {21,31,32,41,42,52,53,61,71}}, //deep forest
        new AlMapZones() {Zone=2, Name = "at the edge of the forest. \r\nYou can see the plains stretching South.", Maps = new int[6] {55,65,75,85,93,102} }, //forest outskirts
        new AlMapZones() {Zone=21, Name = "on the plains.", Maps = new int[20] {66,76,77,86,87,88,94,95,96,97,98,99,103,104,105,106,107,108,109,1010}}, //forest outskirts
        new AlMapZones() {Zone=3, Name = "crossing a wide river.", Maps = new int[16] {14,15,25,26,27,37,38,48,49,59,69,610,710,810,811,912}}, //river
        new AlMapZones() {Zone=4, Name = "on swampy ground. Be careful!", Maps = new int[6] {910,911,913,1011,1012,1013}}, //quicksand
        new AlMapZones() {Zone=5, Name = "in a large area of desert scrubland.", Maps = new int[43] {110,111,112,114,115,211,212,215,311,312,315,316,317,412,413,416,417,512,513,514,517,612,613,614,615,713,714,715,716,717,813,814,815,816,817,914,915,916,917,1014,1015,1016,1017}}, //scrubland
        new AlMapZones() {Zone=6, Name = "in the riverlands.", Maps = new int[32] {13,16,17,18,19,23,24,28,210,35,36,39,310,45,46,47,410,411,56,57,58,510,511,67,68,611,78,79,711,712,89,812}}, //riverlands
        new AlMapZones() {Zone=7, Name = "on the sauropod migration path.", Maps = new int[11] {113,213,214,313,314,414,415,515,516,616,617}}, //migration
        new AlMapZones() {Zone=8, Name = "at a dinosaur nest - is anything guarding it?", Maps = new int[3] {51,84,29}}, //dino nest
        new AlMapZones() {Zone=9, Name = "at an oasis in the desert.", Maps = new int[4] {116,117,216,217}} //oasis
    };
    public static List<AlEnemies> Enemies = new List<AlEnemies>
    {
        new AlEnemies() { Name="Dinosaur Egg", Fierceness=0, bFierceness=0, Agility=0, bAgility=0, Energy=80, bEnergy=80, ImageID=1, Seen=true, CommonZone1=0,CommonZone2=0,RareZone1=0,RareZone2=8, textName="a ",Flavtext=""},
        new AlEnemies() { Name="Dragonfly", Fierceness=0, bFierceness=0, Agility=0.5, bAgility=0.5, Energy=50, bEnergy=50, ImageID=2, Seen=false, CommonZone1=4,CommonZone2=6,RareZone1=1,RareZone2=21, textName="a ",Flavtext=" hovering nearby"},
        new AlEnemies() { Name="Centipede", Fierceness=0.1, bFierceness=0.1, Agility=0.3, bAgility=0.3, Energy=100, bEnergy=100, ImageID=3, Seen=false, CommonZone1=1,CommonZone2=21,RareZone1=2,RareZone2=11, textName="a ",Flavtext=" crawling by"},
        new AlEnemies() { Name="Scorpion", Fierceness=1, bFierceness=1, Agility=0.4, bAgility=0.4, Energy=100, bEnergy=100, ImageID=4, Seen=false, CommonZone1=2,CommonZone2=21,RareZone1=5,RareZone2=11, textName="a ",Flavtext=" nearby"},
        new AlEnemies() { Name="Frog", Fierceness=0.5, bFierceness=0.5, Agility=0.2, bAgility=0.2, Energy=180, bEnergy=180, ImageID=5, Seen=false, CommonZone1=3,CommonZone2=6,RareZone1=1,RareZone2=0, textName="a ",Flavtext=" sitting nearby"},
        new AlEnemies() { Name="Lizard", Fierceness=2.5, bFierceness=2.5, Agility=0.5, bAgility=0.5, Energy=208, bEnergy=208, ImageID=6, Seen=false, CommonZone1=1,CommonZone2=2,RareZone1=21,RareZone2=11, textName="a ",Flavtext=" in the undergrowth"},
        new AlEnemies() { Name="Iguana", Fierceness=5, bFierceness=5, Agility=0.4, bAgility=0.4, Energy=260, bEnergy=260, ImageID=7, Seen=false, CommonZone1=3,CommonZone2=6,RareZone1=0,RareZone2=0, textName="a ",Flavtext=" sunbathing nearby"},
        new AlEnemies() { Name="Rhamphorhynchus", Fierceness=20, bFierceness=20, Agility=0.8, bAgility=0.8, Energy=170, bEnergy=170, ImageID=8, Seen=false, CommonZone1=6,CommonZone2=0,RareZone1=4,RareZone2=3, textName="a ",Flavtext=" resting"},
        new AlEnemies() { Name="Allosaurus (hatchling)", Fierceness=80, bFierceness=80, Agility=0.6, bAgility=0.6, Energy=100, bEnergy=100, ImageID=9, Seen=true, CommonZone1=2,CommonZone2=21,RareZone1=1,RareZone2=11, textName="an ",Flavtext=""},
        new AlEnemies() { Name="Othnielia", Fierceness=10, bFierceness=10, Agility=0.7, bAgility=0.7, Energy=300, bEnergy=300, ImageID=10, Seen=false, CommonZone1=1,CommonZone2=6,RareZone1=2,RareZone2=21, textName="an ",Flavtext=" hiding nearby"},
        new AlEnemies() { Name="Dryosaurus", Fierceness=40, bFierceness=40, Agility=0.7, bAgility=0.7, Energy=400, bEnergy=400, ImageID=11, Seen=false, CommonZone1=6,CommonZone2=0,RareZone1=2,RareZone2=21, textName="a ",Flavtext=" feeding nearby"},
        new AlEnemies() { Name="Ornitholestes", Fierceness=100, bFierceness=100, Agility=0.5, bAgility=0.5, Energy=400, bEnergy=400, ImageID=12, Seen=false, CommonZone1=0,CommonZone2=6,RareZone1=2,RareZone2=8, textName="an ",Flavtext=" lurking"},
        new AlEnemies() { Name="Allosaurus (juvenile)", Fierceness=394, bFierceness=394, Agility=0.7, bAgility=0.7, Energy=500, bEnergy=500, ImageID=13, Seen=false, CommonZone1=6,CommonZone2=0,RareZone1=2,RareZone2=0, textName="an ",Flavtext=""},
        new AlEnemies() { Name="Pterosaur", Fierceness=750, bFierceness=750, Agility=0.6, bAgility=0.6, Energy=500, bEnergy=500, ImageID=14, Seen=false, CommonZone1=5,CommonZone2=0,RareZone1=7,RareZone2=9, textName="a ",Flavtext=" soaring overhead"},
        new AlEnemies() { Name="Crocodile", Fierceness=800, bFierceness=800, Agility=0.2, bAgility=0.2, Energy=1000, bEnergy=1000, ImageID=15, Seen=false, CommonZone1=3,CommonZone2=3,RareZone1=6,RareZone2=0, textName="a ",Flavtext=" approaching"},
        new AlEnemies() { Name="Allosaurus (subadult)", Fierceness=700, bFierceness=700, Agility=0.8, bAgility=0.8, Energy=1000, bEnergy=1000, ImageID=16, Seen=false, CommonZone1=5,CommonZone2=0,RareZone1=6,RareZone2=0, textName="an ",Flavtext=""},
        new AlEnemies() { Name="Stegosaurus", Fierceness=600, bFierceness=600, Agility=0.4, bAgility=0.4, Energy=1500, bEnergy=1500, ImageID=17, Seen=false, CommonZone1=9,CommonZone2=9,RareZone1=5,RareZone2=0, textName="a ",Flavtext=" feeding nearby"},
        new AlEnemies() { Name="Allosaurus (male)", Fierceness=900, bFierceness=900, Agility=0.9, bAgility=0.9, Energy=1500, bEnergy=1500, ImageID=18, Seen=false, CommonZone1=7,CommonZone2=9,RareZone1=5,RareZone2=0, textName="an ",Flavtext=""},
        new AlEnemies() { Name="Allosaurus (female)", Fierceness=1000, bFierceness=1000, Agility=0.9, bAgility=0.9, Energy=2000, bEnergy=2000, ImageID=19, Seen=false, CommonZone1=9,CommonZone2=0,RareZone1=7,RareZone2=5, textName="an ",Flavtext=""},
        new AlEnemies() { Name="Diplodocus", Fierceness=850, bFierceness=850, Agility=0.4, bAgility=0.4, Energy=5000, bEnergy=5000, ImageID=20, Seen=false, CommonZone1=7,CommonZone2=0,RareZone1=9,RareZone2=0, textName="a ",Flavtext=" passing by"},
        new AlEnemies() { Name="mother Allosaurus", Fierceness=1000, bFierceness=1000, Agility=0.9, bAgility=0.9, Energy=2000, bEnergy=2000, ImageID=19, Seen=false, CommonZone1=0,CommonZone2=0,RareZone1=0,RareZone2=0, textName="your ",Flavtext=""},
    };
    public static List<PaleoQuestions> PQs = new List<PaleoQuestions>
    {
        new PaleoQuestions() {Question="The Paleozoic period does not include the: ",A1="Ordovician",A2="Jurassic",A3="Cambrian",A4="Permian",Answer="2"},
        new PaleoQuestions() {Question="Which era was dominated by the dinosaurs?",A1="Precambrian",A2="Paleozoic",A3="Mesozoic",A4="Cenozoic",Answer="3"},
        new PaleoQuestions() {Question="Fossils are most common in which rock types?",A1="Sedimentary",A2="Igneous",A3="Metamorphic",A4="All of these",Answer="1"},
        new PaleoQuestions() {Question="Which of the following is least likely to make a fossil?",A1="Decomposed plants",A2="Plant impressions",A3="Animal footprints",A4="Animal bones",Answer="1"},
        new PaleoQuestions() {Question="What is amber?",A1="Sticky resin",A2="A hard shell",A3="Hardened tree sap",A4="Insect bodies",Answer="3"},
        new PaleoQuestions() {Question="Which of the following is an example of mineral replacement?",A1="La Brea tar pits",A2="Petrified wood",A3="Hardened tree sap",A4="A frozen mammoth",Answer="2"},
        new PaleoQuestions() {Question="One of the largest dinosaurs, Argentinosaurus, is believed to have been how long?",A1="100ft",A2="120ft",A3="80ft",A4="50ft",Answer="2"},
        new PaleoQuestions() {Question="The biggest dinosaur skull ever found was the skull of Torosaurus, how long was it?",A1="9ft",A2="4ft",A3="16ft",A4="2ft",Answer="1"},
        new PaleoQuestions() {Question="The first dinosaur to be described scientifically was Megalosaurus, in: ",A1="1902",A2="1921",A3="1612",A4="1824",Answer="4"},
        new PaleoQuestions() {Question="The most popular estimate of the maximum running speed for a T-Rex is: ",A1="18mph",A2="25mph",A3="30mph",A4="3mph",Answer="1"},
        new PaleoQuestions() {Question="How many dinosaur species have been officially named?",A1="Over 5000",A2="About 300",A3="About 700",A4="Over 10000",Answer="3"},
        new PaleoQuestions() {Question="What are the requirements for an animal to be called a dinosaur?",A1="Socketed teeth",A2="Attached vertebrae",A3="Open hip socket",A4="Three-toed feet",Answer="3"}
    };
    public static List<FactFiles> AlFactFiles = new List<FactFiles>
    {
        new FactFiles() { Name="Dinosaur Egg", Facts="Dinosaur Egg.\r\nThe first fossilized dinosaur eggs found (and the biggest yet to be found) were football-shaped Hypselosaurus eggs found in France in 1869. These eggs were 1 foot (30 cm) long, 10 inches (25 cm) wide, had a volume of about half a gallon (2 liters), and may have weighed up to 15.5 pounds (7 kg).", ImageID=1},
        new FactFiles() { Name="Dragonfly", Facts="Dragonfly.\r\nThe biggest difference between modern and fossil dragonflies is that many of the fossilized ones were several times larger, some having wingspans of over three feet! If anything, dragonflies have devolved, not evolved.", ImageID=2},
        new FactFiles() { Name="Centipede", Facts="Centipede.\r\nEuphoberia was much like the modern centipede in shape and behavior, but with the distinction of being over three feet long. Fossil accounts of these beasts have been found across Europe and North America.", ImageID=3},
        new FactFiles() { Name="Scorpion", Facts="Scorpion.\r\nEarly fossil remains are dated about 430 million years ago. Young Scorpions ride on their mothers back for the first weeks of life. The average lifespan in the wild for the Scorpion is 2 to 10 years.", ImageID=4},
        new FactFiles() { Name="Frog", Facts="Frog.\r\nBeelzebufo ampinga, the so-called 'devil frog,' may be the largest frog that ever lived. These beach-ball-size amphibians, now extinct, grew to 16 inches (41 centimeters) in length and weighed about 10 pounds (4.5 kilograms). The ancient devil frogs may have snatched lizards, small vertebrates, and possibly even hatchling dinosaurs.", ImageID=5},
        new FactFiles() { Name="Lizard", Facts="Lizard.\r\nIt is possible for some lizards to lose their tail when they feel that they are in danger. The tail they leave behind will move and confuse the predator. The tail can grow back but will be slimmer and often a different color.", ImageID=6},
        new FactFiles() { Name="Iguana", Facts="Iguana.\r\nGreen, or common, iguanas are among the largest lizards in the Americas, averaging around 6.5 feet (2 meters) long and weighing about 11 pounds (5 kilograms). Iguanas are active during the day, feeding on leaves, flowers, and fruit. They generally live near water and are excellent swimmers.", ImageID=7},
        new FactFiles() { Name="Rhamphorhynchus", Facts="Rhamphorhynchus.\r\nRhamphorhynchus fed mostly on fish, insects, and their larvae, but they also appeared to like horseshoe crab eggs. This modest-sized pterosaur was fairly wide-spread and successful. Their method of catching fish was dip-feeding, lowering their bill into the water when they see fish.", ImageID=8},
        new FactFiles() { Name="Allosaurus (hatchling)", Facts="Allosaurus (hatchling).\r\nIn 1991 'Big Al' (MOR 693), a 95% complete, partially articulated specimen of Allosaurus was discovered. It measured about 8 meters (about 26 ft) in length. MOR 693 was excavated near Shell, Wyoming, by a joint Museum of the Rockies and University of Wyoming Geological Museum team.", ImageID=9},
        new FactFiles() { Name="Othnielia", Facts="Othnielia.\r\nOthnielia was named as a tribute to the paleontologist Othniel C. Marsh. A herbivore, it ate soft, low-lying plants. It was 4ft long and 1ft tall, and weighed about 50 pounds (22.5 kg).", ImageID=10},
        new FactFiles() { Name="Dryosaurus", Facts="Dryosaurus.\r\nDryosaurus may have stored food in its cheeks. Dryosaurus had a long neck and a stiff tail used for balance. It had large eyes, long, thin legs with three toes, and short arms with five long fingers. It had a horny beak, a toothless upper front jaw, and self-sharpening cheek teeth.", ImageID=11},
        new FactFiles() { Name="Ornitholestes", Facts="Ornitholestes.\r\nThere's still a lot of speculation about Ornitholestes: one paleontologist suggests that this dinosaur snatched fish out of lakes and rivers, another maintains that (if Ornitholestes had hunted in packs) it might have been capable of taking down plant-eating dinosaurs as big as Camptosaurus.", ImageID=12},
        new FactFiles() { Name="Allosaurus (juvenile)", Facts="Allosaurus (juvenile).\r\nAllosaurus is a genus of large theropod dinosaur that lived 155 to 150 million years ago during the late Jurassic period (Kimmeridgian to early Tithonian). The name 'Allosaurus' means 'different lizard'.", ImageID=13},
        new FactFiles() { Name="Pterosaur", Facts="Pterosaur.\r\nThe first pterosaur discovered and described was Pterodactylus Antiquus (above). It was acquired by a German ruler in the late 1700s and kept in a Wunderkammer, or Curiosity Cabinet; the specimen was eventually named by French naturalist Georges Cuvier, who correctly identified it as a flying reptile.", ImageID=14},
        new FactFiles() { Name="Crocodile", Facts="Crocodile.\r\nThe biggest sea-dwelling crocodile ever found has turned up in the Tunisian desert. The whopper of a prehistoric predator grew to over 30 feet long (nearly ten meters) and weighed three tons. Paleontologists have dubbed the new species Machimosaurus rex.", ImageID=15},
        new FactFiles() { Name="Allosaurus (subadult)", Facts="Allosaurus (subadult).\r\nThe completeness, preservation, and scientific importance of this skeleton gave 'Big Al' its name; the individual itself was below the average size for Allosaurus fragilis,[63] and was a subadult estimated at only 87% grown.", ImageID=16},
        new FactFiles() { Name="Stegosaurus", Facts="Stegosaurus.\r\nDue to their distinctive combination of broad, upright plates and tail tipped with spikes, Stegosaurus is one of the most recognizable kinds of dinosaur. Today, it is generally agreed that their spikes were most likely used for defense against predators, while their plates may have been used primarily for display.", ImageID=17},
        new FactFiles() { Name="Allosaurus (male)", Facts="Allosaurus (male).\r\nAllosaurus was a large bipedal predator. Its skull was large and equipped with dozens of sharp, serrated teeth. It averaged 8.5 m (28 ft) in length, though fragmentary remains suggest it could have reached over 12 m (39 ft).", ImageID=18},
        new FactFiles() { Name="Allosaurus (female)", Facts="Allosaurus (female).\r\nSome paleontologists interpret Allosaurus as having had cooperative social behavior, and hunting in packs, while others believe individuals may have been aggressive toward each other, and that congregations of this genus are the result of lone individuals feeding on the same carcasses.", ImageID=19},
        new FactFiles() { Name="Diplodocus", Facts="Diplodocus.\r\nDiplodocus had a 26 foot (8 m) long neck and a 45 foot (14 m) long, whip-like tail. Its head was less than 2 feet long and its nostrils were at the top of the head. The front legs were shorter than its back legs, and all legs had elephant-like, five-toed feet.", ImageID=20},
        new FactFiles() { Name="mother Allosaurus", Facts="Allosaurus (female).\r\nSome paleontologists interpret Allosaurus as having had cooperative social behavior, and hunting in packs, while others believe individuals may have been aggressive toward each other, and that congregations of this genus are the result of lone individuals feeding on the same carcasses.", ImageID=19}
    };

    // Access routines for global variables.
    public static string currFF
    {
        get
        {
            return _currFF;
        }
        set
        {
            _currFF = value;
        }
    }
    public static int ScoreValue
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }
    public static int lastlvlScore
    {
        get
        {
            return _lastlvlScore;
        }
        set
        {
            _lastlvlScore = value;
        }
    }
    public static double LevelValue
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }
    public static double WeightValue
    {
        get
        {
            return _weight;
        }
        set
        {
            _weight = value;
        }
    }
    public static double EnergyValue
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = value;
        }
    }
    public static double FitnessValue
    {
        get
        {
            return _fitness;
        }
        set
        {
            _fitness = value;
        }
    }
    public static int lastlvlcloc1
    {
        get
        {
            return _lastlvlcloc1;
        }
        set
        {
            _lastlvlcloc1 = value;
        }
    }
    public static int lastlvlcloc2
    {
        get
        {
            return _lastlvlcloc2;
        }
        set
        {
            _lastlvlcloc2 = value;
        }
    }

    public static double getalgrowspeed()
    {
        if (AlGlobalVar.LevelValue == 2)
        {
            switch (level2choice) // al grows at different speeds depending on player's choice at start of stage 2
            {
                case 0: return 1;
                case 1: return 2;
                case 2: return 0.5;
                default: return 1;
            }
        }
        else
        {
            return 1;
        }
    }

    public static GameObject FindObject(GameObject parent, string name)
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
}
