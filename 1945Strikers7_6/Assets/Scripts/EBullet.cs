using UnityEngine;

public class EBullet : MonoBehaviour
{
    public float fireSpeed = 4f ;

    /// TODO. 이펙트, 공격력 구현

    void Update()
    {
        //미사일 위쪽 방향으로 움직이기
        transform.Translate(-Vector3.up * fireSpeed * Time.deltaTime);

        if(transform.position.x >= 7f || transform.position.x <= -7f || transform.position.y <= -7f)
            Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
