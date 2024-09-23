using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    [SerializeField] float backAngle = 65f;
    [SerializeField] float sideAngle = 155f;
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void LateUpdate()
    {
        Vector3 camForwardVector = new Vector3 (Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        Debug.DrawRay(Camera.main.transform.position, camForwardVector * 5f, Color.magenta);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector,Vector3.up);

        Vector2 animationDirection = new Vector2(0f, -1f);

        float angle = Mathf.Abs(signedAngle);

        if(signedAngle < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipY = false;

        }

        if(angle < backAngle)
        {
            animationDirection = new Vector2(0f, -1f);
        }
        else if(angle < sideAngle)
        {
            animationDirection = new Vector2 (1f, 0f);

            if (signedAngle < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipY = false;

            }

        }
        else
        {
            //Front Animation daw
            animationDirection = new Vector2(0f, 1f);
        }

        animator.SetFloat("xMove", animationDirection.x);
        animator.SetFloat("yMove", animationDirection.y);

    }
}
