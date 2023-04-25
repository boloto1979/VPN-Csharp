using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotRas;

public partial class Form1 : Form
{
    private RasServer rasServer;
    private const string VpnName = "MyVpn";
    private const string VpnServerIpAddress = "8.8.8.08";
    private const int VpnPort = 1723;
    private const RasVpnStrategy VpnStrategy = RasVpnStrategy.PptpOnly;

    public Form1()
    {
        InitializeComponent();
        rasServer = new RasServer();
        rasServer.ProtocolType = RasProtocolType.Pptp;
        rasServer.ServerIpAddress = IPAddress.Parse(VpnServerIpAddress);
        rasServer.ListenPort = VpnPort;
        rasServer.AllowRemoteConnections = true;
    }

    private async void btnStart_Click(object sender, EventArgs e)
    {
        if (!rasServer.IsRunning)
        {
            await Task.Run(() => rasServer.Start());
            MessageBox.Show("VPN iniciada com sucesso.");
        }
    }

    private async void btnStop_Click(object sender, EventArgs e)
    {
        if (rasServer.IsRunning)
        {
            await Task.Run(() => rasServer.Stop());
            MessageBox.Show("VPN parada com sucesso.");
        }
    }
}
