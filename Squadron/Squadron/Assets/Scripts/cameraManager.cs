using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject cam;
    private Transform camTram;
    private GameObject mapManSc;
    // Start is called before the first frame update
    void Start()
    {
        mapManSc = GameObject.Find("_MapManager");
        camTram = cam.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves camera with wasd
        if(Input.GetKey("a"))
        {
            camTram.Translate(-0.5f,0f,0f);
        }
        if (Input.GetKey("d"))
        {
            camTram.Translate(0.5f, 0f, 0f);
        }
        if (Input.GetKey("w"))
        {
            camTram.Translate(0f, 0f, 0.5f);
        }
        if (Input.GetKey("s"))
        {
            camTram.Translate(0f, 0f, -0.5f);
        }
        //rotates cam around the board with q e
        if(Input.GetButtonDown("q"))
        {
            camTram.Translate(-10.0f, 0f, 10f);
            camTram.Rotate(0f, 90f, 0);
        }
        if (Input.GetButtonDown("e"))
        {
            camTram.Rotate(0f, -90f, 0f);
            camTram.Translate(10f, 0, -10f);
        }
        //select square on board
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitObj = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitObj, 1000000f,1 << 9);
            if(hit)
            {
                mapManSc.GetComponent<mapManager>().SelectRay(hitObj);
            }
        }
    }
}
