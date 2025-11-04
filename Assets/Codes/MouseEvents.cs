using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvents : MonoBehaviour
{
    public Transform player;
     void Update()
    {
       
    }
    private void OnMouseEnter() //OnCollisionEnter
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    private void OnMouseOver() //OnCollisionStay
    {
        if (Input.GetMouseButton(0)) // Sol click yaptýðýmda yeþil olacak
        {
            if(Vector3.Distance(transform.position, player.position) <= 6)
            {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            //player.position = transform.position;
            player.position = new Vector3(transform.position.x, transform.position.y +0.60f, transform.position.z);
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            
        }
    } 

     private void OnMouseExit() //OnCollisionExit
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.9245283f, 0.4055713f, 0.4055713f,1f);
    } 

}
