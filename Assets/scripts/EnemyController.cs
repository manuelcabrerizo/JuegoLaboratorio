using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform transform;
    public GameObject healthBar;
    private int health = 60;
    private float speed = 3.0f;
    public bool isGrounded = false;
    public LayerMask groundLayer;
    public LayerMask nadaLayer;
    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SetIsGrounded();
        ChangeDirecction();
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }

        if(this.health > 40)
        {
            healthBar.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if(this.health <= 40 && this.health > 20)
        {
            healthBar.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if(health <= 20)
        {
            healthBar.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (isGrounded)
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            health -= 20;
        }
    }


    void SetIsGrounded()
    {
        if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.down, 0.9f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void ChangeDirecction()
    {
        
        if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.right, 0.8f, groundLayer))
        {
            speed = -speed;
        }
        else if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.left, 0.8f, groundLayer))
        {
            speed = Mathf.Abs(speed);
        }
        else if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.right, 0.8f, nadaLayer))
        {
            speed = -speed;
        }
        else if (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector2.left, 0.8f, nadaLayer))
        {
            speed = Mathf.Abs(speed);
        }
    }
}
