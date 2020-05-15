using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 destination;
    float speed = 2;

    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Beweg dich zu dieser Position
        Vector3 dir = destination - transform.position;
        Vector3 velocity = dir.normalized * speed * Time.deltaTime;

        //sorgt dafür, dass ich nicht über das Ziel hinausschieße
        velocity = Vector3.ClampMagnitude(velocity, dir.magnitude);

        transform.Translate(velocity);
    }
}
