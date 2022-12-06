using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad4 : MonoBehaviour
{

    private float jumpHeight = 9.0f;
    private float gravityValue = -9.81f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na platforme.");
            player.position+= transform.up * Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
           

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zosta³ wystrzelony z platformy.");
          
        }
    }
}
