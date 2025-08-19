using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [Header("Karakter Özellikleri")]
    [Tooltip("Karakterin hýzýdýr.")] public float speed;

    [Tooltip("Karakterin zýplama gücüdür.")] public float jumpPower;


    public float health = 100;
    [SerializeField] int coin = 0;
    [SerializeField] bool hasKey = false;
    bool unlockGate = false;

    [Header("Move Direction")]
    [SerializeField] Vector3 MoveDirection;

    private Rigidbody rb;

    [SerializeField] Camera cam;

    //public float canDegeri = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

       // StartCoroutine(Routine());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
         if (Input.GetKeyDown(KeyCode.E))
         {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
         } 

        #region MOVEMENT_PART


        speed = Mathf.Clamp(speed, 15f, 30f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
         if(Input.GetKey(KeyCode.LeftShift))
        {
            speed += 0.1f;
        }
         else
        {
            speed -= 0.1f;
        }
        /* if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Routine());
        }*/
        Movement(speed);
        #endregion

        health = Mathf.Clamp(health, 0, 100);

        /*
        if(hasKey && coin >= 3)
        {
            unlockGate = true;
        } */
        //dead code
        if(health <=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    void Movement(float movementSpeed)
        {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        MoveDirection = new Vector3(moveX * speed * Time.deltaTime, 0, moveY * speed * Time.deltaTime);
        
        transform.position += MoveDirection;
        }
    /*
     IEnumerator Routine ()
    {
        canDegeri = 100;

        yield return new WaitForSeconds(3f);

        canDegeri = 50;

        yield return new WaitForSeconds(5f);

        canDegeri = 0;
    } */

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Gate"))
        {
            if (hasKey && coin >= 3)
            {
                unlockGate = true;
            }
            
        }

        if(col.CompareTag("Coin"))
        {
            coin++;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(col.gameObject);
        }

    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Gate"))
        {
            unlockGate = false;
            /*
            //Yazý çýkacak
            if (unlockGate && Input.GetKeyDown(KeyCode.E))
            {
                //Sonraki levela geç
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } */
        }
    }


}
