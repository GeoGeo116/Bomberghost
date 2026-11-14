using UnityEngine;
using UnityEngine.UIElements;

public class bomber : MonoBehaviour
{
    public GameObject explosion;

    private Scale scale; //to track the size of the bomb
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.localScale += Vector3.one * 2f * Time.deltaTime;
    }

    void OnDestroy()
    {
        Instantiate(explosion, new Vector3(GetComponent<Transform>().position.x, explosion.transform.position.y, GetComponent<Transform>().position.z),explosion.transform.rotation);
    }
}
