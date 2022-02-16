using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadshine;
using System.Threading;

namespace elipse {
    public partial class Form1 : Form {

        int x, x0, x1, x2, x3, x4;
        int y, y0, y1, y2, y3, y4;
        int width = 0, height = 0;
        int countLines = 0;
        int[] xPos = new int[30];
        int[] yPos = new int[30];
        ushort mouseDown = 0;//画笔标识
        ushort penUpFlag = 0;
        

        int Min_Vel = 1;
        int Max_Vel = 15;
        int speed = 10;
        readonly ushort CardNo = 0;
        readonly ushort[] axis = { 0, 1, 2 };
        readonly double Tacc = 0.1;  //加速时间
        readonly double Tdec = 0.1;  //减速时间
        readonly uint Stop_Vel = 5;  //停止速度
        readonly double S_para = 1;


        ushort[] AxirArray = { 0, 1 };
        double[] Dist = { 0, 1 };
        double θ = 50;

        double tim = 0;



        readonly double[] xWordPos1 = {  -0.07, 1.82, 1.82, -0.07, -1.94,
                                         -1.94, -0.51, 1.13, 1.13, -0.51,
                                         -1.94, -1.94, 0.79, 2.47, 2.47,
                                          0.79, -5.52, -7.55, -7.55, -5.52,
                                         -3.09, -3.09, -4.36, -6.34, -6.34,
                                         -4.36, -3.09, -3.09, -4.92, -6.98,
                                         -6.98, -4.92, -0.07 };
        readonly double[] xWordPos2 = { 1.60, 0.89, -1.41, -0.80, 1.60, 1.60, 0 };

        readonly double[] yWordPos1 = { 11.49, 11.53, 10.49, 10.53, 10.53,
                                        7.85, 7.85, 7.90, 6.77, 6.81,
                                        6.81, 3.53, 3.53, 3.57, 2.49,
                                        2.53, 2.53, 2.49, 3.57, 3.53,
                                        3.53, 6.81, 6.81, 6.77, 7.90,
                                        7.85  ,7.85  ,10.53 ,10.53,10.49,
                                        11.53 ,11.49 ,11.49 };
        readonly double[] yWordPos2 = { 4.60, 3.79, 5.52, 6.34, 4.60, 4.60, 0 };

        //停止函数多线程 
        private Thread Job1; // 定义线程名
        private Thread Job2; // 定义线程名

        bool laserFlag = false;



        public Form1 () {
            InitializeComponent();
        }



        private void Form1_Load (object sender, EventArgs e) {
            short res = LTSMC.smc_board_init(CardNo, 2, "192.168.5.11", 0);
            if (res != 0) {
                MessageBox.Show("连接错误！", "出错");
                return;
            }
            //三轴打开并设置脉冲当量
            LTSMC.nmcs_set_axis_enable(0, 0);
            LTSMC.nmcs_set_axis_enable(0, 1);
            LTSMC.nmcs_set_axis_enable(0, 2);
            //（设置脉冲当量（控制器号,轴号,脉冲当量）1000脉冲/1mm）
            LTSMC.smc_set_equiv(0, 0, 1000);
            LTSMC.smc_set_equiv(0, 1, 1000);
            LTSMC.smc_set_equiv(0, 2, 1000);

        }

        private void Form1_FormClosed (object sender, FormClosedEventArgs e) {
            LTSMC.smc_board_close(0);
        }
        public void stop_Click (object sender, EventArgs e) {
            LTSMC.smc_stop(CardNo, axis[0], 1);
            LTSMC.smc_stop(CardNo, axis[1], 1);
            LTSMC.smc_stop(CardNo, axis[2], 1);

            Job1.Abort(); // 终止线程
            write.Visible = true; // 按键可见
        }
        private void timerButtonClick_Tick (object sender, EventArgs e) {
            if (LTSMC.smc_read_inbit(0, 29) == 0) {
                write_Click(sender, e);
            }
        }
        private void motorJob () {
            this.PenUp();
            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }

            //赋值速度 把速度曲线设置一下 
            LTSMC.smc_set_vector_profile_unit(CardNo, 0, Min_Vel, speed, Tacc, Tdec, Stop_Vel);

            //画布大小400，64
            Graphics g = pictureBox1.CreateGraphics(); // 创建Graphics对象
            g.Clear(Color.White); // 画布清零
            Graphics f = pictureBox2.CreateGraphics(); // 创建Graphics对象
            f.Clear(Color.White); // 画布清零

            timerDrawTrack.Start();
            timerSpeedCurve.Start();
            
            double ratioX = double.Parse(textBoxWidth.Text) / 9.81; //6.31
            double ratioY = double.Parse(textBoxHight.Text) / 9.04; //9.04

            Console.WriteLine(xWordPos2.Length);

            //正常的字
            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            for (int i = 0; i < xWordPos1.Length; i++) {
                Dist[0] = xWordPos1[i] * ratioX + double.Parse(textBoxMovX.Text) + 2.0 * ratioX;
                Dist[1] = yWordPos1[i] * ratioY + double.Parse(textBoxMovY.Text) - 2.49 * ratioY;
                LTSMC.smc_line_unit(0, 0, 2, AxirArray, Dist, 1);
                while (LTSMC.smc_check_done(0, 0) == 0 ||
                    LTSMC.smc_check_done(0, 1) == 0) {
                    Application.DoEvents();
                }
                this.PenDown();
                while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            }
            this.PenUp();
            while (LTSMC.smc_check_done(0, 2) == 0) {
                Application.DoEvents();
            }

            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            for (int i = 0; i < xWordPos2.Length - 1; i++) {
                Dist[0] = xWordPos2[i] * ratioX + double.Parse(textBoxMovX.Text) + 2.0 * ratioX;
                Dist[1] = yWordPos2[i] * ratioY + double.Parse(textBoxMovY.Text) - 2.5 * ratioY;
                LTSMC.smc_line_unit(0, 0, 2, AxirArray, Dist, 1);
                while (LTSMC.smc_check_done(0, 0) == 0 ||
                    LTSMC.smc_check_done(0, 1) == 0) {
                    Application.DoEvents();
                }
                this.PenDown();
                while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            }

            this.PenUp();
            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }

            //旋转的字
            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); };
            for (int i = 0; i < xWordPos1.Length; i++) {
                Dist[0] = (xWordPos1[i] * Math.Cos(θ) - yWordPos1[i] * Math.Sin(θ)) + 130;
                Dist[1] = (xWordPos1[i] * Math.Sin(θ) + yWordPos1[i] * Math.Cos(θ)) + 30;
                LTSMC.smc_line_unit(0, 0, 2, AxirArray, Dist, 1);
                while (LTSMC.smc_check_done(0, 0) == 0 ||
                    LTSMC.smc_check_done(0, 1) == 0) {
                    Application.DoEvents();
                }
                this.PenDown();
                while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            }
            
            this.PenUp();
            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }

            for (int i = 0; i < xWordPos2.Length-1i++) {
                Dist[0] = (xWordPos2[i] * Math.Cos(θ) - yWordPos2[i] * Math.Sin(θ)) + 130;
                Dist[1] = (xWordPos2[i] * Math.Sin(θ) + yWordPos2[i] * Math.Cos(θ)) + 30;
                LTSMC.smc_line_unit(0, 0, 2, AxirArray, Dist, 1);
                while (LTSMC.smc_check_done(0, 0) == 0 ||
                    LTSMC.smc_check_done(0, 1) == 0) {
                    Application.DoEvents();
                }
                this.PenDown();
                while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            }
            this.PenUp();
            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }

            //水平偏移变换
            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            for (int i = 0; i < xWordPos1.Length; i++) {
                Dist[0] = xWordPos1[i] * 2 + 20;
                Dist[1] = xWordPos1[i] * 2 * 0.7 + yWordPos1[i] * 2 + 30;
                LTSMC.smc_line_unit(0, 0, 2, AxirArray, Dist, 1);
                while (LTSMC.smc_check_done(0, 0) == 0 ||
                    LTSMC.smc_check_done(0, 1) == 0) {
                    Application.DoEvents();
                }
                this.PenDown();
                while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            }
            this.PenUp();
            while (LTSMC.smc_check_done(0, 2) == 0) {
                Application.DoEvents();
            }

            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            for (int i = 0; i < xWordPos2.Length - 1; i++) {
                Dist[0] = xWordPos2[i] * 2 + 20;
                Dist[1] = xWordPos2[i] * 2 * 0.5 + yWordPos2[i] * 2 + 30;
                LTSMC.smc_line_unit(0, 0, 2, AxirArray, Dist, 1);
                while (LTSMC.smc_check_done(0, 0) == 0 ||
                    LTSMC.smc_check_done(0, 1) == 0) {
                    Application.DoEvents();
                }
                this.PenDown();
                while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            }
            this.PenUp();
            while (LTSMC.smc_check_done(0, 2) == 0) { Application.DoEvents(); }
            timerDrawTrack.Stop();


        }
        private void write_Click (object sender, EventArgs e){
            Job1 = new Thread(motorJob);
            // 创建线程
            Job1.Priority = ThreadPriority.Normal;
            // 线程Job1优先级一般
            Job1.Start(); // 启动线程
            write.Visible = false;// 按键不可见，防止多次启动线程
        }

        //激光待补充
        private void textBoxLaser_Click (object sender, EventArgs e) {
            laserFlag = !laserFlag;
            if (laserFlag == true) { 
                LTSMC.smc_write_outbit(0, 60, 0);
                textBoxLaser.Text = "Laser: OPEN";
            }
            else {
                LTSMC.smc_write_outbit(0, 60, 1);
                textBoxLaser.Text = "Laser: CLOSE";
            }
        }





        //未使用此函数已废
        private void Stop () {
            this.Invoke((MethodInvoker)delegate {
                //this.stop.PerformClick();
            });
            Thread.Sleep(1); // 延时1ms
            //线程测试
            //int count1=0;
            //for (int i = 0; i < 100000; i++) {
            //    count1 = count1 + 1;
            //    this.Invoke((MethodInvoker)delegate
            //    { this.home.Text = count1.ToString(); });
            //    // 跨线程操作,在Form1线程上执行指定的委托
            //    Thread.Sleep(1); // 延时1ms
            //}

        }
        
        //实时显示速度
        private void speedChange_Scroll (object sender, EventArgs e) {
            speed = speedChange.Value;
            textBoxSpeed.Text = "SPEED:" + speedChange.Value.ToString() + " mm/s";
        }

        //测试用凸轮
        private void drawElipse_Click (object sender, EventArgs e) {
            pictureBox1.Size = new Size(400, 400);
            Graphics g = pictureBox1.CreateGraphics(); // 创建Graphics对象
            g.PageUnit = GraphicsUnit.Pixel; // 以像素为单位
            g.PageScale = 0.5f; // 像素与坐标单位的比例,即1个单位为0.5个像素。
            g.TranslateTransform(0, 700); // y轴下移 700 ,方向 仍朝下
            g.Clear(Color.White); // 画布清零
            Pen GreenPen = new Pen(Color.Green);
            // 计算P1、P2、P3、P4的坐标
            x1 = (int)(300 - 200 * Math.Cos(30.0 * 3.14159 / 180.0));
            y1 = (int)(300 + 200 * Math.Sin(30.0 * 3.14159 / 180.0));
            x2 = (int)(300 - 120 * Math.Cos(30.0 * 3.14159 / 180.0));
            y2 = (int)(500 + 120 * Math.Sin(30.0 * 3.14159 / 180.0));
            x3 = (int)(300 + 120 * Math.Cos(30.0 * 3.14159 / 180.0));
            y3 = (int)(500 + 120 * Math.Sin(30.0 * 3.14159 / 180.0));
            x4 = (int)(300 + 200 * Math.Cos(30.0 * 3.14159 / 180.0));
            y4 = (int)(300 + 200 * Math.Sin(30.0 * 3.14159 / 180.0));
            // 画直线P1P2和P3P4
            g.DrawLine(GreenPen, x1, -1 * y1, x2, -1 * y2);
            g.DrawLine(GreenPen, x3, -1 * y3, x4, -1 * y4);
            // 画圆弧P2P3
            x0 = (int)(300 + 120 * Math.Cos(30 * 3.14159 / 180.0));
            y0 = -1 * (int)(500 + 120 * Math.Sin(30 * 3.14159 / 180.0));
            for (int i = 31; i < 150; i++) {
                x = (int)(300 + 120 * Math.Cos(i * 3.14159 / 180.0));
                y = -1 * (int)(500 + 120 * Math.Sin(i * 3.14159 / 180.0));
                g.DrawLine(GreenPen, x0, y0, x, y);
                x0 = x;
                y0 = y;
            }
            // 画圆弧P4P1
            x0 = (int)(300 + 200 * Math.Cos(150 * 3.14159 / 180.0));
            y0 = -1 * (int)(300 + 200 * Math.Sin(150 * 3.14159 / 180.0));
            for (int i = 151; i < 390; i++) {
                x = (int)(300 + 200 * Math.Cos(i * 3.14159 / 180.0));
                y = -1 * (int)(300 + 200 * Math.Sin(i * 3.14159 / 180.0));
                g.DrawLine(GreenPen, x0, y0, x, y);
                x0 = x;
                y0 = y;
            }

        }
        private void machiningCAM_Click (object sender, EventArgs e) {
            double[] pos = new double[2];
            double[] centor = new double[2];
            double LookaheadAcc = 10000;
            int LookaheadSegment = 200;
            double PathError = 1;
            short result = 0;

            timer1.Start();
            //设置X轴速度曲线参数
            LTSMC.smc_set_profile_unit(CardNo, axis[0], Min_Vel, Max_Vel, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[0], 0, S_para); //设置S段参数
            LTSMC.smc_pmove_unit(CardNo, 0, x1, 1); //启动定长运动
                                                    //设置Y轴速度曲线参数
            LTSMC.smc_set_profile_unit(CardNo, axis[1], Min_Vel, Max_Vel, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[1], 0, S_para); //设置S段参数
            LTSMC.smc_pmove_unit(CardNo, axis[1], y1, 1); //启动定长运动
            while (LTSMC.smc_check_done(0, 1) == 0) // 等待2个电机都停止
            {
                Application.DoEvents();
            }
            Thread.Sleep(100); // 延时100毫秒
            LTSMC.smc_conti_set_lookahead_mode(CardNo, 0, 1, LookaheadSegment,
            PathError, LookaheadAcc); // 设置连续插补前瞻模式
            LTSMC.smc_set_vector_profile_unit(CardNo, 0, Min_Vel, Max_Vel, Tacc, Tdec, Stop_Vel); // 设置连续插补的速度
            LTSMC.smc_set_vector_s_profile(CardNo, 0, 0, S_para); //设置连续插补S段时间
            LTSMC.smc_conti_open_list(CardNo, 0, 2, axis); // 打开连续插补指令表
            LTSMC.smc_conti_start_list(CardNo, 0); // 开始连续插补
            //连续直线插补P1到P2
            pos[0] = x2; //设置连续直线插补的终点
            pos[1] = y2;
            result = LTSMC.smc_conti_line_unit(CardNo, 0, 2, axis, pos, 1, 0);
            //连续圆弧插补P2到P3
            pos[0] = x3; //设置连续圆弧插补的终点
            pos[1] = y3;
            centor[0] = 300; //设置连续圆弧插补的圆心
            centor[1] = 500;
            LTSMC.smc_conti_arc_move_center_unit(CardNo, 0, 2, axis, pos, centor, 0, 0, 1, 1);
            //连续直线插补P3到P4
            pos[0] = x4;
            pos[1] = y4;
            result = LTSMC.smc_conti_line_unit(CardNo, 0, 2, axis, pos, 1, 2);
            //连续圆弧插补P4到P1
            pos[0] = x1;
            pos[1] = y1;

            LTSMC.smc_conti_arc_move_center_unit(CardNo, 0, 2, axis, pos, centor, 0, 0, 1, 3);
            LTSMC.smc_conti_close_list(CardNo, 0); //关闭连续插补指令表
        }
        private void timer1_Tick (object sender, EventArgs e) {
            double positionX = 0, positionX0 = 0;
            double positionY = 0, positionY0 = 0;
            Graphics g = pictureBox1.CreateGraphics(); // 创建Graphics对象
            g.PageUnit = GraphicsUnit.Pixel; // 以像素为单位
            g.PageScale = 0.5f; // 像素与坐标单位的比例,即1个单位为0.5个像素。
            g.TranslateTransform(0, 700); // y轴下移 700 ,方向 仍朝下
            Pen RedPen = new Pen(Color.Red);
            LTSMC.smc_get_position_unit(CardNo, 0, ref positionX); // 读X轴指令坐标
            textBoxXPos.Text = positionX.ToString();
            LTSMC.smc_get_position_unit(CardNo, 1, ref positionY); // 读Y轴指令坐标
            textBoxYPos.Text = positionY.ToString();
            // 画加工轨迹
            g.DrawLine(RedPen, (float)positionX0, -1 * (float)positionY0, (float)positionX, -1 * (float)positionY); 
            positionX0 = positionX;
            positionY0 = positionY;
        }

        //回零
        private void home_Click (object sender, EventArgs e) {
            this.PenUp();
            for (ushort i = 0; i < 2; i++) {
                //控制器号,轴号,低速,高速,加速时间,减速时间
                LTSMC.smc_set_home_profile_unit(0, i, 1, speed, 0.1, 0.1);

                LTSMC.smc_set_homemode(CardNo, i, 0, 1, 21, 0); // 设置回零模式
                LTSMC.smc_set_home_position_unit(CardNo, i, 1, 0);// 设置偏移模式

                LTSMC.smc_home_move(CardNo, i); // 启动回零
                LTSMC.smc_set_position_unit(CardNo, i, 0);
            }
            while (LTSMC.smc_check_done(0, 0) == 0 ||
                LTSMC.smc_check_done(0, 1) == 0) {
                Application.DoEvents();
            }
            //控制器号,轴号,低速,高速,加速时间,减速时间
            LTSMC.smc_set_home_profile_unit(0, 2, 1, speed, 0.1, 0.1);

            LTSMC.smc_set_homemode(CardNo, 2, 0, 1, 21, 0); // 设置回零模式
            LTSMC.smc_set_home_position_unit(CardNo, 2, 1, 0);// 设置偏移模式

            LTSMC.smc_home_move(CardNo, 2); // 启动回零
            LTSMC.smc_set_position_unit(CardNo, 2, 0);
            timerSpeed.Start();
        }

        //实时读取位置
        private void timerSpeed_Tick (object sender, EventArgs e) {
            double pos = 0;
            LTSMC.smc_get_position_unit(CardNo, axis[0], ref pos); // 获取0号轴当前指令位置
            textBoxXPos.Text = pos.ToString(); // 显示当前位置
            LTSMC.smc_get_position_unit(CardNo, axis[1], ref pos); // 获取1号轴当前指令位置
            textBoxYPos.Text = pos.ToString(); // 显示当前位置
            LTSMC.smc_get_position_unit(CardNo, axis[2], ref pos); // 获取2号轴当前指令位置
            textBoxZPos.Text = pos.ToString(); // 显示当前位置
        }

        //以下是画画事件
        private void drawButton_Click (object sender, EventArgs e) {
            pictureBox1.Size = new Size(360, 150);
            mouseDown = 1;
            Graphics g = pictureBox1.CreateGraphics(); // 创建Graphics对象
            g.Clear(Color.White); // 画布清零

        }
        private void pictureBox1_MouseDown (object sender, MouseEventArgs e) {
            // 画画按钮打开时才可以画画
            if (e.Button == MouseButtons.Left && mouseDown == 1) {
                x1 = e.X; // 获取鼠标左键按下时的坐标
                y1 = e.Y;
                mouseDown = 2; // 鼠标左键按下标识为1
            }
        }
        private void pictureBox1_MouseMove (object sender, MouseEventArgs e) {
            // 鼠标左键按下后的移动
            if (mouseDown == 2) {

                Graphics g = pictureBox1.CreateGraphics();
                Pen WhitePen = new Pen(Color.White);
                Pen RedPen = new Pen(Color.Red);

                //擦除上次画的线
                g.DrawLine(WhitePen, x0, y0, x0 + width, y0 + height);
                width = e.X - x1; // 计算鼠标左键按下后移动的距离
                height = e.Y - y1;
                g.DrawLine(RedPen, x1, y1, e.X, e.Y);
                //Console.WriteLine(x1 + "-" + y1);
                x0 = x1; y0 = y1;
            }
        }
        private void pictureBox1_MouseUp (object sender, MouseEventArgs e) {
            // 鼠标左键抬起
            if (e.Button == MouseButtons.Left) {
                x2 = e.X;// 获取鼠标左键抬起时的坐标
                y2 = e.Y;
                mouseDown = 1; // 鼠标左键按下标识为0
                xPos[countLines] = x1;
                yPos[countLines] = y1;
                countLines++;
                xPos[countLines] = x2;
                yPos[countLines] = y2;
                countLines++;

                //画出保存的线
                Graphics g = pictureBox1.CreateGraphics();
                Pen BluePen = new Pen(Color.Blue);
                g.DrawLine(BluePen, x1, y1, x2, y2);
            }

        }
        private void doDrawButton_Click (object sender, EventArgs e) {
            mouseDown = 0;
            this.PenUp();
            
            //赋值速度
            LTSMC.smc_set_vector_profile_unit(CardNo, 0, Min_Vel, speed, Tacc, Tdec, Stop_Vel);

            //坐标需要先转换
            for (int i = 0; i < countLines; i++) {
                xPos[i] = ConversionX(xPos[i]);
                yPos[i] = ConversionY(yPos[i]);
            }

            timerDrawTrack.Start();
            for (int i = 0; i < countLines; i++) {
                //x与坐标反向正负相反
                Dist[0] = xPos[i];
                Dist[1] = yPos[i];
                LTSMC.smc_line_unit(0, 0, 2, AxirArray, Dist, 1);
                while (LTSMC.smc_check_done(0, 0) == 0 ||
                    LTSMC.smc_check_done(0, 1) == 0) {
                    Application.DoEvents();
                }
                this.PenDown();
                while (LTSMC.smc_check_done(0, 2) == 0) {
                    Application.DoEvents();
                }

                i++;
                Dist[0] = xPos[i];
                Dist[1] = yPos[i];
                LTSMC.smc_line_unit(0, 0, 2, AxirArray, Dist, 1);
                while (LTSMC.smc_check_done(0, 0) == 0 ||
                    LTSMC.smc_check_done(0, 1) == 0) {
                    Application.DoEvents();
                }

                this.PenUp();
                while (LTSMC.smc_check_done(0, 2) == 0) {
                    Application.DoEvents();
                }
            }
            //执行完关闭定时器
            timerDrawTrack.Stop();
        }

        //画画显示位置
        private void timerDrawTrack_Tick (object sender, EventArgs e) {
            double positionX = 0, positionX0 = 0;
            double positionY = 0, positionY0 = 0;
            int temp1, temp2;

            Graphics g = pictureBox1.CreateGraphics(); // 创建Graphics对象
            
            Pen RedPen = new Pen(Color.Red, 2.0f);

            LTSMC.smc_get_position_unit(CardNo, 0, ref positionX); // 读X轴指令坐标
            LTSMC.smc_get_position_unit(CardNo, 1, ref positionY); // 读Y轴指令坐标
            
            temp1 = Convert.ToInt32(positionX);
            temp2 = Convert.ToInt32(positionY);

            //落笔时才画
            if (penUpFlag == 1) { 
                g.DrawLine(RedPen, this.ConversionX(temp1, 1), this.ConversionY(temp2, 1),
                this.ConversionX(temp1, 1) + 1, this.ConversionY(temp2, 1) + 1);
                LTSMC.smc_write_outbit(0, 60, 0);//落笔打开激光
                //textBoxLaser.Text = "Laser: OPEN";
            }
            else {
                LTSMC.smc_write_outbit(0, 60, 1);//抬笔时关闭激光
                //textBoxLaser.Text = "Laser: CLOSE";
            }

            positionX0 = positionX;
            positionY0 = positionY;
        }

        //画画显示速度函数
        private void timerSpeedCurve_Tick (object sender, EventArgs e) {
            
            double nowVec = 0, xVec = 0, yVec = 0;
            //画布大小400，64
            Graphics g = pictureBox2.CreateGraphics(); // 创建Graphics对象
            
            g.TranslateTransform(0, 50);
            // X轴下移50；Y轴右移200，方向仍朝下

            Pen AliceBluePen = new Pen(Color.AliceBlue, 2.0f);
            Pen BlackPen = new Pen(Color.Black);
            g.DrawLine(BlackPen, 0, 0, 400, 0);//画x轴

            LTSMC.smc_read_current_speed_unit(CardNo, axis[0], ref xVec);
            LTSMC.smc_read_current_speed_unit(CardNo, axis[1], ref yVec);
            nowVec = Math.Sqrt(xVec * xVec + yVec* yVec);
            g.DrawEllipse(AliceBluePen, (float)tim, (float)(-nowVec)*3, 1, 1);
            tim += 0.1;

        }


        //以下是坐标转换
        public int ConversionX (int x=0, int flag=0) {
            if (flag == 0)
                return x * 180 / 360;
            else
                return 360 * x / 180;
        }
        public int ConversionY (int y=0, int flag = 0) {
            if (flag == 0)
                return 75 - y * 75 / 150;
            else
                return (75 - y) * 150 / 75;
        }

        //以下是抬笔和落笔
        private void PenUp () {
            LTSMC.smc_set_profile_unit(CardNo, axis[2], Min_Vel, speed + 10, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[2], 0, S_para);
            LTSMC.smc_pmove_unit(0, axis[2], 8, 1);
            penUpFlag = 0;
        }
        private void PenDown () {
            LTSMC.smc_set_profile_unit(CardNo, axis[2], Min_Vel, speed + 10, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[2], 0, S_para);
            LTSMC.smc_pmove_unit(0, axis[2], 0, 1);
            penUpFlag = 1;
        }

        //以下是鼠标点击XYZ事件 点位运动
        private void xMovRelative_Click (object sender, EventArgs e) {
            double pos = double.Parse(textBoxPos.Text);
            LTSMC.smc_set_profile_unit(CardNo, axis[0], Min_Vel, speed, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[0], 0, S_para);
            LTSMC.smc_pmove_unit(0, axis[0], pos, 0);
        }
        private void yMovRelative_Click (object sender, EventArgs e) {
            double pos = double.Parse(textBoxPos.Text);
            LTSMC.smc_set_profile_unit(CardNo, axis[1], Min_Vel, speed, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[1], 0, S_para);
            LTSMC.smc_pmove_unit(0, axis[1], pos, 0);
        }
        private void zMovRelative_Click (object sender, EventArgs e) {
            double pos = double.Parse(textBoxPos.Text);
            LTSMC.smc_set_profile_unit(CardNo, axis[2], Min_Vel, speed, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[2], 0, S_para);
            LTSMC.smc_pmove_unit(0, axis[2], pos, 0);
        }

        //以下是鼠标点击XYZ事件 恒速运动
        private void xMovPostive_MouseDown (object sender, MouseEventArgs e) {
            LTSMC.smc_set_profile_unit(CardNo, axis[0], Min_Vel, speed, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[0], 0, S_para);
            LTSMC.smc_vmove(CardNo, axis[0], 1);//控制器号, 轴号,方向
        }


        private void xMovPostive_MouseUp (object sender, MouseEventArgs e) {
            LTSMC.smc_stop(CardNo, axis[0], 1);
            LTSMC.smc_stop(CardNo, axis[1], 1);
            LTSMC.smc_stop(CardNo, axis[2], 1);
        }
        private void xMovNegative_MouseDown (object sender, MouseEventArgs e) {
            LTSMC.smc_set_profile_unit(CardNo, axis[0], Min_Vel, speed, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[0], 0, S_para);
            LTSMC.smc_vmove(CardNo, axis[0], 0);//控制器号, 轴号,方向
        }
        private void xMovNegative_MouseUp (object sender, MouseEventArgs e) {
            LTSMC.smc_stop(CardNo, axis[0], 1);
            LTSMC.smc_stop(CardNo, axis[1], 1);
            LTSMC.smc_stop(CardNo, axis[2], 1);
        }
        private void yMovPostive_MouseDown (object sender, MouseEventArgs e) {
            LTSMC.smc_set_profile_unit(CardNo, axis[1], Min_Vel, speed, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[1], 0, S_para);
            LTSMC.smc_vmove(CardNo, axis[1], 1);//控制器号, 轴号,方向
        }
        private void yMovPostive_MouseUp (object sender, MouseEventArgs e) {
            LTSMC.smc_stop(CardNo, axis[0], 1);
            LTSMC.smc_stop(CardNo, axis[1], 1);
            LTSMC.smc_stop(CardNo, axis[2], 1);
        }
        private void yMovNegative_MouseDown (object sender, MouseEventArgs e) {
            LTSMC.smc_set_profile_unit(CardNo, axis[1], Min_Vel, speed, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[1], 0, S_para);
            LTSMC.smc_vmove(CardNo, axis[1], 0);//控制器号, 轴号,方向
        }
        private void yMovNegative_MouseUp (object sender, MouseEventArgs e) {
            LTSMC.smc_stop(CardNo, axis[0], 1);
            LTSMC.smc_stop(CardNo, axis[1], 1);
            LTSMC.smc_stop(CardNo, axis[2], 1);
        }
        private void zMovPostive_MouseDown (object sender, MouseEventArgs e) {
            LTSMC.smc_set_profile_unit(CardNo, axis[2], Min_Vel, speed, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[2], 0, S_para);
            LTSMC.smc_vmove(CardNo, axis[2], 1);//控制器号, 轴号,方向
        }
        private void zMovPostive_MouseUp (object sender, MouseEventArgs e) {
            LTSMC.smc_stop(CardNo, axis[0], 1);
            LTSMC.smc_stop(CardNo, axis[1], 1);
            LTSMC.smc_stop(CardNo, axis[2], 1);
        }
        private void zMovNegative_MouseDown (object sender, MouseEventArgs e) {
            LTSMC.smc_set_profile_unit(CardNo, axis[2], Min_Vel, speed, Tacc, Tdec, Stop_Vel);
            LTSMC.smc_set_s_profile(CardNo, axis[2], 0, S_para);
            LTSMC.smc_vmove(CardNo, axis[2], 0);//控制器号, 轴号,方向
        }
        private void zMovNegative_MouseUp (object sender, MouseEventArgs e) {
            LTSMC.smc_stop(CardNo, axis[0], 1);
            LTSMC.smc_stop(CardNo, axis[1], 1);
            LTSMC.smc_stop(CardNo, axis[2], 1);
        }
    }

}


