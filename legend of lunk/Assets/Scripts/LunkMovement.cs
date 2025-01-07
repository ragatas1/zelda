using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunkMovement : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontal;
    float vertical;
    float horizontalMovement;
    float verticalMovement;
    float horizontalCheck;
    float verticalCheck;
    bool horizontalBool;
    bool verticalBool;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

        if (horizontalCheck > verticalCheck||(horizontalBool && horizontalMovement !=0))
        {
            horizontalBool = true;
            verticalBool = false;
            transform.position = new Vector3(horizontal, vertical, 0);
            horizontal = horizontal + horizontalMovement*speed*Time.deltaTime;
            vertical = (int)vertical;
            if (horizontalMovement > 0)
            {
                transform.eulerAngles = new Vector3(0,0,270);
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
            transform.position = new Vector3(horizontal,vertical, 0);
            vertical = vertical + verticalMovement * speed * Time.deltaTime;
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
