using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lecture_01 : MonoBehaviour
{
    // Start is called before the first frame update

    public int para = 100;
    public int canHakki = 3;
    public float can = 100f;
    public bool olduMu;
    //public string nickname;
    public string[] nicknames;

    public GameObject denemeObje;

    Vector3 newPosition;

    void Start()
    {
        para = 50;
        canHakki = 3;

       // transform.position = new Vector3(10f, 10f, 15.5f);
        newPosition = new Vector3(10f, 10f, 15.5f);

        denemeObje.GetComponent<CharacterMovement>().speed = 10;
      /*  foreach(string nickname in nicknames)
        {
            Debug.Log(nickname);
        } */
        
    }

    // Update is called once per frame
    void Update() 
    {

        /*
        if (para == 100)
        {
            para = 0;
            canHakki++;
        }

        if(can == 0)
        {
            olduMu = true;
        }
        if(olduMu)
        {
            Debug.Log("Oyuncu �ld�. Sahne yeniden ba�lat�l�yor..."); //Konsola yaz� yazd�rma fonksiyonumuz
        } */

    }
    void FixedUpdate() 
    {
        //Fizik uygulamalar� buraya

        transform.Translate(newPosition);

    }

    void LateUpdate()
    {
        //Kamera hareketleri ve uygulamalar�
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BoxTrigger") //�arp�lan objenin bilgileri name e eri�tik
        {
            

          /*  gameObject.SetActive(false);
            Debug.Log("Girdi."); */
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "BoxTrigger")
        {
            Debug.Log("��kt�.");
        }
    }
}
