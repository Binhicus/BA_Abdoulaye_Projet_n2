using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField]
    Material dissolvedPlasma;
    public Material[] allMaterials;

    Renderer[] allChildRenderers;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "UltZone")
        {
            Debug.Log("change shader");
            for (int i = 0; i < allChildRenderers.Length; i++)
            {
                allChildRenderers[i].material = dissolvedPlasma;
            }


        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        allChildRenderers = GetComponentsInChildren<Renderer>();
        allMaterials = new Material[allChildRenderers.Length];
        for (int i = 0; i < allChildRenderers.Length; i++)
            {
                allMaterials[i] = allChildRenderers[i].material;
            }        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("aie aie aie ouille ouille");
            //kill
            playerMovement.Die();
        }
        
    }
}
