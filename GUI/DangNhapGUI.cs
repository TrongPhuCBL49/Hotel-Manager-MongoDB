using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using BUS;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using DTO;

namespace GUI
{
    public partial class DangNhapGUI : DevExpress.XtraEditors.XtraForm
    {
        public static string IdNhanVien = "";
        public static int IdChucDanh = -1;

        public DangNhapGUI()
        {
            InitializeComponent();
            txtMaNhanVien.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            login();
        }

        void login()
        {
            if (DangNhapBUS.Instance.KiemTraUser(txtMaNhanVien.Text, txtMatKhau.Text))
            {
                IdNhanVien = txtMaNhanVien.Text;
                IdChucDanh = DangNhapBUS.Instance.IdChucDanh(IdNhanVien);
                ConnectDB.Instance.IpAddress = cboIpAddress.Text;
                ConnectDB.Instance.DatabaseName = txtDatabaseName.Text;
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form f = new MainGUI();
                //Xử lý khi đóng form con thì sẽ chạy event show lại form này
                f.FormClosed += F_FormClosed;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
                this.Hide();
                txtMaNhanVien.Text = "";
                txtMatKhau.Text = "";
            }
            else
                MessageBox.Show("Đăng nhập thất bại, vui lòng kiểm tra lại thông tin!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelDangNhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhapGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                login();
        }

        private void btnQuetIp_Click(object sender, EventArgs e)
        {
            cboIpAddress.Properties.Items.Clear();
            string ipBase = ThisIp();
            ipBase = ipBase.Remove(ThisIp().LastIndexOf(".") + 1);
            for (int i = 1; i < 255; i++)
            {
                string ip = ipBase + i.ToString();

                Ping p = new Ping();
                p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                p.SendAsync(ip, 100, ip);
                
            }
            MessageBox.Show("Đã quét Ip xong!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string ThisIp()
        {
            IPHostEntry host;
            string thisIp = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    thisIp = ip.ToString();
            }
            return thisIp;
        }
        private void p_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {
                cboIpAddress.Properties.Items.Add(ip);
            }
        }

    }
}
