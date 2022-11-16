using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController instance { get => _instance; }
    public Transform[] ts;
    NavMeshAgent meshAgent;
    Animator anim;
    
    void Start()
    {
        if (_instance == null)
            _instance = this;
        else 
            Destroy(this);
        meshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    public void flee()
    {
        anim.SetBool("Move", true);
        meshAgent.SetDestination(ts[0].position);
        if(meshAgent.remainingDistance<=meshAgent.stoppingDistance)
        {
            print("flee");
        }
    }
    public void pass()
    {
        anim.SetBool("Move", true);
        meshAgent.SetDestination(ts[1].position);
        if (meshAgent.remainingDistance <= meshAgent.stoppingDistance)
        {
            print("pass");
        }
    }
}
