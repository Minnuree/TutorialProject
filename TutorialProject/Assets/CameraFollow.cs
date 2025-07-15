using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    Transform player;

    [SerializeField] Vector3 offset;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate() //kamera olaylar�n� bunun i�ine yaz�yoruz
    {
        transform.position = player.position + offset;
    }
}
