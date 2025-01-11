using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EmsEnemyScript : MonoBehaviour
{
   public int direction;
    int lastOne;
    bool jaNei;
    public bool nord;
    public bool soer;
    public bool oest;
    public bool vest;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float fart;
    public LayerMask IgnoreMe;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ray", 0, 1);

    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position+transform.up*fart);
    }
    void ray()
    {
        lastOne = direction;
        if (Physics2D.Raycast(transform.position, new Vector3(-1,0,0), ~IgnoreMe))
        {
            oest = true;
            Debug.Log("øst");
            //øst
            direction = 3;
        }
        else
        {
            oest= false;
        }
        if (Physics2D.Raycast(transform.position, new Vector3(1, 0, 0), ~IgnoreMe))
        {
            vest = true;
            Debug.Log("vest");
            //vest
            direction = 1;
        }
        else
        {
            vest= false;
        }
        if (Physics2D.Raycast(transform.position, new Vector3(0, -1, 0), ~IgnoreMe))
        {
            nord = true;
            Debug.Log("nord");
            jaNei = Random.value < 0.5f;
            if (jaNei)
            {
                //nord
                direction = 0;
            }
        }
        else
        {
            nord = false;
        }
        if (Physics2D.Raycast(transform.position, new Vector3(0, 1, 0), ~IgnoreMe))
        {
            soer = true;
            Debug.Log("sør");
            jaNei = Random.value < 0.5f;
            if (jaNei)
            {
                //sør
                direction = 2;
            }
        }
        else
        {
            nord= false;
        }
        if (lastOne != direction)
        {
            transform.position = new Vector2((int)transform.position.x, (int)transform.position.y);
        }
        transform.eulerAngles = new Vector3 (0, 0, 90*direction);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("krasj");
    }
}
