using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunkMovement : MonoBehaviour
{
    //movement
    [SerializeField] float fart;
    float horizontal;
    float vertical;
    float horizontalMovement;
    float verticalMovement;
    float horizontalCheck;
    float verticalCheck;
    bool horizontalBool;
    bool verticalBool;
    bool ikkeGaa;

    //angrep
    [SerializeField] GameObject sverd;
    [SerializeField] float sverdTid;
    float sverdTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FourWayMovement();
        attack();
    }
    void FourWayMovement()
    {
        horizontalMovement = Input.GetAxisRaw("X axis");
        verticalMovement = Input.GetAxisRaw("Y axis");
        if (horizontalMovement > 0)
        {
            horizontalCheck = horizontalMovement;
        }
        else
        {
            horizontalCheck = -horizontalMovement;
        }
        if (verticalMovement > 0)
        {
            verticalCheck = verticalMovement;
        }
        else
        {
            verticalCheck = -verticalMovement;
        }
        if (!ikkeGaa)
        {
            if (horizontalCheck > verticalCheck || (horizontalBool && horizontalMovement != 0))
            {
                horizontalBool = true;
                verticalBool = false;
                transform.position = new Vector3(horizontal, vertical, 0);
                horizontal = horizontal + horizontalMovement * fart * Time.deltaTime;
                vertical = (int)vertical;
                if (horizontalMovement > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 270);
                }
                else if (horizontalMovement < 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }
            }
            else if (verticalCheck > horizontalCheck || (verticalBool && verticalMovement != 0))
            {
                verticalBool = true;
                horizontalBool = false;
                transform.position = new Vector3(horizontal, vertical, 0);
                vertical = vertical + verticalMovement * fart * Time.deltaTime;
                horizontal = (int)horizontal;
                if (verticalMovement < 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 180);
                }
                else if (verticalMovement > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            else
            {
                verticalBool = false;
                horizontalBool = false;
            }
        }
    }
    void attack()
    {
        if (sverdTimer < 0)
        {
            ikkeGaa = false;
            sverd.SetActive(false);
            if (Input.GetButtonDown("Angrep"))
            {
                sverdTimer = sverdTid;
            }
        }
        else
        {
            ikkeGaa = true;
            sverd.SetActive(true);
            sverdTimer = sverdTimer-1*Time.deltaTime;
        }

    }
}
