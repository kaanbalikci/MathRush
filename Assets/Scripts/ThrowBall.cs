using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    [SerializeField] private Camera Cam;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject ball;
    public float force = 10f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch Touched = Input.GetTouch(0);
            
            if(Touched.phase == TouchPhase.Began)
            {
                Vector3 screenTouch = Cam.ScreenToWorldPoint(Touched.position);
                //Instantiate(ball, player.transform.position, Quaternion.identity);
                GameObject ballTH = Instantiate(ball, player.transform.position, Quaternion.identity);
                rb = ballTH.GetComponent<Rigidbody>();
                rb.AddForce((cube.transform.position-ballTH.transform.position) * 220f);
                Debug.Log(Touched.position);

                //cube.transform.Rotate(0, screenTouch.y, 0 , Space.Self);
                /*ballTH.transform.position = new Vector3(screenTouch.x,screenTouch.y,0);
                ballTH.GetComponent<Rigidbody>().AddForce(ballTH.transform.forward * force);*/
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 screenTouch = Cam.ScreenToWorldPoint();
            
            
            //ballTH.transform.position = new Vector3(screenTouch.x, screenTouch.y, 0);
            //ballTH.GetComponent<Rigidbody>().AddForce(ballTH.transform.forward * force);
        }
    }
        

    /*bool isAttracting = false;
    Vector2 touchPosition;
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, new Vector2(0, 0));
            if (hit.transform != null)
            {
                if (hit.transform.gameObject.Equals(gameObject))
                {
                    isAttracting = true;

                    //transform.position = touchPosition;
                    Debug.Log("This is User Created.");
                }
                else
                {
                    isAttracting = false;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isAttracting) Attract(touchPosition);
    }
    void Attract(Vector2 target)
    {
        Debug.Log(rb.tag);
        // Calculate forces
        Vector2 direction = rb.position - target;
        float distance = direction.magnitude;
        Debug.Log("Distance: " + distance);
        Vector2 force = direction.normalized * followSpeed;
        Debug.Log("Force: " + force);
        rb.AddForce(force);
    }*/
}
