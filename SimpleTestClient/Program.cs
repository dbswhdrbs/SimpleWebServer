using SimpleContents.SWAddress;
using SimpleTestClient.Extensions;
using System;

namespace SimpleTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // 유저가 있는지 검사한다.
            SendPacketEx.SendPacket<Int64>(SWAddress.RequestExistUser, 1L);
        }
    }
}
