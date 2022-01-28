using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update() {
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Vector3 moveCamTo = transform.position - transform.forward * 40.0f + transform.up * 5.0f;
        float bias = 0.96f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);

        transform.position += transform.forward * speed * Time.deltaTime;

        speed -= transform.forward.y * Time.deltaTime * 10.0f;
        
        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        float terrainHeightAtPos = Terrain.activeTerrain.SampleHeight(transform.position);

        if(terrainHeightAtPos > transform.position.y)
        {
            transform.position = new Vector3(
                transform.position.x,
                terrainHeightAtPos,
                transform.position.z
            );
        }
    }
}
