using System;
using System.Collections.Generic;
using UnityEngine;
using Fusion.Sockets;
using Fusion;
public class GameLauncher : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField]
    private NetworkRunner networkRunnerPrefab;
    [SerializeField]
    private NetworkPrefabRef playerAvatarPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private async void Start()
    {
        // NetworkRunner�𐶐�����
        var networkRunner = Instantiate(networkRunnerPrefab);
        // GameLauncher���ANetworkRunner�̃R�[���o�b�N�Ώۂɒǉ�����
        networkRunner.AddCallbacks(this);
        var result = await networkRunner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.Shared,
        });
        Debug.Log(result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void INetworkRunnerCallbacks.OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }
    void INetworkRunnerCallbacks.OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }

    void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    // �v���C���[���Z�b�V�����֎Q���������ɌĂ΂��R�[���o�b�N
    {
        if (player == runner.LocalPlayer)
        // �Z�b�V�����֎Q�������v���C���[���������g���ǂ����𔻒肷��
        {
            var rand = UnityEngine.Random.insideUnitCircle * 5;
            var spawnPosition = new Vector3(rand.x, 2f, rand.y);

            runner.Spawn(playerAvatarPrefab, spawnPosition, Quaternion.identity, onBeforeSpawned : (_, networkObject) =>
            {
                networkObject.GetComponent<PlayerAvater>().NickName = $"Player{UnityEngine.Random.Range(0, 10000)}";
            });
        }
    }

    void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
    void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input) { }
    void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }
    void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner) { }
    void INetworkRunnerCallbacks.OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason) { }
    void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
    void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
    void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
    void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data) { }
    void INetworkRunnerCallbacks.OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress) { }
    void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner) { }
    void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner) { }
}
