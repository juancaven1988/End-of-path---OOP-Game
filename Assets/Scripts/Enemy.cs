using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public  class Enemy : Disparador
{

    //Movimiento
    protected PlayerBehaviur player;
    protected NavMeshAgent agente;
    [SerializeField] protected float velocidad;
    [SerializeField] protected float distanciaDisparo;
    [SerializeField] protected float coolDownDisparo;
 
    protected float tiempoEntreDisparo;



    // Start is called before the first frame update
    protected void Start()
    {
        player = FindObjectOfType<PlayerBehaviur>();
        agente = GetComponent<NavMeshAgent>();
        agente.speed = velocidad;
        
    }

    // Update is called once per frame
   protected void Update()
    {

        tiempoEntreDisparo += Time.deltaTime;

        agente.destination = player.transform.position;

        transform.LookAt(player.transform);

        if(Vector3.Distance(transform.position,player.transform.position) <= distanciaDisparo && tiempoEntreDisparo/coolDownDisparo >= 1 )
        {
            
            Disparar();
            tiempoEntreDisparo = 0;
        }
             
    }

    protected override void Disparar()
    {
        
             
            GameObject[] bala = EncontrarBalas();

            bala[0].transform.position = canons[0].transform.position;
            bala[0].transform.rotation = canons[0].transform.rotation;
            bala[0].SetActive(true);
        
    }

   
}
