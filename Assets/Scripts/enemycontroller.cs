using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public float moveSpeed = 1.5f;
    public Vector3 offset = new Vector3(0f, 0f, 0f);
    private SpriteRenderer spriteRenderer;
    public float followDistance = 20f;
    [SerializeField] private float damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer > followDistance)
        {
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;

        if (direction.x < 0)
            spriteRenderer.flipX = true;
        else if (direction.x > 0)
            spriteRenderer.flipX = false;

        // Calculate movement vector
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
