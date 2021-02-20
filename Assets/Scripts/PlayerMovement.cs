using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 950f;
    [SerializeField] private float verticalRotate = 80f;
    [SerializeField] private float jump = 7.5f;



    public Rigidbody playerRb;
    public Animator animator;
    public GameObject cam;
    public GameObject cam2;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;


    public static int spacePressed = 0;
    public float range = 100f;

    private float gravity = 850f;

    private int tPressed = 0;
    // Start is called before the first frame update
    void Start()
    {
        cam.SetActive(true);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
        //PlayerShoot();
    }

    private void PlayerControls()
    {

        playerRb.AddForce(Vector3.down * Time.deltaTime * gravity);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotateSpeed, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && spacePressed < 1) // fixed jump :)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            spacePressed += 1;
            Debug.Log(spacePressed);
        }

        if(Input.GetKeyDown(KeyCode.Q) && tPressed == 0)
        {
            PlayerShoot();
            Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && tPressed == 1)
        {
            PlayerShoot2();
            Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
        }

        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            cam.transform.Rotate(new Vector3(Time.deltaTime * -verticalRotate, 0, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            cam.transform.Rotate(new Vector3(Time.deltaTime * verticalRotate, 0, 0));
        }*/

        //if(Input.GetKey(KeyCode.T))
        //{
        //    cam.SetActive(false);
        //    cam2.SetActive(true);

        //    tPressed += 1;
        //}

        if(tPressed == 1)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                cam.SetActive(true);
                cam2.SetActive(false);

                tPressed = 0;
            }
        }
        else if (tPressed == 0)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                cam.SetActive(false);
                cam2.SetActive(true);

                tPressed = 1;
            }
        }
        

    }

    private void PlayerShoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }

    private void PlayerShoot2()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam2.transform.position, cam2.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }

}
