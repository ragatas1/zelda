using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunkMovement : MonoBehaviour
{
    [Header("bevegelse")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float fart;
    float horizontalMovement;
    float verticalMovement;
    float horizontalCheck;
    float verticalCheck;
    bool horizontalBool;
    bool verticalBool;
    bool ikkeGaa;

    [Header("angrep")]
    [SerializeField] GameObject sverd;
    [SerializeField] float sverdTid;
    float sverdTimer;

    [Header("skade")]
    [SerializeField] int helse;
    [SerializeField] float iFrames;
    public float iFramesTimer;
    [SerializeField] float knockbackTid;
    [SerializeField] float knockbackLengde;
    bool knockedBack;

    [Header("animasjon")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float blinkOffset;
    float blinkTid;
    bool blink;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!knockedBack)
        {
            bevegelse();
            angrep();
        }
        iframes();
    }
    void bevegelse()
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
        if (horizontalCheck > verticalCheck || (horizontalBool && horizontalMovement != 0))
        {
           horizontalBool = true;
           verticalBool = false;
           rb.velocity = new Vector2 (horizontalMovement * fart, 0);
           if (!ikkeGaa)
           {
                if (horizontalMovement > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 270);
                }
                else if (horizontalMovement < 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }
           }
        }
        else if (verticalCheck > horizontalCheck || (verticalBool && verticalMovement != 0))
        {
            verticalBool = true;
            horizontalBool = false;
            rb.velocity = new Vector2(0, verticalMovement * fart);
            if (!ikkeGaa)
            {
                if (verticalMovement < 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 180);
                }
                else if (verticalMovement > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            verticalBool = false;
            horizontalBool = false;
        }
    }
    void angrep()
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
            rb.velocity = Vector2.zero;
            sverd.SetActive(true);
            sverdTimer = sverdTimer-1*Time.deltaTime;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (iFramesTimer < 0)
        {
            if (collision.gameObject.tag == "farlig")
            {
                sverd.SetActive(false);
                iFramesTimer = iFrames;
                StartCoroutine(knockback());
                helse = helse - 1;
            }
        }
    }
    IEnumerator knockback()
    {
        knockedBack = true;
        rb.AddRelativeForce(new Vector2(0, -knockbackLengde),ForceMode2D.Force);
        yield return new WaitForSeconds(knockbackTid);
        knockedBack = false;
    }
    void iframes()
    {
        if (iFramesTimer < 0)
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
        else
        {
            iFramesTimer = iFramesTimer - 1 * Time.deltaTime;
            if (blinkTid < 0)
            {
                blink = !blink;
                blinkTid = blinkOffset;
            }
            else
            {
                blinkTid = blinkTid - 1 * Time.deltaTime;
            }
            if (blink)
            {
                sprite.color = new Color(1, 1, 1, .5f);
            }
            else
            {
                sprite.color = new Color(1, 1, 1, 1);
            }
        }
    }
}
