using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public float RotateSpeed = 10f;


    void Update()
    {
        // 현재 프레임의 회전량 = 속도 × 프레임 시간
        float delta = RotateSpeed * Time.deltaTime;
        
        // Y축 기준으로 회전
        transform.Rotate(0f, delta, 0f, Space.World);
    }
}
