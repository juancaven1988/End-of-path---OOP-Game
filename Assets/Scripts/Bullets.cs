using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullets : MonoBehaviour
{

    [SerializeField] float velocidad = 5;
    float zLimit = 66;
    float xLimit = 80;

    SFXScript soundEfector;

    // Start is called before the first frame update
    void Start()
    {
        soundEfector = FindObjectOfType<SFXScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        if(transform.position.z > zLimit || transform.position.z < -  zLimit)
        {
            gameObject.SetActive(false);
        }

        if(transform.position.x < - xLimit || transform.position.x > xLimit)
        {
            gameObject.SetActive(false);
        }
    }


    

    private void OnTriggerEnter(Collider other)
    {
        soundEfector.PlayHit();

        
        Salud salud = other.GetComponent<Salud>();

        if(other.CompareTag("Enemy"))
        {
            GameManager.Instancia.IncreaseScore();
        }

        if(salud != null)
        {
            salud.perderSalud();
        }

        gameObject.SetActive(false);
    }
}
