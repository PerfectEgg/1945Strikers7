using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public float moveSpeed = 2f;
    public float delay = 1f;

    public Transform ms1;
    public Transform ms2;
    
    public GameObject bullet;

    // 아이템
    [SerializeField]
    private GameObject item;

    // 이펙트
    [SerializeField]
    private GameObject effect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("ShootBullet", delay, delay);
    }

    // Update is called once per frame
    void ShootBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);
    }

    void Update()
    {
        // 아래 방향으로 움직이기
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);

        // y 값을 비교하여 삭제
        if(transform.position.y < -7f)
            Destroy(gameObject);
    }

    public void Damage(int att)
    {
        hp -= att;

        if(hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(item, transform.position, Quaternion.identity);

            var eff = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(eff, 2);
        }
    }
}
