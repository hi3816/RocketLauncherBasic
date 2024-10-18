using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public Animator animator;  // �ִϸ����� ������Ʈ�� �Ҵ�
    public float impactThreshold = 10f;  // ����� ��� ���� ũ�� �������� ����

    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� ��� �ӵ��� ��� (��ݷ�)
        float impactForce = collision.relativeVelocity.magnitude;

        // ����� �Ӱ谪���� ũ�� �ִϸ��̼� ����
        if (impactForce >= impactThreshold)
        {
            Debug.Log("ū ��� �߻�: " + impactForce);
            animator.SetTrigger("BigImpact");  // "BigImpact" Ʈ���Ÿ� �����Ͽ� �ִϸ��̼� ���
        }
    }
}
