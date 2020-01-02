namespace MysqlCodeGenerator.Models
{
    public class ConnectionModel
    {
        public string RemoteIp{ get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string UserPass { get; set; }

        public ConnectionModel(string remoteIp, int port, string userName, string userPass)
        {
            this.RemoteIp = remoteIp;
            this.Port = port;
            this.UserName = userName;
            this.UserPass = userPass;
        }

        public override string ToString()
        {
            return $"{RemoteIp}>{Port}>{UserName}>{UserPass}";  
        }
    }
}
