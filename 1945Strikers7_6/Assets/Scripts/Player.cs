using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject[] bulletPrefeb;
    public Transform pos = null;

    public int power = 0;

    [SerializeField]
    private GameObject PowerUp;
    [SerializeField]
    private GameObject Bomb;

    [Header("레이저")]
    public GameObject lazer;
    public float gValue = 0;
    public Image Gage;

    Animator ani;   // 애니메이터 컴포넌트

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(x, y);

        // 대각선 보정
        if (input.sqrMagnitude > 1f) input.Normalize();

        if (x <= -0.5f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);

        if (x >= 0.5f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);

        if (y >= 0.5f)
            ani.SetBool("up", true);
        else
            ani.SetBool("up", false);

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            // 폭탄 생성
            Instantiate(Bomb, Vector2.zero, Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 미사일 생성
            Instantiate(bulletPrefeb[power], pos.position, Quaternion.identity);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            gValue += Time.deltaTime;
            // 게이지 바 적용
            Gage.fillAmount = gValue;

            if(gValue >= 1f)
            {
                var la = Instantiate(lazer, pos.position, Quaternion.identity);
                Destroy(la, 3);
                gValue = 0;
            }
        }
        else
        {
            gValue -= Time.deltaTime;

            if(gValue <= 0)
            {
                gValue = 0;
            }

            // 게이지 바 적용
            Gage.fillAmount = gValue;
        }
        

        Vector3 move = new Vector3(input.x, input.y, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        // 화면 밖으로 나가지 않도록 월드 좌표를 뷰포트 좌표로 변환합니다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // 날개가 잘리지 않도록 화면 끝에 여분을 설정
        float marginX = 0.05f;
        float marginY = 0.08f;

        // 뷰포트 x 값을 0~1 범위로 클램프합니다.
        viewPos.x = Mathf.Clamp(viewPos.x, marginX, 1f - marginX);
        // 뷰포트 y 값을 0~1 범위로 클램프합니다.
        viewPos.y = Mathf.Clamp(viewPos.y, marginY, 1f - marginY);
        // 클램프된 뷰포트 좌표를 다시 월드 좌표로 변환하여 적용합니다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos; // 위치 갱신
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            power++;

            if (power >= 3)
                power = 3;
            else
            {
                var powerUp = Instantiate(PowerUp, transform.position, Quaternion.identity);
                Destroy(powerUp, 1);
            }
            
            Destroy(collision.gameObject);
        }
    }
}
