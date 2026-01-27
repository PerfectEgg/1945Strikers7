using UnityEngine;

public class Background : MonoBehaviour
{
    private float scollSpeed = 0.01f;
    public Material myMaterial;
    
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float offsetY = myMaterial.mainTextureOffset.y + scollSpeed * Time.deltaTime;

        myMaterial.mainTextureOffset = new Vector2(0, offsetY);
    }
}
