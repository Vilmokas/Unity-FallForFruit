using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<Health>().ReduceHealth(1);
            Debug.Log("hit ground");
        }
    }
}
