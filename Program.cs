using System.Net.Sockets;
using System.Text;

namespace ConsoleApp19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 8080);
                Console.WriteLine("Підключено до сервера...");

                string message = "Привіт, сервер!";
                byte[] data = Encoding.UTF8.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Повідомлення відправлено на сервер: " + message);

                byte[] buffer = new byte[256];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Відповідь від сервера: " + response);

                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
            }
        }
    }
}
