using Fusion;
using UnityEngine;

public class PlayerAvater : NetworkBehaviour
{
    private NetworkCharacterController characterController;

    [Networked]
    public NetworkString<_16> NickName { get; set; }
    public override void Spawned()
    {
        characterController = GetComponent<NetworkCharacterController>();
        var view = GetComponent<PlayerAvaterView>();
        view.SetNickName(NickName.Value);
        // 自身がアバターの権限を持っているなら、カメラの追従対象にする
        if (HasStateAuthority)
        {
            view.MakeCameraTarget();
        }
    }

    public override void FixedUpdateNetwork()
    {
        var cameraRotation = Quaternion.Euler(0f,
                                              Camera.main.transform.rotation.eulerAngles.y,
                                              0f);
        var inputDirection = new Vector3(Input.GetAxis("Horizontal"),
                                         0f,
                                         Input.GetAxis("Vertical"));

        characterController.Move(cameraRotation * inputDirection);

        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Jump();
        }
    }
}
