using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject maptopleft;

    public int numRows;
    public int numColumns;
    public int mapSquareSizeInPix;

    void Start () {

    }

    public void createmapsquares()
    {
        // create special map squares
        // for al: 9999 = yellow square, 00 = storage
        // for mum: 9900 = red square, 000 = storage  

        Vector2 backupposition = new Vector2(0, 0);
        GameObject mapbackup1 = Instantiate(maptopleft, backupposition, Quaternion.identity);
        mapbackup1.name = "picturemap9999";
        SpriteRenderer backupimg1 = mapbackup1.AddComponent<SpriteRenderer>();
        backupimg1.sprite = Resources.Load("map/mapyellow", typeof(Sprite)) as Sprite; // load image
        backupimg1.color = new Color(backupimg1.color.r, backupimg1.color.g, backupimg1.color.b, 0); // hide map square by default

        GameObject mapbackup2 = Instantiate(maptopleft, backupposition, Quaternion.identity);
        mapbackup2.name = "picturemap00";
        SpriteRenderer backupimg2 = mapbackup2.AddComponent<SpriteRenderer>();
        backupimg2.sprite = null;
        backupimg2.color = new Color(backupimg2.color.r, backupimg2.color.g, backupimg2.color.b, 0); // hide map square by default

        GameObject mapbackup3 = Instantiate(maptopleft, backupposition, Quaternion.identity);
        mapbackup3.name = "picturemap9900";
        SpriteRenderer backupimg3 = mapbackup3.AddComponent<SpriteRenderer>();
        backupimg3.sprite = Resources.Load("map/mapred", typeof(Sprite)) as Sprite; //load image
        backupimg3.color = new Color(backupimg3.color.r, backupimg3.color.g, backupimg3.color.b, 0); // hide map square by default

        GameObject mapbackup4 = Instantiate(maptopleft, backupposition, Quaternion.identity);
        mapbackup4.name = "picturemap000";
        SpriteRenderer backupimg4 = mapbackup4.AddComponent<SpriteRenderer>();
        backupimg4.sprite = null;
        backupimg4.color = new Color(backupimg4.color.r, backupimg4.color.g, backupimg4.color.b, 0); // hide map square by default

        // create main map squares
        for (int m = 0; m < numRows; m++)
        {
            for (int n = 0; n < numColumns; n++)
            {
                // create map square
                Vector2 newposition = new Vector2(maptopleft.transform.position.x + 0.08f + n * mapSquareSizeInPix * 0.01f,
                                                    maptopleft.transform.position.y - 0.04f - m * mapSquareSizeInPix * 0.01f);
                GameObject newmapsquare = Instantiate(maptopleft, newposition, Quaternion.identity);
                int mapx = m + 1;
                int mapy = n + 1;
                newmapsquare.name = "picturemap" + mapx + mapy;

                // adjust transform
                RectTransform newsquaretransform = newmapsquare.GetComponent<RectTransform>();
                newsquaretransform.sizeDelta = new Vector2(newsquaretransform.sizeDelta.x * 0.01f, newsquaretransform.sizeDelta.y * 0.01f); // allow for panel scaling
                newsquaretransform.pivot = new Vector2(0.5f, 0.5f); // centres the image

                // set image
                SpriteRenderer newsquareimg = newmapsquare.AddComponent<SpriteRenderer>();
                newsquareimg.sortingLayerName = "Images";
                newsquareimg.sortingOrder = 1; // display in front
                newsquareimg.sprite = Resources.Load("map/map" + mapx + mapy, typeof(Sprite)) as Sprite; // load image
                newsquareimg.color = new Color(newsquareimg.color.r, newsquareimg.color.g, newsquareimg.color.b, 0); // hide map square by default
            }
        }
    }
	
}
