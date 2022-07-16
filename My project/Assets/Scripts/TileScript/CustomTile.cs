using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class CustomTile : TileBase
{
    public Sprite[] m_AnimatedSprite;

    public float m_AnimationSpeed = 0f;

    public int tileFrame = 0;

    public bool collide = false;

    public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
    {
        if (m_AnimatedSprite != null && m_AnimatedSprite.Length > 0)
        {
            tileData.sprite = m_AnimatedSprite[(int) m_AnimationSpeed];

            if(collide){
                tileData.colliderType = Tile.ColliderType.Grid;
            }
        }
    }

    public override bool StartUp(Vector3Int location, ITilemap tilemap, GameObject go)
   {
       if (go != null)
       {

           Debug.Log("ran");
           m_AnimationSpeed = go.GetComponent<TileSyncronizer>().varient;
       }
       return true;
   }
}
