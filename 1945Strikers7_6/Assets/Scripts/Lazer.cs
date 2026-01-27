using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;

    [SerializeField]
    Transform pos;

    int Attack = 10;

    void Start()
    {
        // 플레이어의 위치는 계속 변동되기에 플레이어를 찾아주어야 함.
        pos = GameObject.FindWithTag("Player").GetComponent<Player>().pos;
    }

    void Update()
    {
        transform.position = pos.position;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Attack);

            CreateEffect(collision.transform.position);
        }

        if (collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().Damage(Attack);

            CreateEffect(collision.transform.position);
        }

        if(collision.CompareTag("BossAccessories"))
        {
            collision.gameObject.GetComponentInParent<Boss>().Damage(Attack);

            CreateEffect(collision.transform.position);
        }
    }

    void CreateEffect(Vector3 vec3)
    {
        //var eff = Instantiate(effect, vec3, Quaternion.identity);
        //Destroy(eff, 2);
    }
}
