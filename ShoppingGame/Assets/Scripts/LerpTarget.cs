using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTarget : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }
}
