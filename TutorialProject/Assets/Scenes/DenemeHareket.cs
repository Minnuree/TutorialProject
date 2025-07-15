using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenemeHareket : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector3 movieCode;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movieObject(speed);
    }

    void movieObject(float speed)
    {
        float movieX = Input.GetAxis("Horizontal");
        float movieY = Input.GetAxis("Vertical");
        movieCode = new Vector3(movieX * speed * Time.deltaTime,0, movieY * speed * Time.deltaTime);

        transform.position += movieCode;
    }
}
