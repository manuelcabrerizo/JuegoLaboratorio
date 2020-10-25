using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapController : MonoBehaviour
{

    public GameObject tile;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    private List<GameObject> tileMap = new List<GameObject>();
    private float tileScale = 2.4f;

    private int[,] map = new int[20, 20]
    {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 4, 4, 0, 0, 0, 4, 0, 0},
        { 0, 0, 0, 0, 0, 0, 4, 0, 3, 3, 3, 3, 0, 0, 3, 5, 3, 0, 4, 0},
        { 3, 0, 0, 0, 0, 0, 0, 3, 5, 5, 1, 1, 3, 3, 5, 1, 1, 3, 0, 4},
        { 5, 3, 3, 3, 3, 3, 3, 1, 5, 5, 1, 1, 1, 1, 1, 1, 5, 1, 3, 5},
        { 5, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5},
        { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

    };

    // Start is called before the first frame update
    void Start()
    {


        tile.transform.localScale = new Vector3(tileScale, tileScale, 0.0f);
        tile2.transform.localScale = new Vector3(tileScale, tileScale, 0.0f);
        tile3.transform.localScale = new Vector3(tileScale, tileScale, 0.0f);
        tile4.transform.localScale = new Vector3(tileScale, tileScale, 0.0f);
        tile5.transform.localScale = new Vector3(tileScale, tileScale, 0.0f);

        float width = (tile.GetComponent<SpriteRenderer>().bounds.size.x);
        float height = (tile.GetComponent<SpriteRenderer>().bounds.size.y);
        float offsetX = 0;
        float offsetY = 0;
        Debug.Log("Width: " + width + " Height: " + height);

        for (int y = 0; y < 20; y++) 
        {
            for (int x = 0; x < 20; x++)
            {
                if(map[(int)y, (int)x] == 1)
                    tileMap.Add(Instantiate(tile , new Vector3(offsetX - 10, -offsetY + 11, 0), Quaternion.identity));
                else if (map[(int)y, (int)x] == 2)             
                    tileMap.Add(Instantiate(tile2, new Vector3(offsetX - 10, -offsetY + 11, 0), Quaternion.identity));
                else if (map[(int)y, (int)x] == 5)            
                    tileMap.Add(Instantiate(tile5, new Vector3(offsetX - 10, -offsetY + 11, 0), Quaternion.identity));
                else if (map[(int)y, (int)x] == 3)             
                    tileMap.Add(Instantiate(tile3, new Vector3(offsetX - 10, -offsetY + 11, 0), Quaternion.identity));
                else if (map[(int)y, (int)x] == 4)
                    tileMap.Add(Instantiate(tile4, new Vector3(offsetX - 10, -offsetY + 11, 0), Quaternion.identity));

                offsetX += width;
            }
            offsetX = 0;
            offsetY += height;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
