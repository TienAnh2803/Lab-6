using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool canFire = false;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(canFire);
        if(canFire)
        {
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 255f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            }
        }else
        {
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 0f);
        }
    }

}
