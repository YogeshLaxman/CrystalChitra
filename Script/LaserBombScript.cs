using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBombScript : MonoBehaviour {
    [SerializeField] GameObject actualShellPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var temp = collision.gameObject.tag;
        if (temp == "Breakable")
        {
            GameObject bombShell = Instantiate(actualShellPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            bombShell.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
