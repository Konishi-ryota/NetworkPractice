using Fusion;
using UnityEngine;

public class PlayerAvater : NetworkBehaviour
{
    private NetworkCharacterController characterController;

    public override void Spawned()
    {
        characterController = GetComponent<NetworkCharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        var inputDirection = new Vector3(Input.GetAxis("Horizontal"),
                                         0f,
                                         Input.GetAxis("Vertical"));

        characterController.Move(inputDirection);
    }
}
