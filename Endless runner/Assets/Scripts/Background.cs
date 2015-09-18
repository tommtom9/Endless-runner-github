using UnityEngine;


public class Background : MonoBehaviour
{
	public float tileSpeed;
    
    void Update ()
	{
        Vector2 offset = GetComponent<Renderer>().material.mainTextureOffset;
        offset.x += tileSpeed * (Time.deltaTime / 10);
        offset.x = (offset.x) % 1;
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}