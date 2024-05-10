using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabber : MonoBehaviour
{
    public float stabTimer = 0f;
    private Animator animationController;

    private bool walking = false;
    private bool canStab = false;

    private StealthKillNotif lastStealthKill = null;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.TryGetComponent(out StealthKillNotif stealthkill))
        {
            canStab = true;
            lastStealthKill = stealthkill;
            Debug.Log("Imamo stealthkill!");
          //  stealthkill.StealthKill();
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
       
            canStab = false;
         

    }
    private void Awake()
    {
        animationController = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animationController.SetBool("Walking", walking);
    }
  
    // Update is called once per frame
    void Update()
    {
        if (canStab)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animationController.SetTrigger("Stab");
                transform.position = lastStealthKill.transform.position;
                lastStealthKill.StealthKill();

                lastStealthKill = null;
            }
         //   else
             //   animationController.SetBool("Stab", false);
        }
       // else
       //     animationController.SetBool("Stab", false);

        if (Input.GetKey(KeyCode.W))
        {
            animationController.SetBool("Walking", true);
            transform.Translate(transform.forward * 1f * Time.deltaTime);

        }
        else
            animationController.SetBool("Walking", false);



       // animationController.SetBool("Stab", true);


        //   animationController.SetBool("Stab", true);

    }
}
