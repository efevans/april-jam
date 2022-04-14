using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private Item TempItem;

    [SerializeField]
    private OptionsMenu TempOptionsMenu;

    [SerializeField]
    private Animator Animator;
    [SerializeField]
    private float Speed;

    private ItemDisplay _itemDisplay;

    [Inject]
    public void Construct(ItemDisplay itemDisplay)
    {
        _itemDisplay = itemDisplay;
    }

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
            Animator.SetTrigger("Toss");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Animator.SetTrigger("Sheesh");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _itemDisplay.Display(TempItem, 120);
            TempOptionsMenu.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _itemDisplay.CloseDisplay();
            TempOptionsMenu.gameObject.SetActive(false);
        }
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
