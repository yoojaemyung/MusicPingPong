using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public float RotateSpeed = 10f;


    void Update()
    {
        // ���� �������� ȸ���� = �ӵ� �� ������ �ð�
        float delta = RotateSpeed * Time.deltaTime;
        
        // Y�� �������� ȸ��
        transform.Rotate(0f, delta, 0f, Space.World);
    }
}
