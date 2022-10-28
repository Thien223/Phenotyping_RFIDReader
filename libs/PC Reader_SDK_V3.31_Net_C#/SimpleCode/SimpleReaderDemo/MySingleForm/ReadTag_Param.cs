using SimpleReaderDemo.MyFormTemplet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimpleReaderDemo.MySingleForm.TestForm
{
    public partial class ReadTag_Param : BaseOption
    {
        String rtParam = "";
        SingleMainForm singleMainForm = null;

        public ReadTag_Param()
        {
            InitializeComponent();
        }

        public ReadTag_Param(SingleMainForm smf, Int32 pageIndex)
            : this()
        {
            this.singleMainForm = smf;
            this.tc_Main.SelectedIndex = pageIndex;
            
        }

        private void ReadTag_Param_Load(object sender, EventArgs e)
        {
            ReadConfig();
            this.Width = 700;
            this.Height = 650;
        }

        private void cb_01_00_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_01_00.SelectedIndex == 1)               
            {
                tb_01_01.Text = "32";
            }
        }

        // 读 6C
        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region 获取参数
            bool userData = false;
            bool reservedData = false;
            bool epcData = false;
            foreach (var item in tp_6C.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        try
                        {
                            if (cb.Name.Equals("chk_01"))              //  匹配参数
                            {
                                rtParam += "1,";
                                String param1 = RFIDReaderAPI.MyHelper.MyString.ByteToString((Byte)cb_01_00.SelectedIndex)+"_";
                                param1 += tb_01_01.Text.Trim() + "_";
                                param1 += tb_01_02.Text.Trim();
                                rtParam += param1 + "&";
                                break;
                            }
                            else if (cb.Name.EndsWith("2"))         // TID参数
                            {
                                rtParam += "2,";
                                rtParam += RFIDReaderAPI.MyHelper.MyString.ByteToString((Byte)cb_02_00.SelectedIndex)+"_";
                                rtParam += GetHexStringByByte(Byte.Parse(tb_02_01.Text.Trim()));
                                rtParam += "&";
                            }
                            else if (cb.Name.EndsWith("3"))         // 用户区参数
                            {
                                rtParam += "3,";
                                rtParam += GetHexStringByUInt16(UInt16.Parse(tb_03_00.Text.Trim()))+"_";
                                rtParam += GetHexStringByByte(Byte.Parse(tb_03_01.Text.Trim()));
                                rtParam += "&";
                                userData = true;
                            }
                            else if (cb.Name.EndsWith("4"))         // 保留区参数
                            {
                                rtParam += "4,";
                                rtParam += GetHexStringByUInt16(UInt16.Parse(tb_04_00.Text.Trim()))+"_";
                                rtParam += GetHexStringByByte(Byte.Parse(tb_04_01.Text.Trim()));
                                rtParam += "&";
                                reservedData = true;
                            }
                            else if (cb.Name.EndsWith("5"))    //QT参数(访问密码)
                            {
                                if (!String.IsNullOrEmpty(qqTextBoxEx1.Text.Trim()))
                                {
                                    rtParam += "5," + qqTextBoxEx1.Text.Trim() + "&";
                                }
                            }

                            else if (cb.Name.Equals("chk_10"))         // EpcData区参数
                            {
                                rtParam += "6,";
                                rtParam += GetHexStringByUInt16(UInt16.Parse(tb_09_00.Text.Trim())) + "_";
                                rtParam += GetHexStringByByte(Byte.Parse(tb_09_01.Text.Trim()));
                                rtParam += "&";
                                epcData = true;
                            }
                        }
                        catch { }
                    }
                }
            }
            #endregion

            rtParam = rtParam.TrimEnd('&');
            if ((userData||reservedData)&&epcData)
            {
                MessageBox.Show("EPCData不能与UserData或者ReservedData一同勾选");
                singleMainForm.readVarParam_6C = "";
                this.DialogResult = DialogResult.OK;
                return;
            }
            if (singleMainForm != null)
            {
                singleMainForm.readVarParam_6C = rtParam;
            }

          
            this.DialogResult = DialogResult.OK;
            SaveConfig();
        }
        // 读 6B
        private void btn_Save_6B_Click(object sender, EventArgs e)
        {
           
            
            rtParam += cb_0010_40_00.SelectedIndex + "|";
            if (!String.IsNullOrEmpty(tb_0010_40_02.Text))
            {
                rtParam += "1," + tb_0010_40_01.Text + "_" + tb_0010_40_02.Text + "&";
            }
            if (!String.IsNullOrEmpty(tb_0010_40_03.Text))
            {
                rtParam += "2," + tb_0010_40_03.Text;
            }
            rtParam = rtParam.TrimEnd('&');
            if (singleMainForm != null)
            {
                singleMainForm.readVarParam_6B = rtParam;
            }

           
            this.DialogResult = DialogResult.OK;
            SaveConfig();
        }
        // 读 GB
        private void btn_Save_GB_Click(object sender, EventArgs e)
        {
            Dictionary<int, byte> dic_Select = new Dictionary<int, byte>()      
            {
                {0,0xFF},                                                   
                {1,0x00},{2,0x10},{3,0x20},
                {4,0x30},{5,0x31},{6,0x32},{7,0x33},{8,0x34},{9,0x35},{10,0x36},{11,0x37},
                {12,0x38},{13,0x39},{14,0x3A},{15,0x3B},{16,0x3C},{17,0x3D},{18,0x3E},{19,0x3F}
            };

            #region 获取参数

            foreach (var item in tp_GB.Controls)
            {
                CheckBox cb = item as CheckBox;
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        try
                        {
                            if (cb.Name.EndsWith("1"))                
                            {
                                rtParam += "1,";
                                String param1 = RFIDReaderAPI.MyHelper.MyString.ByteToString(dic_Select[cb_gb_01_00.SelectedIndex])+"_";    
                                param1 += GetHexStringByUInt16(UInt16.Parse(tb_gb_01_01.Text.Trim()))+"_";
                                param1 += tb_gb_01_02.Text.Trim();
                                rtParam += param1 + "&";
                                break;
                            }
                            else if (cb.Name.EndsWith("2"))
                            {
                                rtParam += "2,";
                                rtParam += RFIDReaderAPI.MyHelper.MyString.ByteToString((Byte)cb_gb_02_00.SelectedIndex)+"_";
                                rtParam += GetHexStringByByte(Byte.Parse(cb_gb_02_01.Text.Trim()));
                                rtParam += "&";
                            }
                            else if (cb.Name.EndsWith("3"))
                            {
                                rtParam="";
                                rtParam += "3,";
                                rtParam += GetHexStringByUInt16(UInt16.Parse(cb_gb_03_01.Text.Trim()))+"_";
                                rtParam += GetHexStringByByte(Byte.Parse(cb_gb_03_02.Text.Trim()));
                                rtParam += "_" + (Convert.ToInt32(txt_subUserDataIndex.Text.Trim())+48);
                                
                                if (!String.IsNullOrEmpty(cb_gb_04_00.Text))
                                {
                                    rtParam += "_"+cb_gb_04_00.Text.Trim();
                                    rtParam += "&";
                                }
                                break;
                            }
                        }
                        catch { }
                    }
                }
            }

            #endregion

            rtParam = rtParam.TrimEnd('&');

            if (singleMainForm != null)
            {
                singleMainForm.readVarParam_GB = rtParam;               // 保存读取6B参数
            }

            

            this.DialogResult = DialogResult.OK;
            SaveConfig();

        }

        // 保存配置
        private void SaveConfig()
        {
            try
            {
                foreach (var item in tp_6C.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, tb.Name, tb.Text.Trim());
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name, cb.SelectedIndex.ToString());
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name, cb.Checked.ToString());
                    }
                }
                foreach (var item in tp_6B.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, tb.Name, tb.Text.Trim());
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name, cb.SelectedIndex.ToString());
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name, cb.Checked.ToString());
                    }
                }
                foreach (var item in tp_GB.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, tb.Name, tb.Text.Trim());
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name, cb.SelectedIndex.ToString());
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name, cb.Checked.ToString());
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
        // 读取配置
        private void ReadConfig()
        {
            try
            {
                foreach (var item in tp_6C.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        tb.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, tb.Name);
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name);
                        cb.SelectedIndex = Int32.Parse(value);
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name);
                        cb.Checked = Boolean.Parse(value);
                    }
                }
                foreach (var item in tp_6B.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        tb.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, tb.Name);
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name);
                        cb.SelectedIndex = Int32.Parse(value);
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name);
                        cb.Checked = Boolean.Parse(value);
                    }
                }
                foreach (var item in tp_GB.Controls)
                {
                    if (item is QQTextBoxEx)
                    {
                        QQTextBoxEx tb = (QQTextBoxEx)item;
                        tb.Text = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, tb.Name);
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name);
                        cb.SelectedIndex = Int32.Parse(value);
                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        string value = Helper.MyXmlHelper.ReadInnerText(XMLFIENAME, "Root/" + this.Name, cb.Name);
                        cb.Checked = Boolean.Parse(value);
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
    }
}
