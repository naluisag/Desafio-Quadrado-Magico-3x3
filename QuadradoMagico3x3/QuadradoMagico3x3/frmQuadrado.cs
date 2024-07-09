using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadradoMagico3x3
{
    public partial class frmQuadrado : Form
    {
        int[,] mat = new int[3, 3];
        int l = 0;
        int c = 1;
        int nome = 1;

        public frmQuadrado()
        {
            InitializeComponent();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    flpQuadrado.Controls.Add(CriarBotao(i,j));
                }
            }
            
        }

        private Button CriarBotao(int linha, int coluna)
        {
            Button btnElemento = new Button();
            btnElemento.Name = "btn" + nome;
            btnElemento.Font = new Font("Arial", 30);
            btnElemento.Size = new Size(100, 100);
            btnElemento.BackColor = Color.LightGray;
            btnElemento.FlatStyle = FlatStyle.Flat;
            btnElemento.FlatAppearance.MouseOverBackColor = Color.Red;
            btnElemento.Text = mat[linha,coluna].ToString();
            nome++;
            return btnElemento;
        }

        private void frmQuadrado_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i == 0)
                {
                    mat[l, c] = i + 1;
                }
                else if (l - 1 < 0 && c + 1 > 2)
                {
                    l++;
                    mat[l, c] = i + 1;
                }
                else if (l - 1 < 0)
                {
                    l = 2;
                    c++;
                    mat[l, c] = i + 1;
                }
                else if (c + 1 > 2)
                {
                    l--;
                    c = 0;
                    mat[l, c] = i + 1;
                }
                else if (mat[l - 1, c + 1] != 0)
                {
                    l++;
                    mat[l, c] = i + 1;
                }
                else
                {
                    l--;
                    c++;
                    mat[l, c] = i + 1;
                }
            }
        }
    }
}
