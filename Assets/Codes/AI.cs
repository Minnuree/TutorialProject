using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent navMesh;

    //Transform target;

    [SerializeField] float lookDistance;
    public GameObject cubePrefab;
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

        //target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                navMesh.SetDestination(hit.point);
                GameObject createdCube =  Instantiate(cubePrefab, hit.point, transform.rotation);
                Destroy(createdCube, 4f);

            }
        }
    }

    void Update()
    {
       // float playDistance = Vector3.Distance(target.transform.position, transform.position);

       /* if(playDistance <= lookDistance)
        {
            //Takip Kodu
            navMesh.SetDestination(target.position);
        } */

        //Takip Kodu
        //navMesh.SetDestination(target.position);

        ////Karaktere Bakma
        //transform.LookAt(target);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookDistance);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<CharacterMovement>().health -= 30.0f;
        }
    }

}
