using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingMovement : MonoBehaviour
{
    [SerializeField] private CharacterHealth characterHealth;

    private void OnEnable()
    {
        characterHealth.OnDeath += Fall;
    }

    private void OnDisable()
    {
        characterHealth.OnDeath -= Fall;
    }

    private void Start()
    {
        RotateGameObject();
    }

    // Rotate so game object walks upside down
    private void RotateGameObject()
    {
        Vector3 currentRotation = gameObject.transform.eulerAngles;
        currentRotation.z = 180;
        //this.gameObject.

        gameObject.transform.eulerAngles = currentRotation;
    }

    // On death must fall to the ground
    private void Fall()
    {

    }
}
