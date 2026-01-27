using UnityEngine;

public class Item : MonoBehaviour
{
    // 아이템 속도
    public float itemSpeed = 20f;

    private float endTime = 10f;
    private float timer = 0f;

    Rigidbody2D rig = null;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(itemSpeed, itemSpeed));
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= endTime)
            Destroy(gameObject);
    }
}
