using System.Collections;
using TMPro;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float ss = -2f;          // 몬스터 시작 x 좌표
    public float es = 2f;           // 몬스터 끝 x 좌표
    public float StartTime = 1f;    // 시작 시간
    public float SpawnStop = 10;    // 종료 시간
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemyBoss;

    bool swi1 = true;
    bool swi2 = true;

    [SerializeField]
    private GameObject textBossWarining;

    void Awake()
    {
        textBossWarining.SetActive(false);
    }

    void Start()
    {
        // 첫번째 몬스터 코루틴
        StartCoroutine(RandomSpawn1());
        Invoke("Stop1", SpawnStop);
    }

    IEnumerator RandomSpawn1()
    {
        while(swi1)
        {
            // 1초마다
            yield return new WaitForSeconds(StartTime);
            // 랜덤 x 값
            float x = Random.Range(ss, es);
            var r = new Vector2(x, transform.position.y);
            // 스폰
            Instantiate(enemy1, r, Quaternion.identity);
        }
    }

    IEnumerator RandomSpawn2()
    {
        while(swi2)
        {
            // 1초마다
            yield return new WaitForSeconds(StartTime + 2);
            // 랜덤 x 값
            float x = Random.Range(ss, es);
            var r = new Vector2(x, transform.position.y);
            // 스폰
            Instantiate(enemy2, r, Quaternion.identity);
        }
    }

    void Stop1()
    {
        swi1 = false;
        
        StopCoroutine(RandomSpawn1());

        // 두번째 몬스터 코루틴
        StartCoroutine(RandomSpawn2());
        Invoke("Stop2", SpawnStop + 20);
    }

    void Stop2()
    {
        swi2 = false;
        
        StopCoroutine(RandomSpawn2());

        textBossWarining.SetActive(true);

        
        StartCoroutine(Shake());

 
        var r = new Vector2(0, transform.position.y);
        Instantiate(enemyBoss, r, Quaternion.identity);
    }

    IEnumerator Shake()
    {
        int shakeCnc = 30;

        while (shakeCnc > 0)
        {
            CameraImpulse.Instance.CameraShakeShow();
            yield return new WaitForSeconds(0.1f);
            shakeCnc--;
        }
    }
}
