using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private Animator Animator;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private ShopKeeperAnimationHelper AnimationHelper;

    private ItemDisplay _itemDisplay;

    [Inject]
    public void Construct(ItemDisplay itemDisplay)
    {
        _itemDisplay = itemDisplay;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    MoveToPoint(new Vector2(transform.position.x - 300, transform.position.y));
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    MoveToPoint(new Vector2(transform.position.x + 300, transform.position.y));
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    Animator.SetTrigger("Toss");
        //}
        if (Input.GetKeyDown(KeyCode.S))
        {
            Animator.SetTrigger("ShowItem");
        }
    }

    public IEnumerator MoveToPoint(Vector2 point)
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

    public IEnumerator ShowItem()
    {
        yield return AnimationHelper.ShowItem();
    }

    private void SetFacedDirection(Vector2 point)
    {
        bool forward = transform.position.x < point.x;

        transform.rotation = Quaternion.Euler(new Vector3(0f, forward ? 0f : 180f, 0f));
    }
}
