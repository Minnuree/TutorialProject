using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent navMesh;

    Transform target;

    [SerializeField] float lookDistance;
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        float playDistance = Vector3.Distance(target.transform.position, transform.position);

       /* if(playDistance <= lookDistance)
        {
            //Takip Kodu
            navMesh.SetDestination(target.position);
        } */

        //Takip Kodu
        navMesh.SetDestination(target.position);

        //Karaktere Bakma
        transform.LookAt(target);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookDistance);
    }
}
