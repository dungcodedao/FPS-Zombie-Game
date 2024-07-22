using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [Header("Wheels colliders")]
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider backLeftWheelCollider;

    [Header("Wheels Transform")]
    public Transform frontRightWheelTransform;
    public Transform backRightWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform vehicleDoor;

    [Header("Vehicle Engine")]
    public float accelerationForce = 100f;
    public float breakingForce = 200f;
    private float pressentBreakForce = 0f;
    private float pressentAccleration = 0f;

    [Header("Vehicle Steering")]
    public float wheelsTorque = 20f;
    private float pressentTurnAngle = 0f;

    [Header("Vehicle Secuirty")]
    public Player player;
    private float radius = 5f;
    private bool isOpened = false;

    [Header("Disable Thing")]
    public GameObject AimCam;
    public GameObject AimCanvas;
    public GameObject ThirdPersonCam;
    public GameObject ThirdPersonCanvas;
    public GameObject PlayerCharater;

    [Header("Vehicle Hit Var")]
    public Camera cam;
    public float hitRange = 2f;
    private float giveDamageOf = 100f;
    public GameObject goreEffect;
  


    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position)  < radius)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                isOpened = true;
                radius = 5000f;


                ObjectivesComplete.occurence.GetObjectivesDone(true, true, true, false);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                player.transform.position = vehicleDoor.transform.position;
                isOpened = false;
                radius = 5f;
            }
        }

        if (isOpened == true)
        {
            ThirdPersonCam.SetActive(false);
            ThirdPersonCanvas.SetActive(false);
            AimCam.SetActive(false);
            AimCanvas.SetActive(false);
            PlayerCharater.SetActive(false);


            MoveVehicle();
            VehicleSteering();
            ApplyBreaks();
            HitZombies();
        }
        else if (isOpened == false)
        {

            ThirdPersonCam.SetActive(true);
            ThirdPersonCanvas.SetActive(true);
            AimCam.SetActive(true);
            AimCanvas.SetActive(true);
            PlayerCharater.SetActive(true);

        }

    }

    void MoveVehicle()
    {
        //FWD
        frontRightWheelCollider.motorTorque = pressentAccleration;
        frontLeftWheelCollider.motorTorque = pressentAccleration;
        backLeftWheelCollider.motorTorque = pressentAccleration;
        backLeftWheelCollider.motorTorque = pressentAccleration;

        pressentAccleration = accelerationForce * - Input.GetAxis("Vertical");
    }

    void VehicleSteering()
    {
        pressentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
        frontRightWheelCollider.steerAngle = pressentTurnAngle;
        frontLeftWheelCollider.steerAngle = pressentTurnAngle;
    
        //animate the wheels
        SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
        SteeringWheels(backRightWheelCollider, backLeftWheelTransform);
        SteeringWheels(backLeftWheelCollider, backLeftWheelTransform);
    }

    void SteeringWheels(WheelCollider WC, Transform WT)
    {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);

        WT.position = position;
        WT.rotation = rotation;
    }

    void ApplyBreaks()
    {
        if(Input.GetKey(KeyCode.Space)) 
            pressentBreakForce = breakingForce;

            else
                pressentBreakForce = 0f;

        frontRightWheelCollider.brakeTorque = pressentBreakForce;
        frontLeftWheelCollider.brakeTorque = pressentBreakForce;
        backRightWheelCollider.brakeTorque = pressentBreakForce;
        backLeftWheelCollider.brakeTorque = pressentBreakForce; 

    }


    void HitZombies()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, hitRange))
        {
            Debug.Log(hitInfo.transform.name);

            Zombie1 zombie1 = hitInfo.transform.GetComponent<Zombie1>();
            Zombie2 zombie2 = hitInfo.transform.GetComponent<Zombie2>();

            if (zombie1 != null)
            {
                zombie1.zombieHitDamage(giveDamageOf);
                GameObject goreEffectGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo, 1f);
            }
            else if (zombie2 != null)
            {
                zombie2.zombieHitDamage(giveDamageOf);
                GameObject goreEffectGo = Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(goreEffectGo, 1f);

            }
           
        }
        }
}
