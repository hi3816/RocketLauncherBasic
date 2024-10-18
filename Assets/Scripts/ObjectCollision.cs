using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public Animator animator;  // 애니메이터 컴포넌트를 할당
    public float impactThreshold = 10f;  // 충격이 어느 정도 크면 반응할지 설정

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 객체의 상대 속도를 계산 (충격량)
        float impactForce = collision.relativeVelocity.magnitude;

        // 충격이 임계값보다 크면 애니메이션 실행
        if (impactForce >= impactThreshold)
        {
            Debug.Log("큰 충격 발생: " + impactForce);
            animator.SetTrigger("BigImpact");  // "BigImpact" 트리거를 실행하여 애니메이션 재생
        }
    }
}
