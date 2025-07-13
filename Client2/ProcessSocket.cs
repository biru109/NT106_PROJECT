using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.ComponentModel.Design;
using UNOClient;
using static CLIENT.GameBoard;

namespace CLIENT
{
    static class Program
    {
     
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConnectMenu());
        }
    }
    class UserInfo
    {
        public static string ID { get; set; }
        public static int LUOT { get; set; }
        public static int SOLUONGBAI { get; set; }
        public static List<string> BAI = new List<string>();
    }

    class USER2
    {
        public string ID { get; set; }
        public string LUOT { get; set; }
        public string SOLUONGBAI { get; set; }
    }
    class ProcessSocket
    {
        public static Socket SKCL;
        public static Thread Thread;
        public static string Data = "";



        public static void LINK(IPEndPoint serverEP)
        {
            SKCL = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SKCL.Connect(serverEP);
            Thread = new Thread(() => ANALYZE());
            Thread.Start();
        }
        public static GameBoard room;
        public static List<USER2> otheruser;

        private static string EffectiveColor()
        {
            if (!string.IsNullOrEmpty(room.overrideColor))
                return room.overrideColor;

            return GetColor(room.currentCard);
        }




        private static void HandleCase2(string[] payload)
        {
            UserInfo.LUOT = int.Parse(payload[2]);
            UserInfo.SOLUONGBAI = int.Parse(payload[3]);

            for (int i = 4; i <= 10; i++)
            {
                UserInfo.BAI.Add(payload[i]);
            }

            room = new GameBoard();

            otheruser = new List<USER2>();

            ConnectMenu.WaitingRoom.Invoke((MethodInvoker)delegate ()
            {
                room.currentCard = payload[11];
                room.SettingUpCard();
                room.ShowCurrentCard();
                room.Show();
            });
        }

        private static void HandleCase3(string[] payload)
        {
            USER2 otherPlayer = new USER2
            {
                ID = payload[1],
                LUOT = payload[2],
                SOLUONGBAI = payload[3]
            };

            otheruser.Add(otherPlayer);
        }

        private static void HandleUpdateMessage(string[] payload)
        {
            room.CARDSYNC(payload[1], payload[2]);  
            if (payload[1] == UserInfo.ID)
            {
                UserInfo.SOLUONGBAI = int.Parse(payload[2]);
            }

            if (payload.Length > 3)
            {
                room.currentCard = payload[3];

                if (payload.Length > 4)
                {
                    room.overrideColor = payload[4]; 
                }
                else
                {
                    string cardColor = GetColor(room.currentCard);
                    if (!room.currentCard.Contains("wd") && !room.currentCard.Contains("df"))
                    {
                        room.overrideColor = "";
                    }
                }

                room.ShowCurrentCard();  
            }
        }




        private static void HandleTurnMessage(string[] payload)
        {
            bool myTurn = payload[1] == UserInfo.ID;

            // --- NHẬN THÔNG BÁO ÉP RÚT ---
            if (myTurn &&
                payload.Length >= 4 &&
                payload[2] == "WAIT_DRAW")
            {
                room.IsForcedDraw = true;
                room.ForcedDrawType = payload[3];   
                                                    
                room.btnBocBai.Enabled = true;
                room.btnDanhBai.Enabled = false;
                room.NotTurn();
                room.ISTURN(payload[1]);
                return;
            }

            if (myTurn) CK();
            room.NotTurn();
            room.ISTURN(payload[1]);
        }




        private static void HandleEndMessage(string[] payload)
        {
            string playerId = payload[1];

            if (ProcessSocket.room == null) return;

            ProcessSocket.room.Invoke(new MethodInvoker(() =>
            {
                // Ẩn bàn chơi khi kết thúc
                ProcessSocket.room.Hide();

                if (UserInfo.ID == playerId) //thắng
                {
                    var win = new EndForm(playerId);
                    win.Show();
                }
                else //thua
                {
                    var lose = new Loser(playerId);
                    lose.Show();
                }
            }));
        }







        public static void SENDER(string data)
        {
            string SendDatastr = Data + ";" + data;
            byte[] SendData = Encoding.UTF8.GetBytes(SendDatastr);
            SKCL.Send(SendData);
        }

        public static void ANALYZE()
        {
            byte[] RData = new byte[1024];

            while (SKCL.Connected)
            {
                if (SKCL.Available > 0)
                {
                    string SendData = "";

                    while (SKCL.Available > 0)
                    {
                        int bRead = SKCL.Receive(RData);
                        SendData += Encoding.UTF8.GetString(RData, 0, bRead);
                    }

                    Process(SendData);
                   
                }
            }
        }

        private static string GetCardNumber(string cardId)
        {
            return new string(cardId.Where(char.IsDigit).ToArray());
        }

        private static bool IsSpecialMatch(string currentCard, string cardId)
        {
            string[] specialTypes = { "s", "Rv", "dt" };

            foreach (var type in specialTypes)
            {
                if (currentCard.Contains(type) && cardId.Contains(type))
                {
                    string color1 = GetColor(currentCard);
                    string color2 = GetColor(cardId);
                    return color1 == color2;
                }
            }

            return false;
        }

        private static void Enable(CardButton bt)
        {
            bt.btn.FlatAppearance.BorderColor = Color.Chartreuse;
            bt.btn.Enabled = true;
        }

        private static void Disable(CardButton bt)
        {
            bt.btn.FlatAppearance.BorderColor = Color.Red;
            bt.btn.Enabled = false;
        }

        public static void CK()
        {
            room.CANDRAW(); 
            room.CANPLAY(); 

            string currentCard = room.currentCard;
            string effectiveColor = EffectiveColor();  

            string currentNumber = GetCardNumber(currentCard);

            foreach (var row in room.Card)
            {
                foreach (var bt in row)
                {
                    string cardId = bt.id;
                    string cardColor = GetColor(cardId);
                    string cardNumber = GetCardNumber(cardId);

                    if (!string.IsNullOrEmpty(currentNumber) && cardNumber == currentNumber)
                    {
                        Enable(bt);
                        continue;
                    }

                    if (cardColor == effectiveColor && !string.IsNullOrEmpty(cardColor))
                    {
                        Enable(bt);
                        continue;
                    }

                    if (IsSpecialMatch(currentCard, cardId))
                    {
                        Enable(bt);
                        continue;
                    }

                    if (cardId.Contains("df"))
                    {
                        Enable(bt);
                        continue;
                    }

                    if (cardId.Contains("wd") && !currentCard.Contains("df") && !currentCard.Contains("dt"))
                    {
                        Enable(bt);
                        continue;
                    }

                    Disable(bt);
                }
            }
        }

        private static string GetColor(string cardId)
        {
            if (cardId.Contains("r")) return "r";
            if (cardId.Contains("g")) return "g";
            if (cardId.Contains("b")) return "b";
            if (cardId.Contains("y")) return "y";
            return "";
        }


        private static void GAMEROOM_FormClosed(object sender, EventArgs e)
        {
            ConnectMenu.WaitingRoom.Show();
        }
        
        public static void Process(string sendData)
        {
            string[] arrPayload = sendData.Split(';');
            string messageType = arrPayload[0];

            switch (messageType)
            {
                case "Case1":
                    ConnectMenu.WaitingRoom.ShowCurrentUser(arrPayload[1]);
                    break;
                case "Case2":
                    HandleCase2(arrPayload);
                    break;
                case "Case3":
                    HandleCase3(arrPayload);
                    break;
                case "Case4":
                    room.SHOW();
                    break;
                    case "Case5":
                        HandleUpdateMessage(arrPayload);
                        break;
                case "Case6":
                    HandleTurnMessage(arrPayload);
                    break;
                case "Case7":
                    room.Invoke((MethodInvoker)delegate ()
                    {
                        for (int i = 2; i < arrPayload.Length; i++)
                        {
                            room.ProcessBocBai(arrPayload[i]);
                        }
                    });
                    break;

                case "Case8":
                    {
                        string victimId = arrPayload[1];          
                        int newCount = int.Parse(arrPayload[2]); 

                        List<string> newCards = new List<string>();

                        string last = arrPayload.Last();
                        bool colorSent = last.Length == 1 && "rgby".Contains(last); 

                        int lastCardIdx = colorSent ? arrPayload.Length - 2
                                                     : arrPayload.Length - 1;

                        for (int i = 3; i <= lastCardIdx; i++)
                            if (!string.IsNullOrWhiteSpace(arrPayload[i]))
                                newCards.Add(arrPayload[i]);

                        if (victimId == UserInfo.ID)
                        {
                            UserInfo.SOLUONGBAI = newCount;
                            UserInfo.BAI.AddRange(newCards);
                        }

                        room.Invoke((MethodInvoker)(() =>
                        {
                            if (victimId == UserInfo.ID)
                                foreach (var c in newCards)
                                    room.ProcessBocBai(c);

                            if (colorSent)
                            {
                                room.currentCard = last;           
                                room.overrideColor = last; //đè mau2u 
                            }
                            else
                            {
                                if (!room.currentCard.Contains("wd") && !room.currentCard.Contains("df"))
                                    room.overrideColor = "";
                            }

                            room.ShowCurrentCard();

                            room.CARDSYNC(victimId, newCount.ToString());

                            if (victimId != UserInfo.ID)
                                room.CARDSYNC(UserInfo.ID, UserInfo.SOLUONGBAI.ToString());

                            room.IsForcedDraw = false;
                            room.ForcedDrawType = "";
                            room.EnableActionButtons();
                        }));

                        break;
                    }


                case "Case9":
                    HandleEndMessage(arrPayload);
                    break;
                default:
                    break;
            }
        }
    }

}
