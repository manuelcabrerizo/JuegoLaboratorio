using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{


    private Transform transform;
    private Animator animation;
    private Rigidbody2D rigidbody2D;
    private bool playState = false;
    public bool isGrounded = false;
    public float speed = 5.0f;
    //public float gravity = -0.5f;
    //private float dy = 0.0f;
    bool aWasPress = false;
    bool dWasPress = false;
    public float verticalForce = 5.0f;
    public LayerMask groundLayer;

    public GameObject fireball;

    public List<GameObject> fireballs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        animation = this.GetComponent<Animator>();
        transform = this.GetComponent<Transform>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        //gravity = -0.5f;
        //dy = 0.0f;
        //Physics.gravity = new Vector3(0.0f, 18.8f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.playState)
        {

            SetIsGrounded();

            for (int i = 0; i < fireballs.Count; i++)
            {
                if(fireballs[i] == null)
                {
                    fireballs.RemoveAt(i);
                }
            }

            //this.dy = this.dy + (gravity * Time.deltaTime);

            //float verticalSpeed = verticalForce * Time.deltaTime;


            //Debug.Log(verticalSpeed);
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && this.isGrounded)
            {
                rigidbody2D.AddRelativeForce(Vector2.up * verticalForce, ForceMode2D.Impulse);
            }
            //rigidbody2D.AddRelativeForce(Vector2.down * verticalSpeed, ForceMode2D.Force);

            if (Input.GetMouseButtonDown(0))
            {
                fireballs.Add(Instantiate(fireball, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity));
                if (dWasPress)
                    fireballs.Last().SendMessage("SetDirection", new Vector2(1, 0));
                else
                    fireballs.Last().SendMessage("SetDirection", new Vector2(-1, 0));
            }

           /*
           transform.position = new Vector3(this.transform.position.x, this.transform.position.y + this.dy, this.transform.position.z);
           if (transform.position.y < -2.779)
           {
               transform.position = new Vector3(this.transform.position.x, -2.779f, this.transform.position.z);
           }
           */



            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(this.transform.position.x - (speed * Time.deltaTime), this.transform.position.y, this.transform.position.z);
                transform.rotation = new Quaternion(0.0f, 90.0f, 0.0f, 0.0f);
                UpdateState("PlayerRun");
                aWasPress = true;
                dWasPress = false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(this.transform.position.x + (speed * Time.deltaTime), this.transform.position.y, this.transform.position.z);
                transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                aWasPress = false;
                dWasPress = true;
                UpdateState("PlayerRun");
            }
            else
            {
                UpdateState("PlayerIdle");
                if(dWasPress)
                {
                    transform.rotation = new Quaternion(0.0f, 90.0f, 0.0f, 0.0f);
                }
                else
                {
                    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                }

            }

        }
    }

    
    void SetIsGrounded()
    {
        if (Physics2D.Raycast(new Vector3(this.transform.position.x - 0.3f, this.transform.position.y, this.transform.position.z), Vector2.down, 0.9f, groundLayer) ||
            Physics2D.Raycast(new Vector3(this.transform.position.x + 0.3f, this.transform.position.y, this.transform.position.z), Vector2.down, 0.9f, groundLayer))
        {
            this.isGrounded = true;
        }else
        {
            this.isGrounded = false;
        }
    }


    public void UpdateState(string state = null)
    {
        if(state != null)
        {
            animation.Play(state);
        }
    }

    public void SetPlayState(bool state)
    {
        this.playState = state;
    }
}
