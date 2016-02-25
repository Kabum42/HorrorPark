using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CycleSprites : MonoBehaviour {

    public List<Texture2D> textures;
    private List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer spriteRenderer;
    private Material mat;

    private float speed = 0.06f;
    private float cooldown = 0f;
    private int currentTexture = 0;


	// Use this for initialization
	void Start () {

        spriteRenderer = this.GetComponent<SpriteRenderer>();
        mat = spriteRenderer.material;

        for (int i = 0; i < textures.Count; i++)
        {
            sprites.Add(Sprite.Create(textures[i], new Rect(0, 0, textures[i].width, textures[i].height), new Vector2(0.5f, 0.5f)));
        }
	
	}

    // Update is called once per frame
    void Update()
    {

        cooldown += Time.deltaTime;
        if (cooldown >= speed)
        {
            cooldown -= speed;
            currentTexture++;
            if (currentTexture > textures.Count - 1)
            {
                currentTexture = 0;
            }
        }

        int currentTexture2 = currentTexture + 1;
        if (currentTexture2 > textures.Count - 1) { currentTexture2 = 0; }
        int currentTexture3 = currentTexture2 + 1;
        if (currentTexture3 > textures.Count - 1) { currentTexture3 = 0; }

        spriteRenderer.sprite = sprites[currentTexture];
        mat.SetTexture("_Tex2", textures[currentTexture2]);
        mat.SetTexture("_Tex3", textures[currentTexture3]);

        Debug.Log(currentTexture);

	}
}
