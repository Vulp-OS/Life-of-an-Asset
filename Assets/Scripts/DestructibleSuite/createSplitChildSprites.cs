using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class createSplitChildSprites : MonoBehaviour {
    public Texture2D source;
    public GameObject target;
    public int resolutionX;
    public int resolutionY;
    public float imageScale;

    void Start()
    {
        for (int i = 0; i < resolutionX; i++)
        {
            for (int j = 0; j < resolutionY; j++)
            {
                Sprite newSprite = Sprite.Create(source, new Rect((i * (source.width / resolutionX)), (j * (source.height / resolutionY)), source.width / resolutionX, source.height / resolutionY), new Vector2(0.5f, 0.5f));
                if (!IsTransparent(newSprite.texture))
                {
                    GameObject n = new GameObject();
                    n.name = "SpriteFragment" + i + "," + j;
                    SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                    sr.sprite = newSprite;
                    n.transform.position = new Vector3(i * ((source.width / resolutionX) / newSprite.pixelsPerUnit), j * ((source.height / resolutionY) / newSprite.pixelsPerUnit), 0);
                    n.transform.parent = target.transform;
                    PolygonCollider2D pc = n.AddComponent<PolygonCollider2D>();
                }
            }
        }
        target.transform.localScale = new Vector3(imageScale, imageScale, imageScale);
    }

    // Update is called once per frame
    void Update () {
		
	}

    bool IsTransparent(Texture2D tex)
    {
        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                if (tex.GetPixel(x, y).a < 5)
                {
                    return false;
                }
            }
        }
        return true;
    }
}