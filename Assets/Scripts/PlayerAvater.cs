using Fusion;
using UnityEngine;

public class PlayerAvater : NetworkBehaviour
{
    private NetworkCharacterController characterController;

    public override void Spawned()
    {
        characterController = GetComponent<NetworkCharacterController>();
        var view = GetComponent<PlayerAvaterView>();
        // ���g���A�o�^�[�̌����������Ă���Ȃ�A�J�����̒Ǐ]�Ώۂɂ���
        if (HasStateAuthority)
        {
            view.MakeCameraTarget();
        }
    }

    public override void FixedUpdateNetwork()
    {
        var inputDirection = new Vector3(Input.GetAxis("Horizontal"),
                                         0f,
                                         Input.GetAxis("Vertical"));

        characterController.Move(inputDirection);

        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Jump();
        }
    }
}
