using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthKillNotif : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D m_Collider;
    private bool canBeStabbed = false;

    public void StealthKill()
    {
        if (canBeStabbed)
        {
            if(transform.parent.TryGetComponent(out Animator animationController))
            {
                animationController.SetBool("Death", true);
            }
        }
    }

    private void Awake()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if(other.gameObject.TryGetComponent(out Stabber stabb))
        {
            Debug.Log("Imamo stab!");
            canBeStabbed = true;

        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        canBeStabbed = false;
    }


    void Start()
    {
     
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
