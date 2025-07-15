using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    [SerializeField] Vector3 MoveDirection;
    public float jumpPower;

    private Rigidbody rb;

    public float canDegeri = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Routine());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        /* if (Input.GetKeyDown(KeyCode.E))
         {
             Debug.Log("E tuþuna basýldý");
         } */

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
         if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Routine());
        }
        Movement(speed);

        
    }
     void Movement(float movementSpeed)
        {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        MoveDirection = new Vector3(moveX * speed * Time.deltaTime, 0, moveY * speed * Time.deltaTime);
        
        transform.position += MoveDirection;
        }

     IEnumerator Routine ()
    {
        canDegeri = 100;

        yield return new WaitForSeconds(3f);

        canDegeri = 50;

        yield return new WaitForSeconds(5f);

        canDegeri = 0;
    }

}
