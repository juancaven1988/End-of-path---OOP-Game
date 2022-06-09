using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navScript : MonoBehaviour
{

   
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new(Input.mousePosition.x, Input.mousePosition.y, 84);
       

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 objetivo = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(objetivo);
            agent.destination = objetivo;
        }
    }
}
