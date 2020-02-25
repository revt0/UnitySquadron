using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    private Vector3 pos;
    private GameObject contain;
    private Material color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Material mat)
    {
        color = mat;
        contain.GetComponent<MeshRenderer>().material = color;
    }
    public Material GetColor()
    {   
        return color;
    }
    public void SetPos(int x, int z)
    {
        pos = new Vector3(x, 0, z);
    }
    
    public Vector3 GetPos()
    {
        return this.pos;
    }

    public void SetContain(GameObject a)
    {
        contain = a;
    }

    public GameObject GetContain()
    {
        return contain;
    }
}
