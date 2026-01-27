using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float fireSpeed = 4f ;
    public int att;

    /// TODO. 이펙트, 공격력 구현

    void Update()
    {
        //미사일 위쪽 방향으로 움직이기
        transform.Translate(Vector3.up * fireSpeed * Time.deltaTime);

        if(transform.position.x >= 7f || transform.position.x <= -7f || transform.position.y <= -7f)
            Destroy(gameObject);
    }

    // 충돌 시 이벤트
    private void OnBecameInvisible()
    {
        // 자기자신 제거
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            // 적에게 미사일 피해
            collision.gameObject.GetComponent<Enemy>().Damage(att);

            // 미사일 삭제
            Destroy(gameObject);
        }

        if(collision.CompareTag("Boss"))
        {
            // 적에게 미사일 피해
            collision.gameObject.GetComponent<Boss>().Damage(att);

            // 미사일 삭제
            Destroy(gameObject);
        }

        if(collision.CompareTag("BossAccessories"))
        {
            // 적에게 미사일 피해
            collision.gameObject.GetComponentInParent<Boss>().Damage(att);

            // 미사일 삭제
            Destroy(gameObject);
        }
    }
}
