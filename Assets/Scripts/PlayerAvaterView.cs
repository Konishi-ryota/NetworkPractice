using Unity.Cinemachine;
using UnityEngine;
using TMPro;

public class PlayerAvaterView : MonoBehaviour
{
    [SerializeField]
    private CinemachineCamera cinemachineCamera;

    [SerializeField]
    private TextMeshPro nameLabel;
    public void MakeCameraTarget()
    {
        // CinemachineCamera�̗D��x���グ�āA�J�����̒Ǐ]�Ώۂɂ���
        cinemachineCamera.Priority.Value = 100;
    }
    public void SetNickName(string nickName)
    {
        nameLabel.text = nickName;
    }
}
