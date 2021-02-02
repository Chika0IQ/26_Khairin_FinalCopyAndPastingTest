using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;

    Vector3 offset = new Vector3(0f, 0.4f, 0.3f);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera();
    }

    private void Camera()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.1f);
    }
}
