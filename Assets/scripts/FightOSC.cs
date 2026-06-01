using UnityEngine;
using OscJack;

public class FightOSC : MonoBehaviour
{
    public static FightOSC Instance;
    private OscClient _client;

    void Awake()
    {
        Instance = this;
        _client = new OscClient("127.0.0.1", 9000);
    }

    public void SendPunch() => _client.Send("/punch", 1);
    public void SendHit()   => _client.Send("/hit", 1);
    public void SendJump()  => _client.Send("/jump", 1);

    public void SendHealth(float current, float max)
    {
        float normalized = Mathf.Clamp01(current / max);
        _client.Send("/health", normalized);
    }

    void OnDestroy() => _client?.Dispose();
}