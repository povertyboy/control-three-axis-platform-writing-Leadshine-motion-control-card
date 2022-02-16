using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Leadshine
{
    public partial class LTSMC
    {
        /*********************************************************************************************************
       功能函数 
       ***********************************************************************************************************/
        //板卡配置	
        [DllImport("LTSMC.dll")]
        public static extern short smc_board_init(ushort ConnectNo, ushort ConnectType, string pconnectstring, uint baud);
        [DllImport("LTSMC.dll")]
        public static extern short smc_board_init_ex(ushort ConnectNo, ushort type, string pconnectstring, uint dwBaudRate, uint dwByteSize, uint dwParity, uint dwStopBits);
        [DllImport("LTSMC.dll")]
        public static extern short smc_board_close(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_CardInfList(ref ushort CardNum, uint[] CardTypeList, ushort[] ConnectTypeList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_card_version(ushort ConnectNo, ref uint CardVersion);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_card_soft_version(ushort ConnectNo, ref uint FirmID, ref uint SubFirmID);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_release_version(ushort ConnectNo, byte[] ReleaseVersion);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_card_lib_version(ref uint LibVer);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_total_axes(ushort ConnectNo, ref uint TotalAxis); 	//读取指定卡轴数
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_total_ionum(ushort ConnectNo, ref ushort TotalIn, ref ushort TotalOut);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_total_adcnum(ushort ConnectNo, ref ushort TotalIn, ref ushort TotalOut);

        [DllImport("LTSMC.dll")]
        public static extern short smc_get_total_liners(ushort ConnectNo, ref uint TotalLiner);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_debug_mode(ushort mode, char[] FileName);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_debug_mode(ref ushort mode, char[] FileName);
        [DllImport("LTSMC.dll")]
        public static extern short smc_format_flash(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ipaddr(ushort ConnectNo, byte[] IpAddr);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ipaddr(ushort ConnectNo, byte[] IpAddr);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_com(ushort ConnectNo, ushort com, uint dwBaudRate, ushort wByteSize, ushort wParity, ushort wStopBits);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_com(ushort ConnectNo, ushort com, ref uint dwBaudRate, ref ushort wByteSize, ref ushort wParity, ref ushort dwStopBits);

        //序列号
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_sn(ushort ConnectNo, UInt64 sn);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_sn(ushort ConnectNo, ref UInt64 sn);
        //加密
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_password(ushort ConnectNo, string str_pass);
        [DllImport("LTSMC.dll")]
        public static extern short smc_check_password(ushort ConnectNo, string str_pass);

        //脉冲模式		
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_pulse_outmode(ushort ConnectNo, ushort axis, ushort outmode);	//设定脉冲输出模式
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_pulse_outmode(ushort ConnectNo, ushort axis, ref ushort outmode);	//读取脉冲输出模式
        //脉冲当量
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_equiv(ushort ConnectNo, ushort axis, double equiv);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_equiv(ushort ConnectNo, ushort axis, ref double equiv);
        //反向间隙
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_backlash_unit(ushort ConnectNo, ushort axis, double backlash);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_backlash_unit(ushort ConnectNo, ushort axis, ref double backlash);
        //编码器		
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_counter_inmode(ushort ConnectNo, ushort axis, ushort mode);	//设定编码器的计数方式
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_counter_inmode(ushort ConnectNo, ushort axis, ref ushort mode);	//读取编码器的计数方式
        [DllImport("LTSMC.dll")]
        public static extern int smc_get_encoder(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_encoder(ushort ConnectNo, ushort axis, int encoder_value);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ez_mode(ushort ConnectNo, ushort axis, ushort ez_logic, ushort ez_mode, double filter);	//设置EZ信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ez_mode(ushort ConnectNo, ushort axis, ref ushort ez_logic, ref ushort ez_mode, ref double filter);	//读取设置EZ信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_counter_reverse(ushort ConnectNo, ushort axis, ushort reverse);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_counter_reverse(ushort ConnectNo, ushort axis, ref ushort reverse);
        //辅助编码器
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_extra_encoder(ushort ConnectNo, ushort axis, int pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_extra_encoder(ushort ConnectNo, ushort axis, ref int pos);
        //单轴速度参数
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_profile_unit(ushort ConnectNo, ushort axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_profile_unit(ushort ConnectNo, ushort axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_s_profile(ushort ConnectNo, ushort axis, ushort s_mode, double s_para);	//设置平滑速度曲线参数
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_s_profile(ushort ConnectNo, ushort axis, ushort s_mode, ref double s_para);	//读取平滑速度曲线参数 兼容DMC5800 s_mode改用指针返回参数值
        //单轴运动
        [DllImport("LTSMC.dll")]
        public static extern short smc_pmove_unit(ushort ConnectNo, ushort axis, double Dist, ushort posi_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_vmove(ushort ConnectNo, ushort axis, ushort dir);	//指定轴做连续运动
        [DllImport("LTSMC.dll")]
        public static extern short smc_change_speed(ushort ConnectNo, ushort axis, double Curr_Vel, double Taccdec);	//在线改变指定轴的当前运动速度
        //正弦曲线定长运动
        [DllImport("LTSMC.dll")]
        public static extern short smc_sine_oscillate_unit(ushort ConnectNo,ushort axis,double Amplitude,double Frequency);//正弦曲线定长运动
        [DllImport("LTSMC.dll")]
        public static extern short smc_sine_oscillate_stop(ushort ConnectNo,ushort axis);//正弦曲线停止，停止在中心位置
        //回零运动	
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_home_pin_logic(ushort ConnectNo, ushort axis, ushort org_logic, double filter); 	//设置HOME信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_home_pin_logic(ushort ConnectNo, ushort axis, ref ushort org_logic, ref double filter); 	//读取设置HOME信号       
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_home_profile_unit(ushort ConnectNo, ushort axis, double Low_Vel, double High_Vel, double Tacc, double Tdec);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_home_profile_unit(ushort ConnectNo, ushort axis, ref double Low_Vel, ref double High_Vel, ref double Tacc, ref double Tdec);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ez_count(ushort ConnectNo, ushort axis, ushort ez_count);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ez_count(ushort ConnectNo, ushort axis, ref ushort ez_count);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_homemode(ushort ConnectNo, ushort axis, ushort home_dir, double vel_mode, ushort mode, ushort pos_source);//设定指定轴的回原点模式
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_homemode(ushort ConnectNo, ushort axis, ref ushort home_dir, ref double vel_mode, ref ushort home_mode, ref ushort pos_source);//读取指定轴的回原点模式
        [DllImport("LTSMC.dll")]
        public static extern short smc_home_move(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_home_result(ushort ConnectNo, ushort axis, ref ushort state);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_home_position_unit(ushort ConnectNo, ushort axis, ushort enable, double position);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_home_position_unit(ushort ConnectNo, ushort axis, ref ushort enable, ref double position);
        //手轮运动(旧)
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_handwheel_channel(ushort CardNo, ushort index);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_handwheel_channel(ushort CardNo, ref ushort index);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_handwheel_inmode(ushort CardNo, ushort axis, ushort inmode, int multi, double vh);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_handwheel_inmode(ushort CardNo, ushort axis, ref ushort inmode, ref int multi, ref double vh);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_handwheel_inmode_extern(ushort CardNo, ushort inmode, ushort AxisNum, ushort[] AxisList, int[] multi);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_handwheel_inmode_extern(ushort CardNo, ref ushort inmode, ref ushort AxisNum, ushort[] AxisList, int[] multi);
        //[DllImport("LTSMC.dll")]
        //public static extern short smc_handwheel_move(ushort CardNo, ushort axis);
        //手轮运动
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_set_axislist(ushort ConnectNo, ushort AxisSelIndex, ushort AxisNum, ushort[] AxisList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_get_axislist(ushort ConnectNo, ushort AxisSelIndex, ref ushort AxisNum, ushort[] AxisList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_set_ratiolist(ushort ConnectNo, ushort AxisSelIndex, ushort StartRatioIndex, ushort RatioSelNum, double[] RatioList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_get_ratiolist(ushort ConnectNo, ushort AxisSelIndex, ushort StartRatioIndex, ushort RatioSelNum, double[] RatioList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_set_mode(ushort ConnectNo, ushort InMode, ushort IfHardEnable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_get_mode(ushort ConnectNo, ref ushort InMode, ref ushort IfHardEnable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_set_index(ushort ConnectNo, ushort AxisSelIndex, ushort RatioSelIndex);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_get_index(ushort ConnectNo, ref ushort AxisSelIndex, ref ushort RatioSelIndex);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_move(ushort ConnectNo, ushort ForceMove);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_stop(ushort ConnectNo);
        //原点锁存
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_homelatch_mode(ushort ConnectNo, ushort axis, ushort enable, ushort logic, ushort source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_homelatch_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort logic, ref ushort source);
        [DllImport("LTSMC.dll")]
        public static extern int smc_get_homelatch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_reset_homelatch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_homelatch_value_unit(ushort ConnectNo, ushort axis, ref double value);
        //EZ锁存
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ezlatch_mode(ushort ConnectNo, ushort axis, ushort enable, ushort logic, ushort source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ezlatch_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort logic, ref ushort source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ezlatch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_reset_ezlatch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ezlatch_value_unit(ushort ConnectNo, ushort axis, ref double pos_by_mm);
        //高速锁存(旧)
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ltc_mode(ushort ConnectNo, ushort axis, ushort ltc_logic, ushort ltc_mode, double filter); 	//设置LTC信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ltc_mode(ushort ConnectNo, ushort axis, ref ushort ltc_logic, ref ushort ltc_mode, ref double filter);	//读取设置LTC信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_latch_mode(ushort ConnectNo, ushort axis, ushort latchmode, ushort latch_source, ushort latch_channel); 	//设置锁存方式
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_latch_mode(ushort ConnectNo, ushort axis, ref ushort latchmode, ref ushort latch_source, ref ushort latch_channel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_SetLtcOutMode(ushort ConnectNo, ushort axis, ushort enable, ushort bitno);//反相输出
        [DllImport("LTSMC.dll")]
        public static extern short smc_GetLtcOutMode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort bitno);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_latch_flag(ushort ConnectNo, ushort axis); 	//读取锁存器标志
        [DllImport("LTSMC.dll")]
        public static extern short smc_reset_latch_flag(ushort ConnectNo, ushort axis); 	//复位锁存器标志
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_latch_value_unit(ushort ConnectNo, ushort axis, ref double value); 	//读取编码器锁存器的值
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_latch_flag_extern(ushort ConnectNo, ushort axis); 	//读取锁存器标志
        [DllImport("LTSMC.dll")]
        public static extern int smc_get_latch_value_extern(ushort ConnectNo, ushort axis, ushort index); //按索引取值
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_latch_stop_time(ushort ConnectNo, ushort axis, int time); //触发急停时间
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_latch_stop_time(ushort ConnectNo, ushort axis, ref int time);
        //高速锁存(新)
        [DllImport("LTSMC.dll")]
        public static extern short smc_ltc_set_mode(ushort ConnectNo, ushort latch, ushort ltc_mode, ushort ltc_logic, double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_ltc_get_mode(ushort ConnectNo, ushort latch, ref ushort ltc_mode, ref ushort ltc_logic, ref double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_ltc_set_source(ushort ConnectNo, ushort latch, ushort axis, ushort ltc_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_ltc_get_source(ushort ConnectNo, ushort latch, ushort axis, ref ushort ltc_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_ltc_reset(ushort ConnectNo, ushort latch);
        [DllImport("LTSMC.dll")]
        public static extern short smc_ltc_get_number(ushort ConnectNo, ushort latch, ushort axis, ref int number);
        [DllImport("LTSMC.dll")]
        public static extern short smc_ltc_get_value_unit(ushort ConnectNo, ushort latch, ushort axis, ref double value);
        //软锁存
        [DllImport("LTSMC.dll")]
        public static extern short smc_softltc_set_mode(ushort ConnectNo, ushort latch, ushort ltc_enable, ushort ltc_mode, ushort ltc_inbit, ushort ltc_logic, double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_softltc_get_mode(ushort ConnectNo, ushort latch, ref ushort ltc_enable, ref ushort ltc_mode, ref ushort ltc_inbit, ref ushort ltc_logic, ref double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_softltc_set_source(ushort ConnectNo, ushort latch, ushort axis, ushort ltc_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_softltc_get_source(ushort ConnectNo, ushort latch, ushort axis, ref ushort ltc_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_softltc_reset(ushort ConnectNo, ushort latch);
        [DllImport("LTSMC.dll")]
        public static extern short smc_softltc_get_number(ushort ConnectNo, ushort latch, ushort axis, ref int number);
        [DllImport("LTSMC.dll")]
        public static extern short smc_softltc_get_value_unit(ushort ConnectNo, ushort latch, ushort axis, ref double value);
        //PVT运动
        [DllImport("LTSMC.dll")]
        public static extern short smc_pvt_table_unit(ushort ConnectNo, ushort iaxis, uint count, double[] pTime, double[] pPos, double[] pVel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_pts_table_unit(ushort ConnectNo, ushort iaxis, uint count, double[] pTime, double[] pPos, double[] pPercent);
        [DllImport("LTSMC.dll")]
        public static extern short smc_pvts_table_unit(ushort ConnectNo, ushort iaxis, uint count, double[] pTime, double[] pPos, double velBegin, double velEnd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_ptt_table_unit(ushort ConnectNo, ushort iaxis, uint count, double[] pTime, double[] pPos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_pvt_move(ushort ConnectNo, ushort AxisNum, ushort[] AxisList);
        //安全机制
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_el_mode(ushort ConnectNo, ushort axis, ushort enable, ushort el_logic, ushort el_mode); 	//设置EL信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_el_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort el_logic, ref ushort el_mode); 	//读取设置EL信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_emg_mode(ushort ConnectNo, ushort axis, ushort enable, ushort emg_logic); 	//设置EMG信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_emg_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort emg_logic); 	//读取设置EMG信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_softlimit_unit(ushort ConnectNo, ushort axis, ushort enable, ushort source_sel, ushort SL_action, double N_limit, double P_limit);	//设置软限位参数
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_softlimit_unit(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort source_sel, ref ushort SL_action, ref double N_limit, ref double P_limit);	//读取软限位参数
        //轴IO映射
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_axis_io_map(ushort ConnectNo, ushort Axis, ushort IoType, ushort MapIoType, ushort MapIoIndex, double Filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_axis_io_map(ushort ConnectNo, ushort Axis, ushort IoType, ref ushort MapIoType, ref ushort MapIoIndex, ref double Filter);
        //状态监控
        [DllImport("LTSMC.dll")]
        public static extern short smc_check_done(ushort ConnectNo, ushort axis);	//读取指定轴的运动状态
        [DllImport("LTSMC.dll")]
        public static extern short smc_stop(ushort ConnectNo, ushort axis, ushort stop_mode);	//单轴停止
        [DllImport("LTSMC.dll")]
        public static extern short smc_emg_stop(ushort ConnectNo);	//紧急停止所有轴       
        [DllImport("LTSMC.dll")]
        public static extern short smc_check_done_multicoor(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_stop_multicoor(ushort ConnectNo, ushort Crd, ushort stop_mode);
        [DllImport("LTSMC.dll")]
        public static extern uint smc_axis_io_status(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern uint smc_axis_io_enable_status(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_axis_run_mode(ushort ConnectNo, ushort axis, ref ushort run_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_current_speed_unit(ushort ConnectNo, ushort axis, ref double current_speed);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_position_unit(ushort ConnectNo, ushort axis, double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_position_unit(ushort ConnectNo, ushort axis, ref double pos);
        [DllImport("LTSMC.dll")]
        public static extern int smc_get_target_position_unit(ushort ConnectNo, ushort axis, ref double pos);	//读取指定轴的目标位置
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_workpos_unit(ushort ConnectNo, ushort axis, double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_workpos_unit(ushort ConnectNo, ushort axis, ref double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_stop_reason(ushort ConnectNo, ushort axis, ref int StopReason);
        [DllImport("LTSMC.dll")]
        public static extern short smc_clear_stop_reason(ushort ConnectNo, ushort axis);
        //通用IO		
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_inbit(ushort ConnectNo, ushort bitno); 	//读取输入口的状态
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_outbit(ushort ConnectNo, ushort bitno, ushort on_off); 	//设置输出口的状态
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_outbit(ushort ConnectNo, ushort bitno);  	//读取输出口的状态
        [DllImport("LTSMC.dll")]
        public static extern uint smc_read_inport(ushort ConnectNo, ushort portno); 	//读取输入端口的值
        [DllImport("LTSMC.dll")]
        public static extern uint smc_read_outport(ushort ConnectNo, ushort portno); 	//读取输出端口的值
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_outport(ushort ConnectNo, ushort portno, uint outport_val);  	//设置输出端口的值
        [DllImport("LTSMC.dll")]
        public static extern short smc_reverse_outbit(ushort ConnectNo, ushort bitno, double reverse_time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_io_count_mode(ushort ConnectNo, ushort bitno, ushort mode, double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_io_count_mode(ushort ConnectNo, ushort bitno, ref ushort mode, ref double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_io_count_value(ushort ConnectNo, ushort bitno, uint CountValue);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_io_count_value(ushort ConnectNo, ushort bitno, ref uint CountValue);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_io_dstp_mode(ushort ConnectNo, ushort axis, ushort enable, ushort logic); 	//enable:0-禁用，1-按时间减速停止，2-按距离减速停止
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_io_dstp_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort logic);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_dec_stop_time(ushort ConnectNo, ushort axis, double time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_dec_stop_time(ushort ConnectNo, ushort axis, ref double time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_io_pwmoutput(ushort ConnectNo, ushort outbit, double time1, double time2, uint counts);//设置IO输出一定脉冲个数的PWM波形曲线
        [DllImport("LTSMC.dll")]
        public static extern short smc_clear_io_pwmoutput(ushort ConnectNo, ushort outbit);//清除IO输出PWM波形曲线
        //专用IO操作
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_alm_mode(ushort ConnectNo, ushort axis, ushort enable, ushort alm_logic, ushort alm_action);	//设置ALM信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_alm_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort alm_logic, ref ushort alm_action);	//读取设置ALM信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_inp_mode(ushort ConnectNo, ushort axis, ushort enable, ushort inp_logic);	//设置INP信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_inp_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort inp_logic);	//读取设置INP信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_rdy_mode(ushort ConnectNo, ushort axis, ushort enable, ushort rdy_logic);	//设置RDY信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_rdy_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort rdy_logic);	//读取设置RDY信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_erc_mode(ushort ConnectNo, ushort axis, ushort enable, ushort erc_logic, ushort erc_width, ushort erc_off_time);	//设置ERC信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_erc_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort erc_logic, ref ushort erc_width, ref ushort erc_off_time);	//读取设置ERC信号

        [DllImport("LTSMC.dll")]
        public static extern short smc_write_sevon_pin(ushort ConnectNo, ushort axis, ushort on_off); 	//输出SEVON信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_sevon_pin(ushort ConnectNo, ushort axis); 	//读取SEVON信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_rdy_pin(ushort ConnectNo, ushort axis); 	//读取RDY状态
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_erc_pin(ushort ConnectNo, ushort axis, ushort on_off); 	//控制ERC信号输出
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_erc_pin(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_sevrst_pin(ushort ConnectNo, ushort axis, ushort on_off); 	//输出伺服复位信号
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_sevrst_pin(ushort ConnectNo, ushort axis); 	//读伺服复位信号

        [DllImport("LTSMC.dll")]
        public static extern short smc_set_dstp_mode(ushort ConnectNo, ushort axis, ushort enable, ushort logic, uint time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_dstp_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort logic, ref uint time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_dstp_time(ushort ConnectNo, ushort axis, uint time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_dstp_time(ushort ConnectNo, ushort axis, ref uint time);

        [DllImport("LTSMC.dll")]
        public static extern short smc_set_io_dstp_bitno(ushort ConnectNo, ushort axis, ushort bitno, double filter); 	//设置通用输入口的一位位减速停止IO口
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_io_dstp_bitno(ushort ConnectNo, ushort axis, ref ushort bitno, ref double filter);
        //插补参数设置
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_profile_unit(ushort ConnectNo, ushort Crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_vector_profile_unit(ushort ConnectNo, ushort Crd, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_tacc(ushort ConnectNo, ushort Crd, double Tacc);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_acc(ushort ConnectNo, ushort Crd, double acc);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_speed_unit(ushort ConnectNo, ushort Crd, double Max_vel);

        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_s_profile(ushort ConnectNo, ushort Crd, ushort s_mode, double s_para);	//设置平滑速度曲线参数
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_vector_s_profile(ushort ConnectNo, ushort Crd, ushort s_mode, ref double s_para);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_dec_stop_time(ushort ConnectNo, ushort Crd, double time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_vector_dec_stop_time(ushort ConnectNo, ushort Crd, ref double time);

        //单段插补       
        [DllImport("LTSMC.dll")]
        public static extern short smc_line_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Dist, ushort posi_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_arc_move_center_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, int Circle, ushort posi_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_arc_move_radius_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double Arc_Radius, ushort Arc_Dir, int Circle, ushort posi_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_arc_move_3points_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, int Circle, ushort posi_mode);
        //连续插补
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_open_list(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList);	//打开连续缓存区
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_close_list(ushort ConnectNo, ushort Crd);	//关闭连续缓存区
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_stop_list(ushort ConnectNo, ushort Crd, ushort stop_mode);	//连续插补中停止
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_pause_list(ushort ConnectNo, ushort Crd);	//连续插补中暂停
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_start_list(ushort ConnectNo, ushort Crd);	//开始连续插补
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_check_done(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_run_state(ushort ConnectNo, ushort Crd);//0-运行，1-暂停，2-正常停止，3-未启动，4-空闲
        [DllImport("LTSMC.dll")]
        public static extern int smc_conti_remain_space(ushort ConnectNo, ushort Crd);	//查连续插补剩余缓存数
        [DllImport("LTSMC.dll")]
        public static extern int smc_conti_read_current_mark(ushort ConnectNo, ushort Crd);	//读取当前连续插补段的标号
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_change_speed_ratio(ushort ConnectNo, ushort Crd, double percent);	//设置插补中动态变速
        //Blend模式
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_blend(ushort ConnectNo, ushort Crd, ushort enable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_blend(ushort ConnectNo, ushort Crd, ref ushort enable);
        //小线段前瞻
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_lookahead_mode(ushort ConnectNo, ushort Crd, ushort enable, int LookaheadSegments, double PathError, double LookaheadAcc);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_lookahead_mode(ushort ConnectNo, ushort Crd, ref ushort enable, ref int LookaheadSegments, ref double PathError, ref double LookaheadAcc);
        //设置每段速度
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_taccdec(ushort ConnectNo, ushort Crd, double Taccdec);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_speed_unit(ushort ConnectNo, ushort Crd, double Max_vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_override(ushort ConnectNo, ushort Crd, double Percent);
        //连续插补IO
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_wait_input(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double TimeOut, int mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_delay_outbit_to_start(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double delay_value, ushort delay_mode, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_delay_outbit_to_stop(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double delay_time, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_ahead_outbit_to_stop(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double ahead_value, ushort ahead_mode, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_accurate_outbit_unit(ushort ConnectNo, ushort Crd, ushort cmp_no, ushort on_off, ushort axis, double abs_pos, ushort pos_source, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_write_outbit(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_clear_io_action(ushort ConnectNo, ushort Crd, uint Io_Mask);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_pause_output(ushort ConnectNo, ushort Crd, ushort action, int mask, int state);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_pause_output(ushort ConnectNo, ushort Crd, ref ushort action, ref int mask, ref int state);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_delay(ushort ConnectNo, ushort Crd, double delay_time, int mark);//延时指令
        //连续插补轨迹
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_line_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] pPosList, ushort posi_mode, int mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_arc_move_center_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, int Circle, ushort posi_mode, int mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_arc_move_radius_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double Arc_Radius, ushort Arc_Dir, int Circle, ushort posi_mode, int mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_arc_move_3points_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, int Circle, ushort posi_mode, int mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_pmove_unit(ushort ConnectNo, ushort Crd, ushort axis, double dist, ushort posi_mode, ushort mode, int imark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_involute_mode(ushort ConnectNo, ushort Crd, ushort mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_involute_mode(ushort ConnectNo, ushort Crd, ref ushort mode);
        //二维位置比较提前输出，读取相对于起点的距离
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_distance_to_start(ushort ConnectNo,ushort Crd,ref double distance_x,ref double distance_y,int imark);
        //二维位置比较提前输出，设置标志位，表示是否开始计算相对起点
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_start_distance_flag(ushort ConnectNo, ushort Crd, ushort flag);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_start_distance_flag(ushort ConnectNo, ushort Crd, ref ushort flag);
        //连续插补PWM
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_pwm_output(ushort ConnectNo, ushort Crd, ushort PwmNo, double fDuty, double fFre);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_pwm_follow_speed(ushort ConnectNo, ushort Crd, ushort pwm_no, ushort mode, double MaxVel, double MaxValue, double OutValue);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_pwm_follow_speed(ushort ConnectNo, ushort Crd, ushort pwm_no, ref ushort mode, ref double MaxVel, ref double MaxValue, ref double OutValue);
        //设置PWM开关对应的占空比
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_pwm_onoff_duty(ushort ConnectNo, ushort PwmNo, double fOnDuty, double fOffDuty);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_pwm_onoff_duty(ushort ConnectNo, ushort PwmNo, ref double fOnDuty, ref double fOffDuty);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_delay_pwm_to_start(ushort ConnectNo, ushort Crd, ushort pwmno, ushort on_off, double delay_value, ushort delay_mode, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_delay_pwm_to_stop(ushort ConnectNo, ushort Crd, ushort pwmno, ushort on_off, double delay_time, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_ahead_pwm_to_stop(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double ahead_value, ushort ahead_mode, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_write_pwm(ushort ConnectNo, ushort Crd, ushort pwmno, ushort on_off, double ReverseTime);
        //PWM功能
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_pwm_enable(ushort ConnectNo, ushort enable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_pwm_enable(ushort ConnectNo, ref ushort enable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_pwm_output(ushort ConnectNo, ushort PwmNo, double fDuty, double fFre);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_pwm_output(ushort ConnectNo, ushort PwmNo, ref double fDuty, ref double fFre);
        //位置比较
        //单轴位置比较		
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_set_config(ushort ConnectNo, ushort axis, ushort enable, ushort cmp_source); 	//配置比较器
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_config(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort cmp_source);	//读取配置比较器
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_clear_points(ushort ConnectNo, ushort axis); 	//清除所有比较点
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_add_point_unit(ushort ConnectNo, ushort axis, double pos, ushort dir, ushort action, uint actpara); 	//添加比较点
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_current_point_unit(ushort ConnectNo, ushort axis, ref double pos); 	//读取当前比较点
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_points_runned(ushort ConnectNo, ushort axis, ref int pointNum); 	//查询已经比较过的点
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_points_remained(ushort ConnectNo, ushort axis, ref int pointNum); 	//查询可以加入的比较点数量
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_add_point_cycle(ushort CardNo, ushort cmp, int pos, ushort dir, uint bitno, uint cycle, ushort level);

        //二维位置比较
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_set_config_extern(ushort ConnectNo, ushort enable, ushort cmp_source); 	//配置比较器
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_config_extern(ushort ConnectNo, ref ushort enable, ref ushort cmp_source);	//读取配置比较器
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_clear_points_extern(ushort ConnectNo); 	//清除所有比较点
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_add_point_extern_unit(ushort ConnectNo, ushort[] axis, double[] pos, ushort[] dir, ushort action, uint actpara); 	//添加两轴位置比较点
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_current_point_extern_unit(ushort ConnectNo, double[] pos); 	//读取当前比较点
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_points_runned_extern(ushort ConnectNo, ref int pointNum); 	//查询已经比较过的点
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_points_remained_extern(ushort ConnectNo, ref int pointNum); 	//查询可以加入的比较点数量

        //高速位置比较
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_set_mode(ushort ConnectNo, ushort hcmp, ushort cmp_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_get_mode(ushort ConnectNo, ushort hcmp, ref ushort cmp_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_set_config(ushort ConnectNo, ushort hcmp, ushort axis, ushort cmp_source, ushort cmp_logic, int time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_get_config(ushort ConnectNo, ushort hcmp, ref ushort axis, ref ushort cmp_source, ref ushort cmp_logic, ref int time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_add_point_unit(ushort ConnectNo, ushort hcmp, double cmp_pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_set_liner_unit(ushort ConnectNo, ushort hcmp, double Increment, int Count);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_get_liner_unit(ushort ConnectNo, ushort hcmp, ref double Increment, ref int Count);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_get_current_state_unit(ushort ConnectNo, ushort hcmp, ref int remained_points, ref double current_point, ref int runned_points);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_clear_points(ushort ConnectNo, ushort hcmp);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_cmp_pin(ushort ConnectNo, ushort hcmp);
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_cmp_pin(ushort ConnectNo, ushort hcmp, ushort on_off);
        //高速二维位置比较
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_set_enable(ushort ConnectNo, ushort hcmp, ushort cmp_enable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_get_enable(ushort ConnectNo, ushort hcmp, ref ushort cmp_enable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_set_config_unit(ushort ConnectNo, ushort hcmp, ushort cmp_mode, ushort x_axis, ushort x_cmp_source, double x_cmp_error, ushort y_axis, ushort y_cmp_source, double y_cmp_error, ushort cmp_logic, int time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_get_config_unit(ushort ConnectNo, ushort hcmp, ref ushort cmp_mode, ref ushort x_axis, ref ushort x_cmp_source, ref double x_cmp_error, ref ushort y_axis, ref ushort y_cmp_source, ref double y_cmp_error, ref ushort cmp_logic, ref int time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_set_pwmoutput(ushort ConnectNo, ushort hcmp, ushort pwm_enable, double duty, double freq, ushort pwm_number);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_get_pwmoutput(ushort ConnectNo, ushort hcmp, ref ushort pwm_enable, ref double duty, ref double freq, ref ushort pwm_number);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_add_point_unit(ushort ConnectNo, ushort hcmp, double x_cmp_pos, double y_cmp_pos, ushort cmp_outbit);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_get_current_state(ushort ConnectNo, ushort hcmp, ref int remained_points, ref double x_current_point, ref double y_current_point, ref int runned_points, ref ushort current_state, ref ushort current_outbit);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_clear_points(ushort ConnectNo, ushort hcmp);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_2d_force_output(ushort ConnectNo, ushort hcmp, ushort outbit);

        //模拟量操作
        //AD
        [DllImport("LTSMC.dll")]
        public static extern double smc_get_ain(ushort ConnectNo, ushort channel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ain_action(ushort ConnectNo, ushort channel, ushort mode, double fvoltage, ushort action, double actpara);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ain_action(ushort ConnectNo, ushort channel, ref ushort mode, ref double fvoltage, ref ushort action, ref double actpara);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ain_state(ushort ConnectNo, ushort channel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ain_state(ushort ConnectNo, ushort channel);
        //DA
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_da_output(ushort ConnectNo, ushort channel, double Vout);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_da_output(ushort ConnectNo, ushort channel, ref double Vout);
        //点胶参数设置
        [DllImport("LTSMC.dll")]
        public static extern short smc_glue_set_profile(ushort ConnectNo, ushort glue, ushort io, ushort on_off, double[] Offset, double[] dist, double[] time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_glue_get_profile(ushort ConnectNo, ushort glue, ref ushort io, ref ushort on_off, double[] Offset, double[] dist, double[] time);
        //文件操作
        [DllImport("LTSMC.dll")]
        public static extern short smc_download_file(ushort CardNo, string pfilename, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_download_memfile(ushort CardNo, byte[] pbuffer, uint buffsize, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_upload_file(ushort CardNo, string pfilename, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_upload_memfile(ushort CardNo, byte[] pbuffer, uint buffsize, byte[] pfilenameinControl, ref uint puifilesize, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_download_file_to_ram(ushort CardNo, string pfilename, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_download_memfile_to_ram(ushort CardNo, byte[] pbuffer, uint buffsize, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_progress(ushort ConnectNo, ref float progress);
        //寄存器操作
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_modbus_0x(ushort CardNo, ushort start, ushort inum, byte[] pdata);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_modbus_0x(ushort CardNo, ushort start, ushort inum, byte[] pdata);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_modbus_4x(ushort CardNo, ushort start, ushort inum, ushort[] pdata);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_modbus_4x(ushort CardNo, ushort start, ushort inum, ushort[] pdata);
        //Basic变量
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_array(ushort CardNo, string name, uint index, long[] var, ref int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_modify_array(ushort CardNo, string name, uint index, long[] var, int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_var(ushort CardNo, string varstring, long[] var, ref int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_modify_var(ushort CardNo, string varstring, long[] var, int varnum);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_array_ex(ushort ConnectNo, string name, uint index, double[] var, ref int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_modify_array_ex(ushort ConnectNo, string name, uint index, double[] var, int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_var_ex(ushort ConnectNo, string varstring, double[] var, ref int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_modify_var_ex(ushort ConnectNo, string varstring, double[] var, int varnum);
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_array_ex(ushort ConnectNo, string name, uint startindex, double[] var, int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_stringtype(ushort CardNo, string varstring, ref int m_Type, ref int num);
        //Basic控制
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_state(ushort CardNo, ref  ushort State);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_run(ushort CardNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_pause(ushort CardNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_stop(ushort CardNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_continue_run(ushort CardNo);
        //Basic调试
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_current_line(ushort CardNo, ref int line);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_break_info(ushort CardNo, int[] line, int linenum);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_step_over(ushort CardNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_step_run(ushort CardNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_message(ushort CardNo, byte[] pbuff, uint uimax, ref uint puiread);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_command(ushort CardNo, byte[] pszCommand, byte[] psResponse, uint uiResponseLength);
        //G代码

        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_start(ushort CardNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_stop(ushort CardNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_pause(ushort CardNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_state(ushort CardNo, ref ushort state);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_clear_file(ushort CardNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_delete_file(ushort CardNo, byte[] pfilenameinControl);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_current_line(ushort CardNo, ref uint line, byte[] pCurLine);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_set_current_file(ushort CardNo, byte[] pFileName);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_get_current_file(ushort CardNo, byte[] pFileName, ref short fileid);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_get_first_file(ushort CardNo, byte[] pfilenameinControl, ref uint pFileSize);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_get_next_file(ushort CardNo, byte[] pfilenameinControl, ref uint pFileSize);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_check_file(ushort CardNo, byte[] pfilenameinControl, ref byte pbIfExist, ref uint pFileSize);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_get_file_profile(ushort CardNo, ref uint maxfilenum, ref uint maxfilesize);
        /******************************************
        U盘文件管理
        ***************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_udisk_get_state(ushort ConnectNo, ref ushort state);
        [DllImport("LTSMC.dll")]
        public static extern short smc_udisk_check_file(ushort ConnectNo, byte[] filename, ref int filesize, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_udisk_get_first_file(ushort ConnectNo, byte[] filename, ref int filesize, ref int fileid, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_udisk_get_next_file(ushort ConnectNo, byte[] filename, ref int filesize, ref int fileid, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_udisk_copy_file(ushort ConnectNo, string SrcFileName, string DstFileName, ushort filetype, ushort mode);
        //当前位置
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_encoder_unit(ushort ConnectNo, ushort axis, double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_encoder_unit(ushort ConnectNo, ushort axis, ref double pos);
        //变速变位
        [DllImport("LTSMC.dll")]
        public static extern short smc_reset_target_position_unit(ushort ConnectNo, ushort axis, double New_Pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_update_target_position_unit(ushort ConnectNo, ushort axis, double New_Pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_change_speed_unit(ushort ConnectNo, ushort axis, double New_Vel, double Taccdec);


        [DllImport("LTSMC.dll")]
        public static extern short smc_enter_password(ushort ConnectNo, byte[] str_pass);
        [DllImport("LTSMC.dll")]
        public static extern short smc_modify_password(ushort ConnectNo, byte[] spassold, byte[] spass);
        //掉电保存寄存器操作
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_persistent_reg(ushort ConnectNo, ushort start, ushort inum, byte[] pdata);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_persistent_reg(ushort ConnectNo, ushort start, ushort inum, byte[] pdata);
        //参数文件
        [DllImport("LTSMC.dll")]
        public static extern short smc_download_parafile(ushort ConnectNo, byte[] FileName);
        [DllImport("LTSMC.dll")]
        public static extern short smc_upload_parafile(ushort ConnectNo, byte[] FileName);
        //圆弧限制
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_arc_limit(ushort ConnectNo, ushort Crd, ushort Enable, double MaxCenAcc, double MaxArcError);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_arc_limit(ushort ConnectNo, ushort Crd, ref ushort Enable, ref double MaxCenAcc, ref double MaxArcError);
        //
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_trace_data(ushort ConnectNo, ushort axis, int bufsize, double[] time, double[] pos, double[] vel, double[] acc, ref int recv_num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_trace_start(ushort ConnectNo, ushort AxisNum, ushort[] AxisList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_trace_stop(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_trace_set_source(ushort ConnectNo, ushort source);
        //
        //实时时钟
        [DllImport("LTSMC.dll")]
        public static extern short smc_rtc_get_time(ushort ConnectNo, ref int year, ref int month, ref int day, ref int hour, ref int min, ref int sec);
        [DllImport("LTSMC.dll")]
        public static extern short smc_rtc_set_time(ushort ConnectNo, int year, int month, int day, int hour, int min, int sec);

        //
        //
        [DllImport("LTSMC.dll")]
        public static extern short smc_soft_reset(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_reset_canopen(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_total_axes(ushort ConnectNo, ref uint TotalAxis); 	//读取指定卡轴数
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_total_ionum(ushort ConnectNo, ref ushort TotalIn, ref ushort TotalOut);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_total_adcnum(ushort ConnectNo, ref ushort TotalIn, ref ushort TotalOut);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_slave_nodes(ushort ConnectNo, ushort PortNum, ushort baudrate, ushort[] NodeID, ref ushort NodeNum);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_EmergeneyMessege_Nodes(ushort CardNo, ushort PortNum, uint[] NodeMsg, ref ushort MsgNum);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_LostHeartbeat_Nodes(ushort CardNo, ushort PortNum, ushort[] NodeID, ref ushort NodeNum);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_manager_od(ushort CardNo, ushort PortNum, ushort index, ushort subindex, ushort valuelength, ref uint value);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_manager_para(ushort CardNo, ushort PortNum, ref uint baudrate, ref ushort ManagerID);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_node_od(ushort CardNo, ushort PortNum, ushort nodenum, ushort index, ushort subindex, ushort valuelength, ref uint value);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_reset_to_factory(ushort CardNo, ushort PortNum, ushort NodeNum);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_SendNmtCommand(ushort CardNo, ushort PortNum, ushort NodeID, ushort NmtCommand);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_alarm_clear(ushort CardNo, ushort PortNum, ushort nodenum);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_axis_enable(ushort CardNo, ushort PortNum, ushort nodenum);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_manager_od(ushort CardNo, ushort PortNum, ushort index, ushort subindex, ushort valuelength, uint value);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_manager_para(ushort CardNo, ushort PortNum, int baudrate, ushort ManagerID);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_node_od(ushort CardNo, ushort PortNum, ushort nodenum, ushort index, ushort subindex, ushort valuelength, uint value);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_syn_move(ushort CardNo, ushort AxisNum, ushort[] AxisList, int[] Position, ushort[] PosiMode);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_write_outbit(ushort ConnectNo, ushort PortNum, ushort NodeID, ushort IoBit, ushort IoValue);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_read_outbit(ushort ConnectNo, ushort PortNum, ushort NodeID, ushort IoBit, ref ushort IoValue);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_read_inbit(ushort ConnectNo, ushort PortNum, ushort NodeID, ushort IoBit, ref ushort IoValue);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_write_outport(ushort ConnectNo, ushort PortNum, ushort NodeID, ushort PortNo, int IoValue);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_read_outport(ushort ConnectNo, ushort PortNum, ushort NodeID, ushort PortNo, ref int IoValue);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_read_inport(ushort ConnectNo, ushort PortNum, ushort NodeID, ushort PortNo, ref int IoValue);

        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_controller_workmode(ushort ConnectNo, ushort controller_mode);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_controller_workmode(ushort ConnectNo, ref ushort controller_mode);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_cycletime(ushort ConnectNo, ushort FieldbusType, uint CycleTime);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_cycletime(ushort ConnectNo, ushort FieldbusType, ref uint CycleTime);

        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_axis_state_machine(ushort ConnectNo, ushort axis, ref ushort Axis_StateMachine);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_axis_statusword(ushort ConnectNo, ushort axis, ref int statusword);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_axis_setting_contrlmode(ushort ConnectNo, ushort axis, ref int contrlmode);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_axis_contrlword(ushort ConnectNo, ushort axis, ref int contrlword);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_axis_type(ushort ConnectNo, ushort axis, ref ushort Axis_Type);

        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_consume_time_fieldbus(ushort ConnectNo, ushort Fieldbustype, ref uint Average_time, ref uint Max_time, ref UInt64 Cycles);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_clear_consume_time_fieldbus(ushort ConnectNo, ushort Fieldbustype);

        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_axis_enable(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_axis_disable(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_axis_io_out(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_axis_io_out(ushort ConnectNo, ushort axis, uint iostate);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_axis_io_in(ushort ConnectNo, ushort axis);

        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_axis_node_address(ushort ConnectNo, ushort axis, ref ushort SlaveAddr, ref ushort Sub_SlaveAddr);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_total_slaves(ushort ConnectNo, ushort PortNum, ref ushort TotalSlaves);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_home_profile(ushort ConnectNo, ushort axis, ushort home_mode, double High_Vel, double Low_Vel, double Tacc, double Tdec, double offsetpos);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_home_profile(ushort ConnectNo, ushort axis, ref ushort home_mode, ref double High_Vel, ref double Low_Vel, ref double Tacc, ref double Tdec, ref double offsetpos);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_home_move(ushort ConnectNo, ushort axis);
        //
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_errcode(ushort CardNo, ushort channel, ref ushort errcode);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_clear_errcode(ushort CardNo, ushort channel);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_axis_errcode(ushort CardNo, ushort axis, ref ushort Errcode);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_clear_axis_errcode(ushort CardNo, ushort axis);
        //
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_write_rxpdo_extra(ushort ConnectNo, ushort PortNum, ushort address, ushort DataLen, uint Value);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_read_rxpdo_extra(ushort ConnectNo, ushort PortNum, ushort address, ushort DataLen, ref uint Value);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_read_txpdo_extra(ushort ConnectNo, ushort PortNum, ushort address, ushort DataLen, ref uint Value);
        //
        //RTEX
        //
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_start_connect(ushort ConnectNo, ushort chan, ushort[] info, ref ushort len);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_vendor_info(ushort ConnectNo, ushort axis, byte[] info, ref ushort len);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_slave_type_info(ushort ConnectNo, ushort axis, byte[] info, ref ushort len);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_slave_name_info(ushort ConnectNo, ushort axis, byte[] info, ref ushort len);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_slave_version_info(ushort ConnectNo, ushort axis, byte[] info, ref ushort len);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_write_parameter(ushort ConnectNo, ushort axis, ushort index, ushort subindex, uint para_data);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_write_slave_eeprom(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_read_parameter(ushort ConnectNo, ushort axis, ushort index, ushort subindex, ref uint para_data);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_read_parameter_attributes(ushort ConnectNo, ushort axis, ushort index, ushort subindex, ref uint para_data);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_set_cmdcycletime(ushort ConnectNo, ushort PortNum, uint cmdtime);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_cmdcycletime(ushort ConnectNo, ushort PortNum, ref uint cmdtime);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_start_log(ushort ConnectNo, ushort chan, ushort node, ushort Ifenable);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_log(ushort ConnectNo, ushort chan, ushort node, uint[] data);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_config_atuo_log(ushort ConnectNo, ushort ifenable, ushort dir, ushort byte_index, ushort mask, ushort condition, uint counter);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_get_log_state(ushort ConnectNo, ushort chan, ref uint state);
        [DllImport("LTSMC.dll")]
        public static extern short nmcs_driver_reset(ushort ConnectNo, ushort axis);



    }
}
