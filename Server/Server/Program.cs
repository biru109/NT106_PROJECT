using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace UNOServer
{

    class Program
    {
        private static Socket SKSV;
        private static Socket SKCL;
        private static Thread Thread1;
        private static List<USER> USERLIST = new List<USER>();
        private static int MacDinh = 1;
        private static bool TakeTurn = true;
        private static int RUT = 0;
        private static string MAU = "";
        static Random rand = new Random();
        static bool IsWaitingDraw = false;


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress iPAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            SKSV = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(iPAddress, 11000);
            SKSV.Bind(serverEP);
            SKSV.Listen(4);
            Console.WriteLine("Server đã được tạo! Vui lòng kiểm tra tiếp bên phía Client");
            Console.WriteLine("Địa chỉ IP của Server: " + iPAddress.ToString());

            while (true)
            {
                SKCL = SKSV.Accept();

                Thread1 = new Thread(() => HandleNewUser(SKCL));
                Thread1.Start();
            }
        }

        private static void SendError(USER user, string message)
        {
            string errorMessage = "ERROR;" + message;
            byte[] data = Encoding.UTF8.GetBytes(errorMessage);
            user.UserSK.Send(data);
        }

        public static void HandleNewUser(Socket client)
        {
            USER User = new USER();
            User.UserSK = client;
            USERLIST.Add(User);

            byte[] data = new byte[1024];

            while (User.UserSK.Connected)
            {
                if (User.UserSK.Available > 0)
                {
                    string receivedata = "";

                    while (User.UserSK.Available > 0)
                    {
                        int bRead = User.UserSK.Receive(data);
                        receivedata += Encoding.UTF8.GetString(data, 0, bRead);
                    }

                    Console.WriteLine(User.UserSK.RemoteEndPoint + ": " + receivedata);
                    ENCRYTINGREADER(receivedata, User);
                }
            }
        }


        //Khởi tạo lượt cho người chơi
        public static void SettingUpTurn()
        {
            int[] turns = new int[USERLIST.Count];

            for (int i = 1; i <= USERLIST.Count; i++)
            {
                turns[i - 1] = i;
            }

            Random rd = new Random();
            foreach (var user in USERLIST)
            {
                int pick = rd.Next(turns.Length);
                user.Luot = turns[pick];
                turns = turns.Where(val => val != turns[pick]).ToArray();


                user.SoLuongBai = 7;
            }
        }

        public static void XaoBai()
        {
            Random rd = new Random();
            XAPBAI.CardName = XAPBAI.CardName.OrderBy(x => rd.Next()).ToArray();
        }

        public static string CreateUserCard()
        {
            Random rd = new Random();
            string usercard = "";
            for (int i = 0; i < 7; i++)
            {
                int pick = rd.Next(XAPBAI.CardName.Length);
                usercard += XAPBAI.CardName[pick] + ";";
                XAPBAI.CardName = XAPBAI.CardName.Where(val => val != XAPBAI.CardName[pick]).ToArray();
            }
            return usercard;
        }

        public static string ShowPileCard()
        {
            string temp = "";
            while (true)
            {
                temp = XAPBAI.CardName[0];

                // kiểm tra nếu KHÔNG phải lá đặc biệt thì break
                if (!IsSpecialCard(temp))
                    break;

                // nếu là bài đặc biệt thì bỏ lá đó ra, lấy lá khác
                XAPBAI.CardName = XAPBAI.CardName.Where(val => val != XAPBAI.CardName[0]).ToArray();
            }

            XAPBAI.CardName = XAPBAI.CardName.Where(val => val != temp).ToArray();
            MoBai.mobai.Add(temp);
            return temp;
        }
        public static bool IsSpecialCard(string card)
        {
            return card.StartsWith("wd") || card.StartsWith("df") ||
                   card.Contains("Rv") || card.Contains("s_") || card.Contains("dt");
        }



        public static bool ISOVER()
        {
            if (XAPBAI.CardName.Length == 0)
                return true;
            return false;
        }

        public static void BroadcastBack(string type, string receivedata)
        {
            foreach (var user in USERLIST)
            {
                byte[] data = Encoding.UTF8.GetBytes(type + receivedata);
                user.UserSK.Send(data);
            }
        }


        private static void HandleConnect(string[] Signal, USER User)
        {
            User.ID = Signal[1];
            foreach (var user in USERLIST)
            {
                byte[] data = Encoding.UTF8.GetBytes("Case1;" + user.ID);
                User.UserSK.Send(data);
                Thread.Sleep(210);
            }
            foreach (var user in USERLIST)
            {
                if (user.UserSK != User.UserSK)
                {
                    byte[] data = Encoding.UTF8.GetBytes("Case1;" + User.ID);
                    user.UserSK.Send(data);
                    Thread.Sleep(210);
                }
            }
        }

        private static void HandleDisconnect(string[] Signal)
        {
            foreach (var user in USERLIST.ToList())
            {
                if (user.ID == Signal[1])
                {
                    user.UserSK.Shutdown(SocketShutdown.Both);
                    user.UserSK.Close();
                    USERLIST.Remove(user);
                }
            }
        }

        private static void HandleStart(string[] Signal, USER User)
        {
            SettingUpTurn();
            USERLIST.Sort((x, y) => x.Luot.CompareTo(y.Luot));
            XaoBai();
            XAPBAI.currentCard = ShowPileCard();
            foreach (var user in USERLIST)
            {

                string SendData = "Case2;" + user.ID + ";" + user.Luot + ";" + user.SoLuongBai + ";" + CreateUserCard() + XAPBAI.currentCard;
                byte[] data = Encoding.UTF8.GetBytes(SendData);
                user.UserSK.Send(data);

                Thread.Sleep(100);
            }


            foreach (var user in USERLIST)
            {
                foreach (var player_ in USERLIST)
                {
                    if (user.ID != player_.ID)
                    {
                        string SendData = "Case3;" + player_.ID + ";" + player_.Luot + ";" + player_.SoLuongBai;
                        byte[] data = Encoding.UTF8.GetBytes(SendData);
                        user.UserSK.Send(data);

                        Thread.Sleep(100);
                    }
                }
            }

            foreach (var user in USERLIST)
            {
                string SendData = "Case4;" + user.ID;
                byte[] data = Encoding.UTF8.GetBytes(SendData);
                user.UserSK.Send(data);

                Thread.Sleep(100);
            }

            foreach (var user in USERLIST)
            {
                string SendData_ = "Case6;" + USERLIST[MacDinh - 1].ID;
                byte[] buffer_ = Encoding.UTF8.GetBytes(SendData_);
                user.UserSK.Send(buffer_);

                Thread.Sleep(100);
            }
        }

        private static void HandleDanhBai(string[] Signal, USER User)
        {
            string userId = Signal[1];
            string playedCard = Signal[3];

            var currentUser = USERLIST.FirstOrDefault(u => u.ID == userId);
            if (currentUser == null) return;

            int remainingCards = currentUser.SoLuongBai;

            // Nếu cố đánh bài khi đã hết
            if (remainingCards == 0 && !string.IsNullOrEmpty(playedCard))
            {
                SendError(User, "Bạn đã hết bài, không thể đánh tiếp!");
                return;
            }

            // Nếu không đúng lượt hoặc đang chờ người khác rút
            if (USERLIST[MacDinh - 1].ID != userId)
            {
                SendError(User, "Bạn không có lượt!");
                return;
            }

            if (IsWaitingDraw)
            {
                SendError(User, "Bạn cần chờ người chơi khác rút bài trước!");
                return;
            }

            // Cập nhật bài
            XAPBAI.currentCard = playedCard;
            MoBai.mobai.Add(playedCard);

            // TẠM thời không giảm số lượng ở đây


            remainingCards = currentUser.SoLuongBai;

            // Nếu hết bài thì kết thúc
            if (remainingCards == 0)
            {
                foreach (var user in USERLIST)
                {
                    string SendData = $"Case9;{userId};{remainingCards};{playedCard}";
                    user.UserSK.Send(Encoding.UTF8.GetBytes(SendData));
                    Thread.Sleep(100);
                }
                return;
            }
            int newCount = currentUser.SoLuongBai - 1;

            // Gửi Case5 cho tất cả
            foreach (var user in USERLIST)
            {
                string SendData = $"Case5;{userId};{newCount};{playedCard}";
                if ((playedCard.Contains("df") || playedCard.Contains("wd")) && Signal.Length > 4)
                {
                    MAU = Signal[4];
                    SendData += $";{MAU}";
                }
                user.UserSK.Send(Encoding.UTF8.GetBytes(SendData));
                Thread.Sleep(100);
            }


            // Sau khi đã gửi Case5 cho tất cả
            if (currentUser.SoLuongBai > 0)
                currentUser.SoLuongBai--;

            remainingCards = currentUser.SoLuongBai;

            // Nếu hết bài thì kết thúc
            if (remainingCards == 0)
            {
                foreach (var user in USERLIST)
                {
                    string SendData = $"Case9;{userId};{remainingCards};{playedCard}";
                    user.UserSK.Send(Encoding.UTF8.GetBytes(SendData));
                    Thread.Sleep(100);
                }
                return;
            }


            // Bài đặc biệt
            bool isDraw2 = playedCard.Contains("dt");
            bool isDraw4 = playedCard.Contains("df");
            bool isReverse = playedCard.Contains("Rv");
            bool isSkip = playedCard.Contains("s_") || (isReverse && USERLIST.Count == 2);

            if (isDraw2) RUT += 2;
            if (isDraw4) RUT += 4;
            if (isReverse && USERLIST.Count > 2)
                TakeTurn = !TakeTurn;

            if (isDraw2 || isDraw4)
            {
                IsWaitingDraw = true;

                int skipstep = (isSkip ? 2 : 1);
                if (USERLIST.Count == 2 && isReverse) skipstep = 1;

                MacDinh = TakeTurn ? MacDinh + skipstep : MacDinh - skipstep;
                if (MacDinh > USERLIST.Count) MacDinh -= USERLIST.Count;
                if (MacDinh < 1) MacDinh += USERLIST.Count;

                string waitType = isDraw4 ? "df" : "dt";

                foreach (var user in USERLIST)
                {
                    string msg = $"Case6;{USERLIST[MacDinh - 1].ID};WAIT_DRAW;{waitType}";
                    user.UserSK.Send(Encoding.UTF8.GetBytes(msg));
                    Thread.Sleep(100);
                }

                return;
            }

            // Cập nhật lượt mới
            int step = (isSkip ? 2 : 1);
            if (USERLIST.Count == 2 && isReverse) step = 1;

            MacDinh = TakeTurn ? MacDinh + step : MacDinh - step;
            if (MacDinh > USERLIST.Count) MacDinh -= USERLIST.Count;
            if (MacDinh < 1) MacDinh += USERLIST.Count;

            if (!playedCard.Contains("df") && !playedCard.Contains("wd")) MAU = "";

            foreach (var user in USERLIST)
            {
                string msg = "Case6;" + USERLIST[MacDinh - 1].ID;
                user.UserSK.Send(Encoding.UTF8.GetBytes(msg));
                Thread.Sleep(100);
            }
        }




        private static void AddNewCard(string[] Signal, USER User)
        {
            string userId = Signal[1];
            var currentUser = USERLIST.FirstOrDefault(u => u.ID == userId);
            if (currentUser == null) return;

            // Không đúng lượt
            if (USERLIST[MacDinh - 1].ID != userId)
            {
                SendError(User, "Bạn không có lượt!");
                return;
            }

            // Rút 1 lá
            List<string> drawnCards = new List<string>();
            int rutSo = 1;

            for (int i = 0; i < rutSo; i++)
            {
                if (XAPBAI.CardName.Length == 0) break;

                string card = XAPBAI.CardName[0];
                drawnCards.Add(card);
                XAPBAI.CardName = XAPBAI.CardName.Where(val => val != card).ToArray();
            }

            currentUser.SoLuongBai += drawnCards.Count;

            // Gửi Case7 cho người rút
            string case7 = $"Case7;{userId};{string.Join(";", drawnCards)}";
            currentUser.UserSK.Send(Encoding.UTF8.GetBytes(case7));

            // Gửi Case5 cho những người khác
            foreach (var user in USERLIST)
            {
                if (user.ID != userId)
                {
                    string msg = $"Case5;{userId};{currentUser.SoLuongBai};{XAPBAI.currentCard}";
                    user.UserSK.Send(Encoding.UTF8.GetBytes(msg));
                    Thread.Sleep(50);
                }
            }

            // Cập nhật lượt
            UpdateTurnAndNotifyUsers();
        }


        private static void HandleSpecialCard(string[] Signal, USER User)
        {
            if (USERLIST[MacDinh - 1].ID != Signal[1])
            {
                string SendData = "ERROR;Bạn không có lượt!";
                byte[] data = Encoding.UTF8.GetBytes(SendData);
                User.UserSK.Send(data);
                return;
            }

            USERLIST[MacDinh - 1].SoLuongBai += RUT;

            List<string> rutCards = new List<string>();
            List<string> deck = XAPBAI.CardName.ToList();

            int rutCount = Math.Min(RUT, deck.Count);
            for (int i = 0; i < rutCount; i++)
            {
                int pick = rand.Next(deck.Count);
                rutCards.Add(deck[pick]);
                deck.RemoveAt(pick);
            }

            XAPBAI.CardName = deck.ToArray();

            string cardstack = $"Case8;{USERLIST[MacDinh - 1].ID};{USERLIST[MacDinh - 1].SoLuongBai}";
            cardstack += rutCards.Count > 0 ? ";" + string.Join(";", rutCards) : ";";
            if (!string.IsNullOrEmpty(MAU)) cardstack += ";" + MAU;

            byte[] buff = Encoding.UTF8.GetBytes(cardstack);
            USERLIST[MacDinh - 1].UserSK.Send(buff);
            Console.WriteLine("Sendback: " + cardstack);

            foreach (var user in USERLIST)
            {
                if (user.Luot != MacDinh)
                {
                    string SendData = $"Case5;{Signal[1]};{USERLIST[MacDinh - 1].SoLuongBai}";
                    if (Signal[2] == "wd") SendData += ";" + MAU;
                    byte[] data = Encoding.UTF8.GetBytes(SendData);
                    user.UserSK.Send(data);
                    Thread.Sleep(100);
                }
            }

            // Chỉ reset trạng thái, KHÔNG tự đổi lượt
            RUT = 0;
            //MAU = "";
            IsWaitingDraw = false;

            // Gọi UpdateTurnAndNotifyUsers() để chuyển lượt và gửi Case6
            UpdateTurnAndNotifyUsers();
        }




        private static void UpdateTurnAndNotifyUsers()
        {
            if (TakeTurn == true)
            {
                MacDinh++;
            }
            else
            {
                MacDinh--;
            }

            if (MacDinh > USERLIST.Count)
                MacDinh = 1;

            if (MacDinh < 1)
                MacDinh = USERLIST.Count;

            foreach (var user in USERLIST)
            {
                string SendData_ = "Case6;" + USERLIST[MacDinh - 1].ID;
                byte[] buffer_ = Encoding.UTF8.GetBytes(SendData_);
                user.UserSK.Send(buffer_);

                Thread.Sleep(100);
            }
        }


        public static void ENCRYTINGREADER(string receivedata, USER User)
        {
            string[] Signal = receivedata.Split(';');

            switch (Signal[0])
            {
                case "CONNECT":
                    HandleConnect(Signal, User);
                    break;
                case "DISCONNECT":
                    HandleDisconnect(Signal);
                    break;
                case "START":
                    HandleStart(Signal, User);
                    break;
                case "DanhBai":
                    HandleDanhBai(Signal, User);
                    break;
                case "AddNewCard":
                    AddNewCard(Signal, User);
                    break;
                case "SpecialCardDT":
                    HandleSpecialCard(Signal, User);
                    break;
                default:
                    break;
            }
        }
    }


    //class phụ

    class XAPBAI
    {
        public static string currentCard = "";
        public static string[] CardName =
            {
                "r0", "r1", "r2", "r3", "r4", "r5", "r1_", "r2_", "r3_", "r4_", "r5_",
                "b0", "b1", "b2", "b3", "b4", "b5", "b1_", "b2_", "b3_", "b4_", "b5_",
                "y0", "y1", "y2", "y3", "y4", "y5", "y1_", "y2_", "y3_", "y4_", "y5_",
                "g0", "g1", "g2", "g3", "g4", "g5", "g1_", "g2_", "g3_", "g4_", "y5_",
                "Rv_r", "Rv_r_X", "Rv_b", "Rv_b_X", "Rv_y", "Rv_y_X", "Rv_g", "Rv_g_X",
                "s_r", "s_r_X", "s_b", "s_b_X", "s_y", "s_y_X", "s_g", "s_g_X",
                "wd", "wd_X", "wd_Y", "wd_Z",
                "df", "df_X", "df_Y", "df_Z",
                "dt_r", "dt_r_X", "dt_b", "dt_b_X", "dt_y", "dt_y_X", "dt_g", "dt_g_X"
            };
    }

    // class để lưu trữ các quân bài mở ra
    class MoBai
    {
        public static List<string> mobai = new List<string>();
    }
    //class để lưu trữ thông tin người chơi
    class USER
    {
        public string ID { get; set; }
        public int SoLuongBai { get; set; }
        public int Luot { get; set; }
        public bool RoomOwner { get; set; }
        public Socket UserSK { get; set; }
    }
}
