using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private bool center;

    void Awake()
    {
        if (center)
        {
            LeanTween.value(gameObject, (float f) =>
            {
                transform.position = new Vector3(f, transform.position.y, transform.position.z);
            }, transform.position.x, -56, 15).setOnComplete(() => { MoveFromStartToEnd(); });
        }
        else
        {
            MoveFromStartToEnd();
        }
    }

    private void MoveFromStartToEnd()
    {
        LeanTween.value(gameObject, (float f) =>
        {
            transform.position = new Vector3(f, transform.position.y, transform.position.z);
        }, 56, -56, 30).setOnComplete(() => { MoveFromStartToEnd(); });
    }

    void Update()
    {
        
    }
}
