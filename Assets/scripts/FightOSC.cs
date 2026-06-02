using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class FightOSC : MonoBehaviour
{
    public static FightOSC Instance;

    UdpClient udp;
    IPEndPoint endPoint;

    void Awake()
    {
        Instance = this;
        udp = new UdpClient();
        endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
    }

    public void SendPunch() => SendOSC("/punch", 1f);
    public void SendHit() => SendOSC("/hit", 1f);
    public void SendJump() => SendOSC("/jump", 1f);

    public void SendHealth(string address, float current, float max)
    {
        float normalized = Mathf.Clamp01(current / max);
        SendOSC(address, normalized);
    }

    void SendOSC(string address, float value)
    {
        byte[] addressBytes = PadOSCString(address);
        byte[] typeBytes = PadOSCString(",f");

        byte[] valueBytes = System.BitConverter.GetBytes(value);

        if (System.BitConverter.IsLittleEndian)
        {
            System.Array.Reverse(valueBytes);
        }

        byte[] message = new byte[addressBytes.Length + typeBytes.Length + valueBytes.Length];

        System.Buffer.BlockCopy(addressBytes, 0, message, 0, addressBytes.Length);
        System.Buffer.BlockCopy(typeBytes, 0, message, addressBytes.Length, typeBytes.Length);
        System.Buffer.BlockCopy(valueBytes, 0, message, addressBytes.Length + typeBytes.Length, valueBytes.Length);

        udp.Send(message, message.Length, endPoint);
    }

    byte[] PadOSCString(string text)
    {
        byte[] raw = Encoding.ASCII.GetBytes(text);
        int paddedLength = ((raw.Length + 4) / 4) * 4;
        byte[] padded = new byte[paddedLength];

        System.Buffer.BlockCopy(raw, 0, padded, 0, raw.Length);
        return padded;
    }

    void OnDestroy()
    {
        udp?.Close();
    }
}