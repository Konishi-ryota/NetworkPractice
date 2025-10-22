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
        // CinemachineCamera‚Ì—Dæ“x‚ğã‚°‚ÄAƒJƒƒ‰‚Ì’Ç]‘ÎÛ‚É‚·‚é
        cinemachineCamera.Priority.Value = 100;
    }
    public void SetNickName(string nickName)
    {
        nameLabel.text = nickName;
    }
}
