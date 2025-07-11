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
            if (int.Parse(Signal[2]) == 0)
            {
                foreach (var user in USERLIST)
                {
                    string SendData = "Case9;" + Signal[1] + ";" + Signal[2] + ";" + Signal[3];
                    byte[] data = Encoding.UTF8.GetBytes(SendData);
                    user.UserSK.Send(data);

                    Thread.Sleep(100);
                }
            }
            else
            {
                XAPBAI.currentCard = Signal[3];
                MoBai.mobai.Add(Signal[3]);
                USERLIST[MacDinh - 1].SoLuongBai = int.Parse(Signal[2]);

                if (USERLIST[MacDinh - 1].SoLuongBai == 0)
                {
                    foreach (var user in USERLIST)
                    {
                        string SendData = "Case9;" + Signal[1] + ";" + Signal[2] + ";" + Signal[3];
                        byte[] data = Encoding.UTF8.GetBytes(SendData);
                        user.UserSK.Send(data);

                        Thread.Sleep(100);
                    }
                }
                else
                {
                    foreach (var user in USERLIST)
                    {
                        if (user.Luot != MacDinh)
                        {
                            string SendData = "Case5;" + Signal[1] + ";" + Signal[2] + ";" + Signal[3];
                            if (Signal[3].Contains("df"))
                            {
                                SendData += ";" + Signal[4];
                            }
                            byte[] data = Encoding.UTF8.GetBytes(SendData);
                            user.UserSK.Send(data);

                            Thread.Sleep(100);
                        }
                    }

                    if (Signal[3].Contains("dt"))
                        RUT += 2;
                    if (Signal[3].Contains("df"))
                    {
                        MAU = Signal[4];
                        RUT += 4;
                    }

                    bool isReverse = Signal[3].Contains("Rv");
                    bool isSkip = Signal[3].Contains("s") || (isReverse && USERLIST.Count == 2);
                    // 2 người: Reverse = Skip

                    // Đổi chiều khi có Reverse (chỉ áp dụng khi ≥3 người)
                    if (isReverse && USERLIST.Count > 2)
                    {
                        TakeTurn = !TakeTurn;
                    }

                    // Tính MacDinh (chỉ số người chơi kế tiếp)
                    if (TakeTurn)          // Đang đi thuận chiều
                    {
                        MacDinh += isSkip ? 2 : 1;
                    }
                    else                    // Đang đi ngược chiều
                    {
                        MacDinh -= isSkip ? 2 : 1;
                    }

                    // Vòng lại đầu/cuối danh sách
                    if (MacDinh > USERLIST.Count) MacDinh -= USERLIST.Count;
                    if (MacDinh < 1) MacDinh += USERLIST.Count;


                    foreach (var user in USERLIST)
                    {
                        string SendData_ = "Case6;" + USERLIST[MacDinh - 1].ID;
                        byte[] buffer_ = Encoding.UTF8.GetBytes(SendData_);
                        user.UserSK.Send(buffer_);

                        Thread.Sleep(100);
                    }
                }
            }

        }

        private static void AddNewCard(string[] Signal, USER User)
        {
            USERLIST[MacDinh - 1].SoLuongBai = int.Parse(Signal[2]);

            List<string> drawnCards = new List<string>();

            // rút 1 lá thường
            int rutSo = 1;
            for (int i = 0; i < rutSo; i++)
            {
                string card = XAPBAI.CardName[0];
                drawnCards.Add(card);
                XAPBAI.CardName = XAPBAI.CardName.Where(val => val != card).ToArray();
            }

            string mkmsg = "Case7;" + Signal[1] + ";" + string.Join(";", drawnCards);
            byte[] bf = Encoding.UTF8.GetBytes(mkmsg);
            USERLIST[MacDinh - 1].UserSK.Send(bf);

            // cập nhật cho những người khác
            foreach (var user in USERLIST)
            {
                if (user.Luot != MacDinh)
                {
                    string SendData = "Case5;" + Signal[1] + ";" + Signal[2];
                    byte[] data = Encoding.UTF8.GetBytes(SendData);
                    user.UserSK.Send(data);
                    Thread.Sleep(100);
                }
            }

            // cập nhật lượt chơi
            if (TakeTurn)
                MacDinh++;
            else
                MacDinh--;

            if (MacDinh > USERLIST.Count) MacDinh = 1;
            if (MacDinh < 1) MacDinh = USERLIST.Count;

            foreach (var user in USERLIST)
            {
                string SendData_ = "Case6;" + USERLIST[MacDinh - 1].ID;
                byte[] buffer_ = Encoding.UTF8.GetBytes(SendData_);
                user.UserSK.Send(buffer_);
                Thread.Sleep(100);
            }
        }


        private static void HandleSpecialCard(string[] Signal, USER User)
        {
            USERLIST[MacDinh - 1].SoLuongBai += RUT;

            List<string> rutCards = new List<string>();
            List<string> deck = XAPBAI.CardName.ToList();

            int rutCount = Math.Min(RUT, deck.Count);
            for (int i = 0; i < rutCount; i++)
            {
                int pick = rand.Next(deck.Count);
                string pickedCard = deck[pick];
                rutCards.Add(pickedCard);
                deck.RemoveAt(pick); // xóa đúng 1 lá
            }

            XAPBAI.CardName = deck.ToArray();

            string cardstack = "Case8;" + USERLIST[MacDinh - 1].ID + ";" + USERLIST[MacDinh - 1].SoLuongBai + ";" + string.Join(";", rutCards);
            if (Signal[2] == "wd")
                cardstack += ";" + MAU;

            byte[] buff = Encoding.UTF8.GetBytes(cardstack);
            USERLIST[MacDinh - 1].UserSK.Send(buff);
            Console.WriteLine("Sendback: " + cardstack);

            foreach (var user in USERLIST)
            {
                if (user.Luot != MacDinh)
                {
                    string SendData = "Case5;" + Signal[1] + ";" + USERLIST[MacDinh - 1].SoLuongBai;
                    if (Signal[2] == "wd")
                        SendData += ";" + MAU;

                    byte[] data = Encoding.UTF8.GetBytes(SendData);
                    user.UserSK.Send(data);
                    Thread.Sleep(100);
                }
            }

            RUT = 0;
            MAU = "";
            XAPBAI.currentCard = "";

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
