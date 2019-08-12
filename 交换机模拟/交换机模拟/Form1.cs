using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 交换机模拟
{
    public partial class Form1 : Form
    {

        public static Form1 form1;
        private Switcher s1 = null;
        Switcher s2 = null;
        Client c1 = null;
        Client c2 = null;
        Client c3 = null;
        Client c4 = null;
        Client c5 = null;
        Client c6 = null;
        bool isFirstLoad = true;
        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindView();
            s1 = new Switcher("s1", 8989);
            s2 = new Switcher("s2", 8990);
            c1 = new Client("c1", mac1.Text.Trim());
            c2 = new Client("c2", mac2.Text.Trim());
            c3 = new Client("c3", mac3.Text.Trim());
            c4 = new Client("c4", mac4.Text.Trim());
            c5 = new Client("c5", mac5.Text.Trim());
            c6 = new Client("c6", mac6.Text.Trim());
            c1.Connect(s1);
            c2.Connect(s1);
            c3.Connect(s1);
            c4.Connect(s2);
            c5.Connect(s2);
            c6.Connect(s2);
            s1.connectSwitcher(s2);
            if (!System.IO.Directory.Exists(@"D:\Switcher"))
            {
                System.IO.Directory.CreateDirectory(@"D:\Switcher");//不存在就创建目录
            }
            isFirstLoad = false;
        }

        protected void BindView()
        {
            from.Items.Add("c1");
            from.Items.Add("c2");
            from.Items.Add("c3");
            from.Items.Add("c4");
            from.Items.Add("c5");
            from.Items.Add("c6");
            from.SelectedIndex = 0;
            to.Items.Add("c1");
            to.Items.Add("c2");
            to.Items.Add("c3");
            to.Items.Add("c4");
            to.Items.Add("c5");
            to.Items.Add("c6");
            to.SelectedIndex = 0;
            mac1.Text = "00-10-B5-4B-30-15";
            mac2.Text = "00-10-B5-4B-30-25";
            mac3.Text = "00-10-B5-4B-30-35";
            mac4.Text = "00-10-B5-4B-30-45";
            mac5.Text = "00-10-B5-4B-30-55";
            mac6.Text = "00-10-B5-4B-30-65";
        }

        private void send_Click(object sender, EventArgs e)
        {
            infos1.Clear();
            infos2.Clear();
            string f_mac = null;
            string t_mac = null;
            string content = text.Text.Trim();
            Client temp = null;
            switch (from.SelectedIndex)
            {
                case 0:
                    temp = c1;
                    f_mac = mac1.Text.Trim();
                    break;
                case 1:
                    temp = c2;
                    f_mac = mac2.Text.Trim();
                    break;
                case 2:
                    temp = c3;
                    f_mac = mac3.Text.Trim();
                    break;
                case 3:
                    temp = c4;
                    f_mac = mac4.Text.Trim();
                    break;
                case 4:
                    temp = c5;
                    f_mac = mac5.Text.Trim();
                    break;
                case 5:
                    temp = c6;
                    f_mac = mac6.Text.Trim();
                    break;
            }

            switch (to.SelectedIndex)
            {
                case 0:
                    t_mac = mac1.Text.Trim();
                    break;
                case 1:
                    t_mac = mac2.Text.Trim();
                    break;
                case 2:
                    t_mac = mac3.Text.Trim();
                    break;
                case 3:
                    t_mac = mac4.Text.Trim();
                    break;
                case 4:
                    t_mac = mac5.Text.Trim();
                    break;
                case 5:
                    t_mac = mac6.Text.Trim();
                    break;
            }
            temp.send("11@"+f_mac +"@"+ t_mac+"@"+content);
        }

        private void infos1_TextChanged(object sender, EventArgs e)
        {

        }

        private void mac1_TextChanged(object sender, EventArgs e)
        {
            //if (!isFirstLoad) {
            //   c1.Mac = mac1.Text.Trim();
            //
            //}
        }

        private void mac2_TextChanged(object sender, EventArgs e)
        {
            //if (!isFirstLoad) {
            //    c2.Mac = mac2.Text.Trim();
            //}
        }

        private void mac3_TextChanged(object sender, EventArgs e)
        {
            //if (!isFirstLoad) {
            //    c3.Mac = mac3.Text.Trim();
            //
            //}
        }

        private void mac4_TextChanged(object sender, EventArgs e)
        {
            //if (!isFirstLoad)
            //{
            //    c4.Mac = mac4.Text.Trim();
            //
            //}
        }

        private void mac5_TextChanged(object sender, EventArgs e)
        {
            //if (!isFirstLoad)
            //{
            //    c5.Mac = mac5.Text.Trim();
            //
            //}
        }

        private void mac6_TextChanged(object sender, EventArgs e)
        {
            //if (!isFirstLoad)
            //{
            //    c6.Mac = mac6.Text.Trim();
            //}
        }

        private void clears1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"D:\Switcher\s1.txt", false);
                sw.Close();

            }
            catch (Exception ex)
            {
                infos1.Text += ex.Message + "\r\n";
            }
        }

        private void clears2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"D:\Switcher\s2.txt", false);
                sw.Close();

            }
            catch (Exception ex)
            {
                infos2.Text += ex.Message + "\r\n";
            }
        }
    }

    class Switcher
    {
        Socket server = null;
        Socket connector = null;
        Thread threadconnector = null;
        Dictionary<string, Socket> clientConnectionItems = new Dictionary<string, Socket> { };
        List<MacRecord> records = new List<MacRecord> { };
        string filepath=null;
        int port;
        string name;
        TextBox info = null;
        SynchronizationContext _syncContext = null;

        public Switcher(string name, int port)
        {
            _syncContext = SynchronizationContext.Current;
            this.name = name;
            this.port = port;
            if (this.name == "s1")
            {
                info = Form1.form1.infos1;
                filepath = @"D:\Switcher\s1.txt";
            }
            else
            {
                info = Form1.form1.infos2;
                filepath = @"D:\Switcher\s2.txt";
            }
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //服务端发送信息需要一个IP地址和端口号  
            IPAddress address = IPAddress.Parse("127.0.0.1");
            //将IP地址和端口号绑定到网络节点point上  
            IPEndPoint point = new IPEndPoint(address, port);
            //监听绑定的网络节点  
            server.Bind(point);

            //将套接字的监听队列长度限制为20  
            server.Listen(20);

            //负责监听客户端的线程:创建一个监听线程  
            Thread threadwatch = new Thread(watchConnecting);

            //将窗体线程设置为与后台同步，随着主线程结束而结束  
            threadwatch.IsBackground = true;

            //启动线程     
            threadwatch.Start();
            info.Text = name + "启动\r\n";
            
        }

        private void updateMessage(object text)
        {
            this.info.Text += text.ToString();
        }

        public void connectSwitcher(Switcher s)
        {
            connector = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse("127.0.0.1");
            IPEndPoint point = new IPEndPoint(address, s.Port);
            try
            {
                connector.Connect(point);
                clientConnectionItems.Add(connector.RemoteEndPoint.ToString(), connector);
            }
            catch (Exception)
            {
                Console.WriteLine("连接失败");
            }

            threadconnector = new Thread(recv);
            threadconnector.IsBackground = true;
            threadconnector.Start(connector);

        }

        public void watchConnecting()
        {
            Socket connection = null;
            _syncContext.Post(updateMessage, name+"监听中\r\n");
            //持续不断监听客户端发来的请求     
            while (true)
            {
                try
                {
                    connection = server.Accept();
                }
                catch (Exception ex)
                {
                    //提示套接字监听异常     
                    Console.WriteLine(ex.Message);
                    break;
                }

                //获取客户端的IP和端口号  
                IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;

                //让客户显示"连接成功的"的信息  
                string sendmsg = "连接服务端成功！\r\n" + "本地IP:" + clientIP + "，本地端口" + clientPort.ToString();
                byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
                connection.Send(arrSendMsg);

                //客户端网络结点号
                string remoteEndPoint = connection.RemoteEndPoint.ToString();
                //显示与客户端连接情况
                _syncContext.Post(updateMessage, name + "成功与" + remoteEndPoint + "客户端建立连接！\r\n");

                //添加客户端信息
                clientConnectionItems.Add(remoteEndPoint, connection);

                IPEndPoint netpoint = connection.RemoteEndPoint as IPEndPoint;

                //创建一个通信线程      
                ParameterizedThreadStart pts = new ParameterizedThreadStart(recv);
                Thread thread = new Thread(pts);
                //设置为后台线程，随着主线程退出而退出 
                thread.IsBackground = true;
                //启动线程     
                thread.Start(connection);
            }
        }

        public void recv(object socketclientpara)
        {
            Socket socketReciver = socketclientpara as Socket;
            while (true)
            {
                //创建一个内存缓冲区，其大小为1024*1024字节  即1M     
                byte[] arrServerRecMsg = new byte[1024 * 1024];
                //将接收到的信息存入到内存缓冲区，并返回其字节数组的长度    
                try
                {
                    int length = socketReciver.Receive(arrServerRecMsg);

                    //将机器接受到的字节数组转换为人可以读懂的字符串     
                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);

                    string[] frame = strSRecMsg.Split('@');
                    if (frame[0] == "11")
                    {
                        _syncContext.Post(updateMessage, "端口"+getPortByIp(socketReciver) + ":" + strSRecMsg + "\r\n");
                        _syncContext.Post(updateMessage, "查表中......\r\n");
                        readfile();
                        bool hasS = false;
                        bool hasD = false;
                        string dPort = null;
                        foreach(MacRecord rec in records)
                        {
                            rec.Ttl = rec.Ttl - 1;
                            //如果是源端口或者目的端口，重置为5
                            if (rec.Mac == frame[1]||rec.Mac==frame[2]) 
                            {
                                hasS = true;
                                rec.Ttl = 5;
                            }
                            
                        }
                        for(int i = 0; i < records.Count; i++)
                        {
                            if (records[i].Ttl <= 0)
                            {
                                records.RemoveAt(i);
                            }
                        }
                        //如果源Mac记录不存在，则写入Mac表中
                        if (hasS == false)
                        {
                            MacRecord newRec = new MacRecord(frame[1], getPortByIp(socketReciver), 5);
                            records.Add(newRec);
                            _syncContext.Post(updateMessage, "Mac表中不存在源Mac,添加源Mac" + frame[1] + "\r\n");
                        }

                        foreach(MacRecord rec in records)
                        {
                            if (rec.Mac == frame[2])
                            {
                                hasD = true;
                                dPort = rec.Port;
                                break;
                            }
                        }
                        if (hasD == true)
                        {
                            //mac表中有目的mac
                            _syncContext.Post(updateMessage, "Mac表中存在目的Mac,转发到端口"+dPort+"\r\n");
                            int i = 1;
                            foreach(KeyValuePair<string,Socket> item in clientConnectionItems)
                            {
                                if (i.ToString() == dPort)
                                {
                                    item.Value.Send(Encoding.UTF8.GetBytes("11@"+frame[1]+"@"+frame[2]+"@"+frame[3]));
                                }
                                i++;
                            }
                        }
                        else
                        {
                            //mac表中没有目的mac,广播
                            _syncContext.Post(updateMessage, "Mac表中没有目的Mac,广播\r\n");
                            //connector.Send(Encoding.UTF8.GetBytes(strSRecMsg));
                            int i = 1;
                            foreach(KeyValuePair<string,Socket> item in clientConnectionItems)
                            {
                                if (i == clientConnectionItems.Count)
                                {
                                    //广播给其他Switcher
                                    item.Value.Send(Encoding.UTF8.GetBytes("10@" + frame[1] + "@" + frame[2]+"@"+frame[3]));//交给交换机
                                }
                                else
                                {
                                    //广播给客户
                                    item.Value.Send(Encoding.UTF8.GetBytes("00@"+frame[1]+"@"+frame[2]+"@"+frame[3]));
                                }
                                i++;
                            }
                        }
                        writefile();
                    }else if (frame[0] == "10")
                    {
                        //代理另一个交换机的广播请求
                        _syncContext.Post(updateMessage, "端口" + getPortByIp(socketReciver) + ":" + strSRecMsg + "\r\n");
                        _syncContext.Post(updateMessage, "查表中......\r\n");
                        readfile();
                        bool hasS = false;
                        bool hasD = false;
                        string dPort = null;
                        foreach (MacRecord rec in records)
                        {
                            rec.Ttl = rec.Ttl - 1;
                            if (rec.Mac == frame[1]||rec.Mac==frame[2])
                            {
                                hasS = true;
                                rec.Ttl = 5;
                            }

                        }
                        for (int i = 0; i < records.Count; i++)
                        {
                            if (records[i].Ttl <= 0)
                            {
                                records.RemoveAt(i);
                            }
                        }
                        //如果源Mac记录不存在，则写入Mac表中
                        if (hasS == false)
                        {
                            MacRecord newRec = new MacRecord(frame[1], getPortByIp(socketReciver), 5);
                            records.Add(newRec);
                            _syncContext.Post(updateMessage, "Mac表中不存在源Mac,添加源Mac" + frame[1] + "\r\n");
                        }
                        foreach (MacRecord rec in records)
                        {
                            if (rec.Mac == frame[2])
                            {
                                hasD = true;
                                dPort = rec.Port;
                                break;
                            }
                        }
                        if (hasD == true)
                        {
                            //mac表中有目的mac,单点传送
                            _syncContext.Post(updateMessage, "Mac表中存在目的Mac,转发到端口" + dPort + "\r\n");

                            int i = 1;
                            foreach (KeyValuePair<string, Socket> item in clientConnectionItems)
                            {
                                if (i.ToString() == dPort)
                                {
                                    item.Value.Send(Encoding.UTF8.GetBytes("11@" + frame[1] + "@" + frame[2] + "@" + frame[3]));

                                }
                                i++;
                            }
                            
                            //告诉另一个switcher,我的mac表中有此目的mac
                            getSwitcher().Send(Encoding.UTF8.GetBytes("01@" + frame[2]));
                        }
                        else
                        {
                            //mac表中没有目的mac,代广播
                            _syncContext.Post(updateMessage, "Mac表中没有目的Mac,广播\r\n");
                            //connector.Send(Encoding.UTF8.GetBytes(strSRecMsg));
                            int i = 1;
                            foreach (KeyValuePair<string, Socket> item in clientConnectionItems)
                            {
                                /*if (i != clientConnectionItems.Count) {
                                    //发送代广播信息，但不发给传来的switcher,避免环
                                    item.Value.Send(Encoding.UTF8.GetBytes("10@"+frame[1]+"@"+frame[2]+"@"+frame[3]));
                                }*/
                                if (item.Value != socketReciver)
                                {
                                    item.Value.Send(Encoding.UTF8.GetBytes("10@" + frame[1] + "@" + frame[2] + "@" + frame[3]));
                                }
                                i++;
                            }
                        }
                        writefile();

                    }
                    else if (frame[0] == "01")
                    {
                        //收到了广播的响应
                        readfile();
                        _syncContext.Post(updateMessage, "端口"+getPortByIp(socketReciver)+"响应了广播,");
                        MacRecord newRec = new MacRecord(frame[1], getPortByIp(socketReciver), 5);
                        records.Add(newRec);
                        _syncContext.Post(updateMessage, "添加目的Mac: " + frame[1]+"到表中\r\n");
                        writefile();
                    }else if (frame[0] == "00")
                    {
                        readfile();
                        //收到了代理广播的响应
                        _syncContext.Post(updateMessage, "端口" + getPortByIp(socketReciver) + "响应了广播");
                        _syncContext.Post(updateMessage, strSRecMsg + "\r\n");
                        MacRecord newRec = new MacRecord(frame[1], getPortByIp(socketReciver), 5);
                        records.Add(newRec);
                        _syncContext.Post(updateMessage, "转发并添加目的Mac:" + frame[1] + "到表中\r\n");
                        //响应交换机的代理信息
                        getSwitcher().Send(Encoding.UTF8.GetBytes("01@" + frame[1]));
                        writefile();
                    }

                }
                catch (Exception ex)
                {
                    if (socketReciver != null)
                    {

                        //提示套接字监听异常
                        _syncContext.Post(updateMessage, "端口" + socketReciver.RemoteEndPoint + "已经中断连接" + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");
                        //Console.WriteLine("客户端" + socketReciver.RemoteEndPoint + "已经中断连接" + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");
                        //关闭之前accept出来的和客户端进行通信的套接字 
                        socketReciver.Close();
                    }

                    break;
                }
            }
        }

        public string getPortByIp(Socket socket)
        {
            int i = 1;
            string port = null;
            foreach (KeyValuePair<string, Socket> item in clientConnectionItems)
            {
                if (item.Key == socket.RemoteEndPoint.ToString())
                {
                    port = i.ToString();
                }
                i++;
            }
            return port;
        }

        public Socket getSwitcher()
        {
            int i = 1;
            foreach (KeyValuePair<string, Socket> item in clientConnectionItems)
            {
                
                if (i == clientConnectionItems.Count)
                {
                    return item.Value;
                }
                i++;
            }
            return null;
        }
        static ReaderWriterLockSlim filelock = new ReaderWriterLockSlim(); 
        public void readfile()
        {
            try
            {
                filelock.EnterReadLock();
                records.Clear();
                int ttl;
                StreamReader sr = new StreamReader(filepath, true);
                string nextline = null;
                string[] str = null;
                while ((nextline = sr.ReadLine()) != null)
                {
                    str = nextline.Split(' ');
                    int.TryParse(str[2], out ttl);
                    MacRecord record = new MacRecord(str[0], str[1], ttl);
                    records.Add(record);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                filelock.ExitReadLock();
            }
        }

        public void writefile()
        {
            try
            {
                filelock.EnterWriteLock();

                StreamWriter sw = new StreamWriter(filepath, false);
                foreach(MacRecord rec in records)
                {
                    sw.WriteLine(string.Format("{0} {1} {2}",rec.Mac,rec.Port,rec.Ttl));
                }
                sw.Close();

            }
            catch (Exception ex)
            {
                _syncContext.Post(updateMessage, ex.Message);
            }
            finally
            {
                filelock.ExitWriteLock();
            }
        }

        public int Port { get => port; set => port = value; }
        public string Name { get => name; set => name = value; }


    }

    class Client
    {
        private Thread threadclient = null;
        private Socket client = null;
        private string mac = null;
        private string name = null;
        TextBox info = null;
        SynchronizationContext _syncContext = null;

        public string Mac { get => mac; set => mac = value; }

        private void updateMessage(object text)
        {
            this.info.Text += text.ToString();
        }

        public Client(string name,string mac)
        {
            _syncContext = SynchronizationContext.Current;
            this.name = name;
            this.Mac = mac;
            if (name == "c1")
            {
                info = Form1.form1.c1Info;
            }else if (name == "c2")
            {
                info = Form1.form1.c2Info;
            }else if (name == "c3")
            {
                info = Form1.form1.c3Info;
            }else if (name == "c4")
            {
                info = Form1.form1.c4Info;
            }else if (name == "c5")
            {
                info = Form1.form1.c5Info;
            }else if (name == "c6")
            {
                info = Form1.form1.c6Info;
            }
        }

        public void Connect(Switcher s)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //获取文本框中的IP地址  
            IPAddress address = IPAddress.Parse("127.0.0.1");

            //将获取的IP地址和端口号绑定在网络节点上
            IPEndPoint point = new IPEndPoint(address, s.Port);

            try
            {
                //客户端套接字连接到网络节点上，用的是Connect  
                client.Connect(point);
            }
            catch (Exception)
            {
                Console.WriteLine("连接失败");
            }

            threadclient = new Thread(recv);
            threadclient.IsBackground = true;
            threadclient.Start();
        }

        public void send(string mess)
        {
            byte[] textByte = Encoding.UTF8.GetBytes(mess);
            client.Send(textByte);
        }

        public void recv()
        {
            int x = 0;
            //持续监听服务端发来的消息 
            while (true)
            {
                try
                {
                    byte[] arrRecvmsg = new byte[1024 * 1024];
                    int length = client.Receive(arrRecvmsg);
                    string strRevMsg = Encoding.UTF8.GetString(arrRecvmsg, 0, length);

                    string[] frame = strRevMsg.Split('@');
                    if (frame[0] == "00")   //广播信息
                    {
                        //send("01@");
                        //响应广播
                        if (frame[2] == mac)
                        {
                            send("01@" + frame[2]);
                            _syncContext.Post(updateMessage, frame[1] + ":" + frame[3] + "\r\n");
                        }
                    }else if (frame[0] == "10")  //代广播信息
                    {
                        //响应代广播
                        //send("00@");
                        if (frame[2] == mac)
                        {
                            send("00@" + frame[2]);
                            _syncContext.Post(updateMessage, frame[1] + ":" + frame[3] + "\r\n");
                        }
                    }else if (frame[0] == "11")
                    {
                        //直接转发
                        _syncContext.Post(updateMessage,frame[1]+":"+frame[3]+"\r\n");
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.Write("远程服务器已经中断连接" + "\r\n" + ex.ToString());
                    break;
                }
            }
        }

    }

    class MacRecord
    {
        string mac;
        string port;
        int ttl;
        public MacRecord(string mac,string port,int ttl)
        {
            this.mac = mac;
            this.port = port;
            this.ttl = ttl;
        }
        public string Mac { get => mac; set => mac = value; }
        public string Port { get => port; set => port = value; }
        public int Ttl { get => ttl; set => ttl = value; }
    }


}
