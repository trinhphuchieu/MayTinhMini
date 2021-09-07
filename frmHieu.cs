using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayTinhBoTui
{
    
    public partial class MayTinh : Form
    {
        private string chiso = "";
        private string  ketqua = "";
        private string dau = "";
        private string num2 = "";
        private static int count = 0;
        private string giatri = "";
   
        public MayTinh()
        {
            InitializeComponent();
        }

        private void MayTinh_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void so1_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("1");
        }

        private void so2_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("2");
        }

        private void so3_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("3");
        }

        private void so4_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("4");
        }

        private void so5_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("5");
        }

        private void so6_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("6");
        }

        private void so7_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("7");
        }

        private void so8_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("8");
        }

        private void so9_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("9");
        }

        private void so0_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTra("0");
        }

        // kiểm tra số 
        private string KiemTra(string so)
        {
            if(bieuthuc.Text == "0")
            {
                return so;
            }
            else
            {
                return bieuthuc.Text+so;
            }
        }

        // xóa kết quả 
        private void xoa_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = "0";
            hienthi.Text = "";
            num2 = "";
            dau = "";
            ketqua = "";
            giatri = "";
            count = 0;
            chiso = ""; 
        }

        private void daucham_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTracham('.');
        }


        // kiểm tra dấu chấm
        private string KiemTracham(char so)
        {
            if (bieuthuc.Text == "0")
            {
                return bieuthuc.Text + so;
            }
            else
            {
                
                string chuoi = bieuthuc.Text;
                string text = "";
                for (int i = chuoi.Length - 1; i >= 0; i--)
                {
                    char kytu = chuoi[i];
                    if (kytu.Equals('+') || kytu.Equals('-') || kytu.Equals('*') || kytu.Equals('/'))
                    {
                        if (text.Contains('.'))
                        {
                            return bieuthuc.Text;
                        }
                        else
                        {
                            if (text.Length == 0)
                            {
                                return bieuthuc.Text +"0"+so;
                            }
                            else
                            {
                                return bieuthuc.Text + so;
                            }
                        }
                    }
                    text += kytu;
                }
                if (text.Contains('.'))
                {
                    return bieuthuc.Text;
                }
                return bieuthuc.Text+so;
                

            }
            
        }


        private void nhan_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTradau('*');
        }

        private void chia_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTradau('/');
        }

        private void cong_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTradau('+');
        }

        private void tru_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTradau('-');
        }

        private void chiadu_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = KiemTraPhanTram();
        }

        // kiêm tra +-*/
        private string KiemTradau(char so)
        {
            count = 0;
            if (bieuthuc.Text == "0")
            {
                return bieuthuc.Text;
            }
            else
            {
                if (chiso.Equals(bieuthuc.Text))
                {
                    return hienthi.Text + so;
                }
                string chuoi = bieuthuc.Text;

                char kytu = chuoi[chuoi.Length - 1];
                if (kytu.Equals('-') || kytu.Equals('*') || kytu.Equals('/') || kytu.Equals('%') || kytu.Equals('+'))
                {
                    chuoi = chuoi.Remove(chuoi.Length - 1);
                    return chuoi + so;
                }
                else
                {
                    return bieuthuc.Text + so;
                }

            }
        }

        // kiểm tra phần trăm 
        private string KiemTraPhanTram()
        {
            count = 0;
            string chuoi = bieuthuc.Text;
            bool isNumeric = double.TryParse(ketqua, out _);
            if (isNumeric)
            {
                double so = double.Parse(ketqua);
                ketqua = hienthi.Text;
                hienthi.Text = (so / 100).ToString();
                return (so / 100).ToString();
            }
            else
            {
                string chuoicon = "";
                int i = 0;
               for( i = chuoi.Length-1; i >= 0; i--)
                {
                    if(chuoi[i].Equals('+')|| chuoi[i].Equals('-') || chuoi[i].Equals('*') || chuoi[i].Equals('/'))
                    {
                        break;
                    }
                    chuoicon =  chuoi[i]+ chuoicon;
                }
               if(chuoicon.Length > 0)
                {
                    double tinh = double.Parse(chuoicon) / 100;
                    return chuoi.Substring(0,i+1) + tinh.ToString();
                }
                else
                {
                    return chuoi;
                }
            }
      
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray(); // chuỗi thành mảng ký tự
            Array.Reverse(arr); // đảo ngược mảng
            return new string(arr); // trả về chuỗi mới sau khi đảo mảng
        }

        private void amduong_Click(object sender, EventArgs e)
        {
            bieuthuc.Text = check_amduong();
    
        }
        // kiểm tra +/-
        private string check_amduong()
        {
            string chuoi = bieuthuc.Text;
            if (chuoi.Length == 0 && bieuthuc.Text=="0")
            {
                
                return bieuthuc.Text;
            }
            

            if(chuoi[chuoi.Length - 1] == '-'|| chuoi[chuoi.Length - 1] == '+'|| chuoi[chuoi.Length - 1] == '*'|| chuoi[chuoi.Length - 1] == '/')
            {
                return chuoi;
            }
            string so = "";
            int i = 0;
            for (i = chuoi.Length-1; i >= 0; i--)            
            {
                
                if (chuoi[i].Equals('+')|| chuoi[i].Equals('/')|| chuoi[i].Equals('*'))
                {
                    
                    return chuoi.Substring(0,i+1)+"-"+ so;
                   
                }
                else if (chuoi[i].Equals('-'))
                {
                    
                    if(i == 0)
                    {                   
                        break;
                    }
                    if (i-1 >= 0)
                    {
                        if(chuoi[i - 1].Equals('+') || chuoi[i - 1].Equals('/') || chuoi[i - 1].Equals('*')|| chuoi[i - 1].Equals('-'))
                        {
                            return chuoi.Substring(0,i) + so;
                        }
                        else
                        {                          
                            return chuoi.Substring(0,i+1) +"-"+ so;
                        }
                    }
                }  
                so = chuoi[i]+ so;
            }
            
            if (chuoi[0].Equals('-'))
            {
                return so;
            }
            else
            {
                return "-" + so;
            }     
        }


            private void xoalui_Click(object sender, EventArgs e)
        {
            count = 0;
            num2 = "";
            giatri = "";
            dau = "";
            ketqua = "";
            chiso = "";
            if(bieuthuc.Text == "0" || bieuthuc.Text == "")
            {
                bieuthuc.Text = "0";
            }
            else
            {
                if (hienthi.Text.Equals("Error"))
                {
                    hienthi.Text = "";
                }
                if(bieuthuc.Text.Length > 0)
                { 
                bieuthuc.Text = bieuthuc.Text.Remove(bieuthuc.Text.Length - 1);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cls_Hieu bieuthuc1 = new Cls_Hieu();
            string chuoi = bieuthuc.Text;         
            if (chuoi.EndsWith("*")|| chuoi.EndsWith("+")|| chuoi.EndsWith("/")|| chuoi.EndsWith("-"))
            {
                
                
                if(ketqua != "")
                {
                    hienthi.Text = bieuthuc1.Calculate(bieuthuc.Text+ketqua).ToString();
                    bieuthuc.Text = bieuthuc.Text+ ketqua;
                    dau = chuoi[chuoi.Length-1].ToString();
                    num2 = ketqua.ToString();
                    count = 2;
                }
                else
                {
                    hienthi.Text = "Error";
                }
            }
            else
            {
                string so = bieuthuc1.Calculate(bieuthuc.Text).ToString();
                if (ketqua == "")
                {
                   
                    ketqua = so;
                }
                else
                {
                    dau = "";
                    num2 = "";
                    string temp = "";
                    for (int i = chuoi.Length - 1; i >= 0; i--)
                    {
                        if (chuoi[i].Equals('+') || chuoi[i].Equals('/') || chuoi[i].Equals('*'))
                        {
                            dau = chuoi[i].ToString() + dau;
                            break;
                        }
                        else if(chuoi[i].Equals('-'))
                        {
                            if (i - 1 >= 0)
                            {
                                if (chuoi[i-1].Equals('+') || chuoi[i-1].Equals('/') || chuoi[i-1].Equals('*')|| chuoi[i - 1].Equals('-'))
                                {
                                    dau = chuoi[i-1].ToString() + chuoi[i].ToString() + dau;
                                    break;
                                }
                                else
                                {
                                    dau = chuoi[i].ToString() + dau;
                                    break;
                                }
                            }
                        }
                        num2 = chuoi[i] + num2;
                    }
                    if(dau != "" && num2 != "") { 
                    if (ketqua.Equals(so))
                    {
                        bieuthuc.Text = ketqua + dau + num2;
                        so = bieuthuc1.Calculate(bieuthuc.Text).ToString();
                        ketqua = so;
                    }
                    else
                    {
                        so = bieuthuc1.Calculate(bieuthuc.Text).ToString();
                        ketqua = so;
                        bieuthuc.Text = ketqua + dau + num2;
                        
                    }
                    }
                }
                chiso = bieuthuc.Text;
     
                
                if (so == "NaN")
                {
                    so = "0";
                }
                hienthi.Text = so;
               
           
                
                

            }         
        }
    }
}
