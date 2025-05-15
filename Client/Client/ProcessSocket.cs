using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ProcessSocket
    {
        private TcpListener listener;
        private List<TcpClient> clients;
        private List<string> playerNames;

        public event Action<List<string>> OnPlayerListUpdated;

        public ProcessSocket()
        {
            clients = new List<TcpClient>();
            playerNames = new List<string>();
        }

        // Tạo phòng (Server)
        public async Task StartServerAsync(string ip, int port)
        {
            listener = new TcpListener(IPAddress.Parse(ip), port);
            listener.Start();
            await AcceptClientsAsync();
        }

        // Kết nối đến phòng (Client)
        public async Task StartClientAsync(string ip, int port, string playerName)
        {
            var client = new TcpClient();
            await client.ConnectAsync(IPAddress.Parse(ip), port);
            clients.Add(client);
            var stream = client.GetStream();

            // Gửi tên người chơi đến server
            byte[] nameBytes = Encoding.UTF8.GetBytes(playerName);
            await stream.WriteAsync(nameBytes, 0, nameBytes.Length);

            // Bắt đầu lắng nghe server
            _ = ListenForMessagesAsync(client);
        }

        private async Task AcceptClientsAsync()
        {
            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                clients.Add(client);
                var stream = client.GetStream();

                _ = HandleClientAsync(client, stream);
            }
        }

        private async Task HandleClientAsync(TcpClient client, NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
            string playerName = Encoding.UTF8.GetString(buffer, 0, byteCount);
            playerNames.Add(playerName);

            // Cập nhật danh sách người chơi cho tất cả các client
            OnPlayerListUpdated?.Invoke(playerNames);
        }

        private async Task ListenForMessagesAsync(TcpClient client)
        {
            var stream = client.GetStream();
            byte[] buffer = new byte[1024];

            while (true)
            {
                int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (byteCount == 0) break;

                // Xử lý thông điệp nhận từ server (nếu cần)
            }
        }
    }
}