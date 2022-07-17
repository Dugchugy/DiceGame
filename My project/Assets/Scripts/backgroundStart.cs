using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class backgroundStart : MonoBehaviour
{
    public Tile[] GroundTiles;

    public int varient;

    public GameObject[] AttachedText;

    // Start is called before the first frame update
    void Start()
    {
        varient = LoadData.RoomType - 1;

        if(varient == 2 || varient == 5){
            Debug.Log("ran");

            for(int i = 0; i < AttachedText.Length; i++){
                AttachedText[i].GetComponent<TMP_Text>().color = new Color(0, 0, 0, 1);
            }
        }

        Tilemap tilemap = GetComponent<Tilemap>();

        for(int x = tilemap.cellBounds.min.x; x< tilemap.cellBounds.max.x;x++){
            for(int y= tilemap.cellBounds.min.y; y< tilemap.cellBounds.max.y;y++){
                tilemap.SetTile(new Vector3Int(x, y, 0), GroundTiles[varient]);
            }
        }

        tilemap.RefreshAllTiles();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
