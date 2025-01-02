using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Web3Laliberte.OperationsAPI.Utility;

public static class WebSocketHandler
{
    public static async Task HandleWebSocketAsync(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!result.CloseStatus.HasValue)
        {
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Console.WriteLine($"Received: {message}");

            var response = Encoding.UTF8.GetBytes("Message received");
            await webSocket.SendAsync(new ArraySegment<byte>(response), result.MessageType, result.EndOfMessage, CancellationToken.None);

            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
    }
}