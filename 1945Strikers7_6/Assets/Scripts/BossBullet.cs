using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float fireSpeed = 3f;
    Vector2 vec2 = Vector2.down;

    void Update()
    {
        transform.Translate(vec2 * Time.deltaTime * fireSpeed);
    }

    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
