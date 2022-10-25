using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnBall : MonoBehaviour
{
    public static SpawnBall SB;

    [SerializeField] private Camera Cam;
    public GameObject player;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject cubePrefab;
    [HideInInspector] public GameObject _cube;

    private Rigidbody rb;
    private Vector3 screenTouch;

    //PUBLICS---------
    public float force = 10f;
    public bool isShot;
    

    private void Awake()
    {
        SB = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /*private void OnEnable()
    {
        CinemachineCore.CameraUpdatedEvent.RemoveListener(OnCamUpdated);
        CinemachineCore.CameraUpdatedEvent.AddListener(OnCamUpdated);
    }
    private void OnDisable()
    {
        CinemachineCore.CameraUpdatedEvent.RemoveListener(OnCamUpdated);
    }

    private void OnCamUpdated(CinemachineBrain brain)
    {
        Camera Cam = brain.OutputCamera;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
        screenTouch = Cam.ScreenToWorldPoint(mousePos);
    }*/
    private void Update()
    {
 
        if (Input.GetMouseButtonDown(0))
        {
            isShot = true;
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f);
            Vector3 screenTouch = Cam.ScreenToWorldPoint(mousePos);

            //instantiate cube to aim position

            //_cube = Instantiate(cubePrefab,screenTouch,Quaternion.identity);

            _cube = ObjectPool.objects.GetCubeObject();

            if(_cube != null)
            {
                Debug.Log("cube");
                _cube.SetActive(true);
                _cube.transform.position = screenTouch;               
            }

            //instantiate ball from our pos
            //GameObject ballTH = Instantiate(ball, player.transform.position, Quaternion.identity);

            ball = ObjectPool.objects.GetObject();

            if(ball != null)
            {
                Debug.Log("ball");
                ball.SetActive(true);
                ball.transform.position = player.transform.position;

                
            }
            
            //throw ball player pos to cube pos
            Vector3 ballForcePoint = new Vector3(_cube.transform.position.x, _cube.transform.position.y + 0.2f, _cube.transform.position.z);
            rb = ball.GetComponent<Rigidbody>();
            rb.AddForce((ballForcePoint - player.transform.position) * 400f);



            _cube.SetActive(false);
            //Destroy(ballTH, 2f);

        }
        
    }



  
}
