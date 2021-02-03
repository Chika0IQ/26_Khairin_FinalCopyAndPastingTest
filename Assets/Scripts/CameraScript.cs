using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    public GameObject cam1;
    public GameObject cam2;

    Vector3 offset = new Vector3(0f, 0.4f, 0.3f);


    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Camera();
    }

    private void Camera()
    {
        //transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.1f);
        if(Input.GetKeyDown(KeyCode.T))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        
    }
}
