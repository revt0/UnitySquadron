using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapManager : MonoBehaviour
{
    //board size
    public int boardSizeX;
    public int boardSizeZ;
    //tile used for the board
    public GameObject tilePrefab;
    public GameObject tileObjectPrefab;
    //the board
    private GameObject[,] map;
    //colors for tiles
    public Material[] mats;
    //playerSelected Objects
    private GameObject playSelectPrev;
    private GameObject playSelectCurr;



    // Start is called before the first frame update
    void Start()
    {
        map = new GameObject[boardSizeX,boardSizeZ];
        //For Loop to create a list of tiles in the array map used as the game map.
        //boardSizeX/Y set in inspector
        for(int i=0; i<boardSizeX; ++i)
        {
            for(int j=0; j< boardSizeZ; ++ j)
            {

                GameObject newTile = Instantiate<GameObject>(tilePrefab, this.transform);
                newTile.name = "pos: " + i + " " + j;
                map[i,j] = newTile;
                map[i, j].GetComponent<tile>().SetPos(i, j);
            }
        }

        ClearMap();
        DrawMap();
        ColorMapRows();
        DrawMap();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //sets contain in tile for each tile in map to blank.
    public void ClearMap()
    {
        for (int i = 0; i < boardSizeX; ++i)
        {
            for (int j = 0; j < boardSizeZ; ++j)
            {
                GameObject a = map[i, j];
                a.GetComponent<tile>().SetContain(tileObjectPrefab);

            }
        }

    }
    
    //instantianes every tile in the map list
    public void DrawMap()
    {
        for (int i = 0; i < boardSizeX; ++i)
        {
            for (int j = 0; j < boardSizeZ; ++j)
            {
                DrawTile(i, j);
            }
        }
    }
    //re-instantiates a specific tile
    public void DrawTile(int x, int z)
    {
        GameObject a = map[x, z];
        GameObject temp = a.GetComponent<tile>().GetContain();
        GameObject temp2 = Instantiate(temp, a.GetComponent<tile>().GetPos(), new Quaternion(0, 0, 0, 0), a.transform);
        if (temp.activeInHierarchy)
            Destroy(temp);
        a.GetComponent<tile>().SetContain(temp2);
        temp2.GetComponent<MeshRenderer>().material = a.GetComponent<tile>().GetColor();
    }
    //overload for drawTile
    public void DrawTile(Vector3 vect)
    {
        int x = (int)vect.x;
        int z = (int)vect.z;
        DrawTile(x, z);
    }
    //randomly colors the map with the mats list
    public void ColorMapRan()
    {
        for (int i = 0; i < boardSizeX; ++i)
        {
            for (int j = 0; j < boardSizeZ; ++j)
            {
                GameObject a = map[i, j];
                int r = Random.Range(0, 4);
                Material temp = mats[r];
                Debug.Log(temp.name);
                a.GetComponent<tile>().SetColor(temp);

            }
        }
    }

    //colors map in rows
    public void ColorMapRows()
    { 
        for (int i = 0; i < boardSizeX; ++i)
        {
            for (int j = 0; j < boardSizeZ; ++j)
            {
                GameObject a = map[i, j];
                int r = (int)a.GetComponent<tile>().GetPos().x;
                //Debug.Log("int r: " + r);
                r = r % 4;
                Material temp = mats[r];
                //Debug.Log(temp.name);
                a.GetComponent<tile>().SetColor(temp);
            }
        }
    }

    //selects a tile on the board with Raycast
    public void SelectRay(RaycastHit hitObj)
    {
        //Debug.Log("selectRay run");
        if (hitObj.transform.gameObject.layer == 9)
        {   
            if(playSelectPrev != null)
            {
                DrawTile(playSelectPrev.GetComponentInParent<tile>().GetPos());
                playSelectPrev = playSelectCurr;
                playSelectCurr = hitObj.transform.gameObject;
                playSelectCurr.GetComponent<MeshRenderer>().material = mats[4];
                //Debug.Log("line 148, playSelectCurr.name: "+playSelectCurr.name);
          
            } else
            {
                playSelectPrev = playSelectCurr;
                playSelectCurr = hitObj.transform.gameObject;
                playSelectCurr.GetComponent<MeshRenderer>().material = mats[4];
            }
        }

    }
}
