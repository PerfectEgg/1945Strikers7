using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 1.5f;
    [SerializeField] private int damage = 50;
    [SerializeField] private LayerMask hitLayers = Physics2D.DefaultRaycastLayers;

    void Start()
    {
        // 트리거에 진입하면 폭탄 범위 내에 모든 콜라이더를 검사하고 배열로 저장
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, hitLayers);

        // 중복을 방지하기 위한 해시셋 사용
        var damaged = new HashSet<Enemy>();
        var Bullet = new HashSet<EBullet>();
        var HBullet = new HashSet<EHomingBullet>();
        var BBullet = new HashSet<BossBullet>();

        // 모든 콜라이더 순회
        foreach(var hit in hits)
        {
            // null 체크
            if(hit == null) continue;
            // 적 컴포넌트를 가져와 데미지 부여
            var enumy = hit.GetComponent<Enemy>();

            // 적 null 체크와 적이 이미 데미지를 받았는 지 체크
            if(enumy != null && !damaged.Contains(enumy))
            {
                // 데미지 적용
                enumy.Damage(damage);
                // 데미지 받은 적을 해시셋에 추가
                damaged.Add(enumy);
            }

            var bullet = hit.GetComponent<EBullet>();

            // 적 null 체크와 적이 이미 데미지를 받았는 지 체크
            if(bullet != null && !Bullet.Contains(bullet))
            {
                // 데미지 적용
                Destroy(bullet.gameObject);
                // 데미지 받은 적을 해시셋에 추가
                Bullet.Add(bullet);
            }

            var h_bullet = hit.GetComponent<EHomingBullet>();

            // 적 null 체크와 적이 이미 데미지를 받았는 지 체크
            if(h_bullet != null && !HBullet.Contains(h_bullet))
            {
                // 데미지 적용
                Destroy(h_bullet.gameObject);
                // 데미지 받은 적을 해시셋에 추가
                HBullet.Add(h_bullet);
            }

            var b_bullet = hit.GetComponent<BossBullet>();

            // 적 null 체크와 적이 이미 데미지를 받았는 지 체크
            if(b_bullet != null && !BBullet.Contains(b_bullet))
            {
                // 데미지 적용
                Destroy(b_bullet.gameObject);
                // 데미지 받은 적을 해시셋에 추가
                BBullet.Add(b_bullet);
            }
        }

        // 적용 후 제거
        Destroy(gameObject, 2);
    }

    private void OnDrawGizmosSelected()
    {
        // 폭발 반경을 반투명 오렌지색 구체로 표시
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.5f);
        // 기즈모 구형태로 그리기  포지션, 반지름
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
