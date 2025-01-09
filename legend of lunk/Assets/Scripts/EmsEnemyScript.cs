using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EmsEnemyScript : MonoBehaviour
{
    public int direction;
    bool jaNei;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            direction = 0;
            ray();
        }
    }
    void ray()
    {

        if (Physics2D.Raycast(transform.position, new Vector3(1,0,0)))
        {
            direction = 1;
        }
        if (Physics2D.Raycast(transform.position, new Vector3(-1, 0, 0)))
        {
            direction = 2;
        }
        if (Physics2D.Raycast(transform.position, new Vector3(0, 1, 0)))
        {
            jaNei = Random.value < 0.5f;
            if (jaNei)
            {
                direction = 3;
                Debug.Log("nord");
            }
            else
            {
                if (direction == 1)
                {
                    Debug.Log("øst");
                }
                else if (direction == 2)
                {
                    Debug.Log("vest");
                }
            }
        }
        if (Physics2D.Raycast(transform.position, new Vector3(0, -1, 0)))
        {
            jaNei = Random.value < 0.5f;
            if (jaNei)
            {
                direction = 4;
                Debug.Log("sør");
            }
            else
            {
                if (direction == 1)
                {
                    Debug.Log("øst");
                }
                else if (direction == 2)
                {
                    Debug.Log("vest");
                }
            }
        }
    }
}
