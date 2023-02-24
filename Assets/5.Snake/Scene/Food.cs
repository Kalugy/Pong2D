
using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D gridArea;
    // Start is called before the first frame update
    void Start()
    {
        RandomP();
    }

    // Update is called once per frame
    void RandomP()
    {
        Bounds b = gridArea.bounds;

        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RandomP();
    }

}
