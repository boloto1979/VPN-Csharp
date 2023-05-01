using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotRas;

public partial class Form1 : Form
{
    private RasServer rasServer;
    private const string VpnName = "MyVpn";
    private const string VpnServerIpAddress = "8.8.8.8";
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
            await StartVpnServer();
            MessageBox.Show("VPN iniciada com sucesso.");
        }
    }

    private async void btnStop_Click(object sender, EventArgs e)
    {
        if (rasServer.IsRunning)
        {
            await StopVpnServer();
            MessageBox.Show("VPN parada com sucesso.");
        }
    }

    private Task StartVpnServer()
    {
        return Task.Run(() =>
        {
            try
            {
                rasServer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar a VPN: " + ex.Message);
            }
        });
    }

    private Task StopVpnServer()
    {
        return Task.Run(() =>
        {
            try
            {
                rasServer.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao parar a VPN: " + ex.Message);
            }
        });
    }
}
