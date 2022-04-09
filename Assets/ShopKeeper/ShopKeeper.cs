using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private Animator Animator;
    [SerializeField]
    private float Speed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveToPoint(new Vector2(transform.position.x - 300, transform.position.y));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveToPoint(new Vector2(transform.position.x + 300, transform.position.y));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Cheer());
        }
    }

    public IEnumerator Cheer()
    {
        Animator.SetTrigger("StartCheering");
        yield return new WaitForSeconds(5);
        Animator.SetTrigger("StopCheering");
    }

    public void MoveToPoint(Vector2 point)
    {
        StartCoroutine(MoveToPointEnumerator(point));
    }

    private IEnumerator MoveToPointEnumerator(Vector2 point)
    {
        Animator.SetTrigger("StartWalking");
        SetFacedDirection(point);
        while (true)
        {
            float speed = Speed * Time.deltaTime;
            gameObject.transform.Translate(new Vector2(point.x - transform.position.x, point.y - transform.position.y).normalized * speed, Space.World);

            if (Vector2.Distance(transform.position, point) < 1)
            {
                break;
            }

            yield return null;
        }
        Animator.SetTrigger("StopWalking");
    }

    private void SetFacedDirection(Vector2 point)
    {
        bool forward = transform.position.x < point.x;

        transform.rotation = Quaternion.Euler(new Vector3(0f, forward ? 0f : 180f, 0f));
    }
}
