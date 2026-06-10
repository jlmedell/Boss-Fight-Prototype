using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public int damage = 1;

    private Rigidbody2D rb;
    private float attackCooldown = 1f;
    private float attackTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        attackTimer -= Time.deltaTime;

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        if (distance > attackRange)
        {
            Vector2 direction =
                (player.position - transform.position).normalized;

            rb.linearVelocity =
                new Vector2(direction.x * moveSpeed,
                rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;

            if (attackTimer <= 0)
            {
                Attack();
                attackTimer = attackCooldown;
            }
        }
    }

    void Attack()
    {
        player.GetComponent<Health>().TakeDamage(damage);
    }
}
