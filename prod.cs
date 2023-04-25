using DotRas;

public partial class Form1 : Form
{
    private RasServer rasServer;
    private const string VpnName = "MyVpn";
    private const string VpnServerIpAddress = "190.167.1.1";
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
}
private void btnStart_Click(object sender, EventArgs e)
{
    if (!rasServer.IsRunning)
    {
        rasServer.Start();
        MessageBox.Show("VPN iniciada com sucesso.");
    }
}

private void btnStop_Click(object sender, EventArgs e)
{
    if (rasServer.IsRunning)
    {
        rasServer.Stop();
        MessageBox.Show("VPN parada com sucesso.");
    }
}
