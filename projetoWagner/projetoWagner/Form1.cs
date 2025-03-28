using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace projetoWagner
{
    public partial class Form1 : Form
    {
        int[] posicaoMouse = new int[10];
        int altura, largura, pontoInicioY, pontoInicioX, selecionado, dashSelecionado = 0,clique = 0, grossura, raioX, raioY;           
        string formaGeometrica = "", textura = "",  path = @"C:\\Arquivos\\dados.dat";
        Color cor, corBotao1 = Color.Black, corBotao2 = Color.Black;
        bool primeira, cor1 = true;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {       
            Pen caneta = selecionarCaneta(cor ,grossura, dashSelecionado);
            switch (selecionado)
            {
                case 0:
                    formaGeometrica = "Linha  ==  X1:" + posicaoMouse[0] + ", Y1:" + posicaoMouse[1] + ", X2: " + posicaoMouse[2] + ", Y2: " + posicaoMouse[3] + ", Cor: " + cor.ToString() + ", Grossura da linha: " + grossura + ", Textura: " + textura + "\n";
                    gravarPrograma(formaGeometrica);
                    desenharLinha(e, caneta, posicaoMouse);
                    break;
                case 1:
                    formaGeometrica = "Retângulo  ==  X1:" + pontoInicioX + ", Y1:" + pontoInicioY + ", Altura: " + altura + " , Largura: " + largura + ", Cor: " + cor.ToString() + ", Grossura da linha: " + grossura + ", Textura: " + textura + "\n";
                    gravarPrograma(formaGeometrica);
                    desenharRetangulo(e, caneta, posicaoMouse);
                    break;
                case 2:
                    formaGeometrica = "Triangulo  ==  X1:" + posicaoMouse[0] + ", Y1:" + posicaoMouse[1] + ", X2: " + posicaoMouse[2] + ", Y2: " + posicaoMouse[3] + ", X3: " + posicaoMouse[4] + ", Y3: " + posicaoMouse[5] + ", Cor: " + cor.ToString() + ", Grossura da linha: " + grossura + ", Textura: " + textura + "\n";
                    gravarPrograma(formaGeometrica);
                    desenharTriangulo(e, caneta, posicaoMouse);
                    break;
                case 4:
                    formaGeometrica = "Losango  ==  X1:" + posicaoMouse[0] + ", Y1:" + posicaoMouse[1] + ", X2: " + posicaoMouse[2] + ", Y2: " + posicaoMouse[3] + " X3: " + posicaoMouse[4] + ", Y3: " + posicaoMouse[5] + ", X4: " + posicaoMouse[6] + ", Y4: " + posicaoMouse[7] + ", Cor: " + cor.ToString() + ", Grossura da linha: " + grossura + ", Textura: " + textura + "\n";
                    gravarPrograma(formaGeometrica);
                    desenharLosango(e, caneta, posicaoMouse);
                    break;
                case 5:
                    formaGeometrica = "Pentagono  ==  X1:" + posicaoMouse[0] + ", Y1:" + posicaoMouse[1] + ", X2: " + posicaoMouse[2] + ", Y2: " + posicaoMouse[3] + ", X3: " + posicaoMouse[4] + ", Y3: " + posicaoMouse[5] + ", X4: " + posicaoMouse[6] + ", Y4: " + posicaoMouse[7] + ", X5: " + posicaoMouse[8] + ", Y5: " + posicaoMouse[9] + ", Cor: " + cor.ToString() + ", Grossura da linha: " + grossura + ", Textura: " + textura + "\n";
                    gravarPrograma(formaGeometrica);
                    desenharPentagono(e, caneta, posicaoMouse);
                    break;
                case 6:
                    formaGeometrica = "Elipse  ==  X1:" + posicaoMouse[0] + ", Y1:" + posicaoMouse[1] + ", Raio X: " + raioX + ", Raio Y: " + raioY + ", Cor: " + cor.ToString() + ", Grossura da linha: " + grossura + ", Textura: " + textura + "\n";
                    gravarPrograma(formaGeometrica);
                    desenharElipse(e, caneta, posicaoMouse);
                    break;
            }
        }

        public void gravarPrograma(string formaGeometrica)
        {
            
        }

        public void desenharLinha(PaintEventArgs e, Pen caneta, int[] posicaoMouse)
        {
            e.Graphics.DrawLine(caneta, posicaoMouse[0], posicaoMouse[1], posicaoMouse[2], posicaoMouse[3]);
        }

        public void desenharPonto(PaintEventArgs e, Pen caneta, int x, int y)
        {
            e.Graphics.DrawLine(caneta, x,y,x + 1,y);
        }

        public void desenharRetangulo(PaintEventArgs e, Pen caneta, int[] posicaoMouse)
        {
            pontoInicioX = Math.Min(posicaoMouse[0], posicaoMouse[2]);
            pontoInicioY = Math.Min(posicaoMouse[1], posicaoMouse[3]);
            largura = Math.Max(posicaoMouse[0], posicaoMouse[2]) - pontoInicioX;
            altura = Math.Max(posicaoMouse[1], posicaoMouse[3]) - pontoInicioY;

            e.Graphics.DrawRectangle(caneta, pontoInicioX, pontoInicioY, largura, altura);
        }

        public void desenharElipse(PaintEventArgs e, Pen caneta, int[] posicaoMouse)
        {
            if (primeira)
            {
                raioX = getInputBox("Digite a largura da Elipse");
                raioY = getInputBox("Digite a altura da Elipse");
            }
                

            for (double teta = 0; teta <= 360; teta += 0.2)
            {
                pontoInicioX = posicaoMouse[0] + (int)(raioX * Math.Cos(teta * Math.PI / 180));
                pontoInicioY = posicaoMouse[1] + (int)(raioY * Math.Sin(teta * Math.PI / 180));
                desenharPonto(e, caneta, pontoInicioX, pontoInicioY);
            }
            primeira = false;
        }

        public void desenharTriangulo(PaintEventArgs e, Pen caneta, int[] posicaoMouse)
        {
            e.Graphics.DrawLine(caneta, posicaoMouse[0], posicaoMouse[1], posicaoMouse[2], posicaoMouse[3]);
            e.Graphics.DrawLine(caneta, posicaoMouse[2], posicaoMouse[3], posicaoMouse[4], posicaoMouse[5]);
            e.Graphics.DrawLine(caneta, posicaoMouse[4], posicaoMouse[5], posicaoMouse[0], posicaoMouse[1]);
        }
        public void desenharLosango(PaintEventArgs e, Pen caneta, int[] posicaoMouse)
        {
            e.Graphics.DrawLine(caneta, posicaoMouse[0], posicaoMouse[1], posicaoMouse[2], posicaoMouse[3]);
            e.Graphics.DrawLine(caneta, posicaoMouse[2], posicaoMouse[3], posicaoMouse[4], posicaoMouse[5]);
            e.Graphics.DrawLine(caneta, posicaoMouse[4], posicaoMouse[5], posicaoMouse[6], posicaoMouse[7]);
            e.Graphics.DrawLine(caneta, posicaoMouse[6], posicaoMouse[7], posicaoMouse[0], posicaoMouse[1]);
        }

        public void desenharPentagono(PaintEventArgs e, Pen caneta, int[] posicaoMouse)
        {
            e.Graphics.DrawLine(caneta, posicaoMouse[0], posicaoMouse[1], posicaoMouse[2], posicaoMouse[3]);
            e.Graphics.DrawLine(caneta, posicaoMouse[2], posicaoMouse[3], posicaoMouse[4], posicaoMouse[5]);
            e.Graphics.DrawLine(caneta, posicaoMouse[4], posicaoMouse[5], posicaoMouse[6], posicaoMouse[7]);
            e.Graphics.DrawLine(caneta, posicaoMouse[6], posicaoMouse[7], posicaoMouse[8], posicaoMouse[9]);
            e.Graphics.DrawLine(caneta, posicaoMouse[8], posicaoMouse[9], posicaoMouse[0], posicaoMouse[1]);

        }

        public float[] selecionarDash(int dashSelecionado)
        {
            switch (dashSelecionado)
            {              
                case 1:
                    textura = "Tracejada";
                    return new float[] { 10, 5 };
                case 2:
                    textura = "Traço Ponto";
                    return new float[] { 10, 5, 2, 5 };
                case 3:
                    textura = "Dois Traços Ponto";
                    return new float[] { 10, 5, 10, 5, 2, 5 };
                case 4:
                    textura = "Pontilhada";
                    return new float[] { 2, 5 };
                default:
                    textura = "Linha sólida";
                    return new float[] {5};
            }
        }

        public Color selecionarCor(int r , int g, int b)
        {
            Color cor = new Color();
            cor = Color.FromArgb(r, g, b);
            return cor;
        }

        public Pen selecionarCaneta(Color cor,int grossura ,int dashSelecionado)
        {
            Pen caneta = new Pen(cor, grossura);
            caneta.DashPattern = selecionarDash(dashSelecionado);
            return caneta;
        }

        public int getInputBox(string prompt)
        {
            int variavel = int.Parse(Interaction.InputBox(prompt));
            return variavel;
        }

        public void trocarCor()
        {
            if (cor1)
            {
                button7.BackColor = cor;
                corBotao1 = cor;
            }
            else
            {
                button8.BackColor = cor;
                corBotao2 = cor;
            }


        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (selecionado)
            {
                case 0:
                case 1:
                    if(clique == 0)
                    {
                        posicaoMouse[0] = e.X;
                        posicaoMouse[1] = e.Y;
                        clique++;
                    }
                    else
                    {
                        posicaoMouse[2] = e.X;
                        posicaoMouse[3] = e.Y;
                        Invalidate();
                        clique = 0;
                    }
                    break;
                case 2:
                    if(clique == 0)
                    {
                        posicaoMouse[0] = e.X;
                        posicaoMouse[1] = e.Y;
                        clique++;
                    }else if(clique == 1)
                    {
                        posicaoMouse[2] = e.X;
                        posicaoMouse[3] = e.Y;
                        clique++;
                    }
                    else
                    {
                        posicaoMouse[4] = e.X;
                        posicaoMouse[5] = e.Y;
                        Invalidate();
                        clique = 0;
                    }
                    break;
                case 6:
                case 3:
                    posicaoMouse[0] = e.X;
                    posicaoMouse[1] = e.Y;
                    primeira = true;
                    Invalidate();
                    break;

                case 4:
                    if(clique == 0)
                    {
                        posicaoMouse[0] = e.X;
                        posicaoMouse[1] = e.Y;
                        clique++;
                    }
                    else if(clique == 1)
                    {
                        posicaoMouse[4] = e.X;
                        posicaoMouse[5] = e.Y;
                        clique++;
                    }
                    else if (clique == 2)
                    {
                        posicaoMouse[2] = e.X;
                        posicaoMouse[3] = e.Y;
                        clique++;
                    }
                    else
                    {
                        posicaoMouse[6] = e.X;
                        posicaoMouse[7] = e.Y;
                        Invalidate();
                        clique = 0;
                    }
                    break;
                case 5:
                    if (clique == 0)
                    {
                        posicaoMouse[0] = e.X;
                        posicaoMouse[1] = e.Y;
                        clique++;
                    }
                    else if (clique == 1)
                    {
                        posicaoMouse[2] = e.X;
                        posicaoMouse[3] = e.Y;
                        clique++;
                    }
                    else if (clique == 2)
                    {
                        posicaoMouse[4] = e.X;
                        posicaoMouse[5] = e.Y;
                        clique++;
                    }
                    else if(clique == 3)
                    {
                        posicaoMouse[6] = e.X;
                        posicaoMouse[7] = e.Y;
                        clique++;
                    }
                    else
                    {
                        posicaoMouse[8] = e.X;
                        posicaoMouse[9] = e.Y;
                        Invalidate();
                        clique = 0;
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selecionado = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selecionado = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selecionado = 2;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            selecionado = 5;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(255, 0, 0);
            trocarCor();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(0,0,0);
            trocarCor();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(255,255,255);
            trocarCor();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(150,150,150);
            trocarCor();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(200, 200, 200);
            trocarCor();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(120, 18, 36);
            trocarCor();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(111, 78, 55);
            trocarCor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cor = selecionarCor(0, 0, 0);
            trocarCor();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(255, 192, 203);
            trocarCor();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(255, 140, 0);
            trocarCor();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(254, 216, 177);
            trocarCor();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(255, 255, 0);
            trocarCor();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(252, 238, 167);
            trocarCor();

        }

        private void button20_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(0,100,0);
            trocarCor();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(127 , 255, 0);
            trocarCor();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(64, 224, 208);
            trocarCor();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(218, 244, 210);
            trocarCor();

        }

        private void button18_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(0,0,255);
            trocarCor();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(177, 156, 217);
            trocarCor();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(106, 13, 173);
            trocarCor();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            cor = selecionarCor(255, 192, 203);
            trocarCor();
        }  
        private void button4_Click(object sender, EventArgs e)
        {
            selecionado = 3;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            selecionado = 4;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            selecionado = 5;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            selecionado = 6;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cor1 = true;
            cor = corBotao1;

        }
        private void button11_Click(object sender, EventArgs e)
        {
            cor1 = false;
            cor = corBotao2; 

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dashSelecionado = comboBox1.SelectedIndex;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            grossura = (int)numericUpDown1.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
