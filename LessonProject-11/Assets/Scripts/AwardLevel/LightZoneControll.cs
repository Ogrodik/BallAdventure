using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightZoneControll : MonoBehaviour
{
    [SerializeField] private GameObject localLight;

    private void OnTriggerEnter(Collider other)
    {
        localLight.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
