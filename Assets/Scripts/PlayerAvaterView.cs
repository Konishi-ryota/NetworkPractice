using Unity.Cinemachine;
using UnityEngine;

public class PlayerAvaterView : MonoBehaviour
{
    [SerializeField]
    private CinemachineCamera cinemachineCamera;

    public void MakeCameraTarget()
    {
        // CinemachineCamera�̗D��x���グ�āA�J�����̒Ǐ]�Ώۂɂ���
        cinemachineCamera.Priority.Value = 100;
    }
}
