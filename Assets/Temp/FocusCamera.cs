using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool Paused = false;
    [SerializeField] private Transform TargetTransform;
    [SerializeField] private Vector3 localOffset;
    [SerializeField] private Vector3 locaRotationlOffset;
    [SerializeField] private float Speed;

    private Camera Camera;

    private Vector3 targetPosition = Vector3.zero;
    private Quaternion targetRotation = Quaternion.identity;
    private Vector3 defaultCameraPos = Vector3.zero;
    private Quaternion defaultCameraRot = Quaternion.identity;
    private void moveCamera()
    {
        transform.position = Vector3.Slerp(transform.position, targetPosition, Speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Speed * Time.deltaTime);
    }

    void Awake()
    {
        Camera = GetComponent<Camera>();
        defaultCameraPos = transform.position;
        defaultCameraRot = transform.rotation;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetTransform != null)
        {
            targetPosition = TargetTransform.position + localOffset;
            targetRotation = Quaternion.Euler(Vector3.zero + locaRotationlOffset);
        }
        else 
        {
            targetPosition = defaultCameraPos;
            targetRotation = defaultCameraRot;
        }


       
    }

    private void FixedUpdate()
    {
        if (!Paused)
        {
            moveCamera();
        }
    }
}
