using UnityEngine;

public class EHomingBullet : MonoBehaviour
{
    // 벡터의 뺄셈
    // ->OA - ->OB = ->BA (A를 바라보는 벡터)

    public GameObject target;       // player
    public float fireSpeed = 3f;
    Vector2 dir;
    Vector2 dirNo;


    void Start()
    {
        // 몬스터는 생성되기 때문에 넣을 수 없고 찾아야 한다.
        target = GameObject.FindGameObjectWithTag("Player");

        // 플레이어 - 미사일 = 플레이어를 바라보는 벡터
        dir = target.transform.position - transform.position;

        // 방향 벡터로 전환
        dirNo = dir.normalized;
    }

    void Update()
    {
        transform.Translate(dirNo * Time.deltaTime * fireSpeed);

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
