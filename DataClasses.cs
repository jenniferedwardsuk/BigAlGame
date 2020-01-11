public class AlMapZones
{
    public int Zone { get; set; }
    public string Name { get; set; }
    public int[] Maps { get; set; }
}

public class AlEnemies
{
    public string Name { get; set; }
    public double Fierceness { get; set; }
    public double Agility { get; set; }
    public double Energy { get; set; }
    public int ImageID { get; set; }
    public bool Seen { get; set; }
    public int CommonZone1 { get; set; }
    public int CommonZone2 { get; set; }
    public int RareZone1 { get; set; }
    public int RareZone2 { get; set; }
    public string textName { get; set; }
    public string Flavtext { get; set; }
    public double bEnergy { get; set; }
    public double bFierceness { get; set; }
    public double bAgility { get; set; }
}

public class PaleoQuestions
{
    public string Question { get; set; }
    public string A1 { get; set; }
    public string A2 { get; set; }
    public string A3 { get; set; }
    public string A4 { get; set; }
    public string Answer { get; set; }
}

public class FactFiles
{
    public string Name { get; set; }
    public string Facts { get; set; }
    public int ImageID { get; set; }
}



