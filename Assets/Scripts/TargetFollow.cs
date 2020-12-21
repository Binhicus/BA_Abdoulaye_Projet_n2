using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    public float Hauteur = 2.3f;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 targetPos = player.position + offset;
        targetPos.y = Hauteur;
        transform.position = targetPos;
    }
}
