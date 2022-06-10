using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviur : Disparador
{


    [Header("Movimiento")]
    [SerializeField] float velocidad = 5;
    [SerializeField] GameObject body;
    float movimiento;
    float rotacion;
    float anguloRotacion = 90;
    public bool rotando = false;

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

       if(!rotando)
        {
            movimiento = Input.GetAxis("Vertical");
            
            if(Input.GetAxis("Horizontal") > 0.05)
            {
                rotacion = 1;
            }
            if(Input.GetAxis("Horizontal") < -0.05)
            {
                rotacion = -1;
            }  
                        
        }

       if(Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
        
    }

    private void FixedUpdate()
    {
        Mover();
        
        if (rotacion != 0)
        {
            StartCoroutine(Rotar());
        }

    }
    //POLIMORFISMO
    protected override void Disparar()
    {
                                        //HERENCIA
        GameObject[] balasDisparar = EncontrarBalas();
        
        if(balasDisparar.Length == canons.Length)
        {
            for(int i = 0; i < canons.Length; i++)
            {
                balasDisparar[i].transform.position = canons[i].position;
                balasDisparar[i].transform.rotation = canons[i].rotation;
                balasDisparar[i].SetActive(true);
            }

        }
       

    }


   

    void Mover()
    {
        transform.Translate(Vector3.forward * movimiento * velocidad * Time.deltaTime);
        
    }

    

    IEnumerator Rotar()
    {
        if(!rotando)
        {
            rotando = true;
            float angulo = anguloRotacion * rotacion;
            rotacion = 0;
            body.transform.Rotate(Vector3.up, angulo);
            yield return new WaitForSeconds(0.2f);
            transform.Rotate(Vector3.up, angulo);
            body.transform.Rotate(Vector3.up, -angulo);
            rotando = false;
        }
        
    }
}
